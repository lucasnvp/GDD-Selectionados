--Drops
DROP SCHEMA SELECTIONADOS;
DROP PROCEDURE [SELECTIONADOS].[migracionDeDatos];
DROP TABLE [SELECTIONADOS].[Afiliados];

--Consultas
SELECT Paciente_Nombre FROM gd_esquema.Maestra WHERE Paciente_Nombre IS NOT NULL;