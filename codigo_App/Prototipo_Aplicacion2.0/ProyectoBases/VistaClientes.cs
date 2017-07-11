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
    public partial class VistaClientes : Form
    {
        Cliente cliente;
        public VistaClientes()
        {
            InitializeComponent();
            cliente = new Cliente();
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
            btnAgregar.Show();
            btnCanceladas.Show();
            btnAutomaticas.Hide();
            dgClientes.DataSource = null;
        }

        private void rbtnFrecuentes_CheckedChanged(object sender, EventArgs e)
        {
            btnHacerFrec.Hide();
            btnEliminarHorario.Show();
            btnQuitarFrecuente.Show();
            btnAgregar.Hide();
            btnAgregarHorario.Show();
            btnCanceladas.Show();
            btnAutomaticas.Show();
            dgClientes.DataSource = null;
        }

        private void rbtnEsporadicos_CheckedChanged(object sender, EventArgs e)
        {
            btnHacerFrec.Show();
            btnEliminarHorario.Hide();
            btnQuitarFrecuente.Hide();
            btnAgregarHorario.Hide();
            btnAgregar.Show();
            btnCanceladas.Show();
            btnAutomaticas.Hide();
            dgClientes.DataSource = null;
        }

        public void llenarTablaNombre(DataGridView dataGridView, string filtroNombre, string filtroApellido)
        {
            DataTable tabla = null;
            if (rbtnTodos.Checked)
            {
                tabla = cliente.obtenerClientes(filtroNombre, filtroApellido);
            }
            else if (rbtnFrecuentes.Checked)
            {
                tabla = cliente.obtenerFrecuentes(filtroNombre, filtroApellido);
            }
            else
            {
                tabla = cliente.obtenerEsporadicos(filtroNombre, filtroApellido);
            }
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = tabla;

                dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                dataGridView.DataSource = bindingSource;

                for (int i = 0; i < dgClientes.ColumnCount; i++)
                {
                    dataGridView.Columns[i].Width = 121;
                }
            
        }

        public void llenarTablaTelefono(DataGridView dataGridView, string telefono)
        {
            DataTable tabla = null;
            if (rbtnTodos.Checked)
            {
                tabla = cliente.obtenerClientes(telefono);
            }
            else if (rbtnFrecuentes.Checked)
            {
                tabla = cliente.obtenerFrecuentes(telefono);
            }
            else
            {
                tabla = cliente.obtenerEsporadicos(telefono);
            }
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = tabla;

            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dataGridView.DataSource = bindingSource;

            for (int i = 0; i < dgClientes.ColumnCount; i++)
            {
                dataGridView.Columns[i].Width = 121;
            }

        }

        private void btnNombre_Click(object sender, EventArgs e)
        {
            llenarTablaNombre(dgClientes, txtNombre.Text, txtApellido.Text);
            txtNombre.Clear();
            txtApellido.Clear();
        }

        private void btnTelefono_Click(object sender, EventArgs e)
        {
            llenarTablaTelefono(dgClientes, txtTelefono.Text);
            txtTelefono.Clear();
        }

        private void btnHacerFrec_Click(object sender, EventArgs e)
        { 
            if (dgClientes.CurrentRow != null)
            {
                if (cliente.hacerFrecuente(dgClientes.CurrentRow.Cells[0].Value.ToString()) != 0)
                {
                    MessageBox.Show("Error al intentar hacer frecuente", "Error");
                }
            }
            dgClientes.DataSource = null;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgClientes.CurrentRow != null)
            {
                if(cliente.eliminarCliente(dgClientes.CurrentRow.Cells[0].Value.ToString()) !=0)
                {
                    MessageBox.Show("Error al eliminar cliente", "Error");
                }
            }
            dgClientes.DataSource = null;
        }

        private void btnQuitarFrecuente_Click(object sender, EventArgs e)
        {
            if (dgClientes.CurrentRow != null)
            {
                if(cliente.quitarEstadoFrecuente(dgClientes.CurrentRow.Cells[0].Value.ToString()) != 0)
                {
                    MessageBox.Show("No se pudo quitar estado de frecuente", "Error");
                }
            }
            dgClientes.DataSource = null;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dgClientes.CurrentRow != null)
            {
                ModificarCliente modificarC = new ModificarCliente(dgClientes.CurrentRow.Cells[0].Value.ToString(),
                    dgClientes.CurrentRow.Cells[1].Value.ToString(), dgClientes.CurrentRow.Cells[2].Value.ToString(), this);
                this.Hide();
                modificarC.Show();
                dgClientes.DataSource = null;
            }
        }

        private void btnAgregarHorario_Click(object sender, EventArgs e)
        {
            if (dgClientes.CurrentRow != null)
            {
                AgregarHorario agregarH = new AgregarHorario(dgClientes.CurrentRow.Cells[0].Value.ToString(), this);
                this.Hide();
                agregarH.Show();
                dgClientes.DataSource = null;
            }
        }

        private void btnDeuda_Click(object sender, EventArgs e)
        {
            if (dgClientes.CurrentRow != null)
            {
                string datos = " " + dgClientes.CurrentRow.Cells[1].Value.ToString() + " " + dgClientes.CurrentRow.Cells[2].Value.ToString();
                datos += ", Deuda: " + dgClientes.CurrentRow.Cells[3].Value.ToString();
                ModificarDeuda modDeuda = new ModificarDeuda(dgClientes.CurrentRow.Cells[0].Value.ToString(), datos, this);
                this.Hide();
                modDeuda.Show();
                dgClientes.DataSource = null;
            }
        }

        private void btnEliminarHorario_Click(object sender, EventArgs e)
        {
            if (dgClientes.CurrentRow != null)
            {
                EliminarHorario eliminarH = new EliminarHorario(dgClientes.CurrentRow.Cells[0].Value.ToString(), this);
                this.Hide();
                eliminarH.Show();
                dgClientes.DataSource = null;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarCliente agregarC = new AgregarCliente(this);
            agregarC.Show();
            this.Hide();
        }

        private void btnCanceladas_Click(object sender, EventArgs e)
        {
            if (dgClientes.CurrentRow != null)
            {
                cliente.reiniciarCanceladas(dgClientes.CurrentRow.Cells[0].Value.ToString());
                dgClientes.DataSource = null;
            }
        }

        private void btnAutomaticas_Click(object sender, EventArgs e)
        {
            cliente.reiniciarAutomaticas(dgClientes.CurrentRow.Cells[0].Value.ToString());
            dgClientes.DataSource = null;
        }
    }
}
