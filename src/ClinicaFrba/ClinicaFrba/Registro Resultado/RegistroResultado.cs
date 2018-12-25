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

namespace ClinicaFrba.Registro_Resultado
{
    public partial class RegistroResultado : Form
    {
        public RegistroResultado(int idUsuario)
        {
            InitializeComponent();
            var idProfesional = ProfesionalDAO.GetIdProfesional(idUsuario.ToString());
            DGV_EnEspera.DataSource = ProfesionalDAO.GetRegistroResultado(idProfesional);
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {

            DataGridViewRow consultaRow = DGV_EnEspera.CurrentRow;
            if (DGV_EnEspera.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una consulta", "Búsqueda consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                SqlServer sql = new SqlServer();
                Parametros parametros = new Parametros();
                parametros.AgregarParametro("nroConsulta", consultaRow.Cells[0].Value.ToString().Trim());
                parametros.AgregarParametro("enfermedad", Txt_Diagnostico.Text);
                parametros.AgregarParametro("sintomas", Txt_Sintomas.Text);
                parametros.AgregarParametro("fechaConsulta", DTP_FechaRealizado.Value.Date.ToString("yyyy-MM-dd HH:mm:ss"));

                try
                {
                    DataTable table = sql.EjecutarSp("SP_Update_FinalizarConsulta", parametros);

                    if (table.Rows.Count > 0 && table.Rows[0].ItemArray[0].ToString() == "ERROR")
                    {
                        MessageBox.Show(table.Rows[0].ItemArray[1].ToString());
                    }
                    else
                    {
                        MessageBox.Show("La Consulta se a guardado con exito");
                        Close();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }
    }
}
