using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Abm_Afiliado;
using ClinicaFrba.Abm_Profesional;
using ClinicaFrba.Abm_Rol;
using ClinicaFrba.Cancelar_Atencion;
using ClinicaFrba.Compra_Bono;
using ClinicaFrba.Conexiones;
using ClinicaFrba.Pedir_Turno;
using ClinicaFrba.Registrar_Agenta_Medico;
using ClinicaFrba.Registro_Llegada;
using ClinicaFrba.Registro_Resultado;

namespace ClinicaFrba.Menus
{
    public partial class MenuInicial : Form
    {
        private int IdUsuario { get; set; }
        private string RolUsuario { get; set; }

        public MenuInicial(int idUsuario)
        {
            InitializeComponent();
            this.IdUsuario = idUsuario;
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LevantarRol(string rol)
        {
            SqlServer sql = new SqlServer();
            Parametros listaParametros = new Parametros();
            DataTable tabla;
            this.RolUsuario = rol;
            listaParametros.AgregarParametro("Nombre_Rol", rol);
            tabla = sql.EjecutarSp("SP_Get_Funcionalidades_Rol", listaParametros);
            foreach (Control subchild in this.Controls)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    if (subchild.Name == tabla.Rows[i][0].ToString())
                    {
                        subchild.Enabled = tabla.Rows[i][1].Equals(true);
                        subchild.Visible = tabla.Rows[i][1].Equals(true);
                    }
                }
            }
        }

        private void Btn_ABM_Rol_Click(object sender, EventArgs e)
        {
            ABM_Rol rol = new ABM_Rol();
            rol.ShowDialog();
        }

        private void Btn_ABM_Profesional_Click(object sender, EventArgs e)
        {
            ABM_Profesional profesional = new ABM_Profesional();
            profesional.ShowDialog();
        }

        private void Btn_ABM_Afiliado_Click(object sender, EventArgs e)
        {
            ABM_Afiliado afiliado = new ABM_Afiliado();
            afiliado.ShowDialog();
        }

        private void Btn_Comprar_Bono_Click(object sender, EventArgs e)
        {
            CompraBono compraBono = new CompraBono();
            compraBono.ShowDialog();
        }

        private void Btn_Registrar_Agenda_Medica_Click(object sender, EventArgs e)
        {
            AgendaMedica agendaMedica = new AgendaMedica(IdUsuario);
            agendaMedica.ShowDialog();
        }

        private void Btn_Pedir_Turno_Click(object sender, EventArgs e)
        {
            Turno turno = new Turno();
            turno.ShowDialog();
        }

        private void Btn_Registro_Llegada_Click(object sender, EventArgs e)
        {
            RegistroLlegada registroLlegada = new RegistroLlegada();
            registroLlegada.ShowDialog();
        }

        private void Btn_Registro_Resultado_Click(object sender, EventArgs e)
        {
            RegistroResultado registroResultado = new RegistroResultado(IdUsuario);
            registroResultado.ShowDialog();
        }

        private void Btn_Cancelar_Atencion_Click(object sender, EventArgs e)
        {
            CancelarAtencion cancelarAtencion = new CancelarAtencion(IdUsuario);
            cancelarAtencion.ShowDialog();
        }
    }
}
