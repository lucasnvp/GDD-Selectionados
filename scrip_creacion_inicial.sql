USE [GD2C2016]
GO

CREATE SCHEMA [SELECTIONADOS] AUTHORIZATION [gd]
GO

-- Creamos la nueva Tabla de Afiliados
create table [SELECTIONADOS].[Afiliados](
  Nro_Afiliado INT PRIMARY KEY,
  Nombre VARCHAR(255),
  Apellido VARCHAR(255),
  Nro_Doc INT,
  Direccion VARCHAR(255),
  Telefono NUMERIC(18),
  Mail VARCHAR(255),
  Fecha_Nac DATETIME,
  Sexo CHAR (1),
  Estado_civil INT,
  Nro_Plan INT,
  Activo BIT,
  Padre INT,
  Conyuge INT
)GO

-- Creamos la nueva Tabla de Estados Civiles
create table [SELECTIONADOS].[Estado_Civil](
  Id_Estado_Civil INT PRIMARY KEY IDENTITY(1,1),
  Descripcion VARCHAR(255),
)
GO

INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Casado')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Casada')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Soltero')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Soltera')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Viudo')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Viuda')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Divorsiado')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Divorsiada')
GO

