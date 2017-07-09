using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoBases
{
    class Venta
    {
        AccesoBaseDatos bd;
        public Venta()
        {
            bd = new AccesoBaseDatos();
        }

        public int crearVenta(DateTime fecha, string cedula)
        {
            int error = 0;
            try
            {
                error = bd.crearVenta(fecha, cedula);
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
                error = bd.cancelarVenta(fecha);
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
                datos = bd.consultarVenta(fecha);
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
