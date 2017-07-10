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
    public partial class VistaResumenReservaciones : Form
    {
        private Reservacion reservacion; //Interfaz 
        private const int posTipo = 6;      //Posicion de donde está el tipo de reservacion
        private VistaSelecMesResumenReserv prevForm; //Window previa 

        /**
         * Constructor de la clase, recibe el mes a consultar y la form previa
         */
        public VistaResumenReservaciones(DateTime monthDate, VistaSelecMesResumenReserv prevForm)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.prevForm = prevForm;
            reservacion = new Reservacion();
            reservacion.llenarTablaResumenReservaciones_DelMes(dataGridReserv, monthDate); //Consulta las reservaciones
            calcularReserv_y_Retos();
            dataGridReserv.AutoResizeColumns();
        }


        /**
         * Calcula cuantas reservaciones y cuantos retos hay
         */
        private void calcularReserv_y_Retos()
        {
            int counterReserv = 0;
            int counterRetos = 0;
            for (int i = 0; i < dataGridReserv.RowCount; i++)
            {
                //Si es un reto sume al contador de retos, si no al de equipo completo
                if (((string)dataGridReserv.Rows[i].Cells[posTipo].Value).Equals("Reto"))
                    counterRetos++;
                else
                    counterReserv++;
            }

            textBoxReto.Text = "" + counterRetos;
            textBoxEquipoCompleto.Text = "" + counterReserv;
        }

        /**
         * Regresa a la pantalla previa
         */
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                prevForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }

        /**
         * Si la cierran de golpe, también cierra la pantalla previa.
         */
        private void ResumenReservaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!prevForm.Visible)
            {
                prevForm.Close();
            }
        }
    }
}
