using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Listados
{
    public partial class ListadosEstadisticos : Form
    {
        public ListadosEstadisticos()
        {
            InitializeComponent();
            setSemestres();
        }
        private void setSemestres()
        {
            DateTime fechaInicio = new DateTime(2015, 01, 01);
            DateTime fechaFinal = DateTime.Now;
            DateTime fechaPaso = fechaInicio;
            while (!(fechaPaso.Year > fechaFinal.Year))
            {
                comboBox1.Items.Add(fechaPaso);
                fechaPaso = fechaPaso.AddMonths(6);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new EspecialidadesMasConsultas(Convert.ToDateTime(comboBox1.SelectedItem)).Show();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            new ProfesionalesMasConsultados(Convert.ToDateTime(comboBox1.SelectedItem)).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ProfesionalesMenosHoras(Convert.ToDateTime(comboBox1.SelectedItem)).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new AfiliadosMasBonos(Convert.ToDateTime(comboBox1.SelectedItem)).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new EspecialidadesMasBonos(Convert.ToDateTime(comboBox1.SelectedItem)).Show();
        }

    }
}
