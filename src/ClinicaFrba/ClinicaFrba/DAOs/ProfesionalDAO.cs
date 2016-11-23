using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Conexiones;

namespace ClinicaFrba.DAOs
{
    class ProfesionalDAO
    {
        public static DataTable Especialidades()
        {
            SqlServer sql = new SqlServer();
            try
            {
                DataTable table = sql.EjecutarSp("SP_Get_EspecialidadMedicas");
                return table;
                //.DisplayMember = "Descripcion";
                //.ValueMember = "ID_Especialidad";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static DataTable EspecialidadesById(string idProfesional)
        {
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();
            parametros.AgregarParametro("idProfesional", idProfesional);
            try
            {
                DataTable table = sql.EjecutarSp("SP_Get_Especialidad_Descripcion", parametros);
                return table;
                //.DisplayMember = "Descripcion";
                //.ValueMember = "ID_Especialidad";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static DataTable ProfesionalByApellido(string apellido)
        {
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();
            parametros.AgregarParametro("apellido", apellido);
            try
            {
                DataTable table = sql.EjecutarSp("SP_Get_Profesional_ByApellido", parametros);
                return table;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static DataTable ProfesionalByApellidoAndEspecialidad(string apellido, string idEspecialidad)
        {
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();
            parametros.AgregarParametro("apellido", apellido);
            parametros.AgregarParametro("idEspeciadad", idEspecialidad);
            try
            {
                DataTable table = sql.EjecutarSp("SP_Get_Profesional_ByApellidoAndEspecialidad", parametros);
                return table;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static DataTable TurnosBy(string idProfesional)
        {
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();
            parametros.AgregarParametro("idProfesional", idProfesional);
            try
            {
                DataTable table = sql.EjecutarSp("SP_Get_Turnos_Today_ByProfesional", parametros);
                return table;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

    }
}
