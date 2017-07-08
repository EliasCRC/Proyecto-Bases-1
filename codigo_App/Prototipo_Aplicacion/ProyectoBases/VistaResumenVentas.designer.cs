namespace ProyectoBases
{
    partial class VistaResumenVentas
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
            this.dataGridVentas = new System.Windows.Forms.DataGridView();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.textBoxMonto = new System.Windows.Forms.TextBox();
            this.btnRegresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridVentas
            // 
            this.dataGridVentas.AllowUserToAddRows = false;
            this.dataGridVentas.AllowUserToDeleteRows = false;
            this.dataGridVentas.AllowUserToResizeColumns = false;
            this.dataGridVentas.AllowUserToResizeRows = false;
            this.dataGridVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridVentas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVentas.Location = new System.Drawing.Point(31, 28);
            this.dataGridVentas.Name = "dataGridVentas";
            this.dataGridVentas.Size = new System.Drawing.Size(426, 498);
            this.dataGridVentas.TabIndex = 1;
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotal.Location = new System.Drawing.Point(12, 539);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(292, 25);
            this.lblMontoTotal.TabIndex = 2;
            this.lblMontoTotal.Text = "Monto total de las ventas:   ₡";
            // 
            // textBoxMonto
            // 
            this.textBoxMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMonto.Location = new System.Drawing.Point(305, 537);
            this.textBoxMonto.Name = "textBoxMonto";
            this.textBoxMonto.ReadOnly = true;
            this.textBoxMonto.Size = new System.Drawing.Size(152, 29);
            this.textBoxMonto.TabIndex = 3;
            this.textBoxMonto.Text = "--------";
            this.textBoxMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(394, 580);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(75, 23);
            this.btnRegresar.TabIndex = 4;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // ResumenVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 615);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.textBoxMonto);
            this.Controls.Add(this.lblMontoTotal);
            this.Controls.Add(this.dataGridVentas);
            this.Name = "ResumenVentas";
            this.Text = "Resumen de Ventas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResumenVentas_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridVentas;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.TextBox textBoxMonto;
        private System.Windows.Forms.Button btnRegresar;
    }
}