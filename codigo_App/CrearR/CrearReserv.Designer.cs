namespace ProyectoBases
{
    partial class CrearReserv
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
            this.textBox_hora = new System.Windows.Forms.TextBox();
            this.textBox_telc = new System.Windows.Forms.TextBox();
            this.textBox_telref = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label_fecha = new System.Windows.Forms.Label();
            this.label_hora = new System.Windows.Forms.Label();
            this.label_telref = new System.Windows.Forms.Label();
            this.label_telc = new System.Windows.Forms.Label();
            this.button_canc = new System.Windows.Forms.Button();
            this.button_acep = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_hora
            // 
            this.textBox_hora.Location = new System.Drawing.Point(218, 70);
            this.textBox_hora.Name = "textBox_hora";
            this.textBox_hora.Size = new System.Drawing.Size(100, 20);
            this.textBox_hora.TabIndex = 0;
            // 
            // textBox_telc
            // 
            this.textBox_telc.Location = new System.Drawing.Point(218, 110);
            this.textBox_telc.Name = "textBox_telc";
            this.textBox_telc.Size = new System.Drawing.Size(100, 20);
            this.textBox_telc.TabIndex = 1;
            // 
            // textBox_telref
            // 
            this.textBox_telref.Location = new System.Drawing.Point(218, 150);
            this.textBox_telref.Name = "textBox_telref";
            this.textBox_telref.Size = new System.Drawing.Size(100, 20);
            this.textBox_telref.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(175, 30);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label_fecha
            // 
            this.label_fecha.AutoSize = true;
            this.label_fecha.Location = new System.Drawing.Point(80, 36);
            this.label_fecha.Name = "label_fecha";
            this.label_fecha.Size = new System.Drawing.Size(37, 13);
            this.label_fecha.TabIndex = 4;
            this.label_fecha.Text = "Fecha";
            // 
            // label_hora
            // 
            this.label_hora.AutoSize = true;
            this.label_hora.Location = new System.Drawing.Point(80, 73);
            this.label_hora.Name = "label_hora";
            this.label_hora.Size = new System.Drawing.Size(30, 13);
            this.label_hora.TabIndex = 5;
            this.label_hora.Text = "Hora";
            // 
            // label_telref
            // 
            this.label_telref.AutoSize = true;
            this.label_telref.Location = new System.Drawing.Point(80, 153);
            this.label_telref.Name = "label_telref";
            this.label_telref.Size = new System.Drawing.Size(80, 13);
            this.label_telref.TabIndex = 6;
            this.label_telref.Text = "Tel. Referencia";
            // 
            // label_telc
            // 
            this.label_telc.AutoSize = true;
            this.label_telc.Location = new System.Drawing.Point(80, 113);
            this.label_telc.Name = "label_telc";
            this.label_telc.Size = new System.Drawing.Size(60, 13);
            this.label_telc.TabIndex = 7;
            this.label_telc.Text = "Tel. Cliente";
            // 
            // button_canc
            // 
            this.button_canc.Location = new System.Drawing.Point(90, 210);
            this.button_canc.Name = "button_canc";
            this.button_canc.Size = new System.Drawing.Size(75, 23);
            this.button_canc.TabIndex = 8;
            this.button_canc.Text = "Cancelar";
            this.button_canc.UseVisualStyleBackColor = true;
            this.button_canc.Click += new System.EventHandler(this.button_canc_Click);
            // 
            // button_acep
            // 
            this.button_acep.Location = new System.Drawing.Point(231, 210);
            this.button_acep.Name = "button_acep";
            this.button_acep.Size = new System.Drawing.Size(75, 23);
            this.button_acep.TabIndex = 9;
            this.button_acep.Text = "Aceptar";
            this.button_acep.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_fecha);
            this.groupBox1.Controls.Add(this.label_hora);
            this.groupBox1.Controls.Add(this.label_telc);
            this.groupBox1.Controls.Add(this.button_acep);
            this.groupBox1.Controls.Add(this.label_telref);
            this.groupBox1.Controls.Add(this.button_canc);
            this.groupBox1.Controls.Add(this.textBox_telref);
            this.groupBox1.Controls.Add(this.textBox_hora);
            this.groupBox1.Controls.Add(this.textBox_telc);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(35, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 260);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // CrearReserv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 321);
            this.Controls.Add(this.groupBox1);
            this.Name = "CrearReserv";
            this.Text = "CrearReserv";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_hora;
        private System.Windows.Forms.TextBox textBox_telc;
        private System.Windows.Forms.TextBox textBox_telref;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label_fecha;
        private System.Windows.Forms.Label label_hora;
        private System.Windows.Forms.Label label_telref;
        private System.Windows.Forms.Label label_telc;
        private System.Windows.Forms.Button button_canc;
        private System.Windows.Forms.Button button_acep;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}