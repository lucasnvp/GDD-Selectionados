using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MercadoEnvio.Menu;
using MercadoEnvio.Clases;

namespace MercadoEnvio.Login
{
    public partial class cl_Login : Form
    {
        private int usuario_id { get; set; }
        private string rol { get; set; }
        public cl_Login()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (this.m_validar( ))
            {
                cl_Roles roles = new cl_Roles(usuario_id);
                if (roles.rol_name.Equals("") == true)
                {
                    roles.ShowDialog();
                }
                if (roles.rol_name.Equals("") == false)
                {
                    cl_Menu menu = new cl_Menu(usuario_id);
                    menu.m_rol(roles.rol_name);
                    menu.ShowDialog();
                }
            }
            txt_contrasenia.Clear();
        }
        private bool m_validar( )
        {
            bool resultado = true;
            int intentos = 0;
            int usuario_aux = 0;
            if (txt_usuario.Text.Length == 0 || txt_contrasenia.Text.Length == 0)
            {
                MessageBox.Show("Completar usuario y contraseña");
                return false;
            }

            string hash_db = m_get_hash_db(txt_usuario.Text, out resultado, out intentos, out usuario_aux);
            if (resultado == false)
            {
                MessageBox.Show(hash_db.ToString());
                this.usuario_id = 0;
                return resultado;
            }
            this.usuario_id = usuario_aux;
            if (intentos == 3)
            {
                MessageBox.Show("Usuario inhabilitado");
                return false;
            }
            resultado = cl_Hash.CheckHash(txt_contrasenia.Text,hash_db);
            if (resultado == false)
            {
                intentos += 1;
                this.m_actualizar_intentos( this.usuario_id, intentos);
                if (intentos == 3)
                   MessageBox.Show("Usuario inhabilitado");
                else
                   MessageBox.Show("Completar Usuario válido y contraseña válida"+
                                   "\n" + "Intentos restantes: " + (3-intentos));
                return false;
            }
            intentos = 0;
            this.m_actualizar_intentos(this.usuario_id, 0);
            return resultado;
        }

        private string m_get_hash_db(string usuario, out bool resultado, out int intentos, out int usuario_id )
        {
            string mensaje = "";
            intentos = 0;
            usuario_id = 0;

            cl_Parametros lista1 = new cl_Parametros();
            cl_SQL sql = new cl_SQL();

            //nombre y valor
            lista1.m_add("usuario", usuario);

            DataTable tabla = sql.m_ejecutarSP("sp_get_hash_db", lista1);
            if (tabla.Rows.Count == 0)
            {
                resultado = false;
                mensaje = "Error con la BD";
                intentos = 0;
            }
            else
            {
                if (tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
                {
                    resultado = false;
                    mensaje = "Error con la BD";
                    intentos = 0;
                    return mensaje;

                }
                else
                {
                    resultado = true;
                    usuario_id = int.Parse(tabla.Rows[0].ItemArray[2].ToString());
                    intentos = int.Parse(tabla.Rows[0].ItemArray[3].ToString());
                }
                mensaje = tabla.Rows[0].ItemArray[0].ToString();
          
            }
            return mensaje;
        }
        private void m_actualizar_intentos(int usuario, int intentos)
        {
            cl_Parametros lista1 = new cl_Parametros();
            cl_SQL sql = new cl_SQL();

            //nombre y valor
            lista1.m_add("usuario", usuario.ToString());
            lista1.m_add("intentos", intentos.ToString());
            lista1.m_add("fecha", MercadoEnvio.Properties.Settings.Default.Fecha_Sistema.ToString("yyyy-MM-dd HH:mm:ss"));

            DataTable tabla = sql.m_ejecutarSP("sp_update_intentos", lista1);
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                intentos -= 1;
            }
        }

        private void cl_Login_Load(object sender, EventArgs e)
        {

        }

    }
}
