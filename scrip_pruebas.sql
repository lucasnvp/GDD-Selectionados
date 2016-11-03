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

-- Profesional especializacion
SELECT SELECTIONADOS.Profesional.Id_Profesional, SELECTIONADOS.Especialidad.id_tipo_especialidad
FROM SELECTIONADOS.Profesional
  INNER JOIN gd_esquema.Maestra
  on Maestra.Medico_Dni = SELECTIONADOS.Profesional.nro_doc AND Maestra.Especialidad_Codigo = SELECTIONADOS.Especialidad.cod_especialidad
GROUP BY SELECTIONADOS.Profesional.Id_Profesional, SELECTIONADOS.Especialidad.id_tipo_especialidad

SELECT Maestra.Medico_Nombre, Maestra.Medico_Dni, Maestra.Especialidad_Codigo, Maestra.Especialidad_Descripcion
FROM gd_esquema.Maestra
GROUP BY Maestra.Medico_Nombre, Maestra.Medico_Dni, Maestra.Especialidad_Codigo, Maestra.Especialidad_Descripcion

SELECT Maestra.Medico_Nombre, Maestra.Medico_Dni,Profesional.Id_Profesional, Maestra.Especialidad_Codigo, Maestra.Especialidad_Descripcion, Especialidad.id_especialidad
FROM gd_esquema.Maestra
  INNER JOIN SELECTIONADOS.Profesional
  ON Maestra.Medico_Dni = SELECTIONADOS.Profesional.nro_doc
  INNER JOIN SELECTIONADOS.Especialidad
  ON Maestra.Especialidad_Codigo = SELECTIONADOS.Especialidad.cod_especialidad

SELECT Profesional.Id_Profesional, Especialidad.id_especialidad
FROM gd_esquema.Maestra
  INNER JOIN SELECTIONADOS.Profesional
  ON Maestra.Medico_Dni = SELECTIONADOS.Profesional.nro_doc
  INNER JOIN SELECTIONADOS.Especialidad
  ON Maestra.Especialidad_Codigo = SELECTIONADOS.Especialidad.cod_especialidad
GROUP BY Profesional.Id_Profesional, Especialidad.id_especialidad

-- Bonos
SELECT Maestra.Compra_Bono_Fecha, Maestra.Bono_Consulta_Fecha_Impresion, Maestra.Bono_Consulta_Numero
FROM gd_esquema.Maestra
WHERE Maestra.Bono_Consulta_Fecha_Impresion IS NOT NULL
ORDER BY Maestra.Bono_Consulta_Numero DESC

SELECT Maestra.Bono_Consulta_Fecha_Impresion
FROM gd_esquema.Maestra
WHERE Bono_Consulta_Fecha_Impresion IS NOT NULL

SELECT Maestra.Compra_Bono_Fecha
FROM gd_esquema.Maestra
WHERE Compra_Bono_Fecha IS NOT NULL

-- Turnos
SELECT Maestra.Turno_Fecha, Maestra.Turno_Numero
FROM gd_esquema.Maestra
WHERE Maestra.Turno_Numero IS NOT NULL

SELECT Maestra.Turno_Numero, Afiliados.Id_afiliado, Profesional.Id_Profesional, Especialidad.id_especialidad, Maestra.Turno_Fecha
FROM gd_esquema.Maestra
  INNER JOIN SELECTIONADOS.Afiliados
  ON SELECTIONADOS.Afiliados.nro_doc = Maestra.Paciente_Dni
  INNER JOIN SELECTIONADOS.Profesional
  ON SELECTIONADOS.Profesional.nro_doc = Maestra.Medico_Dni
  INNER JOIN SELECTIONADOS.Especialidad
  ON SELECTIONADOS.Especialidad.cod_especialidad = Maestra.Especialidad_Codigo
WHERE Maestra.Turno_Numero IS NOT NULL

-- Consultas
SELECT Maestra.Bono_Consulta_Numero, Maestra.Turno_Numero, Maestra.Consulta_Enfermedades, Maestra.Consulta_Sintomas, Maestra.Bono_Consulta_Fecha_Impresion
FROM gd_esquema.Maestra
WHERE Maestra.Bono_Consulta_Fecha_Impresion IS NOT NULL

SELECT Maestra.Bono_Consulta_Numero, Turno.Nro_Turno, Maestra.Consulta_Enfermedades, Maestra.Consulta_Sintomas, Maestra.Bono_Consulta_Fecha_Impresion, NULL AS ID_Bono
FROM gd_esquema.Maestra
  INNER JOIN SELECTIONADOS.Turno
  ON SELECTIONADOS.Turno.Nro_Turno = Maestra.Turno_Numero
WHERE Maestra.Bono_Consulta_Fecha_Impresion IS NOT NULL


SELECT Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac
    FROM gd_esquema.Maestra
    WHERE Medico_Nombre IS NOT NULL
    GROUP BY Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac

SELECT [Paciente_Nombre], [Paciente_Apellido], 'DNI' AS Tipo_Dni, Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac, Planes.Id_Plan, 0 AS Nro_Consultas, 1 AS Activo
FROM gd_esquema.Maestra
  INNER JOIN SELECTIONADOS.Planes
  ON SELECTIONADOS.Planes.Cod_Plan = Maestra.Plan_Med_Codigo
WHERE Paciente_Nombre IS NOT NULL AND Paciente_Apellido IS NOT NULL
GROUP BY [Paciente_Nombre], [Paciente_Apellido], Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac, Planes.Id_Plan

SELECT ID_Usuario FROM SELECTIONADOS.Usuarios WHERE Username = 'admin' AND Password = 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7';

DECLARE @ID_Usuario INT
EXECUTE SELECTIONADOS.SP_Get_Usuario 'admin','admin', @ID_Usuario OUT
EXECUTE SELECTIONADOS.SP_Get_Usuario 'qwer','12345'
EXECUTE SELECTIONADOS.SP_Get_Usuario 'admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'
PRINT @ID_Usuario

EXECUTE SELECTIONADOS.SP_Get_Usuario_Rol '5'