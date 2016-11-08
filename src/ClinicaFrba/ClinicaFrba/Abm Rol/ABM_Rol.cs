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

namespace ClinicaFrba.Abm_Rol
{
    public partial class ABM_Rol : Form
    {
        public ABM_Rol()
        {
            InitializeComponent();
            this.Cmb_Estado.Items.AddRange(new object[] {"Deshabilitado","Habilitado"});
            this.Clb_Funcionalidades.DataSource = GetFuncionalidades();
            this.Clb_Funcionalidades.DisplayMember = "Funcionalidades";
            this.Cmb_Estado.SelectedIndex = 0;
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static DataTable GetFuncionalidades()
        {
            SqlServer sql = new SqlServer();

            DataTable tabla = sql.EjecutarSp("SP_Get_Funcionalidades");
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                return null;
            }
            return tabla;
        }

        private void Lbl_LimpiarCampos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Txt_NombreRol.Text = string.Empty;
            this.Cmb_Estado.SelectedIndex = 0;
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            this.DGV_Roles.DataSource = GetRoles();
            this.DGV_Roles.AllowUserToAddRows = false;
        }

        public static DataTable GetRoles()
        {
            SqlServer sql = new SqlServer();
            DataTable tabla = sql.EjecutarSp("SP_Get_Roles");
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                return null;
            }
            return tabla;
        }

        private void CompletarFuncionalidades()
        {
            if (this.Txt_NombreRol.Text.Length > 0)
            {
                GetFuncilidadRol(this.Txt_NombreRol.Text.ToString(), this.Clb_Funcionalidades);
            }
        }

        public static void GetFuncilidadRol(string nombreRol, CheckedListBox funcionalidades)
        {

            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();

            parametros.AgregarParametro("nombre_rol", nombreRol);

            DataTable tabla = sql.EjecutarSp("SP_Get_Funcionalidades_Rol", parametros);
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                return;
            }

            Int32 cantidad = funcionalidades.Items.Count;
            Int32 cantidad2 = tabla.Rows.Count;
            for (int i = 0; i < cantidad && i < cantidad2; i++)
            {
                Boolean habilitado = Convert.ToBoolean(tabla.Rows[i].ItemArray[1].ToString());
                funcionalidades.SetItemChecked(i, habilitado);
            }
        }

        private void Btn_Crear_Click(object sender, EventArgs e)
        {
            if (this.ValidarForm() == false)
            {
                MessageBox.Show("Por favor complete el Nombre");
                return;
            }
            int estado = Convert.ToInt32(this.Cmb_Estado.SelectedIndex.ToString());
            CrearRol(this.Txt_NombreRol.Text, estado, Clb_Funcionalidades);

            this.DGV_Roles.DataSource = GetRoles();
        }

        private Boolean ValidarForm()
        {
            return (this.Txt_NombreRol.Text.Length > 0);
        }

        public static void CrearRol(string nombreRol, int estado, CheckedListBox funcionalidades)
        {
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();

            parametros.AgregarParametro("nombre_rol", nombreRol);
            parametros.AgregarParametro("habilitado", estado.ToString());
            DataTable tabla = sql.EjecutarSp("SP_Create_Rol", parametros);

            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
            }
            else if (tabla.Rows.Count > 0)
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[0].ToString());
            }
            else
            {
                bool habilitado;
                bool error = false;
                Int32 cantidad = funcionalidades.Items.Count;
                for (int i = 0; i < cantidad; i++)
                {
                    DataRowView fila = (DataRowView)funcionalidades.Items[i];
                    habilitado = funcionalidades.GetItemChecked(i);
                    error = ModificarFuncionalidad(nombreRol, fila.Row[0].ToString(), Convert.ToInt32(habilitado));
                    if (error == true)
                        break;
                }
                if (error == true)
                {
                    MessageBox.Show("Rol creado con inconsistencias");
                }
                else
                {
                    MessageBox.Show("Rol creado exitosamente");
                }
            }
        }

        public static bool ModificarFuncionalidad(string nombreRol, string funcionalidad, Int32 habilitado)
        {
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();

            parametros.AgregarParametro("rol_nombre", nombreRol);
            parametros.AgregarParametro("funcionalidad_nombre", funcionalidad);
            parametros.AgregarParametro("habilitado", habilitado.ToString());
            DataTable tabla = sql.EjecutarSp("SP_Update_Funionalidad_Por_Rol", parametros);
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                return true;
            }
            return false;
        }

        private void DGV_Roles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.Txt_NombreRol.Text = DGV_Roles.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.Cmb_Estado.SelectedIndex = Convert.ToInt32(DGV_Roles.Rows[e.RowIndex].Cells[1].Value);
                this.CompletarFuncionalidades();
            }
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (this.ValidarForm() == false)
            {
                MessageBox.Show("Por favor completar el nombre");
                return;
            }
            int estado = Convert.ToInt32(this.Cmb_Estado.SelectedIndex.ToString());
            ModificarRol(this.Txt_NombreRol.Text, estado, Clb_Funcionalidades);
        }

        public static void ModificarRol(string nombreRol, Int32 estado, CheckedListBox funcionalidades)
        {
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();

            parametros.AgregarParametro("nombre_rol", nombreRol);
            parametros.AgregarParametro("habilitado", estado.ToString());
            DataTable tabla = sql.EjecutarSp("SP_Update_Rol", parametros);
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
            }
            else
            {
                bool habilitado;
                bool error = false;
                Int32 cantidad = funcionalidades.Items.Count;
                for (int i = 0; i < cantidad; i++)
                {
                    DataRowView fila = (DataRowView)funcionalidades.Items[i];
                    habilitado = funcionalidades.GetItemChecked(i);
                    error = ModificarFuncionalidad(nombreRol,
                                  fila.Row[0].ToString(),
                                  Convert.ToInt32(habilitado));
                    if (error == true)
                        break;
                }
                if (error == true)
                {
                    MessageBox.Show("Rol modificado con inconsistencias");
                }
                else
                {
                    MessageBox.Show("Rol modificado exitosamente");
                }
            }
        }

    }
}
