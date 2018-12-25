using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Conexiones
{
    public class Parametro
    {
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public DBNull ValorNull { get; set; }
        public Parametro AgregarParametro(string nombre, string valor)
        {
            this.Nombre = nombre;
            this.Valor = valor;
            return this;
        }

        public Parametro AgregarParametro(string nombre, DBNull valor)
        {
            this.Nombre = nombre;
            this.ValorNull = valor;
            return this;
        }
    }

    public class Parametros
    {
        public List<Parametro> Lista;
        public void AgregarParametro(string nombre, string valor)
        {
            Parametro parametro = new Parametro();
            parametro.AgregarParametro(nombre, valor);
            if (this.Lista == null)
                this.Lista = new List<Parametro>();
            this.Lista.Add(parametro);
        }
        public void AgregarParametro(string nombre, ComboBox combo)
        {
            DataRowView seleccion = (DataRowView)combo.SelectedItem;
            Parametro parametro = new Parametro();

            parametro.AgregarParametro(nombre, seleccion.Row["ID"].ToString());
            if (this.Lista== null)
                this.Lista = new List<Parametro>();
            this.Lista.Add(parametro);
        }

        public void AgregarParametro(string p, DBNull dBNull)
        {
            Parametro parametro = new Parametro();
            parametro.AgregarParametro(p, dBNull);
            if (this.Lista == null)
                this.Lista = new List<Parametro>();
            this.Lista.Add(parametro);
        }
    }
}
