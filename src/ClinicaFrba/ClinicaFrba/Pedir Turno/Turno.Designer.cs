namespace ClinicaFrba.Pedir_Turno
{
    partial class Turno
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
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_NroAfiliado = new System.Windows.Forms.TextBox();
            this.Cbx_Especialidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Cbx_Profesional = new System.Windows.Forms.ComboBox();
            this.Dtp_Turno = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Cbx_Horario = new System.Windows.Forms.ComboBox();
            this.Btn_GenerarTurno = new System.Windows.Forms.Button();
            this.Btn_Cerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número de afiliado";
            // 
            // Txt_NroAfiliado
            // 
            this.Txt_NroAfiliado.Location = new System.Drawing.Point(29, 35);
            this.Txt_NroAfiliado.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_NroAfiliado.Name = "Txt_NroAfiliado";
            this.Txt_NroAfiliado.Size = new System.Drawing.Size(94, 20);
            this.Txt_NroAfiliado.TabIndex = 1;
            // 
            // Cbx_Especialidad
            // 
            this.Cbx_Especialidad.FormattingEnabled = true;
            this.Cbx_Especialidad.Location = new System.Drawing.Point(29, 91);
            this.Cbx_Especialidad.Margin = new System.Windows.Forms.Padding(2);
            this.Cbx_Especialidad.Name = "Cbx_Especialidad";
            this.Cbx_Especialidad.Size = new System.Drawing.Size(217, 21);
            this.Cbx_Especialidad.TabIndex = 2;
            this.Cbx_Especialidad.SelectedIndexChanged += new System.EventHandler(this.Cbx_Especialidad_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Especialidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Profesional";
            // 
            // Cbx_Profesional
            // 
            this.Cbx_Profesional.FormattingEnabled = true;
            this.Cbx_Profesional.Location = new System.Drawing.Point(29, 138);
            this.Cbx_Profesional.Margin = new System.Windows.Forms.Padding(2);
            this.Cbx_Profesional.Name = "Cbx_Profesional";
            this.Cbx_Profesional.Size = new System.Drawing.Size(151, 21);
            this.Cbx_Profesional.TabIndex = 5;
            // 
            // Dtp_Turno
            // 
            this.Dtp_Turno.Location = new System.Drawing.Point(29, 184);
            this.Dtp_Turno.Margin = new System.Windows.Forms.Padding(2);
            this.Dtp_Turno.Name = "Dtp_Turno";
            this.Dtp_Turno.Size = new System.Drawing.Size(151, 20);
            this.Dtp_Turno.TabIndex = 6;
            this.Dtp_Turno.ValueChanged += new System.EventHandler(this.Dtp_Turno_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 168);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha de turno";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 213);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Horario";
            // 
            // Cbx_Horario
            // 
            this.Cbx_Horario.FormattingEnabled = true;
            this.Cbx_Horario.Location = new System.Drawing.Point(29, 229);
            this.Cbx_Horario.Margin = new System.Windows.Forms.Padding(2);
            this.Cbx_Horario.Name = "Cbx_Horario";
            this.Cbx_Horario.Size = new System.Drawing.Size(94, 21);
            this.Cbx_Horario.TabIndex = 9;
            // 
            // Btn_GenerarTurno
            // 
            this.Btn_GenerarTurno.Location = new System.Drawing.Point(30, 269);
            this.Btn_GenerarTurno.Name = "Btn_GenerarTurno";
            this.Btn_GenerarTurno.Size = new System.Drawing.Size(107, 23);
            this.Btn_GenerarTurno.TabIndex = 12;
            this.Btn_GenerarTurno.Text = "Generar Turno";
            this.Btn_GenerarTurno.UseVisualStyleBackColor = true;
            this.Btn_GenerarTurno.Click += new System.EventHandler(this.Btn_GenerarTurno_Click);
            // 
            // Btn_Cerrar
            // 
            this.Btn_Cerrar.Location = new System.Drawing.Point(174, 269);
            this.Btn_Cerrar.Name = "Btn_Cerrar";
            this.Btn_Cerrar.Size = new System.Drawing.Size(72, 23);
            this.Btn_Cerrar.TabIndex = 13;
            this.Btn_Cerrar.Text = "Cancelar";
            this.Btn_Cerrar.UseVisualStyleBackColor = true;
            this.Btn_Cerrar.Click += new System.EventHandler(this.Btn_Cerrar_Click);
            // 
            // Turno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 321);
            this.Controls.Add(this.Btn_Cerrar);
            this.Controls.Add(this.Btn_GenerarTurno);
            this.Controls.Add(this.Cbx_Horario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Dtp_Turno);
            this.Controls.Add(this.Cbx_Profesional);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cbx_Especialidad);
            this.Controls.Add(this.Txt_NroAfiliado);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Turno";
            this.Text = "Pedir turno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_NroAfiliado;
        private System.Windows.Forms.ComboBox Cbx_Especialidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Cbx_Profesional;
        private System.Windows.Forms.DateTimePicker Dtp_Turno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Cbx_Horario;
        private System.Windows.Forms.Button Btn_GenerarTurno;
        private System.Windows.Forms.Button Btn_Cerrar;
    }
}