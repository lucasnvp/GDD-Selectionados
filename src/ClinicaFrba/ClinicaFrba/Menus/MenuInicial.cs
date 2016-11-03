using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Conexiones;

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

        public void LevantarRol(string rol)
        {
            SqlServer sql = new SqlServer();
            Parametros listaParametros = new Parametros();
            DataTable tabla;
            this.RolUsuario = rol;
            listaParametros.AgregarParametro("Nombre_Rol", rol);
            tabla = sql.EjecutarSp("SP_Get_Funcionalidades_Rol", listaParametros);
            foreach (Control subchild in this.Controls)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    if (subchild.Name == tabla.Rows[i][0].ToString())
                    {
                        subchild.Enabled = tabla.Rows[i][1].Equals(true);
                        subchild.Visible = tabla.Rows[i][1].Equals(true);
                    }
                }
            }
        }

    }
}
