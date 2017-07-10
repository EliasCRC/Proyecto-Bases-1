namespace ProyectoBases
{
    partial class EliminarHorario
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
            this.cbHorarios = new System.Windows.Forms.ComboBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbHorarios
            // 
            this.cbHorarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHorarios.FormattingEnabled = true;
            this.cbHorarios.Location = new System.Drawing.Point(12, 12);
            this.cbHorarios.Name = "cbHorarios";
            this.cbHorarios.Size = new System.Drawing.Size(121, 21);
            this.cbHorarios.TabIndex = 0;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(156, 47);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // EliminarHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 82);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.cbHorarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EliminarHorario";
            this.Text = "EliminarHorario";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EliminarHorario_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbHorarios;
        private System.Windows.Forms.Button btnEliminar;
    }
}