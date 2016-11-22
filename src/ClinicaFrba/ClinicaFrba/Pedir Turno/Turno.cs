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

namespace ClinicaFrba.Pedir_Turno
{
    public partial class Turno : Form
    {
        public Turno()
        {
            InitializeComponent();

            this.Cbx_Especialidad.DataSource = GetEspecialidades();
            this.Cbx_Especialidad.DisplayMember = "Descripcion";
            this.Cbx_Especialidad.ValueMember = "ID_Especialidad";
        }

        public static DataTable GetEspecialidades()
        {
            SqlServer sql = new SqlServer();
            DataTable table = sql.EjecutarSp("SP_Get_EspecialidadMedicas");
            if (table.Rows.Count > 0 && table.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(table.Rows[0].ItemArray[1].ToString());
                return null;
            }
            return table;
        }

        private void Cbx_Especialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();
            parametros.AgregarParametro("idEspecialidad", Cbx_Especialidad.SelectedValue.ToString());
            DataTable tabla = sql.EjecutarSp("SP_Get_Profesional_ByEspecialidad", parametros);
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
            }
            this.Cbx_Profesional.DataSource = tabla;
            this.Cbx_Profesional.DisplayMember = "Apellido";
            this.Cbx_Profesional.ValueMember = "ID_Profesional";

        }

        private void Dtp_Turno_ValueChanged(object sender, EventArgs e)
        {
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();
            parametros.AgregarParametro("idProfesional", Cbx_Profesional.SelectedValue.ToString());
            parametros.AgregarParametro("idEspecialidad", Cbx_Especialidad.SelectedValue.ToString());
            parametros.AgregarParametro("fecha", Dtp_Turno.Value.Date.ToString("yyyy-MM-dd"));
            DataTable table = sql.EjecutarSp("SP_Get_DisponibilidadProfesional", parametros);
            if (table.Rows.Count > 0 && table.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(table.Rows[0].ItemArray[1].ToString());
            }
            this.Cbx_Horario.DataSource = table;
            this.Cbx_Horario.DisplayMember = "Turno";
            this.Cbx_Horario.ValueMember = "ID_Disponibilidad";
        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_GenerarTurno_Click(object sender, EventArgs e)
        {
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();
            parametros.AgregarParametro("idAfiliado", "Falta");
            parametros.AgregarParametro("nroAfiliado", Txt_NroAfiliado.Text);
            parametros.AgregarParametro("idProfesional", Cbx_Profesional.SelectedValue.ToString());
            parametros.AgregarParametro("idEspecialidad", Cbx_Especialidad.SelectedValue.ToString());
            parametros.AgregarParametro("idDispProfesional", Cbx_Horario.SelectedValue.ToString());
            DataTable table = sql.EjecutarSp("SP_GenerarTurno", parametros);
            if (table.Rows.Count > 0 && table.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(table.Rows[0].ItemArray[1].ToString());
            }
            //Mostrar el turno
        }
    }
}
