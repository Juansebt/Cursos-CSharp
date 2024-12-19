namespace MongoDB_connection
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
            this.dgvConsulta = new System.Windows.Forms.DataGridView();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txtNombreConsulta = new System.Windows.Forms.TextBox();
            this.txtPaisConsulta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(721, 583);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(247, 59);
            this.btnConectar.TabIndex = 0;
            this.btnConectar.Text = "CONECTAR";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.Location = new System.Drawing.Point(984, 583);
            this.btnDesconectar.Name = "btnDesconectar";
            this.btnDesconectar.Size = new System.Drawing.Size(247, 59);
            this.btnDesconectar.TabIndex = 1;
            this.btnDesconectar.Text = "DESCONECTAR";
            this.btnDesconectar.UseVisualStyleBackColor = true;
            this.btnDesconectar.Click += new System.EventHandler(this.btnDesconectar_Click);
            // 
            // dgvConsulta
            // 
            this.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsulta.Location = new System.Drawing.Point(23, 22);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.RowHeadersWidth = 62;
            this.dgvConsulta.RowTemplate.Height = 28;
            this.dgvConsulta.Size = new System.Drawing.Size(673, 620);
            this.dgvConsulta.TabIndex = 2;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(721, 495);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(510, 59);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "CONSULTAR";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtNombreConsulta
            // 
            this.txtNombreConsulta.Location = new System.Drawing.Point(721, 443);
            this.txtNombreConsulta.Name = "txtNombreConsulta";
            this.txtNombreConsulta.Size = new System.Drawing.Size(247, 26);
            this.txtNombreConsulta.TabIndex = 4;
            // 
            // txtPaisConsulta
            // 
            this.txtPaisConsulta.Location = new System.Drawing.Point(984, 443);
            this.txtPaisConsulta.Name = "txtPaisConsulta";
            this.txtPaisConsulta.Size = new System.Drawing.Size(247, 26);
            this.txtPaisConsulta.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(721, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "NOMBRE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(980, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "PAÍS:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 664);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPaisConsulta);
            this.Controls.Add(this.txtNombreConsulta);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.dgvConsulta);
            this.Controls.Add(this.btnDesconectar);
            this.Controls.Add(this.btnConectar);
            this.Name = "Form1";
            this.Text = "CONEXIÓN A MONGO DATA BASE";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnDesconectar;
        private System.Windows.Forms.DataGridView dgvConsulta;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txtNombreConsulta;
        private System.Windows.Forms.TextBox txtPaisConsulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

