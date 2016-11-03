using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Funcionalidades;

namespace ClinicaFrba.Login
{
    public partial class Roles : Form
    {
        public string rol_name;
        public Roles(int idUsuario)
        {
            InitializeComponent();
            rol_name = "";
            Cmb_Roles = LLenarCombo.FillComboBox(Cmb_Roles, "SP_Get_Usuario_Rol", idUsuario);
            if (Cmb_Roles.Items.Count.Equals(1))
            {
                Cmb_Roles.SelectedIndex = 0;
                DataRowView fila = (DataRowView) Cmb_Roles.Items[0];
                rol_name = fila["Nombre"].ToString();
                this.Close();
            }
        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            DataRowView selectView = (DataRowView) Cmb_Roles.SelectedItem;
            rol_name = selectView.Row[0].ToString();
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
