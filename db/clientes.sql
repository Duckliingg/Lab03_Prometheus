-- Crear la base de datos
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'BD_CLIENTES')
BEGIN
    CREATE DATABASE BD_CLIENTES;
END
GO

USE BD_CLIENTES;
GO

-- Crear tabla TiposDocumentos
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TiposDocumentos' and xtype='U')
BEGIN
    CREATE TABLE TiposDocumentos (
        IdTipoDocumento INT PRIMARY KEY IDENTITY(1,1),
        Nombre VARCHAR(100) NOT NULL,
        Descripcion VARCHAR(255),
        Activo BIT DEFAULT 1
    );

    -- Insertar datos de ejemplo
    INSERT INTO TiposDocumentos (Nombre, Descripcion) VALUES 
    ('DNI', 'Documento Nacional de Identidad'),
    ('Carnet Extranjería', 'Carnet de Extranjería'),
    ('Pasaporte', 'Pasaporte'),
    ('RUC', 'Registro Único de Contribuyentes');
END
GO

-- Crear tabla Clientes
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Clientes' and xtype='U')
BEGIN
    CREATE TABLE Clientes (
        IdCliente INT PRIMARY KEY IDENTITY(1,1),
        Nombres VARCHAR(100) NOT NULL,
        Apellidos VARCHAR(100) NOT NULL,
        IdTipoDocumento INT FOREIGN KEY REFERENCES TiposDocumentos(IdTipoDocumento),
        NumeroDocumento VARCHAR(20) NOT NULL,
        Email VARCHAR(100),
        Telefono VARCHAR(20),
        Activo BIT DEFAULT 1,
        FechaCreacion DATETIME DEFAULT GETDATE()
    );

    -- Insertar algunos clientes de ejemplo
    INSERT INTO Clientes (Nombres, Apellidos, IdTipoDocumento, NumeroDocumento, Email, Telefono) VALUES 
    ('Juan', 'Pérez García', 1, '12345678', 'juan.perez@email.com', '999888777'),
    ('María', 'López Mendoza', 1, '87654321', 'maria.lopez@email.com', '999777666');
END
GO

SELECT 'Base de datos y tablas creadas exitosamente' as Mensaje;