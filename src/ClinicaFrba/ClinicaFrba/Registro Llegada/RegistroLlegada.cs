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
        }

        private void Lbx_Profesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lbx_Turno.DataSource = ProfesionalDAO.TurnosBy(Lbx_Profesional.SelectedValue.ToString());
        }

        private void Lbx_Turno_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Mostrar el afiliado
            //Cargar los nros de bonos que posee.
        }
    }
}
