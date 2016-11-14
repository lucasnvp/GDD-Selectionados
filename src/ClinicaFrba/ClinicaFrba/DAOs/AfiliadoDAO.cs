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

        public static void UpdateFamiliarACargo(string idAfiliado, string nroAfiliado, string nombre, string apellido, string tipo_doc,
            string nro_doc, string sexo, string fecha_nac, string telefono, string mail, string tipo_familiar)
        {
            string result = "";
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();

            parametros.AgregarParametro("ID_Afiliado", idAfiliado.Trim());

            if (nroAfiliado.Equals(""))
            {
                parametros.AgregarParametro("Nro_Afiliado", DBNull.Value);
            }
            else
            {
                parametros.AgregarParametro("Nro_Afiliado", nroAfiliado.Trim());
            }

            parametros.AgregarParametro("Nombre", nombre.Trim());
            parametros.AgregarParametro("Apellido", apellido.Trim());
            parametros.AgregarParametro("Tipo_Dni", tipo_doc.Trim());
            parametros.AgregarParametro("Nro_Doc", nro_doc.Trim());
            parametros.AgregarParametro("Sexo", sexo.Trim());
            parametros.AgregarParametro("Fecha_Nac", fecha_nac);
            parametros.AgregarParametro("Telefono", telefono.Trim());
            parametros.AgregarParametro("Mail", mail.Trim());
            parametros.AgregarParametro("Tipo_Familiar", tipo_familiar.Trim());

            try
            {
                DataTable table = sql.EjecutarSp("SP_Update_FamiliarACargo", parametros);
                if (table.Rows.Count > 0 && table.Rows[0].ItemArray[0].ToString() == "ERROR")
                {
                    MessageBox.Show(table.Rows[0].ItemArray[1].ToString());
                }
                else
                {
                    MessageBox.Show("Familiar guardado");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static DataTable SearchConyuge(string idfiliado, string tipoFamiliar)
        {
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();
            if (idfiliado.Equals(""))
            {
                parametros.AgregarParametro("idAfiliado", DBNull.Value);
            }
            else
            {
                parametros.AgregarParametro("idAfiliado", idfiliado);
            }
            if (tipoFamiliar.Equals(""))
            {
                parametros.AgregarParametro("Tipo_Familiar", DBNull.Value);
            }
            else
            {
                parametros.AgregarParametro("Tipo_Familiar", tipoFamiliar);
            }
            
            try
            {
                DataTable table = null;
                table = sql.EjecutarSp("SP_Get_FamiliarACargo", parametros);
                if (table.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    return table;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static string GetPrecioBono(string nroAfiliado)
        {
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();

            parametros.AgregarParametro("nroAfiliado", nroAfiliado);

            try
            {
                DataTable table = null;
                table = sql.EjecutarSp("SP_Get_Planes_PrecioBono", parametros);
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Error a buscar el precio del bono");
                    return null;
                }
                else
                {
                    DataRow row = table.Rows[0];
                    string precio = row.ItemArray[0].ToString();
                    return precio;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static void ComprarBono(string idAfiliado, string nroAfiliado, string cantComprados)
        {
            Parametros parametros = new Parametros();
            SqlServer sql = new SqlServer();

            parametros.AgregarParametro("idAfiliado", idAfiliado);
            parametros.AgregarParametro("nroAfiliado", nroAfiliado);
            parametros.AgregarParametro("cantComprados", cantComprados);
            sql.EjecutarSp("SP_Insert_Compra_Bono", parametros);
        }

    }
}
