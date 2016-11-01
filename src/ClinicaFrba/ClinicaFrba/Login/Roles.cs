using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Login
{
    public partial class Roles : Form
    {
        public string rol_name;
        public Roles()
        {
            InitializeComponent();
            rol_name = "";
        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (rol_name.Equals("") == true)
                MessageBox.Show("Seleccione un rol");
            else
            {
                this.Close();
            }
        }

        private void Roles_Load(object sender, EventArgs e)
        {

        }
       
    }
}
