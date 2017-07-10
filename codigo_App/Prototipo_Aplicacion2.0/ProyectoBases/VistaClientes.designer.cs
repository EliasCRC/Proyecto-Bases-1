namespace ProyectoBases
{
    partial class VistaClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaClientes));
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
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.gcSeleccion = new System.Windows.Forms.GroupBox();
            this.rbtnEsporadicos = new System.Windows.Forms.RadioButton();
            this.rbtnFrecuentes = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.btnAgregarHorario = new System.Windows.Forms.Button();
            this.btnEliminarHorario = new System.Windows.Forms.Button();
            this.btnQuitarFrecuente = new System.Windows.Forms.Button();
            this.btnHacerFrec = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnDeuda = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCanceladas = new System.Windows.Forms.Button();
            this.btnAutomaticas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).BeginInit();
            this.gbNombre.SuspendLayout();
            this.gbTelelefono.SuspendLayout();
            this.gcSeleccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModificar
            // 
            resources.ApplyResources(this.btnModificar, "btnModificar");
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dgClientes
            // 
            this.dgClientes.AllowUserToAddRows = false;
            this.dgClientes.AllowUserToDeleteRows = false;
            this.dgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgClientes, "dgClientes");
            this.dgClientes.MultiSelect = false;
            this.dgClientes.Name = "dgClientes";
            this.dgClientes.ReadOnly = true;
            this.dgClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgClientes_CellContentClick);
            // 
            // gbNombre
            // 
            this.gbNombre.Controls.Add(this.btnNombre);
            this.gbNombre.Controls.Add(this.txtApellido);
            this.gbNombre.Controls.Add(this.txtNombre);
            this.gbNombre.Controls.Add(this.lblApellido);
            this.gbNombre.Controls.Add(this.lblNombre);
            resources.ApplyResources(this.gbNombre, "gbNombre");
            this.gbNombre.Name = "gbNombre";
            this.gbNombre.TabStop = false;
            // 
            // btnNombre
            // 
            resources.ApplyResources(this.btnNombre, "btnNombre");
            this.btnNombre.Name = "btnNombre";
            this.btnNombre.UseVisualStyleBackColor = true;
            this.btnNombre.Click += new System.EventHandler(this.btnNombre_Click);
            // 
            // txtApellido
            // 
            resources.ApplyResources(this.txtApellido, "txtApellido");
            this.txtApellido.Name = "txtApellido";
            // 
            // txtNombre
            // 
            resources.ApplyResources(this.txtNombre, "txtNombre");
            this.txtNombre.Name = "txtNombre";
            // 
            // lblApellido
            // 
            resources.ApplyResources(this.lblApellido, "lblApellido");
            this.lblApellido.Name = "lblApellido";
            // 
            // lblNombre
            // 
            resources.ApplyResources(this.lblNombre, "lblNombre");
            this.lblNombre.Name = "lblNombre";
            // 
            // gbTelelefono
            // 
            this.gbTelelefono.Controls.Add(this.btnTelefono);
            this.gbTelelefono.Controls.Add(this.txtTelefono);
            this.gbTelelefono.Controls.Add(this.lblTelefono);
            resources.ApplyResources(this.gbTelelefono, "gbTelelefono");
            this.gbTelelefono.Name = "gbTelelefono";
            this.gbTelelefono.TabStop = false;
            // 
            // btnTelefono
            // 
            resources.ApplyResources(this.btnTelefono, "btnTelefono");
            this.btnTelefono.Name = "btnTelefono";
            this.btnTelefono.UseVisualStyleBackColor = true;
            this.btnTelefono.Click += new System.EventHandler(this.btnTelefono_Click);
            // 
            // txtTelefono
            // 
            resources.ApplyResources(this.txtTelefono, "txtTelefono");
            this.txtTelefono.Name = "txtTelefono";
            // 
            // lblTelefono
            // 
            resources.ApplyResources(this.lblTelefono, "lblTelefono");
            this.lblTelefono.Name = "lblTelefono";
            // 
            // gcSeleccion
            // 
            this.gcSeleccion.Controls.Add(this.rbtnEsporadicos);
            this.gcSeleccion.Controls.Add(this.rbtnFrecuentes);
            this.gcSeleccion.Controls.Add(this.rbtnTodos);
            resources.ApplyResources(this.gcSeleccion, "gcSeleccion");
            this.gcSeleccion.Name = "gcSeleccion";
            this.gcSeleccion.TabStop = false;
            // 
            // rbtnEsporadicos
            // 
            resources.ApplyResources(this.rbtnEsporadicos, "rbtnEsporadicos");
            this.rbtnEsporadicos.Name = "rbtnEsporadicos";
            this.rbtnEsporadicos.TabStop = true;
            this.rbtnEsporadicos.UseVisualStyleBackColor = true;
            this.rbtnEsporadicos.CheckedChanged += new System.EventHandler(this.rbtnEsporadicos_CheckedChanged);
            // 
            // rbtnFrecuentes
            // 
            resources.ApplyResources(this.rbtnFrecuentes, "rbtnFrecuentes");
            this.rbtnFrecuentes.Name = "rbtnFrecuentes";
            this.rbtnFrecuentes.TabStop = true;
            this.rbtnFrecuentes.UseVisualStyleBackColor = true;
            this.rbtnFrecuentes.CheckedChanged += new System.EventHandler(this.rbtnFrecuentes_CheckedChanged);
            // 
            // rbtnTodos
            // 
            resources.ApplyResources(this.rbtnTodos, "rbtnTodos");
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btnAgregarHorario
            // 
            resources.ApplyResources(this.btnAgregarHorario, "btnAgregarHorario");
            this.btnAgregarHorario.Name = "btnAgregarHorario";
            this.btnAgregarHorario.UseVisualStyleBackColor = true;
            this.btnAgregarHorario.Click += new System.EventHandler(this.btnAgregarHorario_Click);
            // 
            // btnEliminarHorario
            // 
            resources.ApplyResources(this.btnEliminarHorario, "btnEliminarHorario");
            this.btnEliminarHorario.Name = "btnEliminarHorario";
            this.btnEliminarHorario.UseVisualStyleBackColor = true;
            this.btnEliminarHorario.Click += new System.EventHandler(this.btnEliminarHorario_Click);
            // 
            // btnQuitarFrecuente
            // 
            resources.ApplyResources(this.btnQuitarFrecuente, "btnQuitarFrecuente");
            this.btnQuitarFrecuente.Name = "btnQuitarFrecuente";
            this.btnQuitarFrecuente.UseVisualStyleBackColor = true;
            this.btnQuitarFrecuente.Click += new System.EventHandler(this.btnQuitarFrecuente_Click);
            // 
            // btnHacerFrec
            // 
            resources.ApplyResources(this.btnHacerFrec, "btnHacerFrec");
            this.btnHacerFrec.Name = "btnHacerFrec";
            this.btnHacerFrec.UseVisualStyleBackColor = true;
            this.btnHacerFrec.Click += new System.EventHandler(this.btnHacerFrec_Click);
            // 
            // btnEliminar
            // 
            resources.ApplyResources(this.btnEliminar, "btnEliminar");
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnDeuda
            // 
            resources.ApplyResources(this.btnDeuda, "btnDeuda");
            this.btnDeuda.Name = "btnDeuda";
            this.btnDeuda.UseVisualStyleBackColor = true;
            this.btnDeuda.Click += new System.EventHandler(this.btnDeuda_Click);
            // 
            // btnAgregar
            // 
            resources.ApplyResources(this.btnAgregar, "btnAgregar");
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCanceladas
            // 
            resources.ApplyResources(this.btnCanceladas, "btnCanceladas");
            this.btnCanceladas.Name = "btnCanceladas";
            this.btnCanceladas.UseVisualStyleBackColor = true;
            this.btnCanceladas.Click += new System.EventHandler(this.btnCanceladas_Click);
            // 
            // btnAutomaticas
            // 
            resources.ApplyResources(this.btnAutomaticas, "btnAutomaticas");
            this.btnAutomaticas.Name = "btnAutomaticas";
            this.btnAutomaticas.UseVisualStyleBackColor = true;
            this.btnAutomaticas.Click += new System.EventHandler(this.btnAutomaticas_Click);
            // 
            // VistaClientes
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAutomaticas);
            this.Controls.Add(this.btnCanceladas);
            this.Controls.Add(this.btnDeuda);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnQuitarFrecuente);
            this.Controls.Add(this.gcSeleccion);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dgClientes);
            this.Controls.Add(this.gbNombre);
            this.Controls.Add(this.gbTelelefono);
            this.Controls.Add(this.btnEliminarHorario);
            this.Controls.Add(this.btnAgregarHorario);
            this.Controls.Add(this.btnHacerFrec);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VistaClientes";
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
        private System.Windows.Forms.TextBox txtTelefono;
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
        private System.Windows.Forms.Button btnDeuda;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCanceladas;
        private System.Windows.Forms.Button btnAutomaticas;
    }
}