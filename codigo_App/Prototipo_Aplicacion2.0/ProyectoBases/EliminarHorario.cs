using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBases
{
    public partial class EliminarHorario : Form
    {
        string telefono;
        Cliente cliente;
        VistaClientes vistaClientes;
        string[] diasSemana = {"Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"};
        List<int> dias;
        List<int> horas;


        public EliminarHorario(string telefono, VistaClientes vistaClientes)
        {
            InitializeComponent();
            this.telefono = telefono;
            cliente = new Cliente();
            this.vistaClientes = vistaClientes;
            dias = new List<int>();
            horas = new List<int>();
            llenarComboBox();
        }

        private void llenarComboBox()
        {
            SqlDataReader horarios = cliente.obtenerHorariosFrec(telefono);
            if (horarios != null && horarios.HasRows)
            {
                while (horarios.Read())
                {
                    cbHorarios.Items.Add(diasSemana[(int) horarios.GetValue(0) - 1] + " \t" + horarios.GetValue(1) + ":00");
                    dias.Add((int) horarios.GetValue(0));
                    horas.Add((int) horarios.GetValue(1));
                }
                
            }
            else
            {
                MessageBox.Show("El cliente seleccionado no tiene horarios en este momento");
                vistaClientes.Show();
                this.Hide();
            }
        }

        private void EliminarHorario_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaClientes.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cbHorarios.SelectedItem != null)
            {
                if(cliente.eliminarHorario(dias[cbHorarios.SelectedIndex], horas[cbHorarios.SelectedIndex], telefono) != 0)
                {
                    MessageBox.Show("Error al eliminar horario","Error");
                }
            }
            vistaClientes.Show();
            this.Close();
        }
    }
}
