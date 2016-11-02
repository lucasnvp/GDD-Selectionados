using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using ClinicaFrba.Conexiones;

namespace ClinicaFrba.Login
{
    public partial class Cl_Login : Form
    {
        public Cl_Login()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                Roles roles = new Roles();
                if (roles.rol_name.Equals("") == true)
                {
                    roles.ShowDialog();
                }
                else
                {
                    //Abrir menu
                    this.Close();
                }
            }
        }

        private bool Validar()
        {
            int intentos = 0;
            bool resultado = false;
            int id_usuario;

            if (Txt_Usuario.Text.Length == 0 || Txt_Password.Text.Length == 0)
            {
                MessageBox.Show("Ingresar usuario y password");
                return false;
            }

            string msjLogueo = this.LoguearUsuario(out resultado, out id_usuario);
            //MessageBox.Show(id_usuario.ToString());

//            if (resultado == false)
//            {
//                MessageBox.Show(msjLogueo);
//                intentos++;
//                if (intentos == 3)
//                {
//                    //Bloquear Usuario
//                }
//                return false;
//            }
//            else
//            {
//                return true;
//            }

            return true;
        }

        private string LoguearUsuario(out bool resultado, out int idUsuario)
        {
            string mensaje = "";
            idUsuario = 0;
            string usuario = Txt_Usuario.Text;
            string password = Txt_Password.Text;

            //            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            //            UTF8Encoding utf8 = new UTF8Encoding();
            //Muestro el sha256 - es la pass que voy a preguntar
            //MessageBox.Show(BitConverter.ToString(sha256.ComputeHash(utf8.GetBytes(Txt_Password.Text))));
            //var password = BitConverter.ToString(sha256.ComputeHash(utf8.GetBytes(Txt_Password.Text)));

            Parametros listaParametros = new Parametros();
            SqlServer sqlServer = new SqlServer();

            //Usuario
            listaParametros.AgregarParametro("Usuario", usuario);
            //Password
            listaParametros.AgregarParametro("Password", password);

            DataTable dataTable = sqlServer.EjecutarSp("SP_Get_Usuario", listaParametros);
            if (dataTable.Rows.Count == 0)
            {
                resultado = false;
                mensaje = "Error con la BD";
            }
            else
            {
                if (dataTable.Rows[0].ItemArray[0].ToString() == "ERROR")
                {
                    resultado = false;
                    mensaje = "Error con la BD";
                }
                else
                {
                    resultado = true;
                    idUsuario = int.Parse(dataTable.Rows[0].ItemArray[0].ToString());
                }
            }
            return mensaje;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
