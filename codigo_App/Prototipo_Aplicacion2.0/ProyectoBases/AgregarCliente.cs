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
    public partial class AgregarCliente : Form
    {
        Cliente cliente;
        VistaClientes vistaClientes;
        public AgregarCliente(VistaClientes vistaClientes)
        {
            InitializeComponent();
            this.vistaClientes = vistaClientes;
            cliente = new Cliente();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtTelefono.Text.Length == 0 || txtNombre.Text.Length == 0)
            {
                MessageBox.Show("Los campos teléfono y nombre son obligatorios", "Error");
            }
            string apellido = txtApellido.Text;
      
            if(cliente.agregarCliente(txtTelefono.Text, txtNombre.Text, apellido) != 0)
            {
                MessageBox.Show("Es posible que haya un cliente con ese número de teléfono", "Error");
            }
            vistaClientes.Show();
            this.Close();
        }

        private void AgregarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            vistaClientes.Show();
        }
    }
}
