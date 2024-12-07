namespace DataBase_connection
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
            this.btnConsulta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombrePersona = new System.Windows.Forms.TextBox();
            this.txtEdadPersona = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPaisPersona = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNitPersona = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnConectar.Location = new System.Drawing.Point(40, 534);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(133, 68);
            this.btnConectar.TabIndex = 0;
            this.btnConectar.Text = "CONECTAR";
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDesconectar.ForeColor = System.Drawing.Color.White;
            this.btnDesconectar.Location = new System.Drawing.Point(189, 534);
            this.btnDesconectar.Name = "btnDesconectar";
            this.btnDesconectar.Size = new System.Drawing.Size(150, 68);
            this.btnDesconectar.TabIndex = 2;
            this.btnDesconectar.Text = "DESCONECTAR";
            this.btnDesconectar.UseVisualStyleBackColor = false;
            this.btnDesconectar.Click += new System.EventHandler(this.btnDesconectar_Click);
            // 
            // dgvConsulta
            // 
            this.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsulta.Location = new System.Drawing.Point(392, 33);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.RowHeadersWidth = 62;
            this.dgvConsulta.RowTemplate.Height = 28;
            this.dgvConsulta.Size = new System.Drawing.Size(771, 384);
            this.dgvConsulta.TabIndex = 3;
            // 
            // btnConsulta
            // 
            this.btnConsulta.BackColor = System.Drawing.Color.White;
            this.btnConsulta.Location = new System.Drawing.Point(40, 444);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(299, 68);
            this.btnConsulta.TabIndex = 4;
            this.btnConsulta.Text = "CONSULTAR";
            this.btnConsulta.UseVisualStyleBackColor = false;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 471);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "FILTRAR POR PAIS:";
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(559, 465);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(604, 26);
            this.txtPais.TabIndex = 6;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(36, 349);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(303, 68);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "NOMBRE:";
            // 
            // txtNombrePersona
            // 
            this.txtNombrePersona.Location = new System.Drawing.Point(36, 56);
            this.txtNombrePersona.Name = "txtNombrePersona";
            this.txtNombrePersona.Size = new System.Drawing.Size(303, 26);
            this.txtNombrePersona.TabIndex = 9;
            // 
            // txtEdadPersona
            // 
            this.txtEdadPersona.Location = new System.Drawing.Point(36, 125);
            this.txtEdadPersona.Name = "txtEdadPersona";
            this.txtEdadPersona.Size = new System.Drawing.Size(303, 26);
            this.txtEdadPersona.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "EDAD:";
            // 
            // txtPaisPersona
            // 
            this.txtPaisPersona.Location = new System.Drawing.Point(36, 203);
            this.txtPaisPersona.Name = "txtPaisPersona";
            this.txtPaisPersona.Size = new System.Drawing.Size(303, 26);
            this.txtPaisPersona.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "PAIS:";
            // 
            // txtNitPersona
            // 
            this.txtNitPersona.Location = new System.Drawing.Point(36, 279);
            this.txtNitPersona.Name = "txtNitPersona";
            this.txtNitPersona.Size = new System.Drawing.Size(303, 26);
            this.txtNitPersona.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "NIT:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(397, 534);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(379, 68);
            this.btnActualizar.TabIndex = 16;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(810, 534);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(353, 68);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 628);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.txtNitPersona);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPaisPersona);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEdadPersona);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombrePersona);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtPais);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.dgvConsulta);
            this.Controls.Add(this.btnDesconectar);
            this.Controls.Add(this.btnConectar);
            this.Name = "Form1";
            this.Text = "CONEXIÓN A BASE DE DATOS";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnDesconectar;
        private System.Windows.Forms.DataGridView dgvConsulta;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombrePersona;
        private System.Windows.Forms.TextBox txtEdadPersona;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPaisPersona;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNitPersona;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
    }
}

