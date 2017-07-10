using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBases
{
    public partial class ModificarDeuda : Form
    {
        public string datos;
        public string telefono;
        VistaClientes vistaClientes;
        Cliente cliente;
        public ModificarDeuda(string telefono, string datos, VistaClientes vistaClientes)
        {
            InitializeComponent();
            lblCliente.Text += " " + datos;
            this.telefono = telefono;
            this.vistaClientes = vistaClientes;
            cliente = new Cliente();
        }

        private void btnAumentar_Click(object sender, EventArgs e)
        {
            Regex numerico = new Regex("[0-9]+");
            if (numerico.IsMatch(txtMonto.Text))
            {
                if (cliente.aumentarDeuda(telefono, txtMonto.Text) != 0)
                {
                    MessageBox.Show("Error al aumentar deuda", "Error");
                }
            }
            else
            {
                MessageBox.Show("Solo se aceptan valores numéricos", "Error");
            }
            vistaClientes.Show();
            this.Close();
        }

        private void btnDisminuir_Click(object sender, EventArgs e)
        {
            Regex numerico = new Regex("[0-9]+");
            if (numerico.IsMatch(txtMonto.Text))
            {
                if (cliente.reducirDeuda(telefono, txtMonto.Text) != 0)
                {
                    MessageBox.Show("Error al disminuir deuda", "Error");
                }
            }
            else
            {
                MessageBox.Show("Solo se aceptan valores numéricos", "Error");
            }
            vistaClientes.Show();
            this.Close();
        }
    }
}
