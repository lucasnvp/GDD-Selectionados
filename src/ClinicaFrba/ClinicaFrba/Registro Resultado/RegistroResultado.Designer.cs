namespace ClinicaFrba.Registro_Resultado
{
    partial class RegistroResultado
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
            this.CKB_Atendido = new System.Windows.Forms.CheckBox();
            this.DTP_FechaRealizado = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Sintomas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_Diagnostico = new System.Windows.Forms.TextBox();
            this.DGV_EnEspera = new System.Windows.Forms.DataGridView();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_EnEspera)).BeginInit();
            this.SuspendLayout();
            // 
            // CKB_Atendido
            // 
            this.CKB_Atendido.AutoSize = true;
            this.CKB_Atendido.Location = new System.Drawing.Point(325, 74);
            this.CKB_Atendido.Margin = new System.Windows.Forms.Padding(2);
            this.CKB_Atendido.Name = "CKB_Atendido";
            this.CKB_Atendido.Size = new System.Drawing.Size(113, 17);
            this.CKB_Atendido.TabIndex = 0;
            this.CKB_Atendido.Text = "Atención realizada";
            this.CKB_Atendido.UseVisualStyleBackColor = true;
            // 
            // DTP_FechaRealizado
            // 
            this.DTP_FechaRealizado.Location = new System.Drawing.Point(325, 31);
            this.DTP_FechaRealizado.Margin = new System.Windows.Forms.Padding(2);
            this.DTP_FechaRealizado.Name = "DTP_FechaRealizado";
            this.DTP_FechaRealizado.Size = new System.Drawing.Size(151, 20);
            this.DTP_FechaRealizado.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha de realización";
            // 
            // Txt_Sintomas
            // 
            this.Txt_Sintomas.Location = new System.Drawing.Point(325, 130);
            this.Txt_Sintomas.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_Sintomas.Name = "Txt_Sintomas";
            this.Txt_Sintomas.Size = new System.Drawing.Size(151, 20);
            this.Txt_Sintomas.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Síntomas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 170);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Diagnóstico";
            // 
            // Txt_Diagnostico
            // 
            this.Txt_Diagnostico.Location = new System.Drawing.Point(325, 186);
            this.Txt_Diagnostico.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_Diagnostico.Name = "Txt_Diagnostico";
            this.Txt_Diagnostico.Size = new System.Drawing.Size(151, 20);
            this.Txt_Diagnostico.TabIndex = 6;
            // 
            // DGV_EnEspera
            // 
            this.DGV_EnEspera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_EnEspera.Location = new System.Drawing.Point(12, 12);
            this.DGV_EnEspera.Name = "DGV_EnEspera";
            this.DGV_EnEspera.Size = new System.Drawing.Size(285, 332);
            this.DGV_EnEspera.TabIndex = 9;
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(325, 321);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancelar.TabIndex = 10;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(406, 321);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Guardar.TabIndex = 11;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // RegistroResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 369);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.DGV_EnEspera);
            this.Controls.Add(this.Txt_Diagnostico);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_Sintomas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTP_FechaRealizado);
            this.Controls.Add(this.CKB_Atendido);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RegistroResultado";
            this.Text = "Registro resultado de atención";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_EnEspera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CKB_Atendido;
        private System.Windows.Forms.DateTimePicker DTP_FechaRealizado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_Sintomas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_Diagnostico;
        private System.Windows.Forms.DataGridView DGV_EnEspera;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Guardar;
    }
}