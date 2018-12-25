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

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class CancelarAtencion : Form
    {
        public CancelarAtencion(int idUsuario)
        {
            InitializeComponent();
            var tipoUsuario = GetTipoUsuario(idUsuario);
            if (tipoUsuario == "A")
            {
                var idAfiliado = AfiliadoDAO.GetIdAfiliado(idUsuario.ToString());
                Cbx_Cancelar.DataSource = AfiliadoDAO.GetTurnos(idAfiliado);
                Cbx_Cancelar.DisplayMember = "Fecha";
                Cbx_Cancelar.ValueMember = "Nro_Turno";
            }
        }

        private static string GetTipoUsuario(int idUsuario)
        {
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();
            parametros.AgregarParametro("idUsuario", idUsuario.ToString());
            try
            {
                DataTable table = sql.EjecutarSp("SP_Get_TipoUsuario", parametros);

                if (table.Rows.Count > 0 && table.Rows[0].ItemArray[0].ToString() == "ERROR")
                {
                    MessageBox.Show(table.Rows[0].ItemArray[1].ToString());
                    return null;
                }
                else
                {
                    return table.Rows[0].ItemArray[0].ToString();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
