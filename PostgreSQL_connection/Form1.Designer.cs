namespace PostgreSQL_connection
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnDesconectar = new System.Windows.Forms.Button();
            this.txtNombrePersona = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPaisPersona = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNitPersona = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.dgvConsulta = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreConsulta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPaisConsulta = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEdadPersona = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(19, 473);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(154, 47);
            this.btnConectar.TabIndex = 0;
            this.btnConectar.Text = "CONECTAR";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.Location = new System.Drawing.Point(179, 473);
            this.btnDesconectar.Name = "btnDesconectar";
            this.btnDesconectar.Size = new System.Drawing.Size(154, 47);
            this.btnDesconectar.TabIndex = 1;
            this.btnDesconectar.Text = "DESCONECTAR";
            this.btnDesconectar.UseVisualStyleBackColor = true;
            this.btnDesconectar.Click += new System.EventHandler(this.btnDesconectar_Click);
            // 
            // txtNombrePersona
            // 
            this.txtNombrePersona.Location = new System.Drawing.Point(19, 55);
            this.txtNombrePersona.Name = "txtNombrePersona";
            this.txtNombrePersona.Size = new System.Drawing.Size(128, 26);
            this.txtNombrePersona.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "NOMBRE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "PAÍS:";
            // 
            // txtPaisPersona
            // 
            this.txtPaisPersona.Location = new System.Drawing.Point(323, 55);
            this.txtPaisPersona.Name = "txtPaisPersona";
            this.txtPaisPersona.Size = new System.Drawing.Size(128, 26);
            this.txtPaisPersona.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(474, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "NIT:";
            // 
            // txtNitPersona
            // 
            this.txtNitPersona.Location = new System.Drawing.Point(478, 55);
            this.txtNitPersona.Name = "txtNitPersona";
            this.txtNitPersona.Size = new System.Drawing.Size(128, 26);
            this.txtNitPersona.TabIndex = 6;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(639, 45);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(235, 47);
            this.btnRegistrar.TabIndex = 8;
            this.btnRegistrar.Text = "REGISTRAR";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // dgvConsulta
            // 
            this.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsulta.Location = new System.Drawing.Point(19, 106);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.RowHeadersWidth = 62;
            this.dgvConsulta.RowTemplate.Height = 28;
            this.dgvConsulta.Size = new System.Drawing.Size(587, 346);
            this.dgvConsulta.TabIndex = 9;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(639, 124);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(235, 47);
            this.btnActualizar.TabIndex = 10;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(639, 202);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(235, 47);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(639, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "NOMBRE:";
            // 
            // txtNombreConsulta
            // 
            this.txtNombreConsulta.Location = new System.Drawing.Point(639, 313);
            this.txtNombreConsulta.Name = "txtNombreConsulta";
            this.txtNombreConsulta.Size = new System.Drawing.Size(235, 26);
            this.txtNombreConsulta.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(639, 371);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "PAÍS:";
            // 
            // txtPaisConsulta
            // 
            this.txtPaisConsulta.Location = new System.Drawing.Point(639, 397);
            this.txtPaisConsulta.Name = "txtPaisConsulta";
            this.txtPaisConsulta.Size = new System.Drawing.Size(235, 26);
            this.txtPaisConsulta.TabIndex = 14;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(639, 473);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(235, 47);
            this.btnConsultar.TabIndex = 17;
            this.btnConsultar.Text = "CONSULTAR";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(170, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "EDAD:";
            // 
            // txtEdadPersona
            // 
            this.txtEdadPersona.Location = new System.Drawing.Point(170, 55);
            this.txtEdadPersona.Name = "txtEdadPersona";
            this.txtEdadPersona.Size = new System.Drawing.Size(128, 26);
            this.txtEdadPersona.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 542);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEdadPersona);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPaisConsulta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNombreConsulta);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dgvConsulta);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNitPersona);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPaisPersona);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombrePersona);
            this.Controls.Add(this.btnDesconectar);
            this.Controls.Add(this.btnConectar);
            this.Name = "Form1";
            this.Text = "CONEXIÓN A POSTGRESQL";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnDesconectar;
        private System.Windows.Forms.TextBox txtNombrePersona;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPaisPersona;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNitPersona;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DataGridView dgvConsulta;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombreConsulta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPaisConsulta;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEdadPersona;
    }
}

