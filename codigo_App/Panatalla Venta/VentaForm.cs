using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FVenta : Form
    {
        Venta venta;
        public FVenta()
        {
            InitializeComponent();
            venta = new Venta();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void gbVenta_Enter(object sender, EventArgs e)
        {

        }
    }
}
