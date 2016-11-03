using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Conexiones;

namespace ClinicaFrba.Funcionalidades
{
    class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
    class LLenarCombo
    {
        public static ComboBox FillComboBox(ComboBox combo, string procedure)
        {
            SqlServer sql = new SqlServer();

            DataTable tabla = sql.EjecutarSp(procedure);
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                return null;
            }
            combo.DataSource = tabla;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "ID";
            return combo;
        }

        public static ComboBox FillComboBox(ComboBox combo, string procedure, int param1)
        {
            Parametros lista1 = new Parametros();
            SqlServer sql = new SqlServer();

            //nombre y valor
            lista1.AgregarParametro("idUsuario", param1.ToString());

            DataTable tabla = sql.EjecutarSp(procedure, lista1);
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                return null;
            }
            combo.DataSource = tabla;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "ID_Rol";
            return combo;
        }

        public static int SetSelect(ComboBox combo, string value)
        {
            ComboBoxItem item = null;
            DataRowView row = null;
            for (int i = 0; i < combo.Items.Count; i++)
            {
                row = (DataRowView)combo.Items[i];
                if (row["ID"].ToString() == value)
                    return i;
            }
            return 0;
        }
    }
}
