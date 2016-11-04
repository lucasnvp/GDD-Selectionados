using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.DGV_Resultados.Columns[0].HeaderText = "Nro_Afiliado";
            this.DGV_Resultados.Columns[0].HeaderText = "Nombre";
            this.DGV_Resultados.Columns[0].HeaderText = "Apellido";
            this.DGV_Resultados.Columns[0].HeaderText = "Tipo_Dni";
            this.DGV_Resultados.Columns[0].HeaderText = "Nro_Doc";
            this.DGV_Resultados.Columns[0].HeaderText = "Direccion";
            this.DGV_Resultados.Columns[0].HeaderText = "Telefono";
            this.DGV_Resultados.Columns[0].HeaderText = "Mail";
            this.DGV_Resultados.Columns[0].HeaderText = "Fecha_Nac";
            this.DGV_Resultados.Columns[0].HeaderText = "Sexo";
            this.DGV_Resultados.Columns[0].HeaderText = "Estado_Civil";
            this.DGV_Resultados.Columns[0].HeaderText = "Descipcion_Plan";
            this.DGV_Resultados.Columns[0].HeaderText = "Nro_Consultas";
            
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
