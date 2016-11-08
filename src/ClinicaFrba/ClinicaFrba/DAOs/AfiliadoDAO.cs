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
                parametros.AgregarParametro("apellidoAfiliado", apellido);
            }
            if (nroAfiliado.Equals(""))
            {
                parametros.AgregarParametro("nroAfiliado", DBNull.Value);
            }
            else
            {
                parametros.AgregarParametro("nroAfiliado", nroAfiliado);
            }
            if (dni.Equals(""))
            {
                parametros.AgregarParametro("dni", DBNull.Value);
            }
            else
            {
                parametros.AgregarParametro("dni", dni);
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

        public static void EliminarAfiliado(string idAEliminar)
        {
            Parametros parametros = new Parametros();
            SqlServer sql = new SqlServer();

            parametros.AgregarParametro("ID_Afiliado", idAEliminar);
            sql.EjecutarSp("SP_Delete_Afiliado", parametros);
        }

        public static void UpdateAfiliado(string idAfiliado, string nombre, string apellido, string tipo_dni,
            string nro_doc, string fecha_nac, string sexo, string estadoCivil, string telefono, string direccion,
            string mail, string plan)
        {
            string result = "";
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();

            if (idAfiliado.Equals(""))
            {
                parametros.AgregarParametro("ID_Afiliado", DBNull.Value);
            }
            else
            {
                parametros.AgregarParametro("ID_Afiliado", idAfiliado.Trim());
            }

            parametros.AgregarParametro("Nombre", nombre.Trim());
            parametros.AgregarParametro("Apellido", apellido.Trim());
            parametros.AgregarParametro("Tipo_Dni", tipo_dni.Trim());
            parametros.AgregarParametro("Nro_Doc", nro_doc.Trim());
            parametros.AgregarParametro("Fecha_Nac", fecha_nac);
            parametros.AgregarParametro("Sexo", sexo.Trim());
            parametros.AgregarParametro("ID_Estado_Civil", estadoCivil);
            parametros.AgregarParametro("Telefono", telefono.Trim());
            parametros.AgregarParametro("Direccion", direccion.Trim());
            parametros.AgregarParametro("Mail", mail.Trim());
            parametros.AgregarParametro("ID_Plan", plan);

            try
            {
                DataTable table = sql.EjecutarSp("SP_Update_Afiliado", parametros);
                if (table.Rows.Count > 0 && table.Rows[0].ItemArray[0].ToString() == "ERROR")
                {
                    MessageBox.Show(table.Rows[0].ItemArray[1].ToString());
                }
                else
                {
                    MessageBox.Show("Afiliado guardado");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

    }
}
