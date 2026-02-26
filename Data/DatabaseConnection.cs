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
                                ('300', 'Capital',                  'PATRIMONIO', 1),
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
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al ejecutar migraciones: {ex.Message}", ex);
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
