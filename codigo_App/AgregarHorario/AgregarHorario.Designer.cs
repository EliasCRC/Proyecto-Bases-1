namespace GUI
{
    partial class AgregarHorario
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
            this.rbtnLunes = new System.Windows.Forms.RadioButton();
            this.rbtnMartes = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.rbtnMiercoles = new System.Windows.Forms.RadioButton();
            this.rbtnSabado = new System.Windows.Forms.RadioButton();
            this.rbtnViernes = new System.Windows.Forms.RadioButton();
            this.rbtnDomingo = new System.Windows.Forms.RadioButton();
            this.cbHora = new System.Windows.Forms.ComboBox();
            this.lblHoras = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbtnLunes
            // 
            this.rbtnLunes.AutoSize = true;
            this.rbtnLunes.Location = new System.Drawing.Point(12, 12);
            this.rbtnLunes.Name = "rbtnLunes";
            this.rbtnLunes.Size = new System.Drawing.Size(54, 17);
            this.rbtnLunes.TabIndex = 0;
            this.rbtnLunes.TabStop = true;
            this.rbtnLunes.Text = "Lunes";
            this.rbtnLunes.UseVisualStyleBackColor = true;
            this.rbtnLunes.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbtnMartes
            // 
            this.rbtnMartes.AutoSize = true;
            this.rbtnMartes.Location = new System.Drawing.Point(12, 35);
            this.rbtnMartes.Name = "rbtnMartes";
            this.rbtnMartes.Size = new System.Drawing.Size(57, 17);
            this.rbtnMartes.TabIndex = 1;
            this.rbtnMartes.TabStop = true;
            this.rbtnMartes.Text = "Martes";
            this.rbtnMartes.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(12, 81);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(59, 17);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Jueves";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // rbtnMiercoles
            // 
            this.rbtnMiercoles.AutoSize = true;
            this.rbtnMiercoles.Location = new System.Drawing.Point(12, 58);
            this.rbtnMiercoles.Name = "rbtnMiercoles";
            this.rbtnMiercoles.Size = new System.Drawing.Size(70, 17);
            this.rbtnMiercoles.TabIndex = 2;
            this.rbtnMiercoles.TabStop = true;
            this.rbtnMiercoles.Text = "Miércoles";
            this.rbtnMiercoles.UseVisualStyleBackColor = true;
            // 
            // rbtnSabado
            // 
            this.rbtnSabado.AutoSize = true;
            this.rbtnSabado.Location = new System.Drawing.Point(12, 127);
            this.rbtnSabado.Name = "rbtnSabado";
            this.rbtnSabado.Size = new System.Drawing.Size(62, 17);
            this.rbtnSabado.TabIndex = 5;
            this.rbtnSabado.TabStop = true;
            this.rbtnSabado.Text = "Sábado";
            this.rbtnSabado.UseVisualStyleBackColor = true;
            // 
            // rbtnViernes
            // 
            this.rbtnViernes.AutoSize = true;
            this.rbtnViernes.Location = new System.Drawing.Point(12, 104);
            this.rbtnViernes.Name = "rbtnViernes";
            this.rbtnViernes.Size = new System.Drawing.Size(60, 17);
            this.rbtnViernes.TabIndex = 4;
            this.rbtnViernes.TabStop = true;
            this.rbtnViernes.Text = "Viernes";
            this.rbtnViernes.UseVisualStyleBackColor = true;
            // 
            // rbtnDomingo
            // 
            this.rbtnDomingo.AutoSize = true;
            this.rbtnDomingo.Location = new System.Drawing.Point(12, 150);
            this.rbtnDomingo.Name = "rbtnDomingo";
            this.rbtnDomingo.Size = new System.Drawing.Size(67, 17);
            this.rbtnDomingo.TabIndex = 6;
            this.rbtnDomingo.TabStop = true;
            this.rbtnDomingo.Text = "Domingo";
            this.rbtnDomingo.UseVisualStyleBackColor = true;
            // 
            // cbHora
            // 
            this.cbHora.FormattingEnabled = true;
            this.cbHora.Location = new System.Drawing.Point(207, 22);
            this.cbHora.Name = "cbHora";
            this.cbHora.Size = new System.Drawing.Size(79, 21);
            this.cbHora.TabIndex = 7;
            // 
            // lblHoras
            // 
            this.lblHoras.AutoSize = true;
            this.lblHoras.Location = new System.Drawing.Point(166, 25);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(35, 13);
            this.lblHoras.TabIndex = 8;
            this.lblHoras.Text = "Horas";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(211, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AgregarHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 193);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblHoras);
            this.Controls.Add(this.cbHora);
            this.Controls.Add(this.rbtnDomingo);
            this.Controls.Add(this.rbtnSabado);
            this.Controls.Add(this.rbtnViernes);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.rbtnMiercoles);
            this.Controls.Add(this.rbtnMartes);
            this.Controls.Add(this.rbtnLunes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AgregarHorario";
            this.Text = "AgregarHorario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnLunes;
        private System.Windows.Forms.RadioButton rbtnMartes;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton rbtnMiercoles;
        private System.Windows.Forms.RadioButton rbtnSabado;
        private System.Windows.Forms.RadioButton rbtnViernes;
        private System.Windows.Forms.RadioButton rbtnDomingo;
        private System.Windows.Forms.ComboBox cbHora;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.Button button1;
    }
}