namespace GUI
{
    partial class ClientesSimple
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
            this.gbTelelefono = new System.Windows.Forms.GroupBox();
            this.gbNombre = new System.Windows.Forms.GroupBox();
            this.btnNombre = new System.Windows.Forms.Button();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.btnTelefono = new System.Windows.Forms.Button();
            this.dgClientes = new System.Windows.Forms.DataGridView();
            this.btnModificar = new System.Windows.Forms.Button();
            this.gbTelelefono.SuspendLayout();
            this.gbNombre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTelelefono
            // 
            this.gbTelelefono.Controls.Add(this.btnTelefono);
            this.gbTelelefono.Controls.Add(this.textBox1);
            this.gbTelelefono.Controls.Add(this.lblTelefono);
            this.gbTelelefono.Location = new System.Drawing.Point(12, 12);
            this.gbTelelefono.Name = "gbTelelefono";
            this.gbTelelefono.Size = new System.Drawing.Size(231, 128);
            this.gbTelelefono.TabIndex = 0;
            this.gbTelelefono.TabStop = false;
            this.gbTelelefono.Text = "Buscar por número de teléfono:";
            // 
            // gbNombre
            // 
            this.gbNombre.Controls.Add(this.btnNombre);
            this.gbNombre.Controls.Add(this.txtApellido);
            this.gbNombre.Controls.Add(this.txtNombre);
            this.gbNombre.Controls.Add(this.lblApellido);
            this.gbNombre.Controls.Add(this.lblNombre);
            this.gbNombre.Location = new System.Drawing.Point(249, 12);
            this.gbNombre.Name = "gbNombre";
            this.gbNombre.Size = new System.Drawing.Size(231, 128);
            this.gbNombre.TabIndex = 1;
            this.gbNombre.TabStop = false;
            this.gbNombre.Text = "Buscar por nombre:";
            // 
            // btnNombre
            // 
            this.btnNombre.Location = new System.Drawing.Point(150, 99);
            this.btnNombre.Name = "btnNombre";
            this.btnNombre.Size = new System.Drawing.Size(75, 23);
            this.btnNombre.TabIndex = 6;
            this.btnNombre.Text = "Buscar";
            this.btnNombre.UseVisualStyleBackColor = true;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(59, 64);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(103, 20);
            this.txtApellido.TabIndex = 5;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(59, 26);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(103, 20);
            this.txtNombre.TabIndex = 4;
            this.txtNombre.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(6, 67);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 3;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 29);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(59, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(103, 20);
            this.textBox1.TabIndex = 8;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(6, 29);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(47, 13);
            this.lblTelefono.TabIndex = 7;
            this.lblTelefono.Text = "Número:";
            // 
            // btnTelefono
            // 
            this.btnTelefono.Location = new System.Drawing.Point(150, 99);
            this.btnTelefono.Name = "btnTelefono";
            this.btnTelefono.Size = new System.Drawing.Size(75, 23);
            this.btnTelefono.TabIndex = 7;
            this.btnTelefono.Text = "Buscar";
            this.btnTelefono.UseVisualStyleBackColor = true;
            // 
            // dgClientes
            // 
            this.dgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgClientes.Location = new System.Drawing.Point(12, 146);
            this.dgClientes.Name = "dgClientes";
            this.dgClientes.Size = new System.Drawing.Size(649, 362);
            this.dgClientes.TabIndex = 9;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(586, 518);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // ClientesSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 553);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dgClientes);
            this.Controls.Add(this.gbNombre);
            this.Controls.Add(this.gbTelelefono);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ClientesSimple";
            this.Text = "Clientes";
            this.gbTelelefono.ResumeLayout(false);
            this.gbTelelefono.PerformLayout();
            this.gbNombre.ResumeLayout(false);
            this.gbNombre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTelelefono;
        private System.Windows.Forms.GroupBox gbNombre;
        private System.Windows.Forms.Button btnNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Button btnTelefono;
        private System.Windows.Forms.DataGridView dgClientes;
        private System.Windows.Forms.Button btnModificar;
    }
}

