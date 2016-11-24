namespace ClinicaFrba.Cancelar_Atencion
{
    partial class CancelarAtencion
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
            this.T = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Cbx_Tipo = new System.Windows.Forms.ComboBox();
            this.Lbl_Cancelar = new System.Windows.Forms.Label();
            this.Cbx_Cancelar = new System.Windows.Forms.ComboBox();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // T
            // 
            this.T.Location = new System.Drawing.Point(91, 92);
            this.T.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.T.Name = "T";
            this.T.Size = new System.Drawing.Size(119, 20);
            this.T.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Detalle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo";
            // 
            // Cbx_Tipo
            // 
            this.Cbx_Tipo.FormattingEnabled = true;
            this.Cbx_Tipo.Location = new System.Drawing.Point(91, 59);
            this.Cbx_Tipo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Cbx_Tipo.Name = "Cbx_Tipo";
            this.Cbx_Tipo.Size = new System.Drawing.Size(119, 21);
            this.Cbx_Tipo.TabIndex = 3;
            // 
            // Lbl_Cancelar
            // 
            this.Lbl_Cancelar.AutoSize = true;
            this.Lbl_Cancelar.Location = new System.Drawing.Point(29, 27);
            this.Lbl_Cancelar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Cancelar.Name = "Lbl_Cancelar";
            this.Lbl_Cancelar.Size = new System.Drawing.Size(58, 13);
            this.Lbl_Cancelar.TabIndex = 4;
            this.Lbl_Cancelar.Text = "A cancelar";
            // 
            // Cbx_Cancelar
            // 
            this.Cbx_Cancelar.FormattingEnabled = true;
            this.Cbx_Cancelar.Location = new System.Drawing.Point(91, 24);
            this.Cbx_Cancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Cbx_Cancelar.Name = "Cbx_Cancelar";
            this.Cbx_Cancelar.Size = new System.Drawing.Size(119, 21);
            this.Cbx_Cancelar.TabIndex = 5;
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(12, 152);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancelar.TabIndex = 6;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(135, 152);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Guardar.TabIndex = 7;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            // 
            // CancelarAtencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 200);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Cbx_Cancelar);
            this.Controls.Add(this.Lbl_Cancelar);
            this.Controls.Add(this.Cbx_Tipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.T);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CancelarAtencion";
            this.Text = "Cancelación";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox T;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Cbx_Tipo;
        private System.Windows.Forms.Label Lbl_Cancelar;
        private System.Windows.Forms.ComboBox Cbx_Cancelar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Guardar;
    }
}