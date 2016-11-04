using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Conexiones;

namespace ClinicaFrba.DAOs
{
    class AfiliadoDAO
    {
        public static DataTable SearchBy(string nombre, string apellido, string nroAfiliado, string dni)
        {
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();
            if (nombre.Equals(""))
            {
                parametros.AgregarParametro("nombreAfiliado", DBNull.Value);
            }
            else
            {
                parametros.AgregarParametro("nombreAfiliado", nombre);
            }
            if (apellido.Equals(""))
            {
                parametros.AgregarParametro("apellidoAfiliado", DBNull.Value);
            }
            else
            {
                parametros.AgregarParametro("apellidoAfiliado", nombre);
            }
            if (nroAfiliado.Equals(""))
            {
                parametros.AgregarParametro("nroAfiliado", DBNull.Value);
            }
            else
            {
                parametros.AgregarParametro("nroAfiliado", nombre);
            }
            if (dni.Equals(""))
            {
                parametros.AgregarParametro("dni", DBNull.Value);
            }
            else
            {
                parametros.AgregarParametro("dni", nombre);
            }

            try
            {
                DataTable table = null;
                table = sql.EjecutarSp("SP_Get_Afiliado_By", parametros);
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("El cliente que busca no existe, intente nuevamente");
                }
                else
                {
                    return table;
                }
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
