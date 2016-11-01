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
            }
        }

        private bool Validar()
        {
            //var intentos = 0;

            if (Txt_Usuario.Text.Length == 0 || Txt_Password.Text.Length == 0)
            {
                MessageBox.Show("Ingresar usuario y password");
                return false;
            }

            this.LoguearUsuario();

            return true;
        }

        private void LoguearUsuario()
        {
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            UTF8Encoding utf8 = new UTF8Encoding();
            //Muestro el sha256 - es la pass que voy a preguntar
            MessageBox.Show(BitConverter.ToString(sha256.ComputeHash(utf8.GetBytes(Txt_Password.Text))));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
