USE [GD2C2016]

CREATE SCHEMA [SELECTIONADOS]

-- Creamos la nueva Tabla de Afiliados
CREATE TABLE [SELECTIONADOS].[Afiliados](
  [Id_afiliado] INT PRIMARY KEY IDENTITY(1,1),
  [numero_afiliado] INT,
  [nombre] VARCHAR(255),
  [apellido] VARCHAR(255),
  [tipo_dni] VARCHAR(4),
  [nro_doc] NUMERIC(18),
  [direccion] VARCHAR(255),
  [telefono] NUMERIC(18),
  [mail] VARCHAR(255),
  [fecha_nac] DATETIME,
  [sexo] CHAR,
  [id_estado_civil] INT,
  [id_plan] INT,
  [nro_consulta] INT,
  [activo] BIT
)GO

-- Creamos la nueva Tabla de Estados Civiles
create table [SELECTIONADOS].[Estado_Civil](
  Id_Estado_Civil INT PRIMARY KEY IDENTITY(1,1),
  Descripcion VARCHAR(255),
)GO

-- Se insertar los valosres por defecto en la talba de Estado Civil
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Casado')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Casada')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Soltero')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Soltera')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Viudo')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Viuda')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Divorsiado')
INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Divorsiada')

-- Creamos la nueva Tabla de Planes Medicos
CREATE TABLE [SELECTIONADOS].[Planes](
  [Id_Plan] INT PRIMARY KEY IDENTITY(1,1),
  [Cod_Plan] NUMERIC(18),
  [Descripcion] VARCHAR(255),
  [Precio_Plan] NUMERIC(18),
  [Precio_Bono_Consulta] NUMERIC(18),
  [Precio_Bono_Farmacia] NUMERIC(18)
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

-- Tabla de logs de modificacion
CREATE TABLE [SELECTIONADOS].[Modificación] (
  [id_modificacion] INT PRIMARY KEY,
  [numero_afiliado] INT,
  [fecha_modificacion] DATETIME,
  [motivo] VARCHAR(255)
)GO

--Tabla de Profesionales
CREATE TABLE [SELECTIONADOS].[Profesional] (
  [Id_Profesional]INT PRIMARY KEY IDENTITY(1,1),
  [matricula] INT,
  [nombre] VARCHAR(255),
  [apellido] VARCHAR(255),
  [tipo_doc] VARCHAR(4),
  [nro_doc] NUMERIC(18),
  [direccion] VARCHAR(255),
  [telefono] NUMERIC(18),
  [mail] VARCHAR(255),
  [fecha_nac] DATETIME,
  [sexo] CHAR
)GO

--Tabla de disponibilidad profesional
CREATE TABLE [SELECTIONADOS].[Disp_Profesional] (
  [matricula] INT PRIMARY KEY,
  [dia] INT,
  [hora_desde] DATETIME,
  [hora_hasta] DATETIME,
  [especialidad] INT
)GO

--Tabla de especializacion
CREATE TABLE [SELECTIONADOS].[Profesional_Especialidad] (
  [ID_Profesional] INT,
  [ID_Especialidad] INT
)GO

--Tabla de especialidad
CREATE TABLE [SELECTIONADOS].[Especialidad] (
  [id_especialidad] INT PRIMARY KEY IDENTITY(1,1),
  [cod_especialidad] INT,
  [descripcion] VARCHAR(255),
  [id_tipo_especialidad] INT
)GO

--Tabla de tipo de especialidad
CREATE TABLE [SELECTIONADOS].[Tipo_especialidad] (
  [id_tipo_especialidad] INT PRIMARY KEY IDENTITY(1,1),
  [cod_tipo_especialidad] NUMERIC(18),
  [descripcion] VARCHAR(255)
)GO

--Tabla de turno
CREATE TABLE [SELECTIONADOS].[Turno] (
  [id_turno] INT PRIMARY KEY,
  [id_horario] DATETIME,
  [nro_afiliado] INT,
  [id_especialidad] INT,
  [matricula] INT
)GO

-- SP de migracion de datos
CREATE PROCEDURE [SELECTIONADOS].[migracionDeDatos] AS
  BEGIN
    INSERT INTO [SELECTIONADOS].[Afiliados](nombre,apellido,nro_doc,direccion,telefono,mail,fecha_nac)
      SELECT Paciente_Nombre,Paciente_Apellido,Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac
      FROM gd_esquema.Maestra
      WHERE Paciente_Nombre IS NOT NULL AND Paciente_Apellido IS NOT NULL
      GROUP BY Paciente_Nombre,Paciente_Apellido,Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac
    UPDATE SELECTIONADOS.Afiliados SET numero_afiliado = Id_afiliado * 100

    INSERT INTO [SELECTIONADOS].[Planes] (Cod_Plan, Descripcion, Precio_Plan, Precio_Bono_Consulta, Precio_Bono_Farmacia)
      SELECT Plan_Med_Codigo, Plan_Med_Descripcion,0, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia
      FROM gd_esquema.Maestra
      GROUP BY Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia

    INSERT INTO [SELECTIONADOS].[Profesional] (nombre, apellido, nro_doc, direccion, telefono, mail, fecha_nac)
      SELECT Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac
      FROM gd_esquema.Maestra
      WHERE Medico_Nombre IS NOT NULL
      GROUP BY Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac

    INSERT INTO [SELECTIONADOS].[Tipo_especialidad](id_tipo_especialidad, descripcion)
      SELECT Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
      FROM gd_esquema.Maestra
      GROUP BY Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion

    INSERT INTO [SELECTIONADOS].[Especialidad](cod_especialidad, descripcion, id_tipo_especialidad)
    SELECT Maestra.[Especialidad_Codigo], Maestra.[Especialidad_Descripcion], Tipo_especialidad.[id_tipo_especialidad]
    FROM gd_esquema.[Maestra]
      INNER JOIN SELECTIONADOS.Tipo_especialidad
      ON Tipo_especialidad.cod_tipo_especialidad = Maestra.Tipo_Especialidad_Codigo
    GROUP BY Especialidad_Codigo, Especialidad_Descripcion, Tipo_especialidad.[id_tipo_especialidad]

    INSERT INTO [SELECTIONADOS].[Profesional_Especialidad](ID_Profesional, ID_Especialidad)
    SELECT Profesional.Id_Profesional, Especialidad.id_especialidad
    FROM gd_esquema.Maestra
      INNER JOIN SELECTIONADOS.Profesional
      ON Maestra.Medico_Dni = SELECTIONADOS.Profesional.nro_doc
      INNER JOIN SELECTIONADOS.Especialidad
      ON Maestra.Especialidad_Codigo = SELECTIONADOS.Especialidad.cod_especialidad
    GROUP BY Profesional.Id_Profesional, Especialidad.id_especialidad

  END
GO

EXECUTE [SELECTIONADOS].[migracionDeDatos]
GO

--Creo las FK
ALTER TABLE [SELECTIONADOS].[Afiliados] ADD FOREIGN KEY ([id_estado_civil]) REFERENCES [SELECTIONADOS].[Estado_Civil](Id_Estado_Civil)
ALTER TABLE [SELECTIONADOS].[Afiliados] ADD FOREIGN KEY ([id_plan]) REFERENCES [SELECTIONADOS].[Planes](Id_Plan)
ALTER TABLE [SELECTIONADOS].[Especialidad] ADD FOREIGN KEY ([id_tipo_especialidad]) REFERENCES [SELECTIONADOS].[Tipo_especialidad](id_tipo_especialidad)
ALTER TABLE [SELECTIONADOS].[Profesional_Especialidad] ADD FOREIGN KEY ([ID_Profesional]) REFERENCES [SELECTIONADOS].[Profesional_Especialidad](ID_Profesional)
ALTER TABLE [SELECTIONADOS].[Profesional_Especialidad] ADD FOREIGN KEY ([ID_Especialidad]) REFERENCES [SELECTIONADOS].[Especialidad](ID_Especialidad)

