﻿namespace ProyectoBases
{
    partial class VistaSelecMesResumenReserv
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
            this.comboBoxMes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.comboBoxAnno = new System.Windows.Forms.ComboBox();
            this.labelAnno = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxMes
            // 
            this.comboBoxMes.FormattingEnabled = true;
            this.comboBoxMes.Location = new System.Drawing.Point(23, 41);
            this.comboBoxMes.Name = "comboBoxMes";
            this.comboBoxMes.Size = new System.Drawing.Size(170, 21);
            this.comboBoxMes.TabIndex = 2;
            this.comboBoxMes.SelectedIndexChanged += new System.EventHandler(this.comboBoxMes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingrese el mes a consultar:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Location = new System.Drawing.Point(305, 85);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // comboBoxAnno
            // 
            this.comboBoxAnno.FormattingEnabled = true;
            this.comboBoxAnno.Location = new System.Drawing.Point(209, 41);
            this.comboBoxAnno.Name = "comboBoxAnno";
            this.comboBoxAnno.Size = new System.Drawing.Size(136, 21);
            this.comboBoxAnno.TabIndex = 7;
            this.comboBoxAnno.SelectedIndexChanged += new System.EventHandler(this.comboBoxAnno_SelectedIndexChanged);
            // 
            // labelAnno
            // 
            this.labelAnno.AutoSize = true;
            this.labelAnno.Location = new System.Drawing.Point(206, 25);
            this.labelAnno.Name = "labelAnno";
            this.labelAnno.Size = new System.Drawing.Size(132, 13);
            this.labelAnno.TabIndex = 6;
            this.labelAnno.Text = "Ingrese el año a consultar:";
            // 
            // VistaSelecMesResumenReserv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 120);
            this.Controls.Add(this.comboBoxAnno);
            this.Controls.Add(this.labelAnno);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.comboBoxMes);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VistaSelecMesResumenReserv";
            this.Text = "Mes de Resumen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox comboBoxAnno;
        private System.Windows.Forms.Label labelAnno;
    }
}

