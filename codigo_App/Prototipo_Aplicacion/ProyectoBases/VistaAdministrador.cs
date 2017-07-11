using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBases
{
    public partial class VistaAdministrador : Form
    {
        VistaMenuPrincipal prevForm; //Ventana anterior, usualmente la de menu

        /**
         * Constructor de la clase
         */
        public VistaAdministrador(VistaMenuPrincipal prevForm)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.prevForm = prevForm;
        }

        /**
         * Cuando ciera, muestra la anterior
         */
        private void VistaAdministrador_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.prevForm.Show();
        }
    }
}
