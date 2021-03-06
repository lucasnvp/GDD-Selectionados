﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.DAOs;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ABM_Familiares_Afiliado : Form
    {
        public string IdAfiliado;
        public string NroAfiliado;

        public ABM_Familiares_Afiliado(string idAfiliado)
        {
            InitializeComponent();
            IdAfiliado = idAfiliado;

            DataTable table = new DataTable("Tabla");
            table.Columns.Add("Codigo");
            table.Columns.Add("Descripcion");

            DataRow dr = table.NewRow();
            dr[0] = "M";
            dr[1] = "Masculino";
            table.Rows.Add(dr);

            dr = table.NewRow();
            dr[0] = "F";
            dr[1] = "Femenino";
            table.Rows.Add(dr);

            this.CBX_Sexo.DataSource = table;
            this.CBX_Sexo.ValueMember = "Codigo";
            this.CBX_Sexo.DisplayMember = "Descripcion";
        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ConyugeDatos()
        {
            NroAfiliado = "";
            GBX_Datos.Text = "Datos del Conyuge";
            Btn_Guardar_Conyuge.Visible = true;
            Btn_Guardar_Familiar.Visible = false;

            DataTable table = AfiliadoDAO.SearchConyuge(this.IdAfiliado, "C");
            if (table != null)
            {
                DataRow row = table.Rows[0];
                this.IdAfiliado = row[0].ToString();
                this.NroAfiliado = row[1].ToString();
                
                this.Txt_Nombre.Text = row[2].ToString();
                this.Txt_Nombre.Enabled = false;
                this.Txt_Apellido.Text = row[3].ToString();
                this.Txt_Apellido.Enabled = false;
                this.CBX_TipoDoc.Text = row[4].ToString();
                this.CBX_TipoDoc.Enabled = false;
                this.Txt_Dni.Text = row[5].ToString();
                this.Txt_Dni.Enabled = false;
                this.CBX_Sexo.Text = row[6].ToString();
                this.CBX_Sexo.Enabled = false;
                this.DTP_FechaDeNacimiento.Text = row[7].ToString();
                this.DTP_FechaDeNacimiento.Enabled = false;
                this.Txt_Telefono.Text = row[8].ToString();
                this.Txt_email.Text = row[9].ToString();
            }
        }

        public void FamiliarDatos()
        {
            NroAfiliado = "";
            GBX_Datos.Text = "Datos del familiar a cargo";
            Btn_Guardar_Conyuge.Visible = false;
            Btn_Guardar_Familiar.Visible = true;
        }

        private void Btn_Guardar_Familiar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Se guardaran los datos del Familiar", "Confirmacion Familiar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                //Validar datos
                //Si se modifica el plan hay que ingresarlo al log. 
                AfiliadoDAO.UpdateFamiliarACargo(this.IdAfiliado, this.NroAfiliado, Txt_Nombre.Text, Txt_Apellido.Text,
                    CBX_TipoDoc.Text, Txt_Dni.Text, CBX_Sexo.SelectedValue.ToString(), DTP_FechaDeNacimiento.Value.Date.ToString("yyyy/MM/dd"),
                    Txt_Telefono.Text, Txt_email.Text, "H");

                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void Btn_Guardar_Conyuge_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Se guardaran los datos del conyuge", "Confirmacion Conyuge", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                //Validar datos
                //Si se modifica el plan hay que ingresarlo al log. 
                AfiliadoDAO.UpdateFamiliarACargo(this.IdAfiliado, this.NroAfiliado, Txt_Nombre.Text, Txt_Apellido.Text,
                    CBX_TipoDoc.Text, Txt_Dni.Text, CBX_Sexo.SelectedValue.ToString(), DTP_FechaDeNacimiento.Value.Date.ToString("yyyy/MM/dd"),
                    Txt_Telefono.Text, Txt_email.Text, "C");

                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}
