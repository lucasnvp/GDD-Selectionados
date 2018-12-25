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

namespace ClinicaFrba.Compra_Bono
{
    public partial class CompraBono : Form
    {
        private int _precioBono;
        private string _nroAfiliado;

        public CompraBono()
        {
            InitializeComponent();
            Txt_TotalAPagar.Enabled = false;
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            if (Txt_NroAfiliado.Text.Length == 0)
            {
                MessageBox.Show("Ingresar nro de afiliado para buscar");
            }
            else
            {
                try
                {
                    DataTable table = AfiliadoDAO.SearchBy("", "", Txt_NroAfiliado.Text.Trim(), "");
                    if (table.Rows.Count != 0)
                    {
                        this._nroAfiliado = Txt_NroAfiliado.Text.Trim();
                        string precio = AfiliadoDAO.GetPrecioBono(Txt_NroAfiliado.Text.Trim());
                        this._precioBono = Convert.ToInt32(precio);
                        LBL_ValorBono.Text = "El valor del bono es: " + precio;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        private void BTN_Comprar_Click(object sender, EventArgs e)
        {
            string idAfiliado = _nroAfiliado.Substring(0, _nroAfiliado.Length - 2);
            AfiliadoDAO.ComprarBono(idAfiliado, _nroAfiliado, NUD_Cantidad.Value.ToString());
            MessageBox.Show("La compra se realizo con exito");
            this.Close();
        }

        private void NUD_Cantidad_ValueChanged(object sender, EventArgs e)
        {
            int montoAPagar = _precioBono * Convert.ToInt32(NUD_Cantidad.Value);
            Txt_TotalAPagar.Text = montoAPagar.ToString();
        }
    }
}
