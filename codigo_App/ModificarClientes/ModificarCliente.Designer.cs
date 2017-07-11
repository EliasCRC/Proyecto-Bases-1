namespace GUI
{
    partial class ModificarCliente
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
            this.btnModificar = new System.Windows.Forms.Button();
            this.dgClientes = new System.Windows.Forms.DataGridView();
            this.gbNombre = new System.Windows.Forms.GroupBox();
            this.btnNombre = new System.Windows.Forms.Button();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.gbTelelefono = new System.Windows.Forms.GroupBox();
            this.btnTelefono = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.gcSeleccion = new System.Windows.Forms.GroupBox();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnFrecuentes = new System.Windows.Forms.RadioButton();
            this.rbtnEsporadicos = new System.Windows.Forms.RadioButton();
            this.btnAgregarHorario = new System.Windows.Forms.Button();
            this.btnEliminarHorario = new System.Windows.Forms.Button();
            this.btnQuitarFrecuente = new System.Windows.Forms.Button();
            this.btnHacerFrec = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).BeginInit();
            this.gbNombre.SuspendLayout();
            this.gbTelelefono.SuspendLayout();
            this.gcSeleccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(585, 515);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // dgClientes
            // 
            this.dgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgClientes.Location = new System.Drawing.Point(11, 143);
            this.dgClientes.Name = "dgClientes";
            this.dgClientes.Size = new System.Drawing.Size(649, 362);
            this.dgClientes.TabIndex = 13;
            this.dgClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgClientes_CellContentClick);
            // 
            // gbNombre
            // 
            this.gbNombre.Controls.Add(this.btnNombre);
            this.gbNombre.Controls.Add(this.txtApellido);
            this.gbNombre.Controls.Add(this.txtNombre);
            this.gbNombre.Controls.Add(this.lblApellido);
            this.gbNombre.Controls.Add(this.lblNombre);
            this.gbNombre.Location = new System.Drawing.Point(433, 9);
            this.gbNombre.Name = "gbNombre";
            this.gbNombre.Size = new System.Drawing.Size(231, 128);
            this.gbNombre.TabIndex = 11;
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
            // gbTelelefono
            // 
            this.gbTelelefono.Controls.Add(this.btnTelefono);
            this.gbTelelefono.Controls.Add(this.textBox1);
            this.gbTelelefono.Controls.Add(this.lblTelefono);
            this.gbTelelefono.Location = new System.Drawing.Point(196, 9);
            this.gbTelelefono.Name = "gbTelelefono";
            this.gbTelelefono.Size = new System.Drawing.Size(231, 128);
            this.gbTelelefono.TabIndex = 10;
            this.gbTelelefono.TabStop = false;
            this.gbTelelefono.Text = "Buscar por número de teléfono:";
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
            // gcSeleccion
            // 
            this.gcSeleccion.Controls.Add(this.rbtnEsporadicos);
            this.gcSeleccion.Controls.Add(this.rbtnFrecuentes);
            this.gcSeleccion.Controls.Add(this.rbtnTodos);
            this.gcSeleccion.Location = new System.Drawing.Point(11, 9);
            this.gcSeleccion.Name = "gcSeleccion";
            this.gcSeleccion.Size = new System.Drawing.Size(179, 128);
            this.gcSeleccion.TabIndex = 9;
            this.gcSeleccion.TabStop = false;
            this.gcSeleccion.Text = "Clientes";
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Location = new System.Drawing.Point(6, 29);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 0;
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbtnFrecuentes
            // 
            this.rbtnFrecuentes.AutoSize = true;
            this.rbtnFrecuentes.Location = new System.Drawing.Point(6, 65);
            this.rbtnFrecuentes.Name = "rbtnFrecuentes";
            this.rbtnFrecuentes.Size = new System.Drawing.Size(99, 17);
            this.rbtnFrecuentes.TabIndex = 1;
            this.rbtnFrecuentes.TabStop = true;
            this.rbtnFrecuentes.Text = "Solo frecuentes";
            this.rbtnFrecuentes.UseVisualStyleBackColor = true;
            this.rbtnFrecuentes.CheckedChanged += new System.EventHandler(this.rbtnFrecuentes_CheckedChanged);
            // 
            // rbtnEsporadicos
            // 
            this.rbtnEsporadicos.AutoSize = true;
            this.rbtnEsporadicos.Location = new System.Drawing.Point(6, 99);
            this.rbtnEsporadicos.Name = "rbtnEsporadicos";
            this.rbtnEsporadicos.Size = new System.Drawing.Size(106, 17);
            this.rbtnEsporadicos.TabIndex = 2;
            this.rbtnEsporadicos.TabStop = true;
            this.rbtnEsporadicos.Text = "Solo esporádicos";
            this.rbtnEsporadicos.UseVisualStyleBackColor = true;
            this.rbtnEsporadicos.CheckedChanged += new System.EventHandler(this.rbtnEsporadicos_CheckedChanged);
            // 
            // btnAgregarHorario
            // 
            this.btnAgregarHorario.Location = new System.Drawing.Point(487, 515);
            this.btnAgregarHorario.Name = "btnAgregarHorario";
            this.btnAgregarHorario.Size = new System.Drawing.Size(92, 23);
            this.btnAgregarHorario.TabIndex = 14;
            this.btnAgregarHorario.Text = "Agregar Horario";
            this.btnAgregarHorario.UseVisualStyleBackColor = true;
            // 
            // btnEliminarHorario
            // 
            this.btnEliminarHorario.Location = new System.Drawing.Point(389, 515);
            this.btnEliminarHorario.Name = "btnEliminarHorario";
            this.btnEliminarHorario.Size = new System.Drawing.Size(92, 23);
            this.btnEliminarHorario.TabIndex = 15;
            this.btnEliminarHorario.Text = "Eliminar Horario";
            this.btnEliminarHorario.UseVisualStyleBackColor = true;
            // 
            // btnQuitarFrecuente
            // 
            this.btnQuitarFrecuente.Location = new System.Drawing.Point(232, 515);
            this.btnQuitarFrecuente.Name = "btnQuitarFrecuente";
            this.btnQuitarFrecuente.Size = new System.Drawing.Size(151, 23);
            this.btnQuitarFrecuente.TabIndex = 16;
            this.btnQuitarFrecuente.Text = "Quitar estatus de frecuente";
            this.btnQuitarFrecuente.UseVisualStyleBackColor = true;
            // 
            // btnHacerFrec
            // 
            this.btnHacerFrec.Location = new System.Drawing.Point(477, 515);
            this.btnHacerFrec.Name = "btnHacerFrec";
            this.btnHacerFrec.Size = new System.Drawing.Size(102, 23);
            this.btnHacerFrec.TabIndex = 17;
            this.btnHacerFrec.Text = "Hacer Frecuente";
            this.btnHacerFrec.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(11, 515);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(83, 23);
            this.btnEliminar.TabIndex = 18;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // ModificarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 547);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnHacerFrec);
            this.Controls.Add(this.btnQuitarFrecuente);
            this.Controls.Add(this.btnEliminarHorario);
            this.Controls.Add(this.btnAgregarHorario);
            this.Controls.Add(this.gcSeleccion);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dgClientes);
            this.Controls.Add(this.gbNombre);
            this.Controls.Add(this.gbTelelefono);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ModificarCliente";
            this.Text = "ModificarCliente";
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).EndInit();
            this.gbNombre.ResumeLayout(false);
            this.gbNombre.PerformLayout();
            this.gbTelelefono.ResumeLayout(false);
            this.gbTelelefono.PerformLayout();
            this.gcSeleccion.ResumeLayout(false);
            this.gcSeleccion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridView dgClientes;
        private System.Windows.Forms.GroupBox gbNombre;
        private System.Windows.Forms.Button btnNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox gbTelelefono;
        private System.Windows.Forms.Button btnTelefono;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.GroupBox gcSeleccion;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnEsporadicos;
        private System.Windows.Forms.RadioButton rbtnFrecuentes;
        private System.Windows.Forms.Button btnAgregarHorario;
        private System.Windows.Forms.Button btnEliminarHorario;
        private System.Windows.Forms.Button btnQuitarFrecuente;
        private System.Windows.Forms.Button btnHacerFrec;
        private System.Windows.Forms.Button btnEliminar;
    }
}