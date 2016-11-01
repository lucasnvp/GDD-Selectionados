using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Properties;

namespace ClinicaFrba.Conexiones
{
    class SQLServer
    {
        public SqlConnection CrearSqlConnection()
        {
            return new SqlConnection(CadenaDeConexion());
        }

        private static string CadenaDeConexion()
        {
            string sqlCadenaConexion =  Settings.Default.SQL_Database +
                                        Settings.Default.SQL_Server + @"\" +
                                        Settings.Default.SQL_Name +
                                        Settings.Default.SQL_Password +
                                        Settings.Default.SQL_Security +
                                        Settings.Default.SQL_Timeout +
                                        Settings.Default.SQL_User;
            return sqlCadenaConexion;
        }
    }
}
