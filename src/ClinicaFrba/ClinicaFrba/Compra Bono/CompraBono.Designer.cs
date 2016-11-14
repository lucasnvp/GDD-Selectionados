namespace ClinicaFrba.Compra_Bono
{
    partial class CompraBono
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
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_TotalAPagar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_NroAfiliado = new System.Windows.Forms.TextBox();
            this.NUD_Cantidad = new System.Windows.Forms.NumericUpDown();
            this.BTN_Comprar = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.LBL_ValorBono = new System.Windows.Forms.Label();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Cantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cantidad de bonos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total a pagar";
            // 
            // Txt_TotalAPagar
            // 
            this.Txt_TotalAPagar.Location = new System.Drawing.Point(85, 127);
            this.Txt_TotalAPagar.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_TotalAPagar.Name = "Txt_TotalAPagar";
            this.Txt_TotalAPagar.Size = new System.Drawing.Size(94, 20);
            this.Txt_TotalAPagar.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Número de afiliado";
            // 
            // Txt_NroAfiliado
            // 
            this.Txt_NroAfiliado.Location = new System.Drawing.Point(110, 15);
            this.Txt_NroAfiliado.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_NroAfiliado.Name = "Txt_NroAfiliado";
            this.Txt_NroAfiliado.Size = new System.Drawing.Size(94, 20);
            this.Txt_NroAfiliado.TabIndex = 5;
            // 
            // NUD_Cantidad
            // 
            this.NUD_Cantidad.Location = new System.Drawing.Point(113, 85);
            this.NUD_Cantidad.Name = "NUD_Cantidad";
            this.NUD_Cantidad.Size = new System.Drawing.Size(46, 20);
            this.NUD_Cantidad.TabIndex = 8;
            this.NUD_Cantidad.ValueChanged += new System.EventHandler(this.NUD_Cantidad_ValueChanged);
            // 
            // BTN_Comprar
            // 
            this.BTN_Comprar.Location = new System.Drawing.Point(213, 85);
            this.BTN_Comprar.Name = "BTN_Comprar";
            this.BTN_Comprar.Size = new System.Drawing.Size(75, 23);
            this.BTN_Comprar.TabIndex = 9;
            this.BTN_Comprar.Text = "Comprar";
            this.BTN_Comprar.UseVisualStyleBackColor = true;
            this.BTN_Comprar.Click += new System.EventHandler(this.BTN_Comprar_Click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(213, 124);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancelar.TabIndex = 10;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // LBL_ValorBono
            // 
            this.LBL_ValorBono.AutoSize = true;
            this.LBL_ValorBono.Location = new System.Drawing.Point(12, 52);
            this.LBL_ValorBono.Name = "LBL_ValorBono";
            this.LBL_ValorBono.Size = new System.Drawing.Size(106, 13);
            this.LBL_ValorBono.TabIndex = 11;
            this.LBL_ValorBono.Text = "El valor del bono es: ";
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(213, 15);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Buscar.TabIndex = 12;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // CompraBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 172);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.LBL_ValorBono);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.BTN_Comprar);
            this.Controls.Add(this.NUD_Cantidad);
            this.Controls.Add(this.Txt_NroAfiliado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Txt_TotalAPagar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CompraBono";
            this.Text = "Compra Bono";
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Cantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_TotalAPagar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_NroAfiliado;
        private System.Windows.Forms.NumericUpDown NUD_Cantidad;
        private System.Windows.Forms.Button BTN_Comprar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Label LBL_ValorBono;
        private System.Windows.Forms.Button Btn_Buscar;
    }
}