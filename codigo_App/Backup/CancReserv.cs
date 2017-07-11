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
    public partial class CancReserv : Form
    {
        IntermedioK inter;
        DateTime Momento;
        string Telefono;
        bool EsReto;
        bool EsAuto; //Cuando no es reto, puede ser automatica o no

        public CancReserv(DateTime mom, string tel, bool tipo, bool auto)
        {
            InitializeComponent();
            inter = new IntermedioK();
            Momento = mom;
            Telefono = tel;
            EsReto = tipo;
            EsAuto = auto;
        }

        private void button_si_Click(object sender, EventArgs e)
        {
            inter.Cancelacion(Momento, Telefono, EsReto, EsAuto, true);
            this.Close();
        }

        private void button_no_Click(object sender, EventArgs e)
        {
            inter.Cancelacion(Momento, Telefono, EsReto, EsAuto, false);
            this.Close();
        }

        private void CancReserv_Load(object sender, EventArgs e)
        {
            
        }

    }
}
