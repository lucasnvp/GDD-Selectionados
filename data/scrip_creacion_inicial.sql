-- Base que vamos a usar
USE [GD2C2016] GO

-- Creo el schema que vamos a utilizar
CREATE SCHEMA [SELECTIONADOS] AUTHORIZATION [gd]
GO

  -- Creamos la nueva Tabla de Afiliados
  CREATE TABLE [SELECTIONADOS].[Afiliados](
    [ID_Afiliado] INT PRIMARY KEY IDENTITY(1,1),
    [Nro_Afiliado] INT,
    [Nombre] VARCHAR(255) NOT NULL ,
    [Apellido] VARCHAR(255) NOT NULL ,
    [Tipo_Dni] VARCHAR(4),
    [Nro_Doc] NUMERIC(18),
    [Direccion] VARCHAR(255),
    [Telefono] NUMERIC(18),
    [Mail] VARCHAR(255),
    [Fecha_Nac] DATETIME,
    [Sexo] CHAR,
    [ID_Estado_Civil] INT,
    [ID_Plan] INT,
    [Nro_Consultas] INT DEFAULT 0,
    [Activo] BIT NOT NULL DEFAULT 1, -- 1 Activo 0 Desactivo
  )

  -- Familiares a cargo
  CREATE TABLE [SELECTIONADOS].[Familiar_ACargo] (
    [ID_Afiliado] INT FOREIGN KEY REFERENCES [SELECTIONADOS].[Afiliados](ID_Afiliado),
    [Nro_Afiliado] INT,
    [Nombre] VARCHAR(255),
    [Apellido] VARCHAR(255),
    [Tipo_Doc] VARCHAR(4),
    [Nro_Doc] NUMERIC(18),
    [Sexo] CHAR,
    [Fecha_Nac] DATETIME,
    [Telefono] NUMERIC(18),
    [Mail] VARCHAR(255),
    [Tipo_Familiar] CHAR -- 'C'onyuge 'H'ijos 'O'tros
  );

  -- Creamos la nueva Tabla de Estados Civiles
  create table [SELECTIONADOS].[Estado_Civil](
    Id_Estado_Civil INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(255),
  )

  -- Creamos la tabla Bajas, se utiliza para registrar el evento de baja de un afiliado
  CREATE TABLE [SELECTIONADOS].[Log_Baja_Afiliado](
    ID_Baja INT PRIMARY KEY IDENTITY(1,1),
    ID_Afiliado INT FOREIGN KEY REFERENCES [SELECTIONADOS].[Afiliados](ID_Afiliado),
    Fecha_Baja DATETIME
  )

  -- Creamos la nueva Tabla de Planes Medicos
  CREATE TABLE [SELECTIONADOS].[Planes](
    [Id_Plan] INT PRIMARY KEY IDENTITY(1,1),
    [Cod_Plan] NUMERIC(18),
    [Descripcion] VARCHAR(255),
    [Precio_Plan] NUMERIC(18),
    [Precio_Bono_Consulta] NUMERIC(18),
    [Precio_Bono_Farmacia] NUMERIC(18)
  )

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
  )

  --Tabla de tipo de especialidad
  CREATE TABLE [SELECTIONADOS].[Tipo_Especialidad] (
    [ID_Tipo_Especialidad] INT PRIMARY KEY IDENTITY(1,1),
    [Cod_Tipo_Especialidad] NUMERIC(18),
    [Descripcion] VARCHAR(255)
  )

  --Tabla de especialidad
  CREATE TABLE [SELECTIONADOS].[Especialidad] (
    [ID_Especialidad] INT PRIMARY KEY IDENTITY(1,1),
    [Cod_Especialidad] INT,
    [Descripcion] VARCHAR(255),
    [ID_Tipo_Especialidad] INT
  )

  --Tabla de especializacion
  CREATE TABLE [SELECTIONADOS].[Profesional_Especialidad] (
    [ID_Profesional] INT,
    [ID_Especialidad] INT
  )

  --Tabla de turno
  CREATE TABLE [SELECTIONADOS].[Turno] (
    [Nro_Turno] NUMERIC(18) UNIQUE NOT NULL,
    [ID_Afiliado] INT,
    [ID_Profesional] INT,
    [ID_Especialidad] INT,
    [Fecha_Turno] DATE
  )

  --Tabla de bonos
  CREATE TABLE [SELECTIONADOS].[Compra_Bono] (
    [ID_Bono] INT PRIMARY KEY IDENTITY(1,1),
    [Nro_Afiliado] INT,
    [Fecha_Impresion] DATETIME,
  )

  -- Tabla de consultas
  CREATE TABLE [SELECTIONADOS].[Consulta] (
    [Nro_Consulta] NUMERIC(18) UNIQUE NOT NULL,
    [Nro_Turno] NUMERIC(18),
    [Enfermedades] VARCHAR(255),
    [Sintomas] VARCHAR(255),
    [Fecha_Consulta] DATETIME,
    [Fecha_Llegada] DATETIME,
    [ID_Bono] INT
  )

  -- Tabla de Roles de Usuario
  CREATE TABLE [SELECTIONADOS].[Rol](
    ID_Rol INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255),
    Activo BIT NOT NULL DEFAULT 1 -- 1 Activo 0 Desactivo
  )

  -- Tabla de Funcionalidades
  CREATE TABLE [SELECTIONADOS].[Funcionalidades](
    ID_Funcionalidad INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(255)
  )

  -- Tabla de Rol por funcionalidad. Un rol puedo tener varias funcionalidades.
  CREATE TABLE [SELECTIONADOS].[Rol_X_Funcionalidad](
    ID_Funcionalidad INT FOREIGN KEY REFERENCES SELECTIONADOS.Funcionalidades(ID_Funcionalidad),
    ID_Rol INT FOREIGN KEY REFERENCES SELECTIONADOS.Rol(ID_Rol),
    Activo BIT NOT NULL -- 1 Activo 0 Desactivo
  )

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
  )

  -- Tabla de Asignaciones de Roles y Usuarios cada usuario puede tener mas de un rol
  CREATE TABLE [SELECTIONADOS].[Asignacion_Rol](
    ID_Rol INT FOREIGN KEY REFERENCES [SELECTIONADOS].[Rol] (ID_Rol),
    ID_Usuario INT FOREIGN KEY REFERENCES [SELECTIONADOS].[Usuarios] (ID_Usuario),
    Activo BIT -- 1 Activo 0 Desactivo
  )

/**********************
* Creacion de triggers
***********************/
  -- Trigger Tipo_Afiliado
  CREATE TRIGGER [SELECTIONADOS].[Tr_Nro_Afiliado]
    ON [SELECTIONADOS].[Afiliados]
    AFTER INSERT
  AS
    BEGIN TRY
      DECLARE @ID_Afiliado_Ingresado INT
      DECLARE @Tipo_Afiliado CHAR

      SELECT @ID_Afiliado_Ingresado = ID_Afiliado, @Tipo_Afiliado = Tipo_Afiliado FROM INSERTED

      UPDATE SELECTIONADOS.Afiliados SET [Nro_Afiliado] = ((@ID_Afiliado_Ingresado * 100) + 1) WHERE ID_Afiliado = @ID_Afiliado_Ingresado

    END TRY
    BEGIN CATCH
      SELECT 'ERROR', ERROR_MESSAGE()
    END CATCH
  GO

  -- Triger para que cuando se inserte en esta tabla se tenga que dar de baja en la de afiliados
  CREATE TRIGGER [SELECTIONADOS].[Tr_Log_Baja_Afiliado]
    ON [SELECTIONADOS].[Afiliados]
    AFTER UPDATE
  AS
    BEGIN TRY
      IF UPDATE (Activo)
          INSERT INTO SELECTIONADOS.Log_Baja_Afiliado
          SELECT ID_Afiliado, getdate() FROM INSERTED;
    END TRY
    BEGIN CATCH
      SELECT 'ERROR', ERROR_MESSAGE()
    END CATCH
  GO

/**********************
* SP de Migracion
***********************/

-- SP de inserts de datos
CREATE PROCEDURE [SELECTIONADOS].[01_Insert_Datos_Iniciales] AS
BEGIN
  -- Se insertar los valosres por defecto en la talba de Estado Civil
  INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Completar')
  INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Casado')
  INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Casada')
  INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Soltero')
  INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Soltera')
  INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Viudo')
  INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Viuda')
  INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Divorsiado')
  INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Divorsiada')
  INSERT INTO [SELECTIONADOS].[Estado_Civil]([Descripcion]) VALUES ('Concubinato')

  -- Roles
  INSERT INTO [SELECTIONADOS].[Rol](Nombre) VALUES ('Afiliado')
  INSERT INTO [SELECTIONADOS].[Rol](Nombre) VALUES ('Administrativo')
  INSERT INTO [SELECTIONADOS].[Rol](Nombre) VALUES ('Profesional')
  INSERT INTO [SELECTIONADOS].[Rol](Nombre) VALUES ('Administrador')

  -- Funcionalidades
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

  -- Usuarios
  INSERT INTO [SELECTIONADOS].[Usuarios](Username, Password, Fecha_Creacion) VALUES ('admin', 'e6-b8-70-50-bf-cb-81-43-fc-b8-db-01-70-a4-dc-9e-d0-0d-90-4d-dd-3e-2a-4a-d1-b1-e8-dc-0f-dc-9b-e7', getdate())
  INSERT INTO [SELECTIONADOS].[Usuarios](Username, Password, Fecha_Creacion) VALUES ('afiliado', '7d-f0-a4-df-14-70-55-f8-93-61-48-80-f6-3e-a2-9a-61-7c-87-af-0f-47-ee-2b-38-30-03-f0-16-6f-2b-b6', getdate())
  INSERT INTO [SELECTIONADOS].[Usuarios](Username, Password, Fecha_Creacion) VALUES ('profesional', '79-34-36-03-65-4a-9d-7a-b7-55-0d-e6-02-0b-89-68-ce-cd-9b-05-1f-37-2f-76-e4-c3-bf-8a-02-b1-ee-61', getdate())
  INSERT INTO [SELECTIONADOS].[Usuarios](Username, Password, Fecha_Creacion) VALUES ('administrativo', 'e6-b8-70-50-bf-cb-81-43-fc-b8-db-01-70-a4-dc-9e-d0-0d-90-4d-dd-3e-2a-4a-d1-b1-e8-dc-0f-dc-9b-e7', getdate())

  --Asigno los roles a los usuarios
  INSERT INTO [SELECTIONADOS].[Asignacion_Rol] (ID_Rol, ID_Usuario, Activo)
    SELECT ID_Rol, ID_Usuario, 1 FROM [SELECTIONADOS].[Rol], [SELECTIONADOS].[Usuarios] WHERE Nombre = 'Administrador' AND Username = 'admin'

  INSERT INTO [SELECTIONADOS].[Asignacion_Rol] (ID_Rol, ID_Usuario, Activo)
    SELECT ID_Rol, ID_Usuario, 1 FROM [SELECTIONADOS].[Rol], [SELECTIONADOS].[Usuarios] WHERE Nombre = 'Administrativo' AND Username = 'administrativo'

  INSERT INTO [SELECTIONADOS].[Asignacion_Rol] (ID_Rol, ID_Usuario, Activo)
    SELECT ID_Rol, ID_Usuario, 1 FROM [SELECTIONADOS].[Rol], [SELECTIONADOS].[Usuarios] WHERE Nombre = 'Afiliado' AND Username = 'administrativo'

END
GO

-- SP de migracion de datos
CREATE PROCEDURE [SELECTIONADOS].[02_Migracion_De_Datos] AS
  BEGIN
    INSERT INTO [SELECTIONADOS].[Planes] (Cod_Plan, Descripcion, Precio_Plan, Precio_Bono_Consulta, Precio_Bono_Farmacia)
    SELECT Plan_Med_Codigo, Plan_Med_Descripcion,0, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia
    FROM gd_esquema.Maestra
    GROUP BY Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia

    INSERT INTO [SELECTIONADOS].[Afiliados](Nombre,Apellido,Tipo_Dni,Nro_Doc,Direccion,Telefono,Mail,Fecha_Nac,ID_Estado_Civil,Id_Plan,Nro_Consultas,Activo)
    SELECT [Paciente_Nombre], [Paciente_Apellido], 'DNI' AS Tipo_Dni, Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac, 1, Planes.Id_Plan, 0 AS Nro_Consultas, 1 AS Activo
    FROM gd_esquema.Maestra
      INNER JOIN SELECTIONADOS.Planes
      ON SELECTIONADOS.Planes.Cod_Plan = Maestra.Plan_Med_Codigo
    WHERE Paciente_Nombre IS NOT NULL AND Paciente_Apellido IS NOT NULL
    GROUP BY [Paciente_Nombre], [Paciente_Apellido], Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac, Planes.Id_Plan
    UPDATE SELECTIONADOS.Afiliados SET [Nro_Afiliado] = ((ID_Afiliado * 100) + 1)

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

-- SP se crean las FK
CREATE PROCEDURE [SELECTIONADOS].[03_Creacion_De_Las_FK] AS
BEGIN
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
END
GO

EXECUTE [SELECTIONADOS].[01_Insert_Datos_Iniciales]
EXECUTE [SELECTIONADOS].[02_Migracion_De_Datos]
EXECUTE [SELECTIONADOS].[03_Creacion_De_Las_FK]

/*  FIN De La Migracion */

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

-- SP Get Funcionalidades
CREATE PROCEDURE [SELECTIONADOS].[SP_Get_Funcionalidades]
AS
  BEGIN TRY
    SELECT Descripcion AS Funcionalidades FROM [SELECTIONADOS].[Funcionalidades] ORDER BY Funcionalidades
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

-- SP Get Roles
CREATE PROCEDURE [SELECTIONADOS].[SP_Get_Roles]
AS
  BEGIN TRY
    SELECT Nombre AS Rol, Activo AS Habilitado FROM [SELECTIONADOS].[Rol]
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

-- SP Crear Rol
CREATE PROCEDURE [SELECTIONADOS].[SP_Create_Rol]
  @nombre_rol VARCHAR(255),
  @habilitado BIT
AS
  BEGIN TRY
    DECLARE @nombre VARCHAR(255)
    DECLARE @mensaje VARCHAR(255) SET @mensaje = 'El rol ya existe'
    SELECT @nombre = Nombre FROM [SELECTIONADOS].[Rol] WHERE Nombre = @nombre_rol
    IF @nombre IS NULL
        BEGIN
          INSERT INTO SELECTIONADOS.Rol(Nombre, Activo) VALUES (@nombre_rol, @habilitado)
          INSERT INTO SELECTIONADOS.Rol_X_Funcionalidad(ID_Funcionalidad, ID_Rol, Activo)
            SELECT ID_Funcionalidad, ID_Rol, 0 FROM SELECTIONADOS.Rol, SELECTIONADOS.Funcionalidades WHERE Nombre = @nombre_rol
        END
    ELSE
      SELECT @mensaje
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

-- SP Update Rol
CREATE PROCEDURE [SELECTIONADOS].[SP_Update_Rol]
  @nombre_rol VARCHAR(255),
  @habilitado BIT
AS
  BEGIN TRY
    DECLARE @nombre VARCHAR(255)
    DECLARE @mensaje VARCHAR(255)
    DECLARE @ID_Rol NUMERIC(18)

    SELECT @nombre = nombre, @ID_Rol = ID_Rol FROM [SELECTIONADOS].[Rol] WHERE Nombre = @nombre_rol

    IF @nombre IS NULL
      BEGIN
        INSERT INTO SELECTIONADOS.Rol (Nombre, Activo) VALUES (@nombre_rol, @habilitado)
        INSERT INTO SELECTIONADOS.Rol_X_Funcionalidad(ID_Funcionalidad, ID_Rol, Activo)
          SELECT ID_Rol, ID_Funcionalidad, 0 FROM SELECTIONADOS.Rol, SELECTIONADOS.Funcionalidades WHERE Nombre = @nombre_rol
      END
    ELSE
      UPDATE SELECTIONADOS.Rol SET Activo = @habilitado WHERE Nombre = @nombre
    IF @habilitado = 0
        UPDATE SELECTIONADOS.Asignacion_Rol SET Activo = 0 WHERE ID_Rol = @ID_Rol
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
 GO

-- SP Get Afiliado By
CREATE PROCEDURE [SELECTIONADOS].[SP_Get_Afiliado_By]
  @nombreAfiliado VARCHAR(255) = NULL ,
  @apellidoAfiliado VARCHAR(255) = NULL ,
  @dni INT = NULL,
  @nroAfiliado INT = NULL
AS
  BEGIN TRY
    SELECT
      ID_Afiliado, Nro_Afiliado, Nombre, Apellido, Tipo_Dni, Nro_Doc, Direccion, Telefono, Mail, Fecha_Nac, Sexo,
      Estado_Civil.Descripcion AS Estado_Civil,
      Planes.Descripcion AS Descipcion_Plan,
      Nro_Consultas
    FROM
      [SELECTIONADOS].[Afiliados]
    INNER JOIN SELECTIONADOS.Estado_Civil
      ON Estado_Civil.Id_Estado_Civil = Afiliados.ID_Estado_Civil
    INNER JOIN SELECTIONADOS.Planes
      ON Planes.Id_Plan = Afiliados.ID_Plan
    WHERE
      (@nombreAfiliado IS NULL OR Afiliados.Nombre LIKE @nombreAfiliado + '%') AND
      (@apellidoAfiliado IS NULL OR Afiliados.Apellido LIKE @apellidoAfiliado + '%') AND
      (@dni IS NULL OR Afiliados.Nro_Doc LIKE @dni) AND
      (@nroAfiliado IS NULL OR Afiliados.Nro_Afiliado LIKE @nroAfiliado) AND
      (Activo = 1)
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

CREATE PROCEDURE [SELECTIONADOS].[SP_Delete_Afiliado]
  @ID_Afiliado INT
AS
  BEGIN TRY
    UPDATE [SELECTIONADOS].[Afiliados] SET Activo = 0 WHERE ID_Afiliado = @ID_Afiliado
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

CREATE PROCEDURE [SELECTIONADOS].[SP_Get_Estado_Civil]
AS
  BEGIN TRY
    SELECT Id_Estado_Civil AS IdEstadoCivil, Descripcion FROM [SELECTIONADOS].[Estado_Civil]
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

CREATE PROCEDURE [SELECTIONADOS].[SP_Get_Planes]
AS
  BEGIN TRY
    SELECT Id_Plan AS IdPlan, Descripcion FROM [SELECTIONADOS].[Planes]
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

CREATE PROCEDURE [SELECTIONADOS].[SP_Update_Afiliado]
  @ID_Afiliado INT = NULL,
  @Nombre VARCHAR(255),
  @Apellido VARCHAR(255),
  @Tipo_Dni VARCHAR(4),
  @Nro_Doc NUMERIC(18),
  @Fecha_Nac DATETIME,
  @Sexo CHAR,

  @ID_Estado_Civil INT,
  @Telefono NUMERIC(18) = NULL ,
  @Direccion VARCHAR(255),
  @Mail VARCHAR(255),
  @ID_Plan INT
AS
  BEGIN TRY
    IF @ID_Afiliado IS NULL
      BEGIN
        INSERT INTO [SELECTIONADOS].[Afiliados](Nombre,Apellido,Tipo_Dni,Nro_Doc,Direccion,Telefono,Mail,Fecha_Nac,Sexo,ID_Estado_Civil,Id_Plan)
          VALUES (@Nombre, @Apellido, @Tipo_Dni, @Nro_Doc, @Direccion, @Telefono, @Mail, @Fecha_Nac, @Sexo, @ID_Estado_Civil, @ID_Plan)
        UPDATE [SELECTIONADOS].[Afiliados] SET [Nro_Afiliado] = (([ID_Afiliado] * 100) + 1) WHERE Nro_Doc = @Nro_Doc
      END
    ELSE
      UPDATE [SELECTIONADOS].[Afiliados] SET ID_Estado_Civil = @ID_Estado_Civil, Telefono = @Telefono, Direccion = @Direccion,
          Mail = @Mail, ID_Plan = @ID_Plan
        WHERE ID_Afiliado = @ID_Afiliado
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

CREATE PROCEDURE [SELECTIONADOS].[SP_Get_FamiliarACargo]
  @idAfiliado INT = NULL,
  @Tipo_Familiar CHAR = NULL
AS
  BEGIN TRY
    SELECT * FROM Familiar_ACargo WHERE
      (@idAfiliado IS NULL OR Familiar_ACargo.ID_Afiliado LIKE @idAfiliado) AND
      (@Tipo_Familiar IS NULL OR Familiar_ACargo.Tipo_Familiar LIKE @Tipo_Familiar)
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

CREATE PROCEDURE [SELECTIONADOS].[SP_Update_FamiliarACargo]
  @ID_Afiliado INT,
    @Nro_Afiliado INT = NULL ,
  @Nombre VARCHAR(255),
  @Apellido VARCHAR(255),
  @Tipo_Dni VARCHAR(4),
  @Nro_Doc NUMERIC(18),
  @Sexo CHAR,
  @Fecha_Nac DATETIME,
  @Telefono NUMERIC(18),
  @Mail VARCHAR(255),
  @Tipo_Familiar CHAR
AS
  BEGIN TRY
    IF @Nro_Afiliado IS NULL AND @Tipo_Familiar = 'C'
      BEGIN
        INSERT INTO [SELECTIONADOS].[Familiar_ACargo](ID_Afiliado,Nro_Afiliado,Nombre,Apellido,Tipo_Doc,Nro_Doc,Sexo,Fecha_Nac,Telefono,Mail,Tipo_Familiar)
          VALUES (@ID_Afiliado, @ID_Afiliado * 100 + 2, @Nombre, @Apellido, @Tipo_Dni, @Nro_Doc, @Sexo, @Fecha_Nac, @Telefono, @Mail, @Tipo_Familiar)
      END
    IF @Nro_Afiliado IS NULL AND @Tipo_Familiar = 'H'
      BEGIN
        --Falta hacerlo bien
        INSERT INTO [SELECTIONADOS].[Familiar_ACargo](Nro_Afiliado,Nombre,Apellido,Tipo_Doc,Nro_Doc,Sexo,Fecha_Nac,Telefono,Mail,Tipo_Familiar)
          VALUES (@ID_Afiliado * 100 + 2, @Nombre, @Apellido, @Tipo_Dni, @Nro_Doc, @Sexo, @Fecha_Nac, @Telefono, @Mail, @Tipo_Familiar)
      END
    IF @Nro_Afiliado IS NOT NULL
      UPDATE [SELECTIONADOS].[Familiar_ACargo] SET Telefono = @Telefono, Mail = @Mail WHERE Nro_Afiliado = @Nro_Afiliado
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO