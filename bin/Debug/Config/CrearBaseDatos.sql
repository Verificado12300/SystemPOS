-- ============================================================
-- SCRIPT COMPLETO DE BASE DE DATOS
-- Sistema POS Agropecuario
-- Motor: SQLite
-- Fecha: 27 de Enero 2026
-- ============================================================

-- Habilitar claves foráneas
PRAGMA foreign_keys = ON;

-- ============================================================
-- MÓDULO: CONFIGURACIÓN
-- ============================================================

CREATE TABLE IF NOT EXISTS Empresa (
    EmpresaID INTEGER PRIMARY KEY AUTOINCREMENT,
    RUC TEXT(11) NOT NULL UNIQUE,
    RazonSocial TEXT(200) NOT NULL,
    NombreComercial TEXT(200),
    Direccion TEXT(300),
    Departamento TEXT(50),
    Provincia TEXT(50),
    Distrito TEXT(50),
    Ubigeo TEXT(6),
    Telefono TEXT(20),
    Email TEXT(100),
    Web TEXT(100),
    Logo BLOB,
    FechaRegistro TEXT DEFAULT CURRENT_TIMESTAMP,
    Activo INTEGER DEFAULT 1 CHECK(Activo IN (0,1))
);

CREATE TABLE IF NOT EXISTS Licencia (
    LicenciaID INTEGER PRIMARY KEY AUTOINCREMENT,
    CodigoLicencia TEXT(50) NOT NULL UNIQUE,
    TipoLicencia TEXT(20) NOT NULL CHECK(TipoLicencia IN ('MENSUAL','ANUAL','PERPETUA')),
    FechaActivacion TEXT,
    FechaVencimiento TEXT,
    Estado TEXT(20) DEFAULT 'INACTIVA' CHECK(Estado IN ('ACTIVA','INACTIVA','VENCIDA')),
    EmpresaID INTEGER NOT NULL,
    FOREIGN KEY (EmpresaID) REFERENCES Empresa(EmpresaID) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Roles (
    RolID INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre TEXT(50) NOT NULL UNIQUE,
    Descripcion TEXT(200),
    Activo INTEGER DEFAULT 1 CHECK(Activo IN (0,1))
);

CREATE TABLE IF NOT EXISTS Permisos (
    PermisoID INTEGER PRIMARY KEY AUTOINCREMENT,
    Modulo TEXT(50) NOT NULL,
    Accion TEXT(50) NOT NULL,
    Descripcion TEXT(200),
    CodigoPermiso TEXT(100) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS RolPermisos (
    RolPermisoID INTEGER PRIMARY KEY AUTOINCREMENT,
    RolID INTEGER NOT NULL,
    PermisoID INTEGER NOT NULL,
    FOREIGN KEY (RolID) REFERENCES Roles(RolID) ON DELETE CASCADE,
    FOREIGN KEY (PermisoID) REFERENCES Permisos(PermisoID) ON DELETE CASCADE,
    UNIQUE(RolID, PermisoID)
);

CREATE TABLE IF NOT EXISTS Usuarios (
    UsuarioID INTEGER PRIMARY KEY AUTOINCREMENT,
    NombreUsuario TEXT(50) NOT NULL UNIQUE,
    Contraseña TEXT(100) NOT NULL,
    NombreCompleto TEXT(100) NOT NULL,
    DNI TEXT(8) NOT NULL UNIQUE,
    Email TEXT(100),
    Telefono TEXT(20),
    RolID INTEGER NOT NULL,
    FechaCreacion TEXT DEFAULT CURRENT_TIMESTAMP,
    UltimoAcceso TEXT,
    Activo INTEGER DEFAULT 1 CHECK(Activo IN (0,1)),
    FOREIGN KEY (RolID) REFERENCES Roles(RolID)
);

CREATE TABLE IF NOT EXISTS ConfigGeneral (
    ConfigID INTEGER PRIMARY KEY AUTOINCREMENT,
    Clave TEXT(100) NOT NULL UNIQUE,
    Valor TEXT(500),
    Descripcion TEXT(200),
    Tipo TEXT(20) NOT NULL CHECK(Tipo IN ('STRING','INTEGER','BOOLEAN','DECIMAL')),
    Categoria TEXT(50)
);

-- ============================================================
-- MÓDULO: INVENTARIO
-- ============================================================

CREATE TABLE IF NOT EXISTS Categorias (
    CategoriaID INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre TEXT(100) NOT NULL UNIQUE,
    Descripcion TEXT(300),
    Activo INTEGER DEFAULT 1 CHECK(Activo IN (0,1))
);

CREATE TABLE IF NOT EXISTS UnidadesBase (
    UnidadID INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre TEXT(50) NOT NULL UNIQUE,
    Simbolo TEXT(10) NOT NULL,
    Tipo TEXT(20) NOT NULL CHECK(Tipo IN ('PESO','VOLUMEN','UNIDAD')),
    Activo INTEGER DEFAULT 1 CHECK(Activo IN (0,1))
);

CREATE TABLE IF NOT EXISTS Presentaciones (
    PresentacionID INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre TEXT(50) NOT NULL UNIQUE,
    Descripcion TEXT(200),
    Activo INTEGER DEFAULT 1 CHECK(Activo IN (0,1))
);

CREATE TABLE IF NOT EXISTS Proveedores (
    ProveedorID INTEGER PRIMARY KEY AUTOINCREMENT,
    RUC TEXT(11) NOT NULL UNIQUE,
    RazonSocial TEXT(200) NOT NULL,
    NombreComercial TEXT(200),
    Direccion TEXT(300),
    Telefono TEXT(20),
    Email TEXT(100),
    Contacto TEXT(100),
    TelefonoContacto TEXT(20),
    FechaRegistro TEXT DEFAULT CURRENT_TIMESTAMP,
    Activo INTEGER DEFAULT 1 CHECK(Activo IN (0,1))
);

CREATE TABLE IF NOT EXISTS Productos (
    ProductoID INTEGER PRIMARY KEY AUTOINCREMENT,
    Codigo TEXT(50) NOT NULL UNIQUE,
    CodigoBarras TEXT(50),
    Nombre TEXT(200) NOT NULL,
    Descripcion TEXT(500),
    CategoriaID INTEGER NOT NULL,
    UnidadBaseID INTEGER NOT NULL,
    StockTotal REAL DEFAULT 0 CHECK(StockTotal >= 0),
    StockMinimo REAL DEFAULT 0 CHECK(StockMinimo >= 0),
    StockMaximo REAL DEFAULT 0 CHECK(StockMaximo >= 0),
    ProveedorID INTEGER,
    Imagen BLOB,
    FechaCreacion TEXT DEFAULT CURRENT_TIMESTAMP,
    FechaUltimaModificacion TEXT,
    Activo INTEGER DEFAULT 1 CHECK(Activo IN (0,1)),
    FOREIGN KEY (CategoriaID) REFERENCES Categorias(CategoriaID),
    FOREIGN KEY (UnidadBaseID) REFERENCES UnidadesBase(UnidadID),
    FOREIGN KEY (ProveedorID) REFERENCES Proveedores(ProveedorID) ON DELETE SET NULL
);

CREATE TABLE IF NOT EXISTS ProductoPresentaciones (
    ProductoPresentacionID INTEGER PRIMARY KEY AUTOINCREMENT,
    ProductoID INTEGER NOT NULL,
    PresentacionID INTEGER NOT NULL,
    CantidadUnidades REAL NOT NULL CHECK(CantidadUnidades > 0),
    CostoBase REAL NOT NULL CHECK(CostoBase >= 0),
    PrecioVenta REAL NOT NULL CHECK(PrecioVenta >= 0),
    Ganancia REAL,
    Activo INTEGER DEFAULT 1 CHECK(Activo IN (0,1)),
    PrecioIncluyeIGV INTEGER NOT NULL DEFAULT 0,
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID) ON DELETE CASCADE,
    FOREIGN KEY (PresentacionID) REFERENCES Presentaciones(PresentacionID),
    UNIQUE(ProductoID, PresentacionID)
);

CREATE TABLE IF NOT EXISTS Ajustes (
    AjusteID INTEGER PRIMARY KEY AUTOINCREMENT,
    ProductoID INTEGER NOT NULL,
    TipoAjuste TEXT(20) NOT NULL CHECK(TipoAjuste IN ('ENTRADA','SALIDA','CORRECCION')),
    Cantidad REAL NOT NULL,
    StockAnterior REAL NOT NULL,
    StockNuevo REAL NOT NULL CHECK(StockNuevo >= 0),
    CostoUnitario REAL DEFAULT 0,
    Motivo TEXT(300),
    UsuarioID INTEGER NOT NULL,
    Fecha TEXT DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

-- ============================================================
-- MÓDULO: CONTACTOS
-- ============================================================

CREATE TABLE IF NOT EXISTS Clientes (
    ClienteID INTEGER PRIMARY KEY AUTOINCREMENT,
    TipoDocumento TEXT(20) NOT NULL CHECK(TipoDocumento IN ('DNI','RUC','CE','PASAPORTE')),
    NumeroDocumento TEXT(20) NOT NULL UNIQUE,
    Nombres TEXT(100),
    Apellidos TEXT(100),
    RazonSocial TEXT(200),
    Direccion TEXT(300),
    Telefono TEXT(20),
    Email TEXT(100),
    LimiteCredito REAL DEFAULT 0 CHECK(LimiteCredito >= 0),
    FechaRegistro TEXT DEFAULT CURRENT_TIMESTAMP,
    Activo INTEGER DEFAULT 1 CHECK(Activo IN (0,1))
);

-- ============================================================
-- MÓDULO: FINANZAS
-- ============================================================

CREATE TABLE IF NOT EXISTS Cajas (
    CajaID INTEGER PRIMARY KEY AUTOINCREMENT,
    UsuarioID INTEGER NOT NULL,
    Turno TEXT(20) NOT NULL CHECK(Turno IN ('MAÑANA','TARDE','NOCHE')),
    FechaApertura TEXT NOT NULL,
    HoraApertura TEXT NOT NULL,
    FechaCierre TEXT,
    HoraCierre TEXT,
    MontoInicial REAL NOT NULL CHECK(MontoInicial >= 0),
    TotalVentas REAL DEFAULT 0 CHECK(TotalVentas >= 0),
    TotalEfectivo REAL DEFAULT 0 CHECK(TotalEfectivo >= 0),
    TotalYape REAL DEFAULT 0 CHECK(TotalYape >= 0),
    TotalTarjeta REAL DEFAULT 0 CHECK(TotalTarjeta >= 0),
    TotalTransferencia REAL DEFAULT 0 CHECK(TotalTransferencia >= 0),
    TotalCredito REAL DEFAULT 0 CHECK(TotalCredito >= 0),
    TotalGastos REAL DEFAULT 0 CHECK(TotalGastos >= 0),
    EfectivoEsperado REAL DEFAULT 0,
    EfectivoReal REAL DEFAULT 0,
    Diferencia REAL DEFAULT 0,
    MotivoDiferencia TEXT(300),
    Estado TEXT(20) DEFAULT 'ABIERTA' CHECK(Estado IN ('ABIERTA','CERRADA')),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

-- ============================================================
-- MÓDULO: VENTAS
-- ============================================================

CREATE TABLE IF NOT EXISTS Ventas (
    VentaID INTEGER PRIMARY KEY AUTOINCREMENT,
    NumeroVenta TEXT(20) NOT NULL UNIQUE,
    Fecha TEXT NOT NULL,
    Hora TEXT NOT NULL,
    ClienteID INTEGER,
    TipoComprobante TEXT(20) NOT NULL CHECK(TipoComprobante IN ('BOLETA','FACTURA','NOTA_VENTA')),
    Serie TEXT(10),
    Numero TEXT(20),
    SubTotal      REAL    NOT NULL CHECK(SubTotal >= 0),
    IGV           REAL    NOT NULL CHECK(IGV >= 0),
    TipoIGV       INTEGER NOT NULL DEFAULT 0,
    BaseImponible REAL    NOT NULL DEFAULT 0,
    Total         REAL    NOT NULL CHECK(Total >= 0),
    MetodoPago TEXT(20) NOT NULL CHECK(MetodoPago IN ('EFECTIVO','YAPE','TARJETA','TRANSFERENCIA','MIXTO','CREDITO')),
    MontoEfectivo REAL DEFAULT 0 CHECK(MontoEfectivo >= 0),
    MontoYape REAL DEFAULT 0 CHECK(MontoYape >= 0),
    MontoTarjeta REAL DEFAULT 0 CHECK(MontoTarjeta >= 0),
    MontoTransferencia REAL DEFAULT 0 CHECK(MontoTransferencia >= 0),
    Estado TEXT(20) DEFAULT 'COMPLETADA' CHECK(Estado IN ('COMPLETADA','ANULADA','CREDITO','PENDIENTE')),
    CajaID INTEGER,
    UsuarioID INTEGER NOT NULL,
    Observaciones TEXT(500),
    FechaAnulacion TEXT,
    MotivoAnulacion TEXT(300),
    Eliminado INTEGER NOT NULL DEFAULT 0,
    EliminadoFecha TEXT NULL,
    EliminadoPor TEXT NULL,
    RestauradoFecha TEXT NULL,
    RestauradoPor TEXT NULL,
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID),
    FOREIGN KEY (CajaID) REFERENCES Cajas(CajaID),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

CREATE TABLE IF NOT EXISTS VentaDetalles (
    VentaDetalleID INTEGER PRIMARY KEY AUTOINCREMENT,
    VentaID INTEGER NOT NULL,
    ProductoID INTEGER NOT NULL,
    ProductoPresentacionID INTEGER NOT NULL,
    Cantidad REAL NOT NULL CHECK(Cantidad > 0),
    PrecioUnitario REAL NOT NULL CHECK(PrecioUnitario >= 0),
    Subtotal REAL NOT NULL CHECK(Subtotal >= 0),
    CantidadUnidadesBase REAL NOT NULL CHECK(CantidadUnidadesBase > 0),
    FOREIGN KEY (VentaID) REFERENCES Ventas(VentaID) ON DELETE CASCADE,
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID),
    FOREIGN KEY (ProductoPresentacionID) REFERENCES ProductoPresentaciones(ProductoPresentacionID)
);

CREATE TABLE IF NOT EXISTS CreditosVentas (
    CreditoVentaID INTEGER PRIMARY KEY AUTOINCREMENT,
    VentaID INTEGER NOT NULL UNIQUE,
    ClienteID INTEGER NOT NULL,
    MontoTotal REAL NOT NULL CHECK(MontoTotal >= 0),
    MontoPagado REAL DEFAULT 0 CHECK(MontoPagado >= 0),
    Saldo REAL NOT NULL CHECK(Saldo >= 0),
    FechaVencimiento TEXT NOT NULL,
    Estado TEXT(20) DEFAULT 'PENDIENTE' CHECK(Estado IN ('PENDIENTE','PAGADO','VENCIDO')),
    FechaRegistro TEXT DEFAULT CURRENT_TIMESTAMP,
    FechaPago TEXT,
    FOREIGN KEY (VentaID) REFERENCES Ventas(VentaID),
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID)
);

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
);

CREATE TABLE IF NOT EXISTS PagoVenta (
    PagoVentaID INTEGER PRIMARY KEY AUTOINCREMENT,
    PagoID INTEGER NOT NULL,
    VentaID INTEGER NOT NULL,
    MontoAplicado REAL NOT NULL CHECK(MontoAplicado > 0),
    FOREIGN KEY (PagoID) REFERENCES Pagos(PagoID) ON DELETE CASCADE,
    FOREIGN KEY (VentaID) REFERENCES Ventas(VentaID)
);

-- ============================================================
-- MÓDULO: COMPRAS
-- ============================================================

CREATE TABLE IF NOT EXISTS Compras (
    CompraID INTEGER PRIMARY KEY AUTOINCREMENT,
    NumeroCompra TEXT(20) NOT NULL UNIQUE,
    Fecha TEXT NOT NULL,
    Hora TEXT NOT NULL,
    ProveedorID INTEGER NOT NULL,
    TipoComprobante TEXT(20) NOT NULL CHECK(TipoComprobante IN ('FACTURA','BOLETA','GUIA')),
    Serie TEXT(10),
    Numero TEXT(20),
    IncluyeIGV INTEGER NOT NULL CHECK(IncluyeIGV IN (0,1)),
    TipoIGV INTEGER NOT NULL DEFAULT 0,
    BaseImponible REAL NOT NULL DEFAULT 0,
    SubTotal REAL NOT NULL CHECK(SubTotal >= 0),
    IGV REAL NOT NULL CHECK(IGV >= 0),
    Total REAL NOT NULL CHECK(Total >= 0),
    MetodoPago TEXT(20) NOT NULL CHECK(MetodoPago IN ('EFECTIVO','TRANSFERENCIA','CREDITO')),
    Estado TEXT(20) DEFAULT 'COMPLETADA' CHECK(Estado IN ('COMPLETADA','ANULADA','CREDITO')),
    UsuarioID INTEGER NOT NULL,
    Observaciones TEXT(500),
    FechaAnulacion TEXT,
    MotivoAnulacion TEXT(300),
    Eliminado INTEGER NOT NULL DEFAULT 0,
    EliminadoFecha TEXT NULL,
    EliminadoPor TEXT NULL,
    RestauradoFecha TEXT NULL,
    RestauradoPor TEXT NULL,
    FOREIGN KEY (ProveedorID) REFERENCES Proveedores(ProveedorID),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

CREATE TABLE IF NOT EXISTS CompraDetalles (
    CompraDetalleID INTEGER PRIMARY KEY AUTOINCREMENT,
    CompraID INTEGER NOT NULL,
    ProductoID INTEGER NOT NULL,
    ProductoPresentacionID INTEGER NOT NULL,
    Cantidad REAL NOT NULL CHECK(Cantidad > 0),
    CostoUnitario REAL NOT NULL CHECK(CostoUnitario >= 0),
    CostoPresentacion REAL NOT NULL DEFAULT 0 CHECK(CostoPresentacion >= 0),
    Subtotal REAL NOT NULL CHECK(Subtotal >= 0),
    CantidadUnidadesBase REAL NOT NULL CHECK(CantidadUnidadesBase > 0),
    FOREIGN KEY (CompraID) REFERENCES Compras(CompraID) ON DELETE CASCADE,
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID),
    FOREIGN KEY (ProductoPresentacionID) REFERENCES ProductoPresentaciones(ProductoPresentacionID)
);

CREATE TABLE IF NOT EXISTS CreditosCompras (
    CreditoCompraID INTEGER PRIMARY KEY AUTOINCREMENT,
    CompraID INTEGER NOT NULL UNIQUE,
    ProveedorID INTEGER NOT NULL,
    MontoTotal REAL NOT NULL CHECK(MontoTotal >= 0),
    MontoPagado REAL DEFAULT 0 CHECK(MontoPagado >= 0),
    Saldo REAL NOT NULL CHECK(Saldo >= 0),
    FechaVencimiento TEXT NOT NULL,
    Estado TEXT(20) DEFAULT 'PENDIENTE' CHECK(Estado IN ('PENDIENTE','PAGADO','VENCIDO')),
    FechaRegistro TEXT DEFAULT CURRENT_TIMESTAMP,
    FechaPago TEXT,
    FOREIGN KEY (CompraID) REFERENCES Compras(CompraID),
    FOREIGN KEY (ProveedorID) REFERENCES Proveedores(ProveedorID)
);

-- ============================================================
-- MÓDULO: GASTOS OPERATIVOS
-- ============================================================

CREATE TABLE IF NOT EXISTS Gastos (
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
    Eliminado INTEGER NOT NULL DEFAULT 0,
    EliminadoFecha TEXT NULL,
    EliminadoPor TEXT NULL,
    RestauradoFecha TEXT NULL,
    RestauradoPor TEXT NULL,
    FOREIGN KEY (CajaID)    REFERENCES Cajas(CajaID),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

-- ============================================================
-- MÓDULO: CUENTAS POR PAGAR
-- ============================================================

CREATE TABLE IF NOT EXISTS CuentasPorPagar (
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
);

CREATE TABLE IF NOT EXISTS PagosProveedores (
    PagoProveedorID  INTEGER PRIMARY KEY AUTOINCREMENT,
    CuentaPorPagarID INTEGER NOT NULL,
    Fecha            TEXT NOT NULL,
    Hora             TEXT NOT NULL,
    Monto            REAL NOT NULL CHECK(Monto > 0),
    MetodoPago       TEXT(20) NOT NULL
        CHECK(MetodoPago IN ('EFECTIVO','YAPE','TARJETA','TRANSFERENCIA')),
    Comprobante      TEXT(100),
    Observaciones    TEXT(500),
    Referencia       TEXT NULL,
    AsientoId        INTEGER NULL,
    Anulado          INTEGER NOT NULL DEFAULT 0,
    UsuarioID        INTEGER NOT NULL,
    FOREIGN KEY (CuentaPorPagarID) REFERENCES CuentasPorPagar(CuentaPorPagarID),
    FOREIGN KEY (UsuarioID)        REFERENCES Usuarios(UsuarioID)
);

-- ============================================================
-- MÓDULO: CONTABILIDAD (partida doble)
-- ============================================================

CREATE TABLE IF NOT EXISTS CuentasContables (
    CuentaID  INTEGER PRIMARY KEY AUTOINCREMENT,
    Codigo    TEXT(20)  NOT NULL UNIQUE,
    Nombre    TEXT(200) NOT NULL,
    Tipo      TEXT(20)  NOT NULL CHECK(Tipo IN ('ACTIVO','PASIVO','PATRIMONIO','INGRESO','GASTO')),
    Activa    INTEGER   NOT NULL DEFAULT 1 CHECK(Activa IN (0,1))
);

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
);

CREATE TABLE IF NOT EXISTS AsientosDetalle (
    DetalleID   INTEGER PRIMARY KEY AUTOINCREMENT,
    AsientoID   INTEGER NOT NULL,
    CuentaID    INTEGER NOT NULL,
    Debe        REAL    NOT NULL DEFAULT 0,
    Haber       REAL    NOT NULL DEFAULT 0,
    Descripcion TEXT(300),
    FOREIGN KEY (AsientoID) REFERENCES Asientos(AsientoID) ON DELETE CASCADE,
    FOREIGN KEY (CuentaID)  REFERENCES CuentasContables(CuentaID)
);

-- ============================================================
-- MÓDULO: AUDITORÍA
-- ============================================================

CREATE TABLE IF NOT EXISTS LogsAuditoria (
    LogID INTEGER PRIMARY KEY AUTOINCREMENT,
    Fecha TEXT DEFAULT CURRENT_TIMESTAMP,
    UsuarioID INTEGER NOT NULL,
    Modulo TEXT(50) NOT NULL,
    Accion TEXT(50) NOT NULL,
    TablaAfectada TEXT(50) NOT NULL,
    RegistroID INTEGER,
    ValorAnterior TEXT,
    ValorNuevo TEXT,
    DireccionIP TEXT(50),
    Detalles TEXT(500),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

-- ============================================================
-- DATOS INICIALES
-- ============================================================

-- Roles
INSERT INTO Roles (RolID, Nombre, Descripcion, Activo) VALUES
(1, 'Administrador', 'Control total del sistema', 1),
(2, 'Vendedor', 'Ventas y consulta de inventario', 1),
(3, 'Cajero', 'Ventas y control de caja', 1);

-- Permisos
INSERT INTO Permisos (Modulo, Accion, Descripcion, CodigoPermiso) VALUES
('Ventas', 'Ver', 'Ver módulo de ventas', 'VENTAS_VER'),
('Ventas', 'Crear', 'Crear nuevas ventas', 'VENTAS_CREAR'),
('Ventas', 'Anular', 'Anular ventas existentes', 'VENTAS_ANULAR'),
('Ventas', 'VerHistorial', 'Ver historial de ventas', 'VENTAS_VER_HISTORIAL'),
('Compras', 'Ver', 'Ver módulo de compras', 'COMPRAS_VER'),
('Compras', 'Crear', 'Crear nuevas compras', 'COMPRAS_CREAR'),
('Compras', 'Anular', 'Anular compras existentes', 'COMPRAS_ANULAR'),
('Compras', 'VerHistorial', 'Ver historial de compras', 'COMPRAS_VER_HISTORIAL'),
('Inventario', 'Ver', 'Ver módulo de inventario', 'INVENTARIO_VER'),
('Inventario', 'Crear', 'Crear nuevos productos', 'INVENTARIO_CREAR'),
('Inventario', 'Editar', 'Editar productos existentes', 'INVENTARIO_EDITAR'),
('Inventario', 'Eliminar', 'Eliminar productos', 'INVENTARIO_ELIMINAR'),
('Inventario', 'Ajustar', 'Ajustar stock', 'INVENTARIO_AJUSTAR'),
('Inventario', 'VerAlertas', 'Ver alertas de stock', 'INVENTARIO_VER_ALERTAS'),
('Caja', 'Ver', 'Ver módulo de caja', 'CAJA_VER'),
('Caja', 'Abrir', 'Abrir caja', 'CAJA_ABRIR'),
('Caja', 'Cerrar', 'Cerrar caja', 'CAJA_CERRAR'),
('Caja', 'VerHistorial', 'Ver historial de cajas', 'CAJA_VER_HISTORIAL'),
('Clientes', 'Ver', 'Ver módulo de clientes', 'CLIENTES_VER'),
('Clientes', 'Crear', 'Crear nuevos clientes', 'CLIENTES_CREAR'),
('Clientes', 'Editar', 'Editar clientes existentes', 'CLIENTES_EDITAR'),
('Clientes', 'Eliminar', 'Eliminar clientes', 'CLIENTES_ELIMINAR'),
('Proveedores', 'Ver', 'Ver módulo de proveedores', 'PROVEEDORES_VER'),
('Proveedores', 'Crear', 'Crear nuevos proveedores', 'PROVEEDORES_CREAR'),
('Proveedores', 'Editar', 'Editar proveedores existentes', 'PROVEEDORES_EDITAR'),
('Proveedores', 'Eliminar', 'Eliminar proveedores', 'PROVEEDORES_ELIMINAR'),
('Configuracion', 'Ver', 'Ver módulo de configuración', 'CONFIG_VER'),
('Configuracion', 'Editar', 'Editar configuración', 'CONFIG_EDITAR'),
('Configuracion', 'Usuarios', 'Gestionar usuarios', 'CONFIG_USUARIOS'),
('Configuracion', 'Empresa', 'Editar datos de empresa', 'CONFIG_EMPRESA'),
('Configuracion', 'Licencia', 'Gestionar licencia', 'CONFIG_LICENCIA'),
('Configuracion', 'Respaldo', 'Realizar respaldos', 'CONFIG_RESPALDO'),
('Reportes', 'Ver', 'Ver módulo de reportes', 'REPORTES_VER'),
('Reportes', 'Generar', 'Generar reportes', 'REPORTES_GENERAR'),
('Reportes', 'Exportar', 'Exportar reportes', 'REPORTES_EXPORTAR'),
('Creditos', 'Ver', 'Ver créditos', 'CREDITOS_VER'),
('Creditos', 'Crear', 'Crear créditos', 'CREDITOS_CREAR'),
('Creditos', 'Pagar', 'Registrar pagos', 'CREDITOS_PAGAR');

-- Permisos Administrador (todos)
INSERT INTO RolPermisos (RolID, PermisoID)
SELECT 1, PermisoID FROM Permisos;

-- Permisos Vendedor
INSERT INTO RolPermisos (RolID, PermisoID)
SELECT 2, PermisoID FROM Permisos WHERE CodigoPermiso IN (
    'VENTAS_VER', 'VENTAS_CREAR', 'VENTAS_VER_HISTORIAL',
    'INVENTARIO_VER', 'INVENTARIO_VER_ALERTAS',
    'CLIENTES_VER', 'CLIENTES_CREAR', 'CLIENTES_EDITAR'
);

-- Permisos Cajero
INSERT INTO RolPermisos (RolID, PermisoID)
SELECT 3, PermisoID FROM Permisos WHERE CodigoPermiso IN (
    'VENTAS_VER', 'VENTAS_CREAR', 'VENTAS_VER_HISTORIAL',
    'CAJA_VER', 'CAJA_ABRIR', 'CAJA_CERRAR', 'CAJA_VER_HISTORIAL',
    'CLIENTES_VER'
);

-- Categorías
INSERT INTO Categorias (Nombre, Descripcion, Activo) VALUES
('Alimentos Balanceados', 'Alimentos para animales', 1),
('Vitaminas', 'Suplementos vitamínicos', 1),
('Medicamentos', 'Productos veterinarios', 1),
('Antiparasitarios', 'Productos antiparasitarios', 1),
('Vacunas', 'Vacunas veterinarias', 1),
('Desinfectantes', 'Productos de limpieza y desinfección', 1),
('Accesorios', 'Accesorios para animales', 1);

-- Unidades Base
INSERT INTO UnidadesBase (Nombre, Simbolo, Tipo, Activo) VALUES
('Kilogramo', 'kg', 'PESO', 1),
('Gramo', 'g', 'PESO', 1),
('Litro', 'L', 'VOLUMEN', 1),
('Mililitro', 'ml', 'VOLUMEN', 1),
('Unidad', 'un', 'UNIDAD', 1);

-- Presentaciones
INSERT INTO Presentaciones (Nombre, Descripcion, Activo) VALUES
('Saco', 'Presentación en saco', 1),
('Bolsa', 'Presentación en bolsa', 1),
('Frasco', 'Presentación en frasco', 1),
('Caja', 'Presentación en caja', 1),
('Granel', 'Venta al peso', 1),
('Unidad', 'Venta por unidad', 1),
('Sobre', 'Presentación en sobre', 1),
('Bidón', 'Presentación en bidón', 1);

-- Cliente General (para ventas sin cliente específico)
INSERT INTO Clientes (ClienteID, TipoDocumento, NumeroDocumento, Nombres, Apellidos, RazonSocial, Direccion, Telefono, Email, LimiteCredito, Activo) 
VALUES (1, 'DNI', '00000000', '', '', 'CLIENTE GENERAL', '', '', '', 0, 1);

-- Configuraciones Generales
INSERT INTO ConfigGeneral (Clave, Valor, Descripcion, Tipo, Categoria) VALUES
('IGV', '18', 'Porcentaje de IGV', 'DECIMAL', 'Facturacion'),
('MONEDA', 'PEN', 'Código de moneda (PEN = Soles)', 'STRING', 'Facturacion'),
('SIMBOLO_MONEDA', 'S/', 'Símbolo de la moneda', 'STRING', 'Facturacion'),
('SERIE_BOLETA', 'B001', 'Serie para boletas', 'STRING', 'Facturacion'),
('SERIE_FACTURA', 'F001', 'Serie para facturas', 'STRING', 'Facturacion'),
('CORRELATIVO_BOLETA', '0', 'Correlativo actual de boletas', 'INTEGER', 'Facturacion'),
('CORRELATIVO_FACTURA', '0', 'Correlativo actual de facturas', 'INTEGER', 'Facturacion'),
('DIAS_ALERTA_VENCIMIENTO_CREDITO', '7', 'Días antes de vencimiento para alertar', 'INTEGER', 'Alertas'),
('ENVIAR_EMAIL_ALERTAS', 'false', 'Enviar emails de alerta', 'BOOLEAN', 'Alertas'),
('NOMBRE_EMPRESA_TICKET', 'MI EMPRESA', 'Nombre para tickets', 'STRING', 'Sistema'),
('PIE_PAGINA_TICKET', 'Gracias por su compra', 'Pie de página en tickets', 'STRING', 'Sistema'),
('IMPRESORA_PREDETERMINADA', '', 'Nombre de impresora predeterminada', 'STRING', 'Sistema'),
('ANCHO_PAPEL_TICKET', '80', 'Ancho del papel en mm (58 u 80)', 'INTEGER', 'Sistema'),
('RUTA_RESPALDO', '', 'Ruta para respaldos automáticos', 'STRING', 'Respaldo'),
('RESPALDO_AUTOMATICO', 'false', 'Activar respaldo automático', 'BOOLEAN', 'Respaldo'),
('FRECUENCIA_RESPALDO', '7', 'Días entre respaldos automáticos', 'INTEGER', 'Respaldo');

-- Plan de cuentas contables inicial
INSERT OR IGNORE INTO CuentasContables (Codigo, Nombre, Tipo, Activa) VALUES
('101', 'Caja',                    'ACTIVO',     1),
('102', 'Bancos',                  'ACTIVO',     1),
('120', 'Cuentas por Cobrar',      'ACTIVO',     1),
('140', 'Mercaderías / Inventario','ACTIVO',     1),
('200', 'Cuentas por Pagar',       'PASIVO',     1),
('210', 'Tributos por Pagar',      'PASIVO',     1),
('4012','IGV Crédito Fiscal',      'ACTIVO',     1),
('300', 'Capital',                 'PATRIMONIO', 1),
('400', 'Ventas',                  'INGRESO',    1),
('500', 'Costo de Ventas',         'GASTO',      1),
('600', 'Gastos Operativos',       'GASTO',      1);

-- ============================================================
-- ÍNDICES
-- ============================================================

CREATE INDEX idx_productos_codigo ON Productos(Codigo);
CREATE INDEX idx_productos_nombre ON Productos(Nombre);
CREATE INDEX idx_productos_categoria ON Productos(CategoriaID);
CREATE INDEX idx_ventas_fecha ON Ventas(Fecha);
CREATE INDEX idx_ventas_numero ON Ventas(NumeroVenta);
CREATE INDEX idx_compras_fecha ON Compras(Fecha);
CREATE INDEX idx_usuarios_nombre_usuario ON Usuarios(NombreUsuario);
CREATE INDEX idx_clientes_documento ON Clientes(NumeroDocumento);
CREATE INDEX idx_proveedores_ruc ON Proveedores(RUC);

CREATE INDEX idx_pagos_cliente ON Pagos(ClienteID);
CREATE INDEX idx_pagos_fecha ON Pagos(FechaPago);
CREATE INDEX idx_pagoventa_pago ON PagoVenta(PagoID);
CREATE INDEX idx_pagoventa_venta ON PagoVenta(VentaID);

CREATE INDEX idx_gastos_fecha ON Gastos(Fecha);
CREATE INDEX idx_gastos_categoria ON Gastos(Categoria);
CREATE INDEX idx_gastos_caja ON Gastos(CajaID);
CREATE INDEX idx_cuentasporpagar_proveedor ON CuentasPorPagar(ProveedorID);
CREATE INDEX idx_cuentasporpagar_estado ON CuentasPorPagar(Estado);
CREATE INDEX idx_pagosproveedores_cuenta ON PagosProveedores(CuentaPorPagarID);

CREATE INDEX idx_asientos_fecha       ON Asientos(Fecha);
CREATE INDEX idx_asientos_tipo        ON Asientos(TipoOperacion);
CREATE INDEX idx_asientosdetalle_asiento ON AsientosDetalle(AsientoID);
CREATE INDEX idx_asientosdetalle_cuenta  ON AsientosDetalle(CuentaID);
CREATE UNIQUE INDEX idx_cuentascontables_codigo ON CuentasContables(Codigo);

-- ============================================================
-- MÓDULO: PAPELERA GLOBAL
-- ============================================================

CREATE TABLE IF NOT EXISTS PapeleraLog (
    LogId        INTEGER PRIMARY KEY AUTOINCREMENT,
    Entidad      TEXT    NOT NULL,
    EntidadId    INTEGER NOT NULL,
    Accion       TEXT    NOT NULL,
    Fecha        TEXT    NOT NULL,
    Usuario      TEXT    NOT NULL,
    DatosResumen TEXT    NOT NULL DEFAULT ''
);

-- ============================================================
-- FIN DEL SCRIPT
-- ============================================================