using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ProyectoBases
{
    class Producto
    {
        AccesoBaseDatos bd;
        public Producto()
        {
            bd = new AccesoBaseDatos();
        }

        public SqlDataReader obtenerListaNombresProductos()
        {
            SqlDataReader datos = null;
            try
            {
                datos = bd.consultarProductos();

                                                }
            catch (SqlException ex)
            {

            }
            return datos;
        }
    }
}
