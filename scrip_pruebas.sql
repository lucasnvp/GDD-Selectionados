--Drops
DROP SCHEMA SELECTIONADOS;
DROP PROCEDURE [SELECTIONADOS].[01_Insert_Datos_Iniciales];
DROP PROCEDURE [SELECTIONADOS].[02_Migracion_De_Datos];
DROP PROCEDURE [SELECTIONADOS].[03_Creacion_De_Las_FK];
DROP PROCEDURE [SELECTIONADOS].[SP_Create_Rol];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Afiliado_By];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Estado_Civil];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Funcionalidades];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Funcionalidades_Rol];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Roles];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Usuario];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Usuario_Rol];
DROP PROCEDURE [SELECTIONADOS].[SP_Update_Afiliado];
DROP PROCEDURE [SELECTIONADOS].[SP_Update_Funionalidad_Por_Rol];
DROP PROCEDURE [SELECTIONADOS].[SP_Update_Rol];
DROP TRIGGER [SELECTIONADOS].[Tr_Nro_Afiliado];
DROP TRIGGER [SELECTIONADOS].[Tr_Log_Baja_Afiliado];
DROP TABLE [SELECTIONADOS].[Asignacion_Rol];
DROP TABLE [SELECTIONADOS].[Usuarios];
DROP TABLE [SELECTIONADOS].[Log_Baja_Afiliado];
DROP TABLE [SELECTIONADOS].[Consulta];
DROP TABLE [SELECTIONADOS].[Compra_Bono];
DROP TABLE [SELECTIONADOS].[Turno];
DROP TABLE [SELECTIONADOS].[Afiliados];
DROP TABLE [SELECTIONADOS].[Estado_Civil];
DROP TABLE [SELECTIONADOS].[Familiar_ACargo];
DROP TABLE [SELECTIONADOS].[Planes];
DROP TABLE [SELECTIONADOS].[Rol_X_Funcionalidad];
DROP TABLE [SELECTIONADOS].[Rol];
DROP TABLE [SELECTIONADOS].[Funcionalidades];
DROP TABLE [SELECTIONADOS].[Profesional_Especialidad];
DROP TABLE [SELECTIONADOS].[Especialidad];
DROP TABLE [SELECTIONADOS].[Profesional];
DROP TABLE [SELECTIONADOS].[Tipo_Especialidad];



  -- Triggers
-- Creacion de los Nros de turnos
-- Creacion de los Nros de consultas
-- Crear trigger para que cuando se haga la baja logica de un afiliado, se ingrese el log.

--Hay que completar este trigger para que se liberen los turnos solicitados por este usuario al momento de la baja.
/*
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

INSERT INTO SELECTIONADOS.Afiliados (Nombre, Apellido, Tipo_Dni, Nro_Doc, Direccion, Telefono, Mail, Fecha_Nac, Sexo, ID_Estado_Civil, ID_Plan, Tipo_Afiliado)
  VALUES ('Lucas','Visser','DNI','35726012','Ambrosoni 2136', '44223311','lucas@lucas.com','','M','1','1', 'P')