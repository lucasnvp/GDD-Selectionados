namespace ClinicaFrba.Abm_Rol
{
    partial class ABM_Rol
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
            this.DGV_Roles = new System.Windows.Forms.DataGridView();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Crear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Lbl_LimpiarCampos = new System.Windows.Forms.LinkLabel();
            this.Cmb_Estado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Clb_Funcionalidades = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_NombreRol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Roles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV_Roles
            // 
            this.DGV_Roles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Roles.Location = new System.Drawing.Point(13, 13);
            this.DGV_Roles.Name = "DGV_Roles";
            this.DGV_Roles.Size = new System.Drawing.Size(321, 410);
            this.DGV_Roles.TabIndex = 0;
            this.DGV_Roles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Roles_CellContentClick);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(13, 429);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Buscar.TabIndex = 1;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(95, 429);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancelar.TabIndex = 2;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Location = new System.Drawing.Point(177, 429);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Modificar.TabIndex = 3;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Crear
            // 
            this.Btn_Crear.Location = new System.Drawing.Point(259, 429);
            this.Btn_Crear.Name = "Btn_Crear";
            this.Btn_Crear.Size = new System.Drawing.Size(75, 23);
            this.Btn_Crear.TabIndex = 4;
            this.Btn_Crear.Text = "Crear";
            this.Btn_Crear.UseVisualStyleBackColor = true;
            this.Btn_Crear.Click += new System.EventHandler(this.Btn_Crear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Lbl_LimpiarCampos);
            this.groupBox1.Controls.Add(this.Cmb_Estado);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Clb_Funcionalidades);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Txt_NombreRol);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(340, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 410);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Complete los campos";
            // 
            // Lbl_LimpiarCampos
            // 
            this.Lbl_LimpiarCampos.AutoSize = true;
            this.Lbl_LimpiarCampos.Location = new System.Drawing.Point(7, 391);
            this.Lbl_LimpiarCampos.Name = "Lbl_LimpiarCampos";
            this.Lbl_LimpiarCampos.Size = new System.Drawing.Size(81, 13);
            this.Lbl_LimpiarCampos.TabIndex = 6;
            this.Lbl_LimpiarCampos.TabStop = true;
            this.Lbl_LimpiarCampos.Text = "Limpiar Campos";
            this.Lbl_LimpiarCampos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LimpiarCampos_LinkClicked);
            // 
            // Cmb_Estado
            // 
            this.Cmb_Estado.FormattingEnabled = true;
            this.Cmb_Estado.Location = new System.Drawing.Point(39, 364);
            this.Cmb_Estado.Name = "Cmb_Estado";
            this.Cmb_Estado.Size = new System.Drawing.Size(209, 21);
            this.Cmb_Estado.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estado";
            // 
            // Clb_Funcionalidades
            // 
            this.Clb_Funcionalidades.FormattingEnabled = true;
            this.Clb_Funcionalidades.Location = new System.Drawing.Point(39, 81);
            this.Clb_Funcionalidades.Name = "Clb_Funcionalidades";
            this.Clb_Funcionalidades.Size = new System.Drawing.Size(209, 259);
            this.Clb_Funcionalidades.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Funcionalidades";
            // 
            // Txt_NombreRol
            // 
            this.Txt_NombreRol.Location = new System.Drawing.Point(36, 37);
            this.Txt_NombreRol.Name = "Txt_NombreRol";
            this.Txt_NombreRol.Size = new System.Drawing.Size(212, 20);
            this.Txt_NombreRol.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del Rol";
            // 
            // ABM_Rol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 464);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Crear);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.DGV_Roles);
            this.Name = "ABM_Rol";
            this.Text = "ABM_Rol";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Roles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Roles;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Crear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel Lbl_LimpiarCampos;
        private System.Windows.Forms.ComboBox Cmb_Estado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox Clb_Funcionalidades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_NombreRol;
        private System.Windows.Forms.Label label1;
    }
}