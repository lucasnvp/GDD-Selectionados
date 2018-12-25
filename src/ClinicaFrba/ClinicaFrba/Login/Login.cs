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
using ClinicaFrba.Menus;

namespace ClinicaFrba.Login
{
    public partial class Cl_Login : Form
    {
        private int _intentos = 0;
        private int _idUsuario;

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
                Roles roles = new Roles(_idUsuario);
                if (roles.rol_name.Equals("") == true)
                {
                    roles.ShowDialog();
                }
                else
                {
                    Txt_Password.Clear();
                    MenuInicial menu = new MenuInicial(_idUsuario);
                    menu.LevantarRol(roles.rol_name);
                    menu.ShowDialog();
                }
            }
        }

        private bool Validar()
        {

            bool resultado = false;
            int idUsuario;

            if (Txt_Usuario.Text.Length == 0 || Txt_Password.Text.Length == 0)
            {
                MessageBox.Show("Ingresar usuario y password");
                return false;
            }

            string msjLogueo = this.LoguearUsuario(out resultado, out idUsuario);

            if (resultado == false)
            {
                MessageBox.Show(msjLogueo);
                this._intentos++;
                if (_intentos == 3)
                {
                    Parametros parametros = new Parametros();
                    SqlServer sql = new SqlServer();

                    parametros.AgregarParametro("usuario", Txt_Usuario.Text);
                    sql.EjecutarSp("SP_Block_Usuario", parametros);

                    MessageBox.Show("Usuario Bloqueado");
                }
                return false;
            }
            else
            {
                this._idUsuario = idUsuario;
                return true;
            }
        }

        private string LoguearUsuario(out bool resultado, out int idUsuario)
        {
            string mensaje = "";
            idUsuario = 0;
            string usuario = Txt_Usuario.Text;

            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            UTF8Encoding utf8 = new UTF8Encoding();
            string password = BitConverter.ToString(sha256.ComputeHash(utf8.GetBytes(Txt_Password.Text)));

            Parametros listaParametros = new Parametros();
            SqlServer sqlServer = new SqlServer();

            listaParametros.AgregarParametro("Usuario", usuario);
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
                    mensaje = dataTable.Rows[0].ItemArray[1].ToString();
                }
                else if (dataTable.Rows[0].ItemArray[0].ToString() == "")
                {
                    resultado = false;
                    mensaje = "Password o Usuario Incorrecto";
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
