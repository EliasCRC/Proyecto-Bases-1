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
    class Venta
    {
        private AccesoBaseDatos controlAcceso;

        /**
         * Constructor de la clase 
         */
        public Venta()
        {
            controlAcceso = new AccesoBaseDatos();
        }

        /**
         * Llena un datagrid con las ventas del mes según el mes y año ingresado
         */
        public void llenarTablaResumenVentas_DelMes(DataGridView dataGridView, DateTime monthDate)
        {
            DataTable tabla = controlAcceso.consultar_venta_entreFechas(monthDate, monthDate.AddMonths(1).AddDays(-1));

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = tabla;

            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dataGridView.DataSource = bindingSource;
        }

        /**
         * Llena un datagrid con las ventas que hay entre dos intervalos de tiempo
         */
        public void llenarTablaVentas_Intervalo(DataGridView dataGridView, DateTime monthDateBot, DateTime monthDateTop)
        {
            DataTable tabla = controlAcceso.consultar_venta_entreFechas(monthDateBot, monthDateTop);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = tabla;

            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dataGridView.DataSource = bindingSource;
        }

        /**
         * Devuelve un array con los años que tienen alguna venta asociada
         */
        public int[] annosVentas()
        {
            string consulta = "select distinct year(MomentoVenta) from Venta";
            SqlDataReader datos = null;
            try
            {
                datos = controlAcceso.ejecutarConsulta(consulta);
            }
            catch (SqlException ex)
            {

            }

            int counter = 0;
            while (datos.Read())
            {
                counter++;
            }
            int[] years = new int[counter];
            counter = 0;
            datos = controlAcceso.ejecutarConsulta(consulta);
            while (datos.Read())
            {
                years[counter] = Convert.ToInt32(datos.GetValue(0));
                counter++;
            }
            return years;
        }

        public int crearVenta(DateTime fecha, string cedula)
        {
            int error = 0;
            try
            {
                error = controlAcceso.crearVenta(fecha, cedula);
            }
            catch
            {

            }
            return error;
        }

        public int cancelarVenta(DateTime fecha)
        {
            int error = 0;
            try
            {
                error = controlAcceso.cancelarVenta(fecha);
            }
            catch
            {

            }
            return error;
        }

        public string getMontoTotal(DateTime fecha)
        {
            int error = 0;
            try
            {
                SqlDataReader datos;
                datos = controlAcceso.consultarVenta(fecha);
                datos.Read();
                return datos.GetValue(1).ToString();

            }
            catch
            {

            }
            return "";

        }

    }
}
