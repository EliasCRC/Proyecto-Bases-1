using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ProyectoBases
{
    public partial class InfoReserv : Form
    {
        DateTime Momento;
        bool Tipo;
        IntermedioK interm;

        public InfoReserv()
        {
            InitializeComponent();
        }

        public InfoReserv(DateTime mom, bool t)
        {
            InitializeComponent();
            Momento = mom;
            Tipo = t;
            interm = new IntermedioK();
        }

        private void CambioPart() //Cuando hay algun cambio en los participantes de un reto
        {
            interm.CargarReserv(Momento, Tipo, grid);
            if (grid.RowCount == 2)
            {
                button_agpart.Visible = false;
                button_qpart.Visible = true;
            }
            else
            {
                button_agpart.Visible = true;
                button_qpart.Visible = false;
            }
        }

        private void button_canc_Click(object sender, EventArgs e)
        {
            bool auto = (bool)grid.Rows[0].Cells[7].Value;
            string tel = (string)grid.Rows[0].Cells[6].Value;
            CancReserv cr = new CancReserv(Momento, tel, Tipo, auto);
            cr.Show();
            this.Close();
        }

        private void InfoReservacion_Load(object sender, EventArgs e)
        {
            interm.CargarReserv(Momento, Tipo, grid);
            label_momento.Text = grid.Rows[0].Cells[0].Value.ToString();
            if (!Tipo) //De equipo completo
            {
                button_agpart.Visible = false;
                button_qpart.Visible = false;
            }
            else
                CambioPart();
        }

        private void button_ini_Click(object sender, EventArgs e)
        {
            interm.InicioFin(Momento, false);
            interm.CargarReserv(Momento, Tipo, grid);
        }

        private void button_fin_Click(object sender, EventArgs e)
        {
            interm.InicioFin(Momento, true);
            interm.CargarReserv(Momento, Tipo, grid);
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_agpart_Click(object sender, EventArgs e)
        {
            string tel;
            tel = Interaction.InputBox("Digite el telefono del nuevo participante", "Nuevo participante", "");
            if (tel == "")
            {
                MessageBox.Show("Debe digitar un telefono para poder agregar a alguien", "No hay telefono", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                interm.Participante(Momento, tel, false);
                CambioPart();
            }
        }

        private void button_qpart_Click(object sender, EventArgs e)
        {
            interm.Participante(Momento, "", true);
            CambioPart();
        }

        private void button_mod_Click(object sender, EventArgs e)
        {
            //nuevo form
        }
    }
}
