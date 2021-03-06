﻿namespace ProyectoBases
{
    partial class ResumenReservaciones
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
            this.dataGridReserv = new System.Windows.Forms.DataGridView();
            this.lblResumen = new System.Windows.Forms.Label();
            this.lblEquipoCompleto = new System.Windows.Forms.Label();
            this.lblRetos = new System.Windows.Forms.Label();
            this.textBoxEquipoCompleto = new System.Windows.Forms.TextBox();
            this.textBoxReto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReserv)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridReserv
            // 
            this.dataGridReserv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReserv.Location = new System.Drawing.Point(29, 50);
            this.dataGridReserv.Name = "dataGridReserv";
            this.dataGridReserv.Size = new System.Drawing.Size(414, 489);
            this.dataGridReserv.TabIndex = 3;
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Location = new System.Drawing.Point(25, 21);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(55, 13);
            this.lblResumen.TabIndex = 2;
            this.lblResumen.Text = "Resumen:";
            // 
            // lblEquipoCompleto
            // 
            this.lblEquipoCompleto.AutoSize = true;
            this.lblEquipoCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipoCompleto.Location = new System.Drawing.Point(25, 551);
            this.lblEquipoCompleto.Name = "lblEquipoCompleto";
            this.lblEquipoCompleto.Size = new System.Drawing.Size(266, 20);
            this.lblEquipoCompleto.TabIndex = 4;
            this.lblEquipoCompleto.Text = "Reservaciones de Equipo Completo:";
            // 
            // lblRetos
            // 
            this.lblRetos.AutoSize = true;
            this.lblRetos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetos.Location = new System.Drawing.Point(25, 585);
            this.lblRetos.Name = "lblRetos";
            this.lblRetos.Size = new System.Drawing.Size(56, 20);
            this.lblRetos.TabIndex = 5;
            this.lblRetos.Text = "Retos:";
            // 
            // textBoxEquipoCompleto
            // 
            this.textBoxEquipoCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEquipoCompleto.Location = new System.Drawing.Point(361, 545);
            this.textBoxEquipoCompleto.Name = "textBoxEquipoCompleto";
            this.textBoxEquipoCompleto.ReadOnly = true;
            this.textBoxEquipoCompleto.Size = new System.Drawing.Size(81, 29);
            this.textBoxEquipoCompleto.TabIndex = 6;
            this.textBoxEquipoCompleto.Text = "-----";
            this.textBoxEquipoCompleto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxReto
            // 
            this.textBoxReto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxReto.Location = new System.Drawing.Point(361, 579);
            this.textBoxReto.Name = "textBoxReto";
            this.textBoxReto.ReadOnly = true;
            this.textBoxReto.Size = new System.Drawing.Size(81, 29);
            this.textBoxReto.TabIndex = 7;
            this.textBoxReto.Text = "-----";
            this.textBoxReto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ResumenReservaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 620);
            this.Controls.Add(this.textBoxReto);
            this.Controls.Add(this.textBoxEquipoCompleto);
            this.Controls.Add(this.lblRetos);
            this.Controls.Add(this.lblEquipoCompleto);
            this.Controls.Add(this.dataGridReserv);
            this.Controls.Add(this.lblResumen);
            this.Name = "ResumenReservaciones";
            this.Text = "Resumen de reservaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReserv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridReserv;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Label lblEquipoCompleto;
        private System.Windows.Forms.Label lblRetos;
        private System.Windows.Forms.TextBox textBoxEquipoCompleto;
        private System.Windows.Forms.TextBox textBoxReto;
    }
}