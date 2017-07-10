namespace ProyectoBases
{
    partial class VistaMenuPrincipal
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
            this.btnCrearReserv = new System.Windows.Forms.Button();
            this.btnCrearVenta = new System.Windows.Forms.Button();
            this.btnHReserv = new System.Windows.Forms.Button();
            this.btnConsultarCliente = new System.Windows.Forms.Button();
            this.btnHVentas = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.dataGridResumen = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBtnVenta = new System.Windows.Forms.RadioButton();
            this.radioBtnReto = new System.Windows.Forms.RadioButton();
            this.radioBtnEquipoCompleto = new System.Windows.Forms.RadioButton();
            this.radioBtnTodos = new System.Windows.Forms.RadioButton();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.lblBienv = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResumen)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menú Principal";
            // 
            // btnCrearReserv
            // 
            this.btnCrearReserv.Location = new System.Drawing.Point(-2, 53);
            this.btnCrearReserv.Name = "btnCrearReserv";
            this.btnCrearReserv.Size = new System.Drawing.Size(169, 35);
            this.btnCrearReserv.TabIndex = 1;
            this.btnCrearReserv.Text = "Crear Reservacion";
            this.btnCrearReserv.UseVisualStyleBackColor = true;
            // 
            // btnCrearVenta
            // 
            this.btnCrearVenta.Location = new System.Drawing.Point(-2, 87);
            this.btnCrearVenta.Name = "btnCrearVenta";
            this.btnCrearVenta.Size = new System.Drawing.Size(169, 35);
            this.btnCrearVenta.TabIndex = 2;
            this.btnCrearVenta.Text = "Crear una Venta";
            this.btnCrearVenta.UseVisualStyleBackColor = true;
            this.btnCrearVenta.Click += new System.EventHandler(this.btnCrearVenta_Click);
            // 
            // btnHReserv
            // 
            this.btnHReserv.Location = new System.Drawing.Point(-2, 155);
            this.btnHReserv.Name = "btnHReserv";
            this.btnHReserv.Size = new System.Drawing.Size(169, 35);
            this.btnHReserv.TabIndex = 4;
            this.btnHReserv.Text = "Historial Reservación";
            this.btnHReserv.UseVisualStyleBackColor = true;
            this.btnHReserv.Click += new System.EventHandler(this.btnHReserv_Click);
            // 
            // btnConsultarCliente
            // 
            this.btnConsultarCliente.Location = new System.Drawing.Point(-2, 121);
            this.btnConsultarCliente.Name = "btnConsultarCliente";
            this.btnConsultarCliente.Size = new System.Drawing.Size(169, 35);
            this.btnConsultarCliente.TabIndex = 3;
            this.btnConsultarCliente.Text = "Consultar Cliente";
            this.btnConsultarCliente.UseVisualStyleBackColor = true;
            this.btnConsultarCliente.Click += new System.EventHandler(this.btnConsultarCliente_Click);
            // 
            // btnHVentas
            // 
            this.btnHVentas.Location = new System.Drawing.Point(-2, 189);
            this.btnHVentas.Name = "btnHVentas";
            this.btnHVentas.Size = new System.Drawing.Size(169, 35);
            this.btnHVentas.TabIndex = 6;
            this.btnHVentas.Text = "Historial Ventas";
            this.btnHVentas.UseVisualStyleBackColor = true;
            this.btnHVentas.Click += new System.EventHandler(this.btnHVentas_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(-2, 399);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(169, 35);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Enabled = false;
            this.btnAdmin.Location = new System.Drawing.Point(-2, 223);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(169, 35);
            this.btnAdmin.TabIndex = 8;
            this.btnAdmin.Text = "Ir a Administrador";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // dataGridResumen
            // 
            this.dataGridResumen.AllowUserToAddRows = false;
            this.dataGridResumen.AllowUserToDeleteRows = false;
            this.dataGridResumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridResumen.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResumen.Location = new System.Drawing.Point(193, 87);
            this.dataGridResumen.Name = "dataGridResumen";
            this.dataGridResumen.ReadOnly = true;
            this.dataGridResumen.Size = new System.Drawing.Size(760, 347);
            this.dataGridResumen.TabIndex = 9;
            this.dataGridResumen.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridResumen_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.radioBtnVenta);
            this.groupBox1.Controls.Add(this.radioBtnReto);
            this.groupBox1.Controls.Add(this.radioBtnEquipoCompleto);
            this.groupBox1.Controls.Add(this.radioBtnTodos);
            this.groupBox1.Controls.Add(this.datePicker);
            this.groupBox1.Location = new System.Drawing.Point(193, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 97);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actividades de la fecha elegida";
            // 
            // radioBtnVenta
            // 
            this.radioBtnVenta.AutoSize = true;
            this.radioBtnVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnVenta.Location = new System.Drawing.Point(255, 21);
            this.radioBtnVenta.Name = "radioBtnVenta";
            this.radioBtnVenta.Size = new System.Drawing.Size(58, 17);
            this.radioBtnVenta.TabIndex = 14;
            this.radioBtnVenta.Text = "Ventas";
            this.radioBtnVenta.UseVisualStyleBackColor = true;
            this.radioBtnVenta.CheckedChanged += new System.EventHandler(this.radioBtnVenta_CheckedChanged);
            // 
            // radioBtnReto
            // 
            this.radioBtnReto.AutoSize = true;
            this.radioBtnReto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnReto.Location = new System.Drawing.Point(192, 21);
            this.radioBtnReto.Name = "radioBtnReto";
            this.radioBtnReto.Size = new System.Drawing.Size(53, 17);
            this.radioBtnReto.TabIndex = 13;
            this.radioBtnReto.Text = "Retos";
            this.radioBtnReto.UseVisualStyleBackColor = true;
            this.radioBtnReto.CheckedChanged += new System.EventHandler(this.radioBtnReto_CheckedChanged);
            // 
            // radioBtnEquipoCompleto
            // 
            this.radioBtnEquipoCompleto.AutoSize = true;
            this.radioBtnEquipoCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnEquipoCompleto.Location = new System.Drawing.Point(114, 21);
            this.radioBtnEquipoCompleto.Name = "radioBtnEquipoCompleto";
            this.radioBtnEquipoCompleto.Size = new System.Drawing.Size(69, 17);
            this.radioBtnEquipoCompleto.TabIndex = 12;
            this.radioBtnEquipoCompleto.Text = "Normales";
            this.radioBtnEquipoCompleto.UseVisualStyleBackColor = true;
            this.radioBtnEquipoCompleto.CheckedChanged += new System.EventHandler(this.radioBtnEquipoCompleto_CheckedChanged);
            // 
            // radioBtnTodos
            // 
            this.radioBtnTodos.AutoSize = true;
            this.radioBtnTodos.Checked = true;
            this.radioBtnTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnTodos.Location = new System.Drawing.Point(15, 21);
            this.radioBtnTodos.Name = "radioBtnTodos";
            this.radioBtnTodos.Size = new System.Drawing.Size(95, 17);
            this.radioBtnTodos.TabIndex = 11;
            this.radioBtnTodos.TabStop = true;
            this.radioBtnTodos.Text = "Todas Reserv.";
            this.radioBtnTodos.UseVisualStyleBackColor = true;
            this.radioBtnTodos.CheckedChanged += new System.EventHandler(this.radioBtnTodos_CheckedChanged);
            // 
            // datePicker
            // 
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(372, 21);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(131, 20);
            this.datePicker.TabIndex = 0;
            this.datePicker.ValueChanged += new System.EventHandler(this.dateTimeReserv_ValueChanged);
            // 
            // lblBienv
            // 
            this.lblBienv.AutoSize = true;
            this.lblBienv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienv.Location = new System.Drawing.Point(14, 274);
            this.lblBienv.Name = "lblBienv";
            this.lblBienv.Size = new System.Drawing.Size(90, 16);
            this.lblBienv.TabIndex = 11;
            this.lblBienv.Text = "Bienvenido:";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.Location = new System.Drawing.Point(69, 299);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(20, 16);
            this.lblNombreUsuario.TabIndex = 12;
            this.lblNombreUsuario.Text = "---";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(694, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(60, 23);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // VistaMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 446);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.lblBienv);
            this.Controls.Add(this.dataGridResumen);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnHVentas);
            this.Controls.Add(this.btnHReserv);
            this.Controls.Add(this.btnConsultarCliente);
            this.Controls.Add(this.btnCrearVenta);
            this.Controls.Add(this.btnCrearReserv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VistaMenuPrincipal";
            this.Text = "Menú Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VistaMenuPrincipal_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResumen)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCrearReserv;
        private System.Windows.Forms.Button btnCrearVenta;
        private System.Windows.Forms.Button btnHReserv;
        private System.Windows.Forms.Button btnConsultarCliente;
        private System.Windows.Forms.Button btnHVentas;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.DataGridView dataGridResumen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtnReto;
        private System.Windows.Forms.RadioButton radioBtnEquipoCompleto;
        private System.Windows.Forms.RadioButton radioBtnTodos;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.RadioButton radioBtnVenta;
        private System.Windows.Forms.Label lblBienv;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Button btnRefresh;
    }
}