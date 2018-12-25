using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Conexiones;
using ClinicaFrba.DAOs;

namespace ClinicaFrba.Registro_Llegada
{
    public partial class RegistroLlegada : Form
    {

        public RegistroLlegada()
        {
            InitializeComponent();
            CBX_Especialidades.DataSource = ProfesionalDAO.Especialidades();
            CBX_Especialidades.DisplayMember = "Descripcion";
            CBX_Especialidades.ValueMember = "ID_Especialidad";
            Txt_Afiliado.Enabled = false;
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            Lbx_Profesional.DataSource = ProfesionalDAO.ProfesionalByApellidoAndEspecialidad(Txt_Profesional.Text,
                CBX_Especialidades.SelectedValue.ToString());
            Lbx_Profesional.DisplayMember = "Apellido";
            Lbx_Profesional.ValueMember = "Profesional.ID_Profesional";
        }

        private void Btn_Registrar_Click(object sender, EventArgs e)
        {
            //Registrar
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();
            parametros.AgregarParametro("nroTurno", Lbx_Turno.SelectedValue.ToString());
            parametros.AgregarParametro("nroBono", Cbx_BonoAfiliado.SelectedValue.ToString());
            try
            {
                sql.EjecutarSp("SP_Insert_Consulta", parametros);
                MessageBox.Show("Paciente ingresado");
                this.Close();
            }
            catch (Exception errorException)
            {
                Console.WriteLine(errorException);
            }
        }

        private void Lbx_Profesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lbx_Turno.DataSource = ProfesionalDAO.TurnosBy(Lbx_Profesional.SelectedValue.ToString());
            Lbx_Turno.DisplayMember = "Fecha";
            Lbx_Turno.ValueMember = "Nro_Turno";
        }

        private void Lbx_Turno_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Mostrar el afiliado
            Txt_Afiliado.Text = AfiliadoDAO.GetNroAfiliadoByTurno(Lbx_Turno.SelectedValue.ToString());
            //Cargar los nros de bonos que posee.
            Cbx_BonoAfiliado.DataSource = AfiliadoDAO.GetNrosBonosDisponibles(AfiliadoDAO.GetIdByNro(Txt_Afiliado.Text));
            Cbx_BonoAfiliado.DisplayMember = "Nro_Bono";
            Cbx_BonoAfiliado.ValueMember = "Nro_Bono";
        }
    }
}
