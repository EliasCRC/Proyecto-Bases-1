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
                datos = bd.ejecutarConsulta("Select	distinct	nombre	from Producto");

                                                }
            catch (SqlException ex)
            {

            }
            return datos;
        }
    }
}
