using System;
using System.Data.SQLite;
using System.IO;

namespace SistemaPOS.Data
{
    public class DatabaseConnection
    {
        private static string _connectionString;
        private static string _databasePath;

        /// <summary>
        /// Inicializa la conexion a la base de datos
        /// </summary>
        public static void Initialize()
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string databaseFileName = "sistema_pos.db";
            string appDatabasePath = Path.Combine(appPath, databaseFileName);

            if (File.Exists(appDatabasePath))
            {
                _databasePath = appDatabasePath;
            }
            else if (CanWriteDirectory(appPath))
            {
                _databasePath = appDatabasePath;
            }
            else
            {
                string appDataPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "SistemaPOS");
                Directory.CreateDirectory(appDataPath);
                _databasePath = Path.Combine(appDataPath, databaseFileName);
            }

            _connectionString = $"Data Source={_databasePath};Version=3;";

            if (!File.Exists(_databasePath))
            {
                CreateDatabase();
            }
            else if (!IsCoreSchemaValid())
            {
                RecreateCorruptDatabase();
            }

            RunMigrations();
        }

        /// <summary>
        /// Obtiene una nueva conexion a la base de datos
        /// </summary>
        public static SQLiteConnection GetConnection()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                Initialize();
            }

            var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            // IMPORTANTE: Habilitar claves foraneas en SQLite
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "PRAGMA foreign_keys = ON;";
                cmd.ExecuteNonQuery();
            }

            return connection;
        }

        /// <summary>
        /// Ejecuta migraciones necesarias para actualizar la BD existente
        /// </summary>
        private static void RunMigrations()
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            CREATE TABLE IF NOT EXISTS Pagos (
                                PagoID INTEGER PRIMARY KEY AUTOINCREMENT,
                                ClienteID INTEGER NOT NULL,
                                Monto REAL NOT NULL CHECK(Monto > 0),
                                MetodoPago TEXT(20) NOT NULL CHECK(MetodoPago IN ('EFECTIVO','YAPE','TRANSFERENCIA','MIXTO')),
                                MontoEfectivo REAL DEFAULT 0 CHECK(MontoEfectivo >= 0),
                                MontoYape REAL DEFAULT 0 CHECK(MontoYape >= 0),
                                MontoTransferencia REAL DEFAULT 0 CHECK(MontoTransferencia >= 0),
                                FechaPago TEXT NOT NULL,
                                HoraPago TEXT NOT NULL,
                                Observaciones TEXT(500),
                                FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID)
                            );";
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            CREATE TABLE IF NOT EXISTS PagoVenta (
                                PagoVentaID INTEGER PRIMARY KEY AUTOINCREMENT,
                                PagoID INTEGER NOT NULL,
                                VentaID INTEGER NOT NULL,
                                MontoAplicado REAL NOT NULL CHECK(MontoAplicado > 0),
                                FOREIGN KEY (PagoID) REFERENCES Pagos(PagoID) ON DELETE CASCADE,
                                FOREIGN KEY (VentaID) REFERENCES Ventas(VentaID)
                            );";
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            CREATE TABLE IF NOT EXISTS Gastos (
                                GastoID INTEGER PRIMARY KEY AUTOINCREMENT,
                                Fecha TEXT NOT NULL,
                                Hora TEXT NOT NULL,
                                Concepto TEXT(300) NOT NULL,
                                Monto REAL NOT NULL CHECK(Monto > 0),
                                Categoria TEXT(50) NOT NULL,
                                MetodoPago TEXT(20) NOT NULL CHECK(MetodoPago IN ('EFECTIVO','YAPE','TARJETA','TRANSFERENCIA')),
                                Comprobante TEXT(100),
                                Observaciones TEXT(500),
                                CajaID INTEGER,
                                UsuarioID INTEGER NOT NULL,
                                FOREIGN KEY (CajaID) REFERENCES Cajas(CajaID),
                                FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
                            );";
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            CREATE TABLE IF NOT EXISTS CuentasPorPagar (
                                CuentaPorPagarID INTEGER PRIMARY KEY AUTOINCREMENT,
                                CompraID INTEGER NOT NULL,
                                ProveedorID INTEGER NOT NULL,
                                MontoTotal REAL NOT NULL CHECK(MontoTotal >= 0),
                                MontoPagado REAL DEFAULT 0 CHECK(MontoPagado >= 0),
                                MontoPendiente REAL NOT NULL CHECK(MontoPendiente >= 0),
                                FechaVencimiento TEXT,
                                Estado TEXT(20) NOT NULL DEFAULT 'PENDIENTE' CHECK(Estado IN ('PENDIENTE','PARCIAL','PAGADO')),
                                FOREIGN KEY (CompraID) REFERENCES Compras(CompraID),
                                FOREIGN KEY (ProveedorID) REFERENCES Proveedores(ProveedorID)
                            );";
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            CREATE TABLE IF NOT EXISTS PagosProveedores (
                                PagoProveedorID INTEGER PRIMARY KEY AUTOINCREMENT,
                                CuentaPorPagarID INTEGER NOT NULL,
                                Fecha TEXT NOT NULL,
                                Hora TEXT NOT NULL,
                                Monto REAL NOT NULL CHECK(Monto > 0),
                                MetodoPago TEXT(20) NOT NULL CHECK(MetodoPago IN ('EFECTIVO','YAPE','TARJETA','TRANSFERENCIA')),
                                Comprobante TEXT(100),
                                Observaciones TEXT(500),
                                UsuarioID INTEGER NOT NULL,
                                FOREIGN KEY (CuentaPorPagarID) REFERENCES CuentasPorPagar(CuentaPorPagarID),
                                FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
                            );";
                        cmd.ExecuteNonQuery();
                    }

                    // Migrar datos existentes de CreditosCompras a CuentasPorPagar
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            INSERT OR IGNORE INTO CuentasPorPagar (CompraID, ProveedorID, MontoTotal, MontoPagado, MontoPendiente, FechaVencimiento, Estado)
                            SELECT cc.CompraID, cc.ProveedorID, cc.MontoTotal, cc.MontoPagado, cc.Saldo, cc.FechaVencimiento,
                                   CASE WHEN cc.Estado = 'PAGADO' THEN 'PAGADO'
                                        WHEN cc.MontoPagado > 0 THEN 'PARCIAL'
                                        ELSE 'PENDIENTE' END
                            FROM CreditosCompras cc
                            WHERE NOT EXISTS (SELECT 1 FROM CuentasPorPagar cp WHERE cp.CompraID = cc.CompraID);";
                        cmd.ExecuteNonQuery();
                    }

                    // Indices
                    string[] indexes = new[]
                    {
                        "CREATE INDEX IF NOT EXISTS idx_pagos_cliente ON Pagos(ClienteID);",
                        "CREATE INDEX IF NOT EXISTS idx_pagos_fecha ON Pagos(FechaPago);",
                        "CREATE INDEX IF NOT EXISTS idx_pagoventa_pago ON PagoVenta(PagoID);",
                        "CREATE INDEX IF NOT EXISTS idx_pagoventa_venta ON PagoVenta(VentaID);",
                        "CREATE INDEX IF NOT EXISTS idx_gastos_fecha ON Gastos(Fecha);",
                        "CREATE INDEX IF NOT EXISTS idx_gastos_categoria ON Gastos(Categoria);",
                        "CREATE INDEX IF NOT EXISTS idx_gastos_caja ON Gastos(CajaID);",
                        "CREATE INDEX IF NOT EXISTS idx_cuentasporpagar_proveedor ON CuentasPorPagar(ProveedorID);",
                        "CREATE INDEX IF NOT EXISTS idx_cuentasporpagar_estado ON CuentasPorPagar(Estado);",
                        "CREATE INDEX IF NOT EXISTS idx_pagosproveedores_cuenta ON PagosProveedores(CuentaPorPagarID);"
                    };

                    foreach (var index in indexes)
                    {
                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = index;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Reforzar a nivel BD que solo exista una caja ABIERTA.
                    // Si hay datos historicos inconsistentes, no bloquear el arranque.
                    try
                    {
                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "CREATE UNIQUE INDEX IF NOT EXISTS idx_cajas_unica_abierta ON Cajas(Estado) WHERE Estado = 'ABIERTA';";
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        // Ignorar para mantener compatibilidad con instalaciones antiguas.
                    }

                    // Migración: tabla Ajustes — eliminar STOCK_INICIAL del CHECK y añadir CostoUnitario.
                    // El tipo 'STOCK_INICIAL' ya no existe en BD; se usa ENTRADA + Motivo='Stock inicial'.
                    // SQLite no permite ALTER CONSTRAINT, se requiere recrear la tabla cuando hay cambios.
                    try
                    {
                        string tableSql;
                        bool hasCostoUnitario;

                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "SELECT sql FROM sqlite_master WHERE type='table' AND name='Ajustes'";
                            tableSql = cmd.ExecuteScalar()?.ToString() ?? "";
                        }

                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('Ajustes') WHERE name='CostoUnitario'";
                            hasCostoUnitario = (long)cmd.ExecuteScalar() > 0;
                        }

                        if (tableSql.Contains("STOCK_INICIAL"))
                        {
                            // Tabla tiene el tipo obsoleto STOCK_INICIAL en el CHECK.
                            // Pasos: convertir filas existentes → recrear sin ese tipo.
                            string selCosto = hasCostoUnitario ? "CostoUnitario" : "0";

                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "PRAGMA foreign_keys = OFF";
                                cmd.ExecuteNonQuery();
                            }

                            // Tabla destino con CHECK correcto (sin STOCK_INICIAL) y columna CostoUnitario
                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = @"
                                    CREATE TABLE Ajustes_Mig (
                                        AjusteID       INTEGER PRIMARY KEY AUTOINCREMENT,
                                        ProductoID     INTEGER NOT NULL,
                                        TipoAjuste     TEXT(20) NOT NULL CHECK(TipoAjuste IN ('ENTRADA','SALIDA','CORRECCION')),
                                        Cantidad       REAL NOT NULL,
                                        StockAnterior  REAL NOT NULL,
                                        StockNuevo     REAL NOT NULL,
                                        CostoUnitario  REAL DEFAULT 0,
                                        Motivo         TEXT(300),
                                        UsuarioID      INTEGER NOT NULL,
                                        Fecha          TEXT DEFAULT CURRENT_TIMESTAMP,
                                        FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID),
                                        FOREIGN KEY (UsuarioID)  REFERENCES Usuarios(UsuarioID)
                                    )";
                                cmd.ExecuteNonQuery();
                            }

                            // Copiar datos: STOCK_INICIAL → ENTRADA con Motivo='Stock inicial'
                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = $@"
                                    INSERT INTO Ajustes_Mig
                                        (AjusteID, ProductoID, TipoAjuste, Cantidad,
                                         StockAnterior, StockNuevo, CostoUnitario, Motivo, UsuarioID, Fecha)
                                    SELECT
                                        AjusteID, ProductoID,
                                        CASE WHEN TipoAjuste = 'STOCK_INICIAL' THEN 'ENTRADA' ELSE TipoAjuste END,
                                        Cantidad, StockAnterior, StockNuevo,
                                        {selCosto},
                                        CASE WHEN TipoAjuste = 'STOCK_INICIAL' THEN 'Stock inicial' ELSE Motivo END,
                                        UsuarioID, Fecha
                                    FROM Ajustes";
                                cmd.ExecuteNonQuery();
                            }

                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "DROP TABLE Ajustes";
                                cmd.ExecuteNonQuery();
                            }

                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "ALTER TABLE Ajustes_Mig RENAME TO Ajustes";
                                cmd.ExecuteNonQuery();
                            }

                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "PRAGMA foreign_keys = ON";
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else if (!hasCostoUnitario)
                        {
                            // CHECK ya es correcto pero falta la columna CostoUnitario
                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "ALTER TABLE Ajustes ADD COLUMN CostoUnitario REAL DEFAULT 0";
                                cmd.ExecuteNonQuery();
                            }
                        }
                        // else: tabla ya en estado correcto, nada que hacer
                    }
                    catch { }

                    // Migración: tablas de contabilidad de partida doble.
                    // Agregadas después del commit inicial; instalaciones antiguas no las tienen.
                    try
                    {
                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = @"
                                CREATE TABLE IF NOT EXISTS CuentasContables (
                                    CuentaID  INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Codigo    TEXT(20)  NOT NULL UNIQUE,
                                    Nombre    TEXT(200) NOT NULL,
                                    Tipo      TEXT(20)  NOT NULL CHECK(Tipo IN ('ACTIVO','PASIVO','PATRIMONIO','INGRESO','GASTO')),
                                    Activa    INTEGER   NOT NULL DEFAULT 1 CHECK(Activa IN (0,1))
                                )";
                            cmd.ExecuteNonQuery();
                        }

                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = @"
                                CREATE TABLE IF NOT EXISTS Asientos (
                                    AsientoID     INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Fecha         TEXT NOT NULL,
                                    Hora          TEXT NOT NULL,
                                    TipoOperacion TEXT(20) NOT NULL,
                                    Documento     TEXT(100),
                                    ReferenciaID  INTEGER,
                                    UsuarioID     INTEGER,
                                    Glosa         TEXT(500),
                                    TotalDebe     REAL NOT NULL DEFAULT 0,
                                    TotalHaber    REAL NOT NULL DEFAULT 0,
                                    ModuloOrigen  TEXT NOT NULL DEFAULT 'SISTEMA',
                                    OrigenId      INTEGER NULL,
                                    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
                                )";
                            cmd.ExecuteNonQuery();
                        }

                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = @"
                                CREATE TABLE IF NOT EXISTS AsientosDetalle (
                                    DetalleID   INTEGER PRIMARY KEY AUTOINCREMENT,
                                    AsientoID   INTEGER NOT NULL,
                                    CuentaID    INTEGER NOT NULL,
                                    Debe        REAL    NOT NULL DEFAULT 0,
                                    Haber       REAL    NOT NULL DEFAULT 0,
                                    Descripcion TEXT(300),
                                    FOREIGN KEY (AsientoID) REFERENCES Asientos(AsientoID) ON DELETE CASCADE,
                                    FOREIGN KEY (CuentaID)  REFERENCES CuentasContables(CuentaID)
                                )";
                            cmd.ExecuteNonQuery();
                        }

                        // Índices contables
                        string[] idxContabilidad = new[]
                        {
                            "CREATE INDEX IF NOT EXISTS idx_asientos_fecha            ON Asientos(Fecha);",
                            "CREATE INDEX IF NOT EXISTS idx_asientos_tipo             ON Asientos(TipoOperacion);",
                            "CREATE INDEX IF NOT EXISTS idx_asientosdetalle_asiento   ON AsientosDetalle(AsientoID);",
                            "CREATE INDEX IF NOT EXISTS idx_asientosdetalle_cuenta    ON AsientosDetalle(CuentaID);",
                            "CREATE UNIQUE INDEX IF NOT EXISTS idx_cuentascontables_codigo ON CuentasContables(Codigo);"
                        };
                        foreach (var idx in idxContabilidad)
                        {
                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = idx;
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Seed plan de cuentas básico (INSERT OR IGNORE para no duplicar)
                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = @"
                                INSERT OR IGNORE INTO CuentasContables (Codigo, Nombre, Tipo, Activa) VALUES
                                ('101', 'Caja',                     'ACTIVO',     1),
                                ('102', 'Bancos',                   'ACTIVO',     1),
                                ('120', 'Cuentas por Cobrar',       'ACTIVO',     1),
                                ('140', 'Mercaderías / Inventario', 'ACTIVO',     1),
                                ('200', 'Cuentas por Pagar',        'PASIVO',     1),
                                ('210', 'Tributos por Pagar',       'PASIVO',     1),
                                ('4012','IGV Crédito Fiscal',       'ACTIVO',     1),
                                ('300', 'Capital',                  'PATRIMONIO', 1),
                                ('390', 'Utilidad del Ejercicio',   'PATRIMONIO', 1),
                                ('400', 'Ventas',                   'INGRESO',    1),
                                ('500', 'Costo de Ventas',          'GASTO',      1),
                                ('503', 'Ajuste de Inventario',      'GASTO',      1),
                                ('600', 'Gastos Operativos',        'GASTO',      1)";
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch { }

                    // Migración: CostoPromPonderado en Productos
                    // Columna de fallback para costo promedio ponderado cuando no hay kardex histórico.
                    // Compatible con BD existentes (ALTER TABLE seguro).
                    try
                    {
                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('Productos') WHERE name='CostoPromPonderado'";
                            bool hasCol = (long)cmd.ExecuteScalar() > 0;
                            if (!hasCol)
                            {
                                cmd.CommandText = "ALTER TABLE Productos ADD COLUMN CostoPromPonderado REAL DEFAULT 0";
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch { }

                    // Migración: CostoPresentacion en CompraDetalles
                    // Guarda el costo por presentación ingresado por el usuario (ej. S/90 por Saco),
                    // además del CostoUnitario base (S/1.80 por kg) que ya existía.
                    try
                    {
                        string schemaCD;
                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "SELECT sql FROM sqlite_master WHERE type='table' AND name='CompraDetalles'";
                            schemaCD = cmd.ExecuteScalar()?.ToString() ?? "";
                        }

                        if (!schemaCD.Contains("CostoPresentacion"))
                        {
                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "ALTER TABLE CompraDetalles ADD COLUMN CostoPresentacion REAL NOT NULL DEFAULT 0";
                                cmd.ExecuteNonQuery();
                            }
                            // Backfill: costoPres = costoBase × factor, donde factor = CantidadUnidadesBase / Cantidad
                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = @"
                                    UPDATE CompraDetalles
                                    SET CostoPresentacion = CASE
                                        WHEN Cantidad > 0 THEN ROUND(CostoUnitario * (CantidadUnidadesBase / Cantidad), 4)
                                        ELSE CostoUnitario
                                    END
                                    WHERE CostoPresentacion = 0";
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch { }

                    // Migración: TipoIGV y BaseImponible en Ventas.
                    // Fallo aquí es crítico: propagamos con mensaje claro.
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('Ventas') WHERE name='TipoIGV'";
                        if ((long)cmd.ExecuteScalar() == 0)
                        {
                            try
                            {
                                cmd.CommandText = "ALTER TABLE Ventas ADD COLUMN TipoIGV INTEGER NOT NULL DEFAULT 0";
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Migración Ventas.TipoIGV falló: " + ex.Message, ex);
                            }
                        }

                        cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('Ventas') WHERE name='BaseImponible'";
                        if ((long)cmd.ExecuteScalar() == 0)
                        {
                            try
                            {
                                cmd.CommandText = "ALTER TABLE Ventas ADD COLUMN BaseImponible REAL NOT NULL DEFAULT 0";
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Migración Ventas.BaseImponible falló: " + ex.Message, ex);
                            }
                        }
                    }

                    // Migración: PrecioIncluyeIGV en ProductoPresentaciones.
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('ProductoPresentaciones') WHERE name='PrecioIncluyeIGV'";
                        if ((long)cmd.ExecuteScalar() == 0)
                        {
                            try
                            {
                                cmd.CommandText = "ALTER TABLE ProductoPresentaciones ADD COLUMN PrecioIncluyeIGV INTEGER NOT NULL DEFAULT 0";
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Migración ProductoPresentaciones.PrecioIncluyeIGV falló: " + ex.Message, ex);
                            }
                        }
                    }

                    // Migración: TipoIGV y BaseImponible en Compras.
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('Compras') WHERE name='TipoIGV'";
                        if ((long)cmd.ExecuteScalar() == 0)
                        {
                            try
                            {
                                cmd.CommandText = "ALTER TABLE Compras ADD COLUMN TipoIGV INTEGER NOT NULL DEFAULT 0";
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Migración Compras.TipoIGV falló: " + ex.Message, ex);
                            }
                        }

                        cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('Compras') WHERE name='BaseImponible'";
                        if ((long)cmd.ExecuteScalar() == 0)
                        {
                            try
                            {
                                cmd.CommandText = "ALTER TABLE Compras ADD COLUMN BaseImponible REAL NOT NULL DEFAULT 0";
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Migración Compras.BaseImponible falló: " + ex.Message, ex);
                            }
                        }
                    }

                    // Migración: TipoIGV y BaseImponible en Gastos.
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('Gastos') WHERE name='TipoIGV'";
                        if ((long)cmd.ExecuteScalar() == 0)
                        {
                            try
                            {
                                cmd.CommandText = "ALTER TABLE Gastos ADD COLUMN TipoIGV INTEGER NOT NULL DEFAULT 0";
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Migración Gastos.TipoIGV falló: " + ex.Message, ex);
                            }
                        }

                        cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('Gastos') WHERE name='BaseImponible'";
                        if ((long)cmd.ExecuteScalar() == 0)
                        {
                            try
                            {
                                cmd.CommandText = "ALTER TABLE Gastos ADD COLUMN BaseImponible REAL NOT NULL DEFAULT 0";
                                cmd.ExecuteNonQuery();
                                // Backfill: registros históricos → BaseImponible = Monto (sin IGV)
                                cmd.CommandText = "UPDATE Gastos SET BaseImponible = Monto WHERE BaseImponible = 0";
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Migración Gastos.BaseImponible falló: " + ex.Message, ex);
                            }
                        }
                    }

                    // Migración: columnas de auditoría en Asientos — ModuloOrigen y OrigenId.
                    // UsuarioID INTEGER ya existe en la tabla original; no se toca.
                    // Fallo aquí es crítico: propagamos con mensaje claro.
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('Asientos') WHERE name='ModuloOrigen'";
                        if ((long)cmd.ExecuteScalar() == 0)
                        {
                            try
                            {
                                cmd.CommandText = "ALTER TABLE Asientos ADD COLUMN ModuloOrigen TEXT NOT NULL DEFAULT 'SISTEMA'";
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Migración Asientos.ModuloOrigen falló: " + ex.Message, ex);
                            }
                        }

                        cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('Asientos') WHERE name='OrigenId'";
                        if ((long)cmd.ExecuteScalar() == 0)
                        {
                            try
                            {
                                cmd.CommandText = "ALTER TABLE Asientos ADD COLUMN OrigenId INTEGER NULL";
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Migración Asientos.OrigenId falló: " + ex.Message, ex);
                            }
                        }
                    }

                    // Migración: PeriodosContables — cierre de período contable
                    // CREATE TABLE IF NOT EXISTS → seguro para BD existentes.
                    try
                    {
                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = @"
                                CREATE TABLE IF NOT EXISTS PeriodosContables (
                                    PeriodoId   INTEGER PRIMARY KEY AUTOINCREMENT,
                                    FechaInicio TEXT    NOT NULL,
                                    FechaFin    TEXT    NOT NULL,
                                    Cerrado     INTEGER NOT NULL DEFAULT 0,
                                    CerradoEn   TEXT    NULL,
                                    CerradoPor  TEXT    NULL
                                )";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = @"
                                CREATE INDEX IF NOT EXISTS idx_periodos_rango
                                ON PeriodosContables(FechaInicio, FechaFin, Cerrado)";
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch { }

                    // Migración: Gastos — agregar CREDITO a MetodoPago CHECK y columna ProveedorID.
                    // SQLite no permite ALTER CONSTRAINT; se usa recreación de tabla.
                    // Debe ejecutarse DESPUÉS de las migraciones TipoIGV/BaseImponible.
                    try
                    {
                        string gastosTableSql;
                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "SELECT sql FROM sqlite_master WHERE type='table' AND name='Gastos'";
                            gastosTableSql = cmd.ExecuteScalar()?.ToString() ?? "";
                        }

                        if (!gastosTableSql.Contains("CREDITO"))
                        {
                            // Detectar columnas opcionales que quizás ya existen
                            bool hasTipoIGV, hasBaseImponible;
                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('Gastos') WHERE name='TipoIGV'";
                                hasTipoIGV = (long)cmd.ExecuteScalar() > 0;
                                cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('Gastos') WHERE name='BaseImponible'";
                                hasBaseImponible = (long)cmd.ExecuteScalar() > 0;
                            }

                            string selTipoIGV      = hasTipoIGV      ? "TipoIGV"      : "0";
                            string selBaseImponible = hasBaseImponible ? "BaseImponible" : "Monto";

                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "PRAGMA foreign_keys = OFF";
                                cmd.ExecuteNonQuery();
                            }

                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = @"
                                    CREATE TABLE Gastos_Mig (
                                        GastoID       INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Fecha         TEXT NOT NULL,
                                        Hora          TEXT NOT NULL,
                                        Concepto      TEXT(300) NOT NULL,
                                        Monto         REAL NOT NULL CHECK(Monto > 0),
                                        Categoria     TEXT(50) NOT NULL,
                                        MetodoPago    TEXT(20) NOT NULL
                                            CHECK(MetodoPago IN ('EFECTIVO','YAPE','TARJETA','TRANSFERENCIA','CREDITO')),
                                        Comprobante   TEXT(100),
                                        Observaciones TEXT(500),
                                        TipoIGV       INTEGER NOT NULL DEFAULT 0,
                                        BaseImponible REAL    NOT NULL DEFAULT 0,
                                        ProveedorID   INTEGER NULL,
                                        CajaID        INTEGER,
                                        UsuarioID     INTEGER NOT NULL,
                                        FOREIGN KEY (CajaID)    REFERENCES Cajas(CajaID),
                                        FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
                                    )";
                                cmd.ExecuteNonQuery();
                            }

                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = $@"
                                    INSERT INTO Gastos_Mig
                                        (GastoID, Fecha, Hora, Concepto, Monto, Categoria, MetodoPago,
                                         Comprobante, Observaciones, TipoIGV, BaseImponible,
                                         ProveedorID, CajaID, UsuarioID)
                                    SELECT
                                        GastoID, Fecha, Hora, Concepto, Monto, Categoria, MetodoPago,
                                        Comprobante, Observaciones, {selTipoIGV}, {selBaseImponible},
                                        NULL, CajaID, UsuarioID
                                    FROM Gastos";
                                cmd.ExecuteNonQuery();
                            }

                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "DROP TABLE Gastos";
                                cmd.ExecuteNonQuery();
                            }

                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "ALTER TABLE Gastos_Mig RENAME TO Gastos";
                                cmd.ExecuteNonQuery();
                            }

                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "PRAGMA foreign_keys = ON";
                                cmd.ExecuteNonQuery();
                            }

                            // Recrear índices (se pierden con la tabla)
                            string[] idxGastos = new[]
                            {
                                "CREATE INDEX IF NOT EXISTS idx_gastos_fecha     ON Gastos(Fecha);",
                                "CREATE INDEX IF NOT EXISTS idx_gastos_categoria ON Gastos(Categoria);",
                                "CREATE INDEX IF NOT EXISTS idx_gastos_caja      ON Gastos(CajaID);"
                            };
                            foreach (var idx in idxGastos)
                            {
                                using (var cmd = connection.CreateCommand())
                                {
                                    cmd.CommandText = idx;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            // Ya tiene CREDITO; solo verificar si falta ProveedorID
                            bool hasProveedorID;
                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('Gastos') WHERE name='ProveedorID'";
                                hasProveedorID = (long)cmd.ExecuteScalar() > 0;
                            }

                            if (!hasProveedorID)
                            {
                                using (var cmd = connection.CreateCommand())
                                {
                                    cmd.CommandText = "ALTER TABLE Gastos ADD COLUMN ProveedorID INTEGER NULL";
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    catch { }

                    // Migración: CuentasPorPagar — agregar ANULADO a Estado CHECK y nuevas columnas.
                    // SQLite no permite ALTER CONSTRAINT; se usa recreación de tabla.
                    try
                    {
                        string cxpTableSql;
                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "SELECT sql FROM sqlite_master WHERE type='table' AND name='CuentasPorPagar'";
                            cxpTableSql = cmd.ExecuteScalar()?.ToString() ?? "";
                        }

                        if (!cxpTableSql.Contains("ANULADO"))
                        {
                            bool oldHasFechaVenc;
                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('CuentasPorPagar') WHERE name='FechaVencimiento'";
                                oldHasFechaVenc = (long)cmd.ExecuteScalar() > 0;
                            }

                            string selFechaVenc = oldHasFechaVenc ? "cp.FechaVencimiento" : "NULL";
                            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "PRAGMA foreign_keys = OFF";
                                cmd.ExecuteNonQuery();
                            }

                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = @"
                                    CREATE TABLE CuentasPorPagar_Mig (
                                        CuentaPorPagarID INTEGER PRIMARY KEY AUTOINCREMENT,
                                        TipoOrigen       TEXT    NOT NULL DEFAULT 'COMPRA',
                                        IdOrigen         INTEGER NOT NULL DEFAULT 0,
                                        CompraID         INTEGER NULL,
                                        ProveedorID      INTEGER NULL,
                                        ProveedorNombre  TEXT    NULL,
                                        MontoTotal       REAL    NOT NULL CHECK(MontoTotal >= 0),
                                        MontoPagado      REAL    DEFAULT 0 CHECK(MontoPagado >= 0),
                                        MontoPendiente   REAL    NOT NULL CHECK(MontoPendiente >= 0),
                                        FechaEmision     TEXT    NOT NULL DEFAULT '',
                                        FechaVencimiento TEXT    NULL,
                                        Estado           TEXT(20) NOT NULL DEFAULT 'PENDIENTE'
                                            CHECK(Estado IN ('PENDIENTE','PARCIAL','PAGADO','ANULADO')),
                                        Observacion      TEXT    NULL,
                                        CreatedAt        TEXT    NOT NULL DEFAULT '',
                                        UpdatedAt        TEXT    NOT NULL DEFAULT '',
                                        FOREIGN KEY (ProveedorID) REFERENCES Proveedores(ProveedorID)
                                    )";
                                cmd.ExecuteNonQuery();
                            }

                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = $@"
                                    INSERT INTO CuentasPorPagar_Mig
                                        (CuentaPorPagarID, TipoOrigen, IdOrigen, CompraID, ProveedorID, ProveedorNombre,
                                         MontoTotal, MontoPagado, MontoPendiente,
                                         FechaEmision, FechaVencimiento, Estado, CreatedAt, UpdatedAt)
                                    SELECT
                                        cp.CuentaPorPagarID, 'COMPRA', cp.CompraID, cp.CompraID, cp.ProveedorID, p.RazonSocial,
                                        cp.MontoTotal, cp.MontoPagado, cp.MontoPendiente,
                                        COALESCE(co.Fecha, '{now}'), {selFechaVenc}, cp.Estado,
                                        '{now}', '{now}'
                                    FROM CuentasPorPagar cp
                                    LEFT JOIN Compras     co ON cp.CompraID    = co.CompraID
                                    LEFT JOIN Proveedores p  ON cp.ProveedorID = p.ProveedorID";
                                cmd.ExecuteNonQuery();
                            }

                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "DROP TABLE CuentasPorPagar";
                                cmd.ExecuteNonQuery();
                            }

                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "ALTER TABLE CuentasPorPagar_Mig RENAME TO CuentasPorPagar";
                                cmd.ExecuteNonQuery();
                            }

                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "PRAGMA foreign_keys = ON";
                                cmd.ExecuteNonQuery();
                            }

                            // Recrear índices
                            string[] idxCxp = new[]
                            {
                                "CREATE INDEX IF NOT EXISTS idx_cuentasporpagar_proveedor ON CuentasPorPagar(ProveedorID);",
                                "CREATE INDEX IF NOT EXISTS idx_cuentasporpagar_estado    ON CuentasPorPagar(Estado);",
                                "CREATE INDEX IF NOT EXISTS idx_cuentasporpagar_tipo      ON CuentasPorPagar(TipoOrigen);"
                            };
                            foreach (var idx in idxCxp)
                            {
                                using (var cmd = connection.CreateCommand())
                                {
                                    cmd.CommandText = idx;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            // Ya tiene ANULADO; verificar columnas nuevas faltantes
                            string[] newColDefs = new[]
                            {
                                "TipoOrigen TEXT NOT NULL DEFAULT 'COMPRA'",
                                "IdOrigen INTEGER NOT NULL DEFAULT 0",
                                "ProveedorNombre TEXT NULL",
                                "FechaEmision TEXT NOT NULL DEFAULT ''",
                                "Observacion TEXT NULL",
                                "CreatedAt TEXT NOT NULL DEFAULT ''",
                                "UpdatedAt TEXT NOT NULL DEFAULT ''"
                            };
                            string[] newColNames = new[]
                            {
                                "TipoOrigen", "IdOrigen", "ProveedorNombre",
                                "FechaEmision", "Observacion", "CreatedAt", "UpdatedAt"
                            };

                            for (int i = 0; i < newColNames.Length; i++)
                            {
                                bool hasCol;
                                using (var cmd = connection.CreateCommand())
                                {
                                    cmd.CommandText = $"SELECT COUNT(*) FROM pragma_table_info('CuentasPorPagar') WHERE name='{newColNames[i]}'";
                                    hasCol = (long)cmd.ExecuteScalar() > 0;
                                }

                                if (!hasCol)
                                {
                                    using (var cmd = connection.CreateCommand())
                                    {
                                        cmd.CommandText = $"ALTER TABLE CuentasPorPagar ADD COLUMN {newColDefs[i]}";
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                    catch { }

                    // Migración: PagosProveedores — agregar columnas Referencia y AsientoId.
                    try
                    {
                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('PagosProveedores') WHERE name='Referencia'";
                            if ((long)cmd.ExecuteScalar() == 0)
                            {
                                cmd.CommandText = "ALTER TABLE PagosProveedores ADD COLUMN Referencia TEXT NULL";
                                cmd.ExecuteNonQuery();
                            }

                            cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('PagosProveedores') WHERE name='AsientoId'";
                            if ((long)cmd.ExecuteScalar() == 0)
                            {
                                cmd.CommandText = "ALTER TABLE PagosProveedores ADD COLUMN AsientoId INTEGER NULL";
                                cmd.ExecuteNonQuery();
                            }

                            cmd.CommandText = "SELECT COUNT(*) FROM pragma_table_info('PagosProveedores') WHERE name='Anulado'";
                            if ((long)cmd.ExecuteScalar() == 0)
                            {
                                cmd.CommandText = "ALTER TABLE PagosProveedores ADD COLUMN Anulado INTEGER NOT NULL DEFAULT 0";
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex) { throw new Exception("Migración PagosProveedores falló: " + ex.Message, ex); }

                    // Migración: columnas Soft-Delete en Gastos, Ventas, Compras + tabla PapeleraLog.
                    MigrarColumnasSoftDelete("Gastos",  connection);
                    MigrarColumnasSoftDelete("Ventas",  connection);
                    MigrarColumnasSoftDelete("Compras", connection);
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            CREATE TABLE IF NOT EXISTS PapeleraLog (
                                LogId        INTEGER PRIMARY KEY AUTOINCREMENT,
                                Entidad      TEXT    NOT NULL,
                                EntidadId    INTEGER NOT NULL,
                                Accion       TEXT    NOT NULL,
                                Fecha        TEXT    NOT NULL,
                                Usuario      TEXT    NOT NULL,
                                DatosResumen TEXT    NOT NULL DEFAULT ''
                            )";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al ejecutar migraciones: {ex.Message}", ex);
            }
        }

        private static void MigrarColumnasSoftDelete(string tabla, SQLiteConnection conn)
        {
            var cols = new[]
            {
                "Eliminado INTEGER NOT NULL DEFAULT 0",
                "EliminadoFecha TEXT NULL",
                "EliminadoPor TEXT NULL",
                "RestauradoFecha TEXT NULL",
                "RestauradoPor TEXT NULL"
            };
            foreach (var col in cols)
            {
                string nombre = col.Split(' ')[0];
                bool existe;
                using (var chk = new SQLiteCommand(
                    $"SELECT COUNT(*) FROM pragma_table_info('{tabla}') WHERE name='{nombre}'", conn))
                    existe = Convert.ToInt32(chk.ExecuteScalar()) > 0;
                if (!existe)
                    using (var alt = new SQLiteCommand(
                        $"ALTER TABLE {tabla} ADD COLUMN {col}", conn))
                        alt.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Crea la base de datos ejecutando el script SQL
        /// </summary>
        private static void CreateDatabase()
        {
            try
            {
                // Crear el archivo de BD
                SQLiteConnection.CreateFile(_databasePath);

                // Ejecutar el script de creacion
                string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "CrearBaseDatos.sql");

                if (!File.Exists(scriptPath))
                {
                    throw new FileNotFoundException($"No se encontro el script SQL en: {scriptPath}");
                }

                string script = File.ReadAllText(scriptPath);

                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    // Habilitar claves foraneas
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "PRAGMA foreign_keys = ON;";
                        cmd.ExecuteNonQuery();
                    }

                    // Ejecutar el script completo para preservar bloques SQL complejos.
                    // SQLite soporta multiples sentencias en un solo ExecuteNonQuery.
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = script;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear la base de datos: {ex.Message}", ex);
            }
        }

        private static bool IsCoreSchemaValid()
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    return TableExists(connection, "Usuarios")
                        && TableExists(connection, "Ventas")
                        && TableExists(connection, "Compras")
                        && TableExists(connection, "ConfigGeneral");
                }
            }
            catch
            {
                return false;
            }
        }

        private static bool TableExists(SQLiteConnection connection, string tableName)
        {
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT 1 FROM sqlite_master WHERE type = 'table' AND name = @name LIMIT 1;";
                cmd.Parameters.AddWithValue("@name", tableName);
                var value = cmd.ExecuteScalar();
                return value != null && value != DBNull.Value;
            }
        }

        private static void RecreateCorruptDatabase()
        {
            try
            {
                string backupPath = _databasePath + ".broken_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                File.Copy(_databasePath, backupPath, true);
                File.Delete(_databasePath);
            }
            catch
            {
                // Si no se puede respaldar/eliminar, intentar recrear encima.
            }

            CreateDatabase();
        }

        /// <summary>
        /// Verifica si existe al menos un usuario en el sistema
        /// </summary>
        public static bool ExistenUsuarios()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM Usuarios";
                        long count = (long)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Obtiene la ruta de la base de datos
        /// </summary>
        public static string GetDatabasePath()
        {
            if (string.IsNullOrEmpty(_databasePath))
            {
                Initialize();
            }
            return _databasePath;
        }

        private static bool CanWriteDirectory(string directoryPath)
        {
            try
            {
                string testFilePath = Path.Combine(directoryPath, $".write_test_{Guid.NewGuid():N}.tmp");
                File.WriteAllText(testFilePath, "ok");
                File.Delete(testFilePath);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
