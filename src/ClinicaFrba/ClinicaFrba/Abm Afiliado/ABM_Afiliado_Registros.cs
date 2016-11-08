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
using ClinicaFrba.DAOs;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ABM_Afiliado_Registros : Form
    {
        private DataGridViewRow row;
        private string _IdAfiliado = "";

        public ABM_Afiliado_Registros()
        {
            InitializeComponent();
            this.CBX_EstadoCivil.DataSource = GetEstadoCivil();
            this.CBX_EstadoCivil.DisplayMember = "Descripcion";
            this.CBX_EstadoCivil.ValueMember = "IdEstadoCivil";
            this.CBX_PlanMedico.DataSource = GetPlanes();
            this.CBX_PlanMedico.DisplayMember = "Descripcion";
            this.CBX_PlanMedico.ValueMember = "IdPlan";

            DataTable table = new DataTable("Tabla");
            table.Columns.Add("Codigo");
            table.Columns.Add("Descripcion");

            DataRow dr = table.NewRow(); 
            dr[0] = "M";
            dr[1] = "Masculino";
            table.Rows.Add(dr);

            dr = table.NewRow();
            dr[0] = "F";
            dr[1] = "Femenino";
            table.Rows.Add(dr);

            this.CBX_Sexo.DataSource = table;
            this.CBX_Sexo.ValueMember = "Codigo";
            this.CBX_Sexo.DisplayMember = "Descripcion";
        }

        public void ObtenerDatosAfiliado(IWin32Window owner, DataGridViewRow dataRow)
        {
            this.row = dataRow;
            base.Show(owner);

            this.Text = "Afiliado Nro " + row.Cells[1].Value.ToString().Trim();
            GBX_DatosPersonales.Enabled = false;

            _IdAfiliado = row.Cells[0].Value.ToString().Trim();
            Txt_Nombre.Text = row.Cells[2].Value.ToString().Trim();
            Txt_Apellido.Text = row.Cells[3].Value.ToString().Trim();
            CBX_TipoDni.Text = row.Cells[4].Value.ToString().Trim();
            Txt_Dni.Text = row.Cells[5].Value.ToString().Trim();
            DTP_FechaDeNacimiento.Text = row.Cells[9].Value.ToString().Trim();
            CBX_Sexo.Text = row.Cells[10].Value.ToString().Trim();

            CBX_EstadoCivil.Text = row.Cells[11].Value.ToString().Trim();
            Txt_Telefono.Text = row.Cells[7].Value.ToString().Trim();
            Txt_Direccion.Text = row.Cells[6].Value.ToString().Trim();
            Txt_email.Text = row.Cells[8].Value.ToString().Trim();
            CBX_PlanMedico.Text = row.Cells[12].Value.ToString().Trim();
        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static DataTable GetEstadoCivil()
        {
            SqlServer sql = new SqlServer();
            DataTable table = sql.EjecutarSp("SP_Get_Estado_Civil");
            if (table.Rows.Count > 0 && table.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(table.Rows[0].ItemArray[1].ToString());
                return null;
            }
            return table;
        }

        public static DataTable GetPlanes()
        {
            SqlServer sql = new SqlServer();
            DataTable table = sql.EjecutarSp("SP_Get_Planes");
            if (table.Rows.Count > 0 && table.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(table.Rows[0].ItemArray[1].ToString());
                return null;
            }
            return table;
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Se guardaran los datos del afiliado: " + Txt_Nombre.Text , "Confirmacion Afiliado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                //Validar datos
                //Si se modifica el plan hay que ingresarlo al log. 
                AfiliadoDAO.UpdateAfiliado(_IdAfiliado, Txt_Nombre.Text, Txt_Apellido.Text,
                    CBX_TipoDni.Text, Txt_Dni.Text, DTP_FechaDeNacimiento.Value.Date.ToString("yyyy/MM/dd"), CBX_Sexo.SelectedValue.ToString(), CBX_EstadoCivil.SelectedValue.ToString(),
                    Txt_Telefono.Text, Txt_Direccion.Text, Txt_email.Text, CBX_PlanMedico.SelectedValue.ToString());

                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}
