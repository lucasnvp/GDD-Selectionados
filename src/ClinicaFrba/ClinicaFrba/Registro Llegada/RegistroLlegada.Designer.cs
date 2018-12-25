namespace ClinicaFrba.Registro_Llegada
{
    partial class RegistroLlegada
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CBX_Especialidades = new System.Windows.Forms.ComboBox();
            this.Txt_Profesional = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Lbx_Profesional = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Lbx_Turno = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Txt_Afiliado = new System.Windows.Forms.TextBox();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Registrar = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Cbx_BonoAfiliado = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CBX_Especialidades
            // 
            this.CBX_Especialidades.FormattingEnabled = true;
            this.CBX_Especialidades.Location = new System.Drawing.Point(153, 41);
            this.CBX_Especialidades.Margin = new System.Windows.Forms.Padding(2);
            this.CBX_Especialidades.Name = "CBX_Especialidades";
            this.CBX_Especialidades.Size = new System.Drawing.Size(167, 21);
            this.CBX_Especialidades.TabIndex = 0;
            // 
            // Txt_Profesional
            // 
            this.Txt_Profesional.Location = new System.Drawing.Point(7, 42);
            this.Txt_Profesional.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_Profesional.Name = "Txt_Profesional";
            this.Txt_Profesional.Size = new System.Drawing.Size(124, 20);
            this.Txt_Profesional.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Apellido del Profesional";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Especialidad";
            // 
            // Lbx_Profesional
            // 
            this.Lbx_Profesional.FormattingEnabled = true;
            this.Lbx_Profesional.Location = new System.Drawing.Point(19, 105);
            this.Lbx_Profesional.Margin = new System.Windows.Forms.Padding(2);
            this.Lbx_Profesional.Name = "Lbx_Profesional";
            this.Lbx_Profesional.Size = new System.Drawing.Size(124, 121);
            this.Lbx_Profesional.TabIndex = 4;
            this.Lbx_Profesional.SelectedIndexChanged += new System.EventHandler(this.Lbx_Profesional_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Profesionales";
            // 
            // Lbx_Turno
            // 
            this.Lbx_Turno.FormattingEnabled = true;
            this.Lbx_Turno.Location = new System.Drawing.Point(164, 105);
            this.Lbx_Turno.Margin = new System.Windows.Forms.Padding(2);
            this.Lbx_Turno.Name = "Lbx_Turno";
            this.Lbx_Turno.Size = new System.Drawing.Size(124, 329);
            this.Lbx_Turno.TabIndex = 6;
            this.Lbx_Turno.SelectedIndexChanged += new System.EventHandler(this.Lbx_Turno_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Turnos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(308, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nro Afiliado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 149);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Bonos de afiliado";
            // 
            // Txt_Afiliado
            // 
            this.Txt_Afiliado.Location = new System.Drawing.Point(304, 105);
            this.Txt_Afiliado.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_Afiliado.Name = "Txt_Afiliado";
            this.Txt_Afiliado.Size = new System.Drawing.Size(130, 20);
            this.Txt_Afiliado.TabIndex = 11;
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(359, 411);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancelar.TabIndex = 14;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Registrar
            // 
            this.Btn_Registrar.Location = new System.Drawing.Point(362, 203);
            this.Btn_Registrar.Name = "Btn_Registrar";
            this.Btn_Registrar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Registrar.TabIndex = 15;
            this.Btn_Registrar.Text = "Registrar";
            this.Btn_Registrar.UseVisualStyleBackColor = true;
            this.Btn_Registrar.Click += new System.EventHandler(this.Btn_Registrar_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(341, 41);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Buscar.TabIndex = 16;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Btn_Buscar);
            this.groupBox1.Controls.Add(this.CBX_Especialidades);
            this.groupBox1.Controls.Add(this.Txt_Profesional);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 73);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda de Profesional";
            // 
            // Cbx_BonoAfiliado
            // 
            this.Cbx_BonoAfiliado.FormattingEnabled = true;
            this.Cbx_BonoAfiliado.Location = new System.Drawing.Point(304, 165);
            this.Cbx_BonoAfiliado.Name = "Cbx_BonoAfiliado";
            this.Cbx_BonoAfiliado.Size = new System.Drawing.Size(130, 21);
            this.Cbx_BonoAfiliado.TabIndex = 18;
            // 
            // RegistroLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 444);
            this.Controls.Add(this.Cbx_BonoAfiliado);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Registrar);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Txt_Afiliado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Lbx_Turno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Lbx_Profesional);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RegistroLlegada";
            this.Text = "Registro llegada";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBX_Especialidades;
        private System.Windows.Forms.TextBox Txt_Profesional;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox Lbx_Profesional;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox Lbx_Turno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Txt_Afiliado;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Registrar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Cbx_BonoAfiliado;
    }
}