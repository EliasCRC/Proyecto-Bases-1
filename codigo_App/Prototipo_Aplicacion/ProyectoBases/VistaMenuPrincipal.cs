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
    public partial class VistaMenuPrincipal : Form
    {
        private VistaLogin loginWindow;     //Ventana de login oculta 
        private Reservacion reservacion;    //
        private Venta venta;

        /**
         * Constructor de la clase 
         */
        public VistaMenuPrincipal(VistaLogin loginWindow, bool esAdmin)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.loginWindow = loginWindow;
            reservacion = new Reservacion();
            venta = new Venta();
            //Verifica si el usuario era admin, en ese caso le habilita el boton de admin
            if (esAdmin)
            {
                btnAdmin.Enabled = true;
            }
            lblNombreUsuario.Text = UsuarioActual.UserName;
            actualizarDataGrid();
        }

        /**
         * Actualiza el Datagrid según el radio button seleccionado
         */
        private void actualizarDataGrid ()
        {
            DateTime fechaSelec = datePicker.Value.Date;
            if (radioBtnTodos.Checked)
            {
                reservacion.llenarTabla_TodasReservaciones_Intervalo(dataGridResumen, fechaSelec, fechaSelec.AddDays(1));
            }
            if (radioBtnEquipoCompleto.Checked)
            {
                reservacion.llenarTabla_EquipoCompleto_Intervalo(dataGridResumen, fechaSelec, fechaSelec.AddDays(1));
            }
            if (radioBtnReto.Checked)
            {
                reservacion.llenarTabla_Reto_Intervalo(dataGridResumen, fechaSelec, fechaSelec.AddDays(1));
            }
            if (radioBtnVenta.Checked)
            {
                venta.llenarTablaVentas_Intervalo(dataGridResumen, fechaSelec, fechaSelec.AddDays(1));
            }
            dataGridResumen.AutoResizeColumns();
        }

        /**
         * Click boton historial de reservacion
         */
        private void btnHReserv_Click(object sender, EventArgs e)
        {
            (new VistaSelecMesResumenReserv()).Show();
        }

        /**
         * Click boton historial de venta
         */
        private void btnHVentas_Click(object sender, EventArgs e)
        {
            (new VistaSelecMesResumenVentas()).Show();
        }

        /**
         * Click boton ventan de admin
         */
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            (new VistaAdministrador(this)).Show();
            this.Hide();
        }

        /**
         * Click boton logout 
         */
        private void btnLogout_Click(object sender, EventArgs e)
        {
            loginWindow.Show();
            loginWindow.clearPassword();
            UsuarioActual.setName("UNAUTHORIZED USER"); //Por si acaso pone al usuario actual como un error
            this.Close();
        }

        /**
         * Si cierran esta entonces también cierra la de login
         */
        private void VistaMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!loginWindow.Visible)
            {
                loginWindow.Close();
            }
        }

        /**
         * Cuando se hace cambio en algun radio button se actualiza la grid
         */
        private void radioBtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnTodos.Checked)
            {
                actualizarDataGrid();
            }
        }

        /**
         * Cuando se hace cambio en algun radio button se actualiza la grid
         */
        private void radioBtnEquipoCompleto_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnEquipoCompleto.Checked)
            {
                actualizarDataGrid();
            }
        }

        /**
         * Cuando se hace cambio en algun radio button se actualiza la grid
         */
        private void radioBtnReto_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnReto.Checked)
            {
                actualizarDataGrid();
            }
        }

        /**
         * Cuando se hace cambio en algun radio button se actualiza la grid
         */
        private void radioBtnVenta_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnVenta.Checked)
            {
                actualizarDataGrid();
            }
        }

        /**
         * Cuando se hace cambio en la fecha se actualiza la grid
         */
        private void dateTimeReserv_ValueChanged(object sender, EventArgs e)
        {
            actualizarDataGrid();
        }

        /**
         * Cuando se hace doble click en una celda del grid debe de aparecer las especificaciones de la reservacion
         * en caso de ser una venta no muestra nada
         */
        private void dataGridResumen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radioBtnTodos.Checked)
            {
                int lastValue = dataGridResumen.ColumnCount - 1;
                int row = dataGridResumen.SelectedCells[0].RowIndex;
                bool esReto = ((string)dataGridResumen.Rows[row].Cells[lastValue].Value).Equals("Reto") ? true : false;
                DateTime momento = (DateTime)dataGridResumen.Rows[row].Cells[0].Value;
                Console.WriteLine(esReto + " " + momento);
                /*
                InfoReserv newInfo = new InfoReserv (momento, esReto);
                newInfo.ShowDialog(); 
                */
            }
            else if (radioBtnEquipoCompleto.Checked) {
                int row = dataGridResumen.SelectedCells[0].RowIndex;
                DateTime momento = (DateTime)dataGridResumen.Rows[row].Cells[0].Value;
                Console.WriteLine(false + " " + momento);
                /*
                InfoReserv newInfo = new InfoReserv (momento, false);
                newInfo.ShowDialog(); 
                */
            }
            else if (radioBtnReto.Checked)
            {
                int row = dataGridResumen.SelectedCells[0].RowIndex;
                DateTime momento = (DateTime)dataGridResumen.Rows[row].Cells[0].Value;
                Console.WriteLine(true + " " + momento);
                /*
                InfoReserv newInfo = new InfoReserv (momento, true);
                newInfo.ShowDialog(); 
                */
            }
        }
    }
}
