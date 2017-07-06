namespace WindowsFormsApplication1
{
    partial class FVenta
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
            this.bttnTerminar = new System.Windows.Forms.Button();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.bttnIngresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVentas)).BeginInit();
            this.gbVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // cbAgregar
            // 
            this.cbAgregar.FormattingEnabled = true;
            this.cbAgregar.Location = new System.Drawing.Point(55, 33);
            this.cbAgregar.Name = "cbAgregar";
            this.cbAgregar.Size = new System.Drawing.Size(121, 21);
            this.cbAgregar.Sorted = true;
            this.cbAgregar.TabIndex = 0;
            // 
            // dataGVentas
            // 
            this.dataGVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVentas.Location = new System.Drawing.Point(16, 59);
            this.dataGVentas.Name = "dataGVentas";
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
            // 
            // bttnCancelar
            // 
            this.bttnCancelar.Location = new System.Drawing.Point(473, 297);
            this.bttnCancelar.Name = "bttnCancelar";
            this.bttnCancelar.Size = new System.Drawing.Size(75, 23);
            this.bttnCancelar.TabIndex = 0;
            this.bttnCancelar.Text = "Cancelar";
            this.bttnCancelar.UseVisualStyleBackColor = true;
            // 
            // gbVenta
            // 
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
            // bttnTerminar
            // 
            this.bttnTerminar.Location = new System.Drawing.Point(473, 267);
            this.bttnTerminar.Name = "bttnTerminar";
            this.bttnTerminar.Size = new System.Drawing.Size(75, 23);
            this.bttnTerminar.TabIndex = 4;
            this.bttnTerminar.Text = "Terminar";
            this.bttnTerminar.UseVisualStyleBackColor = true;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(31, 285);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(67, 13);
            this.lblMonto.TabIndex = 5;
            this.lblMonto.Text = "Monto Total:";
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
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(248, 34);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 20);
            this.nudCantidad.TabIndex = 7;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bttnIngresar
            // 
            this.bttnIngresar.Location = new System.Drawing.Point(473, 30);
            this.bttnIngresar.Name = "bttnIngresar";
            this.bttnIngresar.Size = new System.Drawing.Size(75, 23);
            this.bttnIngresar.TabIndex = 8;
            this.bttnIngresar.Text = "Ingresar";
            this.bttnIngresar.UseVisualStyleBackColor = true;
            // 
            // FVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 373);
            this.Controls.Add(this.gbVenta);
            this.Name = "FVenta";
            this.Text = "Venta";
            ((System.ComponentModel.ISupportInitialize)(this.dataGVentas)).EndInit();
            this.gbVenta.ResumeLayout(false);
            this.gbVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.ResumeLayout(false);

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
    }
}