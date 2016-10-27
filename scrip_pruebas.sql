--Drops
DROP SCHEMA SELECTIONADOS;
DROP PROCEDURE [SELECTIONADOS].[migracionDeDatos];
DROP TABLE [SELECTIONADOS].[Afiliados];
DROP TABLE [SELECTIONADOS].[Tipo_especialidad];

SELECT count(*) FROM gd_esquema.Maestra -- 59708
SELECT count(*) FROM SELECTIONADOS.Afiliados -- 5548

--Consultas
SELECT DISTINCT Paciente_Nombre,Paciente_Apellido,Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac
  FROM gd_esquema.Maestra
  WHERE Paciente_Nombre IS NOT NULL AND Paciente_Apellido IS NOT NULL

--Plan Medico
SELECT Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia
  FROM gd_esquema.Maestra
  GROUP BY Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia

--Turnos
SELECT Turno_Numero, Turno_Fecha
  FROM gd_esquema.Maestra

--Consulta_Sintomas
SELECT Consulta_Sintomas, Consulta_Enfermedades
  FROM gd_esquema.Maestra
  WHERE Consulta_Sintomas IS NOT NULL
  GROUP BY Consulta_Sintomas, Consulta_Enfermedades

-- Medicos
SELECT Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac
  FROM gd_esquema.Maestra
  GROUP BY Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac

-- Especialidad
SELECT Maestra.[Especialidad_Codigo], Maestra.[Especialidad_Descripcion], Tipo_especialidad.[id_tipo_especialidad]
  FROM gd_esquema.[Maestra]
    INNER JOIN SELECTIONADOS.Tipo_especialidad
    ON Tipo_especialidad.cod_tipo_especialidad = Maestra.Tipo_Especialidad_Codigo
  GROUP BY Especialidad_Codigo, Especialidad_Descripcion, Tipo_especialidad.[id_tipo_especialidad]


-- Tipo de especialidad
SELECT Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
  FROM gd_esquema.Maestra
  GROUP BY Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion