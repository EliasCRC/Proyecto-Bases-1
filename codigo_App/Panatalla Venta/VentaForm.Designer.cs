namespace ProyectoBases
{
    partial class VentaForm
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
            this.cbAgregar = new System.Windows.Forms.ComboBox();
            this.dataGVentas = new System.Windows.Forms.DataGridView();
            this.lblProducto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bttnEliminar = new System.Windows.Forms.Button();
            this.bttnCancelar = new System.Windows.Forms.Button();
            this.gbVenta = new System.Windows.Forms.GroupBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.bttnIngresar = new System.Windows.Forms.Button();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.bttnTerminar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVentas)).BeginInit();
            this.gbVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // cbAgregar
            // 
            this.cbAgregar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAgregar.FormattingEnabled = true;
            this.cbAgregar.Location = new System.Drawing.Point(55, 33);
            this.cbAgregar.Name = "cbAgregar";
            this.cbAgregar.Size = new System.Drawing.Size(121, 21);
            this.cbAgregar.Sorted = true;
            this.cbAgregar.TabIndex = 0;
            // 
            // dataGVentas
            // 
            this.dataGVentas.AllowUserToAddRows = false;
            this.dataGVentas.AllowUserToDeleteRows = false;
            this.dataGVentas.AllowUserToResizeColumns = false;
            this.dataGVentas.AllowUserToResizeRows = false;
            this.dataGVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVentas.Location = new System.Drawing.Point(16, 59);
            this.dataGVentas.MultiSelect = false;
            this.dataGVentas.Name = "dataGVentas";
            this.dataGVentas.ReadOnly = true;
            this.dataGVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGVentas.Size = new System.Drawing.Size(570, 202);
            this.dataGVentas.TabIndex = 2;
            // 
            // lblProducto
            // 
            this.lblProducto.Location = new System.Drawing.Point(52, 13);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(66, 16);
            this.lblProducto.TabIndex = 0;
            this.lblProducto.Text = "Producto:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(394, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            // 
            // bttnEliminar
            // 
            this.bttnEliminar.Location = new System.Drawing.Point(354, 267);
            this.bttnEliminar.Name = "bttnEliminar";
            this.bttnEliminar.Size = new System.Drawing.Size(75, 23);
            this.bttnEliminar.TabIndex = 0;
            this.bttnEliminar.Text = "Eliminar";
            this.bttnEliminar.UseVisualStyleBackColor = true;
            this.bttnEliminar.Click += new System.EventHandler(this.bttnEliminar_Click);
            // 
            // bttnCancelar
            // 
            this.bttnCancelar.Location = new System.Drawing.Point(473, 297);
            this.bttnCancelar.Name = "bttnCancelar";
            this.bttnCancelar.Size = new System.Drawing.Size(75, 23);
            this.bttnCancelar.TabIndex = 0;
            this.bttnCancelar.Text = "Cancelar";
            this.bttnCancelar.UseVisualStyleBackColor = true;
            this.bttnCancelar.Click += new System.EventHandler(this.bttnCancelar_Click);
            // 
            // gbVenta
            // 
            this.gbVenta.Controls.Add(this.txtMonto);
            this.gbVenta.Controls.Add(this.bttnIngresar);
            this.gbVenta.Controls.Add(this.nudCantidad);
            this.gbVenta.Controls.Add(this.lblCantidad);
            this.gbVenta.Controls.Add(this.lblMonto);
            this.gbVenta.Controls.Add(this.bttnTerminar);
            this.gbVenta.Controls.Add(this.dataGVentas);
            this.gbVenta.Controls.Add(this.bttnCancelar);
            this.gbVenta.Controls.Add(this.cbAgregar);
            this.gbVenta.Controls.Add(this.bttnEliminar);
            this.gbVenta.Controls.Add(this.label2);
            this.gbVenta.Controls.Add(this.lblProducto);
            this.gbVenta.Location = new System.Drawing.Point(12, 40);
            this.gbVenta.Name = "gbVenta";
            this.gbVenta.Size = new System.Drawing.Size(607, 325);
            this.gbVenta.TabIndex = 3;
            this.gbVenta.TabStop = false;
            this.gbVenta.Text = "Venta";
            this.gbVenta.Enter += new System.EventHandler(this.gbVenta_Enter);
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(115, 282);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 9;
            // 
            // bttnIngresar
            // 
            this.bttnIngresar.Location = new System.Drawing.Point(473, 30);
            this.bttnIngresar.Name = "bttnIngresar";
            this.bttnIngresar.Size = new System.Drawing.Size(75, 23);
            this.bttnIngresar.TabIndex = 8;
            this.bttnIngresar.Text = "Ingresar";
            this.bttnIngresar.UseVisualStyleBackColor = true;
            this.bttnIngresar.Click += new System.EventHandler(this.bttnIngresar_Click);
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(248, 34);
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 20);
            this.nudCantidad.TabIndex = 7;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(245, 13);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(49, 13);
            this.lblCantidad.TabIndex = 6;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(31, 285);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(78, 13);
            this.lblMonto.TabIndex = 5;
            this.lblMonto.Text = "Monto Total: ₡";
            // 
            // bttnTerminar
            // 
            this.bttnTerminar.Location = new System.Drawing.Point(473, 267);
            this.bttnTerminar.Name = "bttnTerminar";
            this.bttnTerminar.Size = new System.Drawing.Size(75, 23);
            this.bttnTerminar.TabIndex = 4;
            this.bttnTerminar.Text = "Terminar";
            this.bttnTerminar.UseVisualStyleBackColor = true;
            this.bttnTerminar.Click += new System.EventHandler(this.bttnTerminar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.SystemColors.Menu;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTitulo.Location = new System.Drawing.Point(271, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(74, 29);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "Venta";
            // 
            // VentaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 373);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gbVenta);
            this.Name = "VentaForm";
            this.Text = "Venta";
            this.Load += new System.EventHandler(this.FVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGVentas)).EndInit();
            this.gbVenta.ResumeLayout(false);
            this.gbVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAgregar;
        private System.Windows.Forms.DataGridView dataGVentas;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bttnEliminar;
        private System.Windows.Forms.Button bttnCancelar;
        private System.Windows.Forms.GroupBox gbVenta;
        private System.Windows.Forms.Button bttnTerminar;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button bttnIngresar;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblTitulo;
    }
}