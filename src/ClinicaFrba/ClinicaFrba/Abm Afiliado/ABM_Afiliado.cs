using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.DAOs;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ABM_Afiliado : Form
    {
        private DataTable _resultadoDataTable;

        public ABM_Afiliado()
        {
            InitializeComponent();
        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            if (Txt_NroAfiliado.Text.Length == 0 && Txt_Apellido.Text.Length == 0 && Txt_Dni.Text.Length == 0 &&
                Txt_Nombre.Text.Length == 0)
            {
                MessageBox.Show("Ingresar algun criterio de busqueda");
            }
            else if (Txt_NroAfiliado.Text.Equals("") || Txt_Apellido.Text.Equals("") || Txt_Dni.Text.Equals("") ||
                     Txt_Nombre.Text.Equals(""))
            {
                //Busqueda de usuario
                _resultadoDataTable = new DataTable();
                try
                {
                    _resultadoDataTable = AfiliadoDAO.SearchBy(Txt_Nombre.Text.Trim(), Txt_Apellido.Text.Trim(),
                        Txt_NroAfiliado.Text.Trim(), Txt_Dni.Text.Trim());

                    if (_resultadoDataTable.Rows.Count != 0)
                    {
                        //Muestro los resultados
                        ResultadosDeBusqueda resultadosDeBusqueda = new ResultadosDeBusqueda(_resultadoDataTable);
                        resultadosDeBusqueda.Show();
                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un solo parametro de busqueda");
            }


        }
    }
}
