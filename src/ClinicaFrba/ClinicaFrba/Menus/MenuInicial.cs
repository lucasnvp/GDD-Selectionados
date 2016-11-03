using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Menus
{
    public partial class MenuInicial : Form
    {
        private int IdUsuario { get; set; }
        private string RolUsuario { get; set; }

        public MenuInicial(int idUsuario)
        {
            InitializeComponent();
            this.IdUsuario = idUsuario;
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
