-- Base que vamos a usar
USE [GD2C2016] GO

-- Creo el schema que vamos a utilizar
CREATE SCHEMA [SELECTIONADOS] AUTHORIZATION [gd]
GO

-- Creamos la nueva Tabla de Afiliados
CREATE TABLE [SELECTIONADOS].[Afiliados](
  [ID_Afiliado] INT PRIMARY KEY IDENTITY(1,1),
  [Nro_Afiliado] INT,
  [Nombre] VARCHAR(255),
  [Apellido] VARCHAR(255),
  [Tipo_Dni] VARCHAR(4),
  [Nro_Doc] NUMERIC(18),
  [Direccion] VARCHAR(255),
  [Telefono] NUMERIC(18),
  [Mail] VARCHAR(255),
  [Fecha_Nac] DATETIME,
  [Sexo] CHAR,
  [ID_Estado_Civil] INT,
  [ID_Plan] INT,
  [Nro_Consultas] INT,
  [Activo] BIT -- 1 Activo 0 Desactivo
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

--Tabla de Profesionales
CREATE TABLE [SELECTIONADOS].[Profesional] (
  [ID_Profesional]INT PRIMARY KEY IDENTITY(1,1),
  [Matricula] INT,
  [Nombre] VARCHAR(255),
  [Apellido] VARCHAR(255),
  [Tipo_Doc] VARCHAR(4),
  [Nro_Doc] NUMERIC(18),
  [Direccion] VARCHAR(255),
  [Telefono] NUMERIC(18),
  [Mail] VARCHAR(255),
  [Fecha_Nac] DATETIME,
  [Sexo] CHAR
)GO

--Tabla de tipo de especialidad
CREATE TABLE [SELECTIONADOS].[Tipo_Especialidad] (
  [ID_Tipo_Especialidad] INT PRIMARY KEY IDENTITY(1,1),
  [Cod_Tipo_Especialidad] NUMERIC(18),
  [Descripcion] VARCHAR(255)
)GO

--Tabla de especialidad
CREATE TABLE [SELECTIONADOS].[Especialidad] (
  [ID_Especialidad] INT PRIMARY KEY IDENTITY(1,1),
  [Cod_Especialidad] INT,
  [Descripcion] VARCHAR(255),
  [ID_Tipo_Especialidad] INT
)GO

--Tabla de especializacion
CREATE TABLE [SELECTIONADOS].[Profesional_Especialidad] (
  [ID_Profesional] INT,
  [ID_Especialidad] INT
)GO

--Tabla de turno
CREATE TABLE [SELECTIONADOS].[Turno] (
  [Nro_Turno] NUMERIC(18) UNIQUE NOT NULL,
  [ID_Afiliado] INT,
  [ID_Profesional] INT,
  [ID_Especialidad] INT,
  [Fecha_Turno] DATE
)GO

--Tabla de bonos
CREATE TABLE [SELECTIONADOS].[Compra_Bono] (
  [ID_Bono] INT PRIMARY KEY IDENTITY(1,1),
  [Nro_Afiliado] INT,
  [Fecha_Impresion] DATETIME,
)GO

-- Tabla de consultas
CREATE TABLE [SELECTIONADOS].[Consulta] (
  [Nro_Consulta] NUMERIC(18) UNIQUE NOT NULL,
  [Nro_Turno] NUMERIC(18),
  [Enfermedades] VARCHAR(255),
  [Sintomas] VARCHAR(255),
  [Fecha_Consulta] DATETIME,
  [Fecha_Llegada] DATETIME,
  [ID_Bono] INT
)GO

-- Tabla de Roles de Usuario
CREATE TABLE [SELECTIONADOS].[Rol](
  ID_Rol INT PRIMARY KEY IDENTITY(1,1),
  Nombre VARCHAR(255),
  Activo BIT NOT NULL DEFAULT 1 -- 1 Activo 0 Desactivo
)GO

-- Roles
INSERT INTO [SELECTIONADOS].[Rol](Nombre) VALUES ('Afiliado')
INSERT INTO [SELECTIONADOS].[Rol](Nombre) VALUES ('Administrativo')
INSERT INTO [SELECTIONADOS].[Rol](Nombre) VALUES ('Profesional')
INSERT INTO [SELECTIONADOS].[Rol](Nombre) VALUES ('Administrador')

-- Tabla de Funcionalidades
CREATE TABLE [SELECTIONADOS].[Funcionalidades](
  ID_Funcionalidad INT PRIMARY KEY IDENTITY(1,1),
  Descripcion VARCHAR(255)
)GO

INSERT INTO SELECTIONADOS.Funcionalidades (Descripcion) VALUES ('Btn_ABM_Afiliado')
INSERT INTO SELECTIONADOS.Funcionalidades (Descripcion) VALUES ('Btn_ABM_Especialidad')
INSERT INTO SELECTIONADOS.Funcionalidades (Descripcion) VALUES ('Btn_ABM_Planes')
INSERT INTO SELECTIONADOS.Funcionalidades (Descripcion) VALUES ('Btn_ABM_Profesional')
INSERT INTO SELECTIONADOS.Funcionalidades (Descripcion) VALUES ('Btn_ABM_Rol')
INSERT INTO SELECTIONADOS.Funcionalidades (Descripcion) VALUES ('Btn_Cancelar_Atencion')
INSERT INTO SELECTIONADOS.Funcionalidades (Descripcion) VALUES ('Btn_Comprar_Bono')
INSERT INTO SELECTIONADOS.Funcionalidades (Descripcion) VALUES ('Btn_Listados')
INSERT INTO SELECTIONADOS.Funcionalidades (Descripcion) VALUES ('Btn_Pedir_Turno')
INSERT INTO SELECTIONADOS.Funcionalidades (Descripcion) VALUES ('Btn_Registrar_Agenda_Medica')
INSERT INTO SELECTIONADOS.Funcionalidades (Descripcion) VALUES ('Btn_Registro_Llegada')
INSERT INTO SELECTIONADOS.Funcionalidades (Descripcion) VALUES ('Btn_Registro_Resultado')

-- Tabla de Rol por funcionalidad. Un rol puedo tener varias funcionalidades.
CREATE TABLE [SELECTIONADOS].[Rol_X_Funcionalidad](
  ID_Funcionalidad INT FOREIGN KEY REFERENCES SELECTIONADOS.Funcionalidades(ID_Funcionalidad),
  ID_Rol INT FOREIGN KEY REFERENCES SELECTIONADOS.Rol(ID_Rol),
  Activo BIT NOT NULL -- 1 Activo 0 Desactivo
)GO

-- Create / Update Funcionalidades por rol
CREATE PROCEDURE [SELECTIONADOS].[SP_Update_Funionalidad_Por_Rol]
  @rol_nombre VARCHAR(255),
  @funcionalidad_nombre VARCHAR(255),
  @habilitado bit
AS
  BEGIN TRY
    DECLARE @ID_Rol NUMERIC(18)
    DECLARE @ID_Funcionalidad NUMERIC(18)
    DECLARE @ID_Rol_Aux NUMERIC(18)
    DECLARE @ID_Funcionalidad_Aux NUMERIC(18)

    SELECT @ID_Rol = ID_Rol FROM [SELECTIONADOS].[Rol] WHERE Nombre = @rol_nombre
    SELECT @ID_Funcionalidad = ID_Funcionalidad FROM [SELECTIONADOS].[Funcionalidades] WHERE Descripcion = @funcionalidad_nombre

    SELECT @ID_Rol_Aux = ID_Rol, @ID_Funcionalidad_Aux = ID_Funcionalidad FROM SELECTIONADOS.Rol_X_Funcionalidad WHERE ID_Rol = @ID_Rol AND ID_Funcionalidad = @ID_Funcionalidad

    IF @ID_Rol_Aux IS NOT NULL AND @ID_Funcionalidad_Aux IS NOT NULL
      UPDATE [SELECTIONADOS].[Rol_X_Funcionalidad] SET Activo = @habilitado WHERE ID_Rol = @ID_Rol AND ID_Funcionalidad = @ID_Funcionalidad
    ELSE
      INSERT INTO [SELECTIONADOS].[Rol_X_Funcionalidad](ID_Funcionalidad, ID_Rol, Activo) VALUES (@ID_Funcionalidad, @ID_Rol, @habilitado)
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

-- Agrego las funciones por rol
EXECUTE [SELECTIONADOS].[SP_Update_Funionalidad_Por_Rol] 'Administrador','Btn_ABM_Afiliado',1
EXECUTE [SELECTIONADOS].[SP_Update_Funionalidad_Por_Rol] 'Administrador','Btn_ABM_Especialidad',1
EXECUTE [SELECTIONADOS].[SP_Update_Funionalidad_Por_Rol] 'Administrador','Btn_ABM_Planes',1
EXECUTE [SELECTIONADOS].[SP_Update_Funionalidad_Por_Rol] 'Administrador','Btn_ABM_Profesional',1
EXECUTE [SELECTIONADOS].[SP_Update_Funionalidad_Por_Rol] 'Administrador','Btn_ABM_Rol',1
EXECUTE [SELECTIONADOS].[SP_Update_Funionalidad_Por_Rol] 'Administrador','Btn_Cancelar_Atencion',1
EXECUTE [SELECTIONADOS].[SP_Update_Funionalidad_Por_Rol] 'Administrador','Btn_Comprar_Bono',1
EXECUTE [SELECTIONADOS].[SP_Update_Funionalidad_Por_Rol] 'Administrador','Btn_Listados',1
EXECUTE [SELECTIONADOS].[SP_Update_Funionalidad_Por_Rol] 'Administrador','Btn_Pedir_Turno',1
EXECUTE [SELECTIONADOS].[SP_Update_Funionalidad_Por_Rol] 'Administrador','Btn_Registrar_Agenda_Medica',1
EXECUTE [SELECTIONADOS].[SP_Update_Funionalidad_Por_Rol] 'Administrador','Btn_Registro_Llegada',1
EXECUTE [SELECTIONADOS].[SP_Update_Funionalidad_Por_Rol] 'Administrador','Btn_Registro_Resultado',1

-- Tabla de usuarios.
CREATE TABLE [SELECTIONADOS].[Usuarios](
  ID_Usuario INT PRIMARY KEY IDENTITY(1,1),
  Username VARCHAR(255) UNIQUE NOT NULL,
  Password VARCHAR(255) NOT NULL ,
  Fecha_Creacion DATETIME NOT NULL,
  Activo BIT NOT NULL DEFAULT 1, -- 1 Activo 0 Desactivo
  ID_Afiliado_Profesional INT,

  CONSTRAINT Afiliado_FK FOREIGN KEY (ID_Afiliado_Profesional) REFERENCES SELECTIONADOS.Afiliados(ID_Afiliado),
  CONSTRAINT Profesioanl_FK FOREIGN KEY (ID_Afiliado_Profesional) REFERENCES SELECTIONADOS.Profesional(ID_Profesional)
)GO

-- Usuarios
INSERT INTO [SELECTIONADOS].[Usuarios](Username, Password, Fecha_Creacion) VALUES ('admin', 'e6-b8-70-50-bf-cb-81-43-fc-b8-db-01-70-a4-dc-9e-d0-0d-90-4d-dd-3e-2a-4a-d1-b1-e8-dc-0f-dc-9b-e7', getdate())
INSERT INTO [SELECTIONADOS].[Usuarios](Username, Password, Fecha_Creacion) VALUES ('afiliado', '7d-f0-a4-df-14-70-55-f8-93-61-48-80-f6-3e-a2-9a-61-7c-87-af-0f-47-ee-2b-38-30-03-f0-16-6f-2b-b6', getdate())
INSERT INTO [SELECTIONADOS].[Usuarios](Username, Password, Fecha_Creacion) VALUES ('profesional', '79-34-36-03-65-4a-9d-7a-b7-55-0d-e6-02-0b-89-68-ce-cd-9b-05-1f-37-2f-76-e4-c3-bf-8a-02-b1-ee-61', getdate())
INSERT INTO [SELECTIONADOS].[Usuarios](Username, Password, Fecha_Creacion) VALUES ('administrativo', 'e6-b8-70-50-bf-cb-81-43-fc-b8-db-01-70-a4-dc-9e-d0-0d-90-4d-dd-3e-2a-4a-d1-b1-e8-dc-0f-dc-9b-e7', getdate())

-- Tabla de Asignaciones de Roles y Usuarios cada usuario puede tener mas de un rol
CREATE TABLE [SELECTIONADOS].[Asignacion_Rol](
  ID_Rol INT,
  ID_Usuario INT,
)GO

INSERT INTO [SELECTIONADOS].[Asignacion_Rol] (ID_Rol, ID_Usuario)
  SELECT ID_Rol, ID_Usuario FROM [SELECTIONADOS].[Rol], [SELECTIONADOS].[Usuarios] WHERE Nombre = 'Administrador' AND Username = 'admin'

INSERT INTO [SELECTIONADOS].[Asignacion_Rol] (ID_Rol, ID_Usuario)
  SELECT ID_Rol, ID_Usuario FROM [SELECTIONADOS].[Rol], [SELECTIONADOS].[Usuarios] WHERE Nombre = 'Administrativo' AND Username = 'administrativo1'

INSERT INTO [SELECTIONADOS].[Asignacion_Rol] (ID_Rol, ID_Usuario)
  SELECT ID_Rol, ID_Usuario FROM [SELECTIONADOS].[Rol], [SELECTIONADOS].[Usuarios] WHERE Nombre = 'Afiliado' AND Username = 'administrativo1'

/*            Lo que me falta ver

-- Creamos la tabla Bajas, se utiliza para registrar el evento de baja de un afiliado
create table [SELECTIONADOS].[Baja](
  Id_Baja INT PRIMARY KEY IDENTITY(1,1),
  Id_Afiliado INT,
  Fecha_Baja DATETIME,
  Motivo VARCHAR(255),
)GO
-- Crear triger para que cuando se inserte en esta tabla se tenga que dar de baja en la de afiliados

-- Tabla de logs de modificacion
CREATE TABLE [SELECTIONADOS].[Modificación] (
  [id_modificacion] INT PRIMARY KEY,
  [numero_afiliado] INT,
  [fecha_modificacion] DATETIME,
  [motivo] VARCHAR(255)
)GO

--Tabla de disponibilidad profesional
CREATE TABLE [SELECTIONADOS].[Disp_Profesional] (
  [matricula] INT PRIMARY KEY,
  [dia] INT,
  [hora_desde] DATETIME,
  [hora_hasta] DATETIME,
  [especialidad] INT
)GO

*/

-- SP de migracion de datos
CREATE PROCEDURE [SELECTIONADOS].[MigracionDeDatos] AS
  BEGIN
    INSERT INTO [SELECTIONADOS].[Planes] (Cod_Plan, Descripcion, Precio_Plan, Precio_Bono_Consulta, Precio_Bono_Farmacia)
    SELECT Plan_Med_Codigo, Plan_Med_Descripcion,0, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia
    FROM gd_esquema.Maestra
    GROUP BY Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia

    INSERT INTO [SELECTIONADOS].[Afiliados](Nombre,Apellido,Tipo_Dni,Nro_Doc,Direccion,Telefono,Mail,Fecha_Nac,Id_Plan,Nro_Consultas,Activo)
    SELECT [Paciente_Nombre], [Paciente_Apellido], 'DNI' AS Tipo_Dni, Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac, Planes.Id_Plan, 0 AS Nro_Consultas, 1 AS Activo
    FROM gd_esquema.Maestra
      INNER JOIN SELECTIONADOS.Planes
      ON SELECTIONADOS.Planes.Cod_Plan = Maestra.Plan_Med_Codigo
    WHERE Paciente_Nombre IS NOT NULL AND Paciente_Apellido IS NOT NULL
    GROUP BY [Paciente_Nombre], [Paciente_Apellido], Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac, Planes.Id_Plan
    UPDATE SELECTIONADOS.Afiliados SET [Nro_Afiliado] = [ID_Afiliado] * 100

    INSERT INTO [SELECTIONADOS].[Profesional] (Nombre, Apellido, Nro_Doc, Direccion, Telefono, Mail, Fecha_Nac)
    SELECT Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac
    FROM gd_esquema.Maestra
    WHERE Medico_Nombre IS NOT NULL
    GROUP BY Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac

    INSERT INTO [SELECTIONADOS].[Tipo_Especialidad](Cod_Tipo_Especialidad, Descripcion)
    SELECT Maestra.[Tipo_Especialidad_Codigo], Maestra.[Tipo_Especialidad_Descripcion]
    FROM gd_esquema.Maestra
    GROUP BY Maestra.[Tipo_Especialidad_Codigo], Maestra.[Tipo_Especialidad_Descripcion]

    INSERT INTO [SELECTIONADOS].[Especialidad](Cod_Especialidad, Descripcion, ID_Tipo_Especialidad)
    SELECT Maestra.[Especialidad_Codigo], Maestra.[Especialidad_Descripcion], Tipo_especialidad.[ID_Tipo_Especialidad]
    FROM gd_esquema.[Maestra]
      INNER JOIN SELECTIONADOS.Tipo_especialidad
      ON Tipo_especialidad.Cod_Tipo_Especialidad = Maestra.Tipo_Especialidad_Codigo
    GROUP BY Maestra.[Especialidad_Codigo], Maestra.[Especialidad_Descripcion], Tipo_especialidad.[ID_Tipo_Especialidad], Maestra.[Especialidad_Descripcion], Maestra.[Especialidad_Codigo]

    INSERT INTO [SELECTIONADOS].[Profesional_Especialidad](ID_Profesional, ID_Especialidad)
    SELECT Profesional.ID_Profesional, Especialidad.ID_Especialidad
    FROM gd_esquema.Maestra
      INNER JOIN SELECTIONADOS.Profesional
      ON Maestra.Medico_Dni = SELECTIONADOS.Profesional.Nro_Doc
      INNER JOIN SELECTIONADOS.Especialidad
      ON Maestra.Especialidad_Codigo = SELECTIONADOS.Especialidad.Cod_Especialidad
    GROUP BY Profesional.ID_Profesional, Especialidad.ID_Especialidad

    INSERT INTO [SELECTIONADOS].[Turno](Nro_Turno, ID_Afiliado, ID_Profesional, ID_Especialidad, Fecha_Turno)
    SELECT Maestra.Turno_Numero, Afiliados.ID_Afiliado, Profesional.ID_Profesional, Especialidad.ID_Especialidad, Maestra.Turno_Fecha
    FROM gd_esquema.Maestra
      INNER JOIN SELECTIONADOS.Afiliados
      ON SELECTIONADOS.Afiliados.Nro_Doc = Maestra.Paciente_Dni
      INNER JOIN SELECTIONADOS.Profesional
      ON SELECTIONADOS.Profesional.Nro_Doc = Maestra.Medico_Dni
      INNER JOIN SELECTIONADOS.Especialidad
      ON SELECTIONADOS.Especialidad.Cod_Especialidad = Maestra.Especialidad_Codigo
    WHERE Maestra.Turno_Numero IS NOT NULL

    INSERT INTO [SELECTIONADOS].[Consulta](Nro_Consulta, Nro_Turno, Enfermedades, Sintomas, Fecha_Consulta, Fecha_Llegada, ID_Bono)
    SELECT Maestra.Bono_Consulta_Numero, Turno.Nro_Turno, Maestra.Consulta_Enfermedades, Maestra.Consulta_Sintomas, Maestra.Bono_Consulta_Fecha_Impresion,Maestra.Bono_Consulta_Fecha_Impresion, NULL AS ID_Bono
    FROM gd_esquema.Maestra
      INNER JOIN SELECTIONADOS.Turno
      ON SELECTIONADOS.Turno.Nro_Turno = Maestra.Turno_Numero
    WHERE Maestra.Bono_Consulta_Fecha_Impresion IS NOT NULL

  END
GO

EXECUTE [SELECTIONADOS].[MigracionDeDatos]
GO

--Creo las FK
ALTER TABLE [SELECTIONADOS].[Afiliados] ADD FOREIGN KEY ([ID_Estado_Civil]) REFERENCES [SELECTIONADOS].[Estado_Civil](Id_Estado_Civil)
ALTER TABLE [SELECTIONADOS].[Afiliados] ADD FOREIGN KEY ([ID_Plan]) REFERENCES [SELECTIONADOS].[Planes](ID_Plan)
ALTER TABLE [SELECTIONADOS].[Especialidad] ADD FOREIGN KEY ([ID_Tipo_Especialidad]) REFERENCES [SELECTIONADOS].[Tipo_Especialidad](ID_Tipo_Especialidad)
ALTER TABLE [SELECTIONADOS].[Profesional_Especialidad] ADD FOREIGN KEY ([ID_Profesional]) REFERENCES [SELECTIONADOS].[Profesional](ID_Profesional)
ALTER TABLE [SELECTIONADOS].[Profesional_Especialidad] ADD FOREIGN KEY ([ID_Especialidad]) REFERENCES [SELECTIONADOS].[Especialidad](ID_Especialidad)
ALTER TABLE [SELECTIONADOS].[Turno] ADD FOREIGN KEY ([ID_Afiliado]) REFERENCES [SELECTIONADOS].[Afiliados](ID_Afiliado)
ALTER TABLE [SELECTIONADOS].[Turno] ADD FOREIGN KEY ([ID_Profesional]) REFERENCES [SELECTIONADOS].[Profesional](ID_Profesional)
ALTER TABLE [SELECTIONADOS].[Turno] ADD FOREIGN KEY ([ID_Especialidad]) REFERENCES [SELECTIONADOS].[Especialidad](ID_Especialidad)
ALTER TABLE [SELECTIONADOS].[Consulta] ADD FOREIGN KEY ([Nro_Turno]) REFERENCES [SELECTIONADOS].[Turno](Nro_Turno)
ALTER TABLE [SELECTIONADOS].[Consulta] ADD FOREIGN KEY ([ID_Bono]) REFERENCES [SELECTIONADOS].[Compra_Bono](ID_Bono)

-- Triggers
-- Creacion de los Nros de turnos
-- Creacion de los Nros de consultas

-- SP Get Usuario
CREATE PROCEDURE [SELECTIONADOS].[SP_Get_Usuario]
  @usuario VARCHAR(255),
  @password VARCHAR(255)
AS
  BEGIN TRY
    DECLARE @ID_Usuario INT
    SELECT @ID_Usuario = ID_Usuario FROM [SELECTIONADOS].[Usuarios] WHERE Username = @usuario AND Password = @password
    SELECT @ID_Usuario
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

-- SP Get Usuario Rol
CREATE PROCEDURE [SELECTIONADOS].[SP_Get_Usuario_Rol]
  @idUsuario INT
AS
  BEGIN TRY
    SELECT Nombre, Asignacion_Rol.ID_Rol FROM [SELECTIONADOS].[Asignacion_Rol]
    INNER JOIN [SELECTIONADOS].[Rol]
        ON [Asignacion_Rol].[ID_Rol] = [Rol].[ID_Rol]
    WHERE [Asignacion_Rol].[ID_Usuario] = @idUsuario
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

-- SP Get Funcionalidades por rol
CREATE PROCEDURE [SELECTIONADOS].[SP_Get_Funcionalidades_Rol]
  @nombre_rol VARCHAR(255)
AS
  BEGIN TRY
    SELECT f.Descripcion AS Funcionalidad, rf.Activo AS  Habilitado FROM SELECTIONADOS.Rol_X_Funcionalidad AS rf
      INNER JOIN SELECTIONADOS.Funcionalidades AS f
      ON f.ID_Funcionalidad = rf.ID_Funcionalidad
      INNER JOIN SELECTIONADOS.Rol AS r
      ON rf.ID_Rol = r.ID_Rol
        WHERE r.Nombre = @nombre_rol
    ORDER BY Funcionalidad
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO