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
    public partial class AgregarHorario : Form
    {
        string telCliente;
        VistaClientes vistaClientes;
        Cliente cliente;
        Encargado encargado;
        public AgregarHorario(string telCliente, VistaClientes vistaClientes)
        {
            InitializeComponent();
            this.telCliente = telCliente;
            this.vistaClientes = vistaClientes;
            cliente = new Cliente();
            encargado = new Encargado();
            for (int i = 6; i <= 11; i++)
            {
                cbHora.Items.Add(i + " AM");
            }
            cbHora.Items.Add(12 + " PM");
            for (int i = 1; i < 11; i++)
            {
                cbHora.Items.Add(i + " PM");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AgregarHorario_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaClientes.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbHora.SelectedItem != null)
            {
                DateTime proximo = new DateTime();
                if (rbtnDomingo.Checked)
                {
                    proximo = obtenerDiaSemanaMasProximo(DayOfWeek.Sunday);
                }
                else if (rbtnLunes.Checked)
                {
                    proximo = obtenerDiaSemanaMasProximo(DayOfWeek.Monday);
                }
                else if (rbtnMartes.Checked)
                {
                    proximo = obtenerDiaSemanaMasProximo(DayOfWeek.Tuesday);
                }
                else if (rbtnMiercoles.Checked)
                {
                    proximo = obtenerDiaSemanaMasProximo(DayOfWeek.Wednesday);
                }
                else if (rbtnJueves.Checked)
                {
                    proximo = obtenerDiaSemanaMasProximo(DayOfWeek.Thursday);
                }
                else if (rbtnViernes.Checked)
                {
                    proximo = obtenerDiaSemanaMasProximo(DayOfWeek.Friday);
                }
                else if (rbtnSabado.Checked)
                {
                    proximo = obtenerDiaSemanaMasProximo(DayOfWeek.Saturday);
                    
                }

                proximo = proximo.AddHours(cbHora.SelectedIndex + 6);
                if (cliente.agregarHorarioFrec(proximo.ToString(), telCliente, encargado.getCedula()) != 0)
                {
                    MessageBox.Show("No se logró agregar el horario", "Error");
                }
                vistaClientes.Show();
                this.Close();
            }
        }

        DateTime obtenerDiaSemanaMasProximo(DayOfWeek dia)
        {
            DateTime hoy = DateTime.Today;
            int diasPendientes = ((int) dia - (int)hoy.DayOfWeek + 7) % 7;
            DateTime proximo = hoy.AddDays(diasPendientes);
            return proximo;
        }
    }
}
