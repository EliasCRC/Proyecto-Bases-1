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
    class Contiene
    {
        AccesoBaseDatos bd;
        public Contiene()
        {
            bd = new AccesoBaseDatos();
        }

        public int agregar_Contiene(string producto, DateTime fecha,int cantidad)
        {
            int error = 0;
            try
            {
                error = bd.agregarContiene(producto,fecha,cantidad);
            }
            catch
            {

            }
            return error;
        }

        public DataTable consultar_Contiene(DateTime fecha)
        {
            DataTable datos = null;
            try
            {
                datos = bd.consultarTodoContiene(fecha);

            }
            catch (SqlException ex)
            {

            }
            return datos;
        }
        
        public int modificarContiene(string producto1, string producto2, DateTime fecha1, DateTime fecha2, int cantidad)
        {
            int error = 0;
            try
            {
                bd.Modificar_Contenidos(producto1,producto2,fecha1,fecha2,cantidad);
            }
            catch
            {
                error = -1;
            }
            return error;

        }
        public int eliminarContiene(string producto, DateTime fecha)
        {
            int error = 0;
            try
            {
                bd.borrarContiene(producto, fecha);
            }
            catch
            {

            }
            return error;

        }
    }
}
