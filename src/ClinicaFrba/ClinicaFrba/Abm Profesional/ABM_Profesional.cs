﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Profesional
{
    public partial class ABM_Profesional : Form
    {
        public ABM_Profesional()
        {
            InitializeComponent();
        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
