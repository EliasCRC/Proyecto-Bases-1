using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBases
{
    class Reservacion
    {
        private AccesoBaseDatos controlAcceso;
        
        /**
         * Constructor de la clase, inicializa el acceso 
         */
        public Reservacion()
        {
            controlAcceso = new AccesoBaseDatos();
        }

        /**
         * Llena un datagrid con las reservaciones del mes según el mes y año ingresado
         */
        public void llenarTablaResumenReservaciones_DelMes(DataGridView dataGridView, DateTime monthDate)
        {
            /* Agarra el mes de la fecha enviada y año */
            DateTime monthBot = new DateTime (monthDate.Year, monthDate.Month, 1);
            /* Le suma uno al mes */
            DateTime monthTop = new DateTime (monthDate.Year, monthDate.Month, 1).AddMonths(1);
            /* Llena los elementos */
            DataTable tabla = controlAcceso.consultar_reservaciones(monthBot, monthTop);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = tabla;

            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dataGridView.DataSource = bindingSource;
        }

        /**
         * Llena un datagrid con las reservaciones que hay entre dos intervalos de tiempo
         */
        public void llenarTabla_TodasReservaciones_Intervalo(DataGridView dataGridView, DateTime dateBot, DateTime dateTop)
        {
            DataTable tabla = controlAcceso.consultar_reservaciones(dateBot, dateTop);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = tabla;

            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dataGridView.DataSource = bindingSource;
        }

        /**
         * Llena un datagrid con las reservaciones de equipo completo que hay entre dos intervalos de tiempo
         */
        public void llenarTabla_EquipoCompleto_Intervalo(DataGridView dataGridView, DateTime dateBot, DateTime dateTop)
        {
            DataTable tabla = controlAcceso.consultar_EquipoCompleto_Intervalo(dateBot, dateTop);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = tabla;

            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dataGridView.DataSource = bindingSource;
        }

        /**
         * Llena un datagrid con los retos que hay entre dos intervalos de tiempo
         */
        public void llenarTabla_Reto_Intervalo(DataGridView dataGridView, DateTime dateBot, DateTime dateTop)
        {
            DataTable tabla = controlAcceso.consultar_Reto_Intervalo(dateBot, dateTop);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = tabla;

            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dataGridView.DataSource = bindingSource;

        }

        /**
         * Devuelve un array con los años que tienen alguna reservacion asociada
         */
        public int[] annosReservaciones()
        {
            /* Consulta explicita asi que se rodea de un try & catch por si acaso */
            string consulta = "select distinct year(MomentoReservado) from Reservacion";
            SqlDataReader datos = null;
            try
            {
                datos = controlAcceso.ejecutarConsulta(consulta);
            }
            catch (SqlException ex)
            {

            }

            /* Cuenta cuantos años leyó para inicializar el array */
            int counter = 0;
            while (datos.Read())
            {
                counter++;
            }
            int[] years = new int[counter];

            /* Vuelve a consultar y usa el contador ahora como indice para ir metiendo los años en el array*/
            counter = 0;
            datos = controlAcceso.ejecutarConsulta(consulta);
            while (datos.Read())
            {
                years[counter] = Convert.ToInt32(datos.GetValue(0));
                counter++;
            }
            return years;
        }

        public void CargarReserv(DateTime Momento, bool tipo, DataGridView dgv)
        {
            DataTable dt = controlAcceso.ConsultarReserv(Momento, tipo);
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = dt;
            dgv.Refresh();
        }

        public void Cancelacion(DateTime Momento, string tel, bool tipo, bool auto, bool contar)
        {
            controlAcceso.EliminarReserv(Momento, tel, tipo, auto, contar);
            if (contar)
                MessageBox.Show("La reserva ha sido cancelada y contada en las veces canceladas", "Cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                MessageBox.Show("La reserva ha sido cancelada, pero no ha sido tomada en cuenta", "Cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void InicioFin(DateTime Momento, bool fin)
        {
            controlAcceso.FinalReserv(Momento, DateTime.Now.TimeOfDay, fin);
        }

        public void Participante(DateTime Momento, string tel, bool quitar)
        {
            if (quitar)
                controlAcceso.QuitPart(Momento);
            else //Va a agregarlo
                controlAcceso.AgPart(Momento, tel);
        }

    }
}
