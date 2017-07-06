using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ModificarCliente : Form
    {
        public ModificarCliente()
        {
            InitializeComponent();
        }

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            btnHacerFrec.Hide();
            btnEliminarHorario.Hide();
            btnQuitarFrecuente.Hide();
            btnAgregarHorario.Hide();
        }

        private void rbtnFrecuentes_CheckedChanged(object sender, EventArgs e)
        {
            btnHacerFrec.Hide();
            btnEliminarHorario.Show();
            btnQuitarFrecuente.Show();
            btnAgregarHorario.Show();
        }

        private void rbtnEsporadicos_CheckedChanged(object sender, EventArgs e)
        {
            btnHacerFrec.Show();
            btnEliminarHorario.Hide();
            btnQuitarFrecuente.Hide();
            btnAgregarHorario.Hide();
        }
    }
}
