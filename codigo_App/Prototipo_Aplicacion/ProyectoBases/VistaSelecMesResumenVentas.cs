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
    public partial class VistaSelecMesResumenVentas : Form
    {
        private Venta venta = new Venta();
        /* Array para ver los meses en el combo box */
        private string[] meses = new string[] {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"};

        /**
         * Constructor de la clase, inicializa el combo boc del mes y del año
         * para el año se fija qué años tienen alguna venta asociada
         */
        public VistaSelecMesResumenVentas()
        {
            InitializeComponent();
            this.CenterToScreen();
            for (int indexMes = 0; indexMes < meses.Length; indexMes++)
            {
                comboBoxMes.Items.Add(meses[indexMes]);

            }

            int[] annosEnBase = venta.annosVentas();
            for (int counterAnyo = 0; counterAnyo < annosEnBase.Length; counterAnyo++)
            {
                comboBoxAnno.Items.Add(annosEnBase[counterAnyo]);
            }

        }

        /**
         * Cuando se apreta aceptar agarra el mes y año seleccionado, y muestra la proxima ventana
         */
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            //Selecciona el primer dia del año seleccionado del mes seleccionado
            try
            {
                int mesSeleccionado = comboBoxMes.SelectedIndex + 1;
                DateTime anyoSeleccionado = new DateTime((int)comboBoxAnno.SelectedItem, 1, 1);
                VistaResumenVentas nuevoResumen = new VistaResumenVentas(new DateTime(anyoSeleccionado.Year, mesSeleccionado, 1), this);
                nuevoResumen.Show();
                this.Hide();
            }
            catch (Exception ex)
            {

            }
        }

        /**
         * Hasta que ambos combo box tengan algo, se habilita el boton de aceptar
         */
        private void comboBoxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAnno.SelectedIndex != -1)
                btnAceptar.Enabled = true;
        }

        /**
         * Hasta que ambos combo box tengan algo, se habilita el boton de aceptar
         */
        private void comboBoxAnno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMes.SelectedIndex != -1)
                btnAceptar.Enabled = true;
        }
    }
}
