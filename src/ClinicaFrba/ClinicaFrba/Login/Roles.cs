using MercadoEnvio.Clases;
using System;
using System.Data;
using System.Windows.Forms;

namespace MercadoEnvio.Login
{
    public partial class cl_Roles : Form
    {
        public string rol_name;
        public cl_Roles(int usuario_id)
        {
            InitializeComponent();
            rol_name = "";
            cmb_roles = cl_combo.m_fill_combo(cmb_roles, "sp_get_usuario_roles", usuario_id);
            if (cmb_roles.Items.Count.Equals(1))
            {

                cmb_roles.SelectedIndex = 0;
                DataRowView fila = (DataRowView)cmb_roles.Items[0];
                rol_name = fila["Nombre"].ToString();
                this.Close();
            }
        }

       

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            DataRowView seleccion = (DataRowView)cmb_roles.SelectedItem;
            rol_name = seleccion.Row[0].ToString();
            if (rol_name.Equals("") == true)
              MessageBox.Show("Seleccione un rol");
            else
              this.Close();
        }
    }
}
