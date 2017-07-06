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
    public partial class SelecMesResumenVentas : Form
    {
        private string[] meses = new string[] {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"};
        public SelecMesResumenVentas()
        {
            InitializeComponent();
            for (int i = 0; i < meses.Length; i++)
            {
                comboBoxMes.Items.Add(meses[i]);

            }
            comboBoxMes.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
