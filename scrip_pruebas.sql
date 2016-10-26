--Drops
DROP SCHEMA SELECTIONADOS;
DROP PROCEDURE [SELECTIONADOS].[migracionDeDatos];
DROP TABLE [SELECTIONADOS].[Afiliados];

SELECT count(*) FROM gd_esquema.Maestra -- 59708
SELECT count(*) FROM SELECTIONADOS.Afiliados -- 5548

--Consultas
SELECT DISTINCT Paciente_Nombre,Paciente_Apellido,Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac
  FROM gd_esquema.Maestra
  WHERE Paciente_Nombre IS NOT NULL AND Paciente_Apellido IS NOT NULL