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
DROP PROCEDURE [SELECTIONADOS].[SP_Insert_Compra_Bono];
DROP TRIGGER [SELECTIONADOS].[Tr_Nro_Afiliado];
DROP TRIGGER [SELECTIONADOS].[Tr_Log_Baja_Afiliado];
DROP TRIGGER [SELECTIONADOS].[Tr_Bloqueo_Usuarios];
DROP TABLE [SELECTIONADOS].[Asignacion_Rol];
DROP TABLE [SELECTIONADOS].[Usuarios];
DROP TABLE [SELECTIONADOS].[Log_Baja_Afiliado];
DROP TABLE [SELECTIONADOS].[Log_Compra_Bono];
DROP TABLE [SELECTIONADOS].[Consulta];
DROP TABLE [SELECTIONADOS].[Bono_Afiliado];
DROP TABLE [SELECTIONADOS].[Turno];
DROP TABLE [SELECTIONADOS].[Afiliados];
DROP TABLE [SELECTIONADOS].[Estado_Civil];
DROP TABLE [SELECTIONADOS].[Familiar_ACargo];
DROP TABLE [SELECTIONADOS].[Planes];
DROP TABLE [SELECTIONADOS].[Rol_X_Funcionalidad];
DROP TABLE [SELECTIONADOS].[Rol];
DROP TABLE [SELECTIONADOS].[Funcionalidades];
DROP TABLE [SELECTIONADOS].[Disp_Profesional];
DROP TABLE [SELECTIONADOS].[Profesional_Especialidad];
DROP TABLE [SELECTIONADOS].[Especialidad];
DROP TABLE [SELECTIONADOS].[Profesional];
DROP TABLE [SELECTIONADOS].[Tipo_Especialidad];

SELECTIONADOS.SP_Insert_Disponibilidad_Profesional 1, 10, '11/15/2015 07:00:00'

SELECT ID_Afiliado_Profesional FROM SELECTIONADOS.Usuarios WHERE ID_Usuario = 5;

SELECT Especialidad.ID_Especialidad, Especialidad.Descripcion FROM SELECTIONADOS.Profesional
      INNER JOIN SELECTIONADOS.Profesional_Especialidad
      ON Profesional.ID_Profesional = Profesional_Especialidad.ID_Profesional
      INNER JOIN SELECTIONADOS.Especialidad
      ON Profesional_Especialidad.ID_Especialidad = Especialidad.ID_Especialidad
      WHERE Profesional.ID_Profesional = 1

-- Disponibilidad
-- Id Prof = 2 // Especialidad = 18 8 // Primer turno de la semana entre el ultimo turno de semana
SELECT Disp_Profesional.ID_Profesional, Disp_Profesional.ID_Especialidad, Disp_Profesional.Fecha
  FROM SELECTIONADOS.Disp_Profesional
  WHERE ID_Profesional = 2 AND ID_Especialidad = 18 AND Fecha BETWEEN '2016-11-21 00:00:00' AND '2016-11-26 23:59:59';

[SELECTIONADOS].[SP_Get_AgendaProfesional] 2, 18, '2016-11-21 00:00:00', '2016-11-26 23:59:59'
