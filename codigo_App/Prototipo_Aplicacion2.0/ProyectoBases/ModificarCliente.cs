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
    public partial class ModificarCliente : Form
    {
        string telViejo;
        Cliente cliente;
        VistaClientes vistaClientes;
        public ModificarCliente(string telViejo, string nombViejo, string apeViejo, VistaClientes vistaClientes)
        {
            InitializeComponent();
            cliente = new Cliente();
            this.telViejo = telViejo;
            this.vistaClientes = vistaClientes;
            txtTelefono.Text = telViejo;
            txtNombre.Text = nombViejo;
            txtApellido.Text = apeViejo;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string apellido = txtApellido.Text;
            if (cliente.modificarCliente(telViejo, txtTelefono.Text, txtNombre.Text, apellido) != 0)
            {
                MessageBox.Show("Error al modificar cliente", "Error");
            }
            vistaClientes.Show();
            this.Hide();
        }
    }
}
