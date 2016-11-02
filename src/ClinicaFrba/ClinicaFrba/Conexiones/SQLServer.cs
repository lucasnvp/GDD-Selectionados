using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Properties;

namespace ClinicaFrba.Conexiones
{
    class SqlServer
    {
        public SqlConnection CrearSqlConnection()
        {
            return new SqlConnection(this.CadenaDeConexion());
        }

        private string CadenaDeConexion()
        {
//            string sqlCadenaConexion = Settings.Default.SQL_Database +
//                                       Settings.Default.SQL_Server + @"\" +
//                                       Settings.Default.SQL_Name +
//                                       Settings.Default.SQL_Password +
//                                       Settings.Default.SQL_Security +
//                                       Settings.Default.SQL_Timeout +
//                                       Settings.Default.SQL_User;
            string sqlCadenaConexion = "Data Source = 192.168.1.130; Initial Catalog = master; Persist Security Info = True; User ID = gd";

            return sqlCadenaConexion;

        }

        public SqlConnection AbrirConnection()
        {
            SqlConnection sqlConexion = new SqlConnection(this.CadenaDeConexion());
            try
            {
                sqlConexion.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return sqlConexion;
        }

        public static void CerraConnection(SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public DataSet EjecutarConsulta(String query)
        {
            if (query.Length == 0)
            {
                throw (new Exception());
            }
            try
            {
                DataSet dato = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, AbrirConnection());
                dataAdapter.Fill(dato);
                return dato;
            }
            catch (Exception)
            {
                throw (new Exception());
            }
        }

        public DataTable EjecutarSp(string procedure, Parametros parametros)
        {
            SqlCommand cmdCommand = new SqlCommand();
            SqlDataAdapter dataAdapter;
            DataTable dataTable = new DataTable();

            try
            {
                cmdCommand.CommandType = CommandType.StoredProcedure;
                cmdCommand.Connection = AbrirConnection();
                cmdCommand.CommandText = "[" + Settings.Default.SQL_Schema + "].[" + procedure + "]";

                for (int i = 0; i < parametros.Lista.Count; i++)
                {
                    cmdCommand.Parameters.AddWithValue("@" + parametros.Lista[i].Nombre, parametros.Lista[i].Valor);
                }

                dataAdapter = new SqlDataAdapter(cmdCommand);
                dataAdapter.Fill(dataTable);
                CerraConnection(cmdCommand.Connection);
                cmdCommand.Dispose();
            }
            catch (Exception e)
            {
                dataTable.Columns.Add("0", Type.GetType("System.String"));
                dataTable.Columns.Add("1", Type.GetType("System.String"));
                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = "ERROR";
                dataRow[1] = e.ToString();
                dataTable.Rows.Add(dataRow);
                return dataTable;
            }
            return dataTable;
        }

    }
}
