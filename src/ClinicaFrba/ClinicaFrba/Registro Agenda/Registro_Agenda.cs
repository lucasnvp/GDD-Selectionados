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

namespace ClinicaFrba.Registro_Agenda
{
    public partial class Registrar_Agenda : Form
    {
        public Registrar_Agenda()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
                comboBox1.Enabled = true;
            if (checkBox1.CheckState != CheckState.Checked)
                comboBox1.Enabled = false;
            if (checkBox1.CheckState == CheckState.Checked)
                comboBox2.Enabled = true;
            if (checkBox1.CheckState != CheckState.Checked)
                comboBox2.Enabled = false;
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Checked)
                comboBox3.Enabled = true;
            if (checkBox2.CheckState != CheckState.Checked)
                comboBox3.Enabled = false;
            if (checkBox2.CheckState == CheckState.Checked)
                comboBox4.Enabled = true;
            if (checkBox2.CheckState != CheckState.Checked)
                comboBox4.Enabled = false;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.CheckState == CheckState.Checked)
                comboBox8.Enabled = true;
            if (checkBox6.CheckState != CheckState.Checked)
                comboBox8.Enabled = false;
            if (checkBox6.CheckState == CheckState.Checked)
                comboBox7.Enabled = true;
            if (checkBox6.CheckState != CheckState.Checked)
                comboBox7.Enabled = false;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.CheckState == CheckState.Checked)
                comboBox6.Enabled = true;
            if (checkBox5.CheckState != CheckState.Checked)
                comboBox6.Enabled = false;
            if (checkBox5.CheckState == CheckState.Checked)
                comboBox5.Enabled = true;
            if (checkBox5.CheckState != CheckState.Checked)
                comboBox5.Enabled = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.CheckState == CheckState.Checked)
                comboBox9.Enabled = true;
            if (checkBox4.CheckState != CheckState.Checked)
                comboBox9.Enabled = false;
            if (checkBox4.CheckState == CheckState.Checked)
                comboBox10.Enabled = true;
            if (checkBox4.CheckState != CheckState.Checked)
                comboBox10.Enabled = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.CheckState == CheckState.Checked)
                comboBox11.Enabled = true;
            if (checkBox3.CheckState != CheckState.Checked)
                comboBox11.Enabled = false;
            if (checkBox3.CheckState == CheckState.Checked)
                comboBox12.Enabled = true;
            if (checkBox3.CheckState != CheckState.Checked)
                comboBox12.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void CrearAgenda(int ID_Profesional, DateTime fecha, int hora_desde, int hora_hasta,int ID_Especialidad, CheckedListBox funcionalidades)
        {
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();

            parametros.AgregarParametro("id_profesional", ID_Profesional.ToString());
            parametros.AgregarParametro("fecha", fecha.ToString());
            parametros.AgregarParametro("hora_desde", hora_desde.ToString());
            parametros.AgregarParametro("hora_hasta", hora_hasta.ToString());
            parametros.AgregarParametro("id_especialidad", ID_Especialidad.ToString());
            DataTable tabla = sql.EjecutarSp("SP_Cargar_Dia_Agenda", parametros);

            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
            }
            else if (tabla.Rows.Count > 0)
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[0].ToString());
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
  
    }
}
