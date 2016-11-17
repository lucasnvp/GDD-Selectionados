namespace ClinicaFrba.Registrar_Agenta_Medico
{
    partial class AgendaMedica
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
            this.CLB_Lunes = new System.Windows.Forms.CheckedListBox();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.DTP_Fecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.CBX_Especialidad = new System.Windows.Forms.ComboBox();
            this.Lbl_Miercoles = new System.Windows.Forms.Label();
            this.CLB_Jueves = new System.Windows.Forms.CheckedListBox();
            this.CLB_Viernes = new System.Windows.Forms.CheckedListBox();
            this.CLB_Miercoles = new System.Windows.Forms.CheckedListBox();
            this.CLB_Martes = new System.Windows.Forms.CheckedListBox();
            this.Lbl_Lunes = new System.Windows.Forms.Label();
            this.Lbl_Martes = new System.Windows.Forms.Label();
            this.Lbl_Jueves = new System.Windows.Forms.Label();
            this.Lbl_Viernes = new System.Windows.Forms.Label();
            this.Lbl_Sabado = new System.Windows.Forms.Label();
            this.CLB_Sabado = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // CLB_Lunes
            // 
            this.CLB_Lunes.FormattingEnabled = true;
            this.CLB_Lunes.Location = new System.Drawing.Point(12, 87);
            this.CLB_Lunes.Name = "CLB_Lunes";
            this.CLB_Lunes.Size = new System.Drawing.Size(87, 394);
            this.CLB_Lunes.TabIndex = 0;
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(489, 12);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Guardar.TabIndex = 1;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Location = new System.Drawing.Point(489, 458);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(75, 23);
            this.Btn_Salir.TabIndex = 2;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // DTP_Fecha
            // 
            this.DTP_Fecha.Location = new System.Drawing.Point(12, 12);
            this.DTP_Fecha.MaxDate = new System.DateTime(2045, 12, 31, 0, 0, 0, 0);
            this.DTP_Fecha.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.DTP_Fecha.Name = "DTP_Fecha";
            this.DTP_Fecha.Size = new System.Drawing.Size(222, 20);
            this.DTP_Fecha.TabIndex = 3;
            this.DTP_Fecha.ValueChanged += new System.EventHandler(this.DTP_Fecha_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Especialidad";
            // 
            // CBX_Especialidad
            // 
            this.CBX_Especialidad.FormattingEnabled = true;
            this.CBX_Especialidad.Location = new System.Drawing.Point(320, 12);
            this.CBX_Especialidad.Name = "CBX_Especialidad";
            this.CBX_Especialidad.Size = new System.Drawing.Size(151, 21);
            this.CBX_Especialidad.TabIndex = 5;
            // 
            // Lbl_Miercoles
            // 
            this.Lbl_Miercoles.AutoSize = true;
            this.Lbl_Miercoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Miercoles.Location = new System.Drawing.Point(198, 64);
            this.Lbl_Miercoles.Name = "Lbl_Miercoles";
            this.Lbl_Miercoles.Size = new System.Drawing.Size(76, 20);
            this.Lbl_Miercoles.TabIndex = 6;
            this.Lbl_Miercoles.Text = "Miercoles";
            // 
            // CLB_Jueves
            // 
            this.CLB_Jueves.FormattingEnabled = true;
            this.CLB_Jueves.Location = new System.Drawing.Point(291, 87);
            this.CLB_Jueves.Name = "CLB_Jueves";
            this.CLB_Jueves.Size = new System.Drawing.Size(87, 394);
            this.CLB_Jueves.TabIndex = 7;
            // 
            // CLB_Viernes
            // 
            this.CLB_Viernes.FormattingEnabled = true;
            this.CLB_Viernes.Location = new System.Drawing.Point(384, 87);
            this.CLB_Viernes.Name = "CLB_Viernes";
            this.CLB_Viernes.Size = new System.Drawing.Size(87, 394);
            this.CLB_Viernes.TabIndex = 8;
            // 
            // CLB_Miercoles
            // 
            this.CLB_Miercoles.FormattingEnabled = true;
            this.CLB_Miercoles.Location = new System.Drawing.Point(198, 87);
            this.CLB_Miercoles.Name = "CLB_Miercoles";
            this.CLB_Miercoles.Size = new System.Drawing.Size(87, 394);
            this.CLB_Miercoles.TabIndex = 9;
            // 
            // CLB_Martes
            // 
            this.CLB_Martes.FormattingEnabled = true;
            this.CLB_Martes.Location = new System.Drawing.Point(105, 87);
            this.CLB_Martes.Name = "CLB_Martes";
            this.CLB_Martes.Size = new System.Drawing.Size(87, 394);
            this.CLB_Martes.TabIndex = 10;
            // 
            // Lbl_Lunes
            // 
            this.Lbl_Lunes.AutoSize = true;
            this.Lbl_Lunes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Lunes.Location = new System.Drawing.Point(12, 64);
            this.Lbl_Lunes.Name = "Lbl_Lunes";
            this.Lbl_Lunes.Size = new System.Drawing.Size(53, 20);
            this.Lbl_Lunes.TabIndex = 11;
            this.Lbl_Lunes.Text = "Lunes";
            // 
            // Lbl_Martes
            // 
            this.Lbl_Martes.AutoSize = true;
            this.Lbl_Martes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Martes.Location = new System.Drawing.Point(105, 64);
            this.Lbl_Martes.Name = "Lbl_Martes";
            this.Lbl_Martes.Size = new System.Drawing.Size(58, 20);
            this.Lbl_Martes.TabIndex = 12;
            this.Lbl_Martes.Text = "Martes";
            // 
            // Lbl_Jueves
            // 
            this.Lbl_Jueves.AutoSize = true;
            this.Lbl_Jueves.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Jueves.Location = new System.Drawing.Point(291, 64);
            this.Lbl_Jueves.Name = "Lbl_Jueves";
            this.Lbl_Jueves.Size = new System.Drawing.Size(59, 20);
            this.Lbl_Jueves.TabIndex = 13;
            this.Lbl_Jueves.Text = "Jueves";
            // 
            // Lbl_Viernes
            // 
            this.Lbl_Viernes.AutoSize = true;
            this.Lbl_Viernes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Viernes.Location = new System.Drawing.Point(384, 64);
            this.Lbl_Viernes.Name = "Lbl_Viernes";
            this.Lbl_Viernes.Size = new System.Drawing.Size(63, 20);
            this.Lbl_Viernes.TabIndex = 14;
            this.Lbl_Viernes.Text = "Viernes";
            // 
            // Lbl_Sabado
            // 
            this.Lbl_Sabado.AutoSize = true;
            this.Lbl_Sabado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Sabado.Location = new System.Drawing.Point(477, 64);
            this.Lbl_Sabado.Name = "Lbl_Sabado";
            this.Lbl_Sabado.Size = new System.Drawing.Size(65, 20);
            this.Lbl_Sabado.TabIndex = 16;
            this.Lbl_Sabado.Text = "Sabado";
            // 
            // CLB_Sabado
            // 
            this.CLB_Sabado.FormattingEnabled = true;
            this.CLB_Sabado.Location = new System.Drawing.Point(477, 87);
            this.CLB_Sabado.Name = "CLB_Sabado";
            this.CLB_Sabado.Size = new System.Drawing.Size(87, 154);
            this.CLB_Sabado.TabIndex = 15;
            // 
            // AgendaMedica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 506);
            this.Controls.Add(this.Lbl_Sabado);
            this.Controls.Add(this.CLB_Sabado);
            this.Controls.Add(this.Lbl_Viernes);
            this.Controls.Add(this.Lbl_Jueves);
            this.Controls.Add(this.Lbl_Martes);
            this.Controls.Add(this.Lbl_Lunes);
            this.Controls.Add(this.CLB_Martes);
            this.Controls.Add(this.CLB_Miercoles);
            this.Controls.Add(this.CLB_Viernes);
            this.Controls.Add(this.CLB_Jueves);
            this.Controls.Add(this.Lbl_Miercoles);
            this.Controls.Add(this.CBX_Especialidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTP_Fecha);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.CLB_Lunes);
            this.Name = "AgendaMedica";
            this.Text = "Agenda Medica";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CLB_Lunes;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.DateTimePicker DTP_Fecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBX_Especialidad;
        private System.Windows.Forms.Label Lbl_Miercoles;
        private System.Windows.Forms.CheckedListBox CLB_Jueves;
        private System.Windows.Forms.CheckedListBox CLB_Viernes;
        private System.Windows.Forms.CheckedListBox CLB_Miercoles;
        private System.Windows.Forms.CheckedListBox CLB_Martes;
        private System.Windows.Forms.Label Lbl_Lunes;
        private System.Windows.Forms.Label Lbl_Martes;
        private System.Windows.Forms.Label Lbl_Jueves;
        private System.Windows.Forms.Label Lbl_Viernes;
        private System.Windows.Forms.Label Lbl_Sabado;
        private System.Windows.Forms.CheckedListBox CLB_Sabado;
    }
}