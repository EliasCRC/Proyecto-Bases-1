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
    public partial class AgregarHorario : Form
    {
        public AgregarHorario()
        {
            InitializeComponent();
            for (int i = 6; i < 12; i++)
            {
                cbHora.Items.Add(i + " AM");
            }
            for (int i = 1; i < 10; i++)
            {
                cbHora.Items.Add(i + " PM");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
