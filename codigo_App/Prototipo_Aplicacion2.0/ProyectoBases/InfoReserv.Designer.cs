namespace ProyectoBases
{
    partial class InfoReserv
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_texto1 = new System.Windows.Forms.Label();
            this.label_momento = new System.Windows.Forms.Label();
            this.button_ini = new System.Windows.Forms.Button();
            this.button_fin = new System.Windows.Forms.Button();
            this.button_agpart = new System.Windows.Forms.Button();
            this.button_qpart = new System.Windows.Forms.Button();
            this.button_canc = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.button_volver = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_texto1
            // 
            this.label_texto1.AutoSize = true;
            this.label_texto1.Location = new System.Drawing.Point(23, 31);
            this.label_texto1.Name = "label_texto1";
            this.label_texto1.Size = new System.Drawing.Size(132, 16);
            this.label_texto1.TabIndex = 0;
            this.label_texto1.Text = "Reservación del día:";
            // 
            // label_momento
            // 
            this.label_momento.AutoSize = true;
            this.label_momento.Location = new System.Drawing.Point(165, 31);
            this.label_momento.Name = "label_momento";
            this.label_momento.Size = new System.Drawing.Size(169, 16);
            this.label_momento.TabIndex = 1;
            this.label_momento.Text = "AAAA-MM-DD 00:00:00.000";
            // 
            // button_ini
            // 
            this.button_ini.Location = new System.Drawing.Point(38, 274);
            this.button_ini.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_ini.Name = "button_ini";
            this.button_ini.Size = new System.Drawing.Size(96, 40);
            this.button_ini.TabIndex = 2;
            this.button_ini.Text = "Iniciar Reservación";
            this.button_ini.UseVisualStyleBackColor = true;
            this.button_ini.Click += new System.EventHandler(this.button_ini_Click);
            // 
            // button_fin
            // 
            this.button_fin.Location = new System.Drawing.Point(150, 274);
            this.button_fin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_fin.Name = "button_fin";
            this.button_fin.Size = new System.Drawing.Size(94, 40);
            this.button_fin.TabIndex = 3;
            this.button_fin.Text = "Finalizar Reservación";
            this.button_fin.UseVisualStyleBackColor = true;
            this.button_fin.Click += new System.EventHandler(this.button_fin_Click);
            // 
            // button_agpart
            // 
            this.button_agpart.Location = new System.Drawing.Point(262, 274);
            this.button_agpart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_agpart.Name = "button_agpart";
            this.button_agpart.Size = new System.Drawing.Size(82, 40);
            this.button_agpart.TabIndex = 4;
            this.button_agpart.Text = "Agregar Participante";
            this.button_agpart.UseVisualStyleBackColor = true;
            this.button_agpart.Click += new System.EventHandler(this.button_agpart_Click);
            // 
            // button_qpart
            // 
            this.button_qpart.Location = new System.Drawing.Point(375, 274);
            this.button_qpart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_qpart.Name = "button_qpart";
            this.button_qpart.Size = new System.Drawing.Size(82, 40);
            this.button_qpart.TabIndex = 6;
            this.button_qpart.Text = "Quitar Participante";
            this.button_qpart.UseVisualStyleBackColor = true;
            this.button_qpart.Click += new System.EventHandler(this.button_qpart_Click);
            // 
            // button_canc
            // 
            this.button_canc.Location = new System.Drawing.Point(488, 274);
            this.button_canc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_canc.Name = "button_canc";
            this.button_canc.Size = new System.Drawing.Size(94, 40);
            this.button_canc.TabIndex = 8;
            this.button_canc.Text = "Cancelar Reservación";
            this.button_canc.UseVisualStyleBackColor = true;
            this.button_canc.Click += new System.EventHandler(this.button_canc_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(26, 97);
            this.grid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.Size = new System.Drawing.Size(532, 104);
            this.grid.TabIndex = 9;
            // 
            // button_volver
            // 
            this.button_volver.Location = new System.Drawing.Point(501, 27);
            this.button_volver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(57, 24);
            this.button_volver.TabIndex = 10;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grid);
            this.groupBox1.Controls.Add(this.button_volver);
            this.groupBox1.Controls.Add(this.label_texto1);
            this.groupBox1.Controls.Add(this.label_momento);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 241);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // InfoReserv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 341);
            this.Controls.Add(this.button_canc);
            this.Controls.Add(this.button_qpart);
            this.Controls.Add(this.button_agpart);
            this.Controls.Add(this.button_fin);
            this.Controls.Add(this.button_ini);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InfoReserv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Información de Reservación";
            this.Load += new System.EventHandler(this.InfoReservacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_texto1;
        private System.Windows.Forms.Label label_momento;
        private System.Windows.Forms.Button button_ini;
        private System.Windows.Forms.Button button_fin;
        private System.Windows.Forms.Button button_agpart;
        private System.Windows.Forms.Button button_qpart;
        private System.Windows.Forms.Button button_canc;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

