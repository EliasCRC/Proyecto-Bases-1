namespace ProyectoBases
{
    partial class CancReserv
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
            this.label_preg = new System.Windows.Forms.Label();
            this.button_si = new System.Windows.Forms.Button();
            this.button_no = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_preg
            // 
            this.label_preg.AutoSize = true;
            this.label_preg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_preg.Location = new System.Drawing.Point(35, 42);
            this.label_preg.Name = "label_preg";
            this.label_preg.Size = new System.Drawing.Size(480, 20);
            this.label_preg.TabIndex = 0;
            this.label_preg.Text = "¿Desea sumar esta cancelación al contador de veces canceladas?";
            // 
            // button_si
            // 
            this.button_si.Location = new System.Drawing.Point(172, 79);
            this.button_si.Name = "button_si";
            this.button_si.Size = new System.Drawing.Size(80, 25);
            this.button_si.TabIndex = 1;
            this.button_si.Text = "Sí";
            this.button_si.UseVisualStyleBackColor = true;
            this.button_si.Click += new System.EventHandler(this.button_si_Click);
            // 
            // button_no
            // 
            this.button_no.Location = new System.Drawing.Point(277, 79);
            this.button_no.Name = "button_no";
            this.button_no.Size = new System.Drawing.Size(80, 25);
            this.button_no.TabIndex = 2;
            this.button_no.Text = "No";
            this.button_no.UseVisualStyleBackColor = true;
            this.button_no.Click += new System.EventHandler(this.button_no_Click);
            // 
            // CancReserv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 147);
            this.Controls.Add(this.button_no);
            this.Controls.Add(this.button_si);
            this.Controls.Add(this.label_preg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CancReserv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contar cancelación de reservación";
            this.Load += new System.EventHandler(this.CancReserv_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_preg;
        private System.Windows.Forms.Button button_si;
        private System.Windows.Forms.Button button_no;
    }
}