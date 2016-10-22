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
)GO

INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Casado')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Casada')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Soltero')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Soltera')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Viudo')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Viuda')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Divorsiado')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Divorsiada')
GO

-- Creamos la nueva Tabla de Planes Medicos
CREATE TABLE [SELECTIONADOS].[Planes](
  Id_Plan INT PRIMARY KEY IDENTITY(1,1),
  Descripcion VARCHAR(255),
)GO

--Creamos la tabla de Cuotas
CREATE TABLE [SELECTIONADOS].[Cuotas](
  Id_Cuota INT PRIMARY KEY IDENTITY(1,1),
  Nro_Afiliado INT,
  monto money,
)GO

-- Creamos la tabla Bajas, se utiliza para registrar el evento de baja de un afiliado
create table [SELECTIONADOS].[Baja](
  Id_Baja INT PRIMARY KEY IDENTITY(1,1),
  Id_Afiliado INT,
  Fecha_Baja DATETIME,
  Motivo VARCHAR(255),
)GO
-- Crear triger para que cuando se inserte en esta tabla se tenga que dar de baja en la de afiliados

-- Tabla de usuarios.
create table [SELECTIONADOS].[Usuarios](
  Id_Usuario INT PRIMARY KEY IDENTITY(1,1),
  Username VARCHAR(255),
  Password VARCHAR(255),
)GO

-- Tabla de Asignaciones de Roles y Usuarios cada usuario puede tener mas de un rol
create table [SELECTIONADOS].[Asignacion_Rol](
  Id_Rol INT,
  Id_Usuario INT,
  PRIMARY KEY (Id_Rol,Id_Usuario)
)GO

-- Tabla de Roles de Usuario
create table [SELECTIONADOS].[Rol](
  Id_Rol INT PRIMARY KEY IDENTITY(1,1),
  Nombre VARCHAR(255),
  Activo BIT,
)GO

-- Tabla de Funcionalidades
create table [SELECTIONADOS].[Funcionalidades](
  Id_Funcionalidad INT PRIMARY KEY IDENTITY(1,1),
  Descripcion VARCHAR(255),
)GO

-- Creamos la tabla de roles por funcionalidad, cada rol puede tener muchas funcionalidades y una funcionalidad puede estar presente en varios roles.

create table [SELECTIONADOS].[Rol_X_Funcionalidad](
  Id_Funcionalidad INT,
  Id_Rol INT,
  PRIMARY KEY (Id_Funcionalidad,Id_Rol)
)GO

