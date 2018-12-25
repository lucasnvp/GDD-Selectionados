using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.DAOs;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ResultadosDeBusqueda : Form
    {
        public ResultadosDeBusqueda(DataTable resulTable)
        {
            InitializeComponent();
            this.DGV_Resultados.DataSource = resulTable;
            this.DGV_Resultados.Columns[0].Visible = false;
            this.DGV_Resultados.Columns[0].HeaderText = "ID_Afiliado";
            this.DGV_Resultados.Columns[1].HeaderText = "Nro_Afiliado";
            this.DGV_Resultados.Columns[2].HeaderText = "Nombre";
            this.DGV_Resultados.Columns[3].HeaderText = "Apellido";
            this.DGV_Resultados.Columns[4].HeaderText = "Tipo_Dni";
            this.DGV_Resultados.Columns[5].HeaderText = "Nro_Doc";
            this.DGV_Resultados.Columns[6].HeaderText = "Direccion";
            this.DGV_Resultados.Columns[7].HeaderText = "Telefono";
            this.DGV_Resultados.Columns[8].HeaderText = "Mail";
            this.DGV_Resultados.Columns[9].HeaderText = "Fecha_Nac";
            this.DGV_Resultados.Columns[10].HeaderText = "Sexo";
            this.DGV_Resultados.Columns[11].HeaderText = "Estado_Civil";
            this.DGV_Resultados.Columns[12].HeaderText = "Descipcion_Plan";
            this.DGV_Resultados.Columns[13].HeaderText = "Nro_Consultas";
            
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridRow = DGV_Resultados.CurrentRow;
            if (DGV_Resultados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un Afiliado", "Búsqueda Afiliado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                int fil = dataGridRow.Index;
                AfiliadoDAO.EliminarAfiliado(dataGridRow.Cells[0].Value.ToString());
                DGV_Resultados.Rows.RemoveAt(fil);
            }
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            DataGridViewRow afiliadoRow = DGV_Resultados.CurrentRow;
            if (DGV_Resultados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un Afiliado", "Búsqueda Afiliado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                ABM_Afiliado_Registros abmAfiliadoRegistros = new ABM_Afiliado_Registros();
                abmAfiliadoRegistros.ObtenerDatosAfiliado(this, afiliadoRow);
            }
        }
    }
}
