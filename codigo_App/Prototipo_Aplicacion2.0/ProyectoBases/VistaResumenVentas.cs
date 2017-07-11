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
    public partial class VistaResumenVentas : Form
    {
        private const int posMonto = 1; //Posicion en la fila del monto
        private Venta venta;            //Interfaz
        private VistaSelecMesResumenVentas prevForm; //Window previa

        /**
         * Constructor de la clase, recibe el mes a consultar y la form previa
         */
        public VistaResumenVentas(DateTime monthDate, VistaSelecMesResumenVentas prevForm)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.prevForm = prevForm;
            venta = new Venta();
            venta.llenarTablaResumenVentas_DelMes(dataGridVentas, monthDate); //Consulta las ventas
            calcularMontoTotal();
            dataGridVentas.AutoResizeColumns();
        }
        
        /**
         * Calcula en total cuanto suman todas las ventas.
         */
        private void calcularMontoTotal ()
        {
            int counter = 0;
            for (int i = 0; i < dataGridVentas.RowCount; i++)
            {
                counter += (int)dataGridVentas.Rows[i].Cells[posMonto].Value;
            }

            textBoxMonto.Text = "" + counter;
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
        private void ResumenVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!prevForm.Visible)
            {
                prevForm.Close();
            }
        }
    }
}
