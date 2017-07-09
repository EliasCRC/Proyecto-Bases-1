using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Configuration;
// Namespace de acceso a base de datos
using System.Data;
using System.Data.SqlClient;

/*Cambiar el namespace para que funcione!!*/
namespace ProyectoBases
{
    class AccesoBaseDatos
    {
        /*En Initial Catalog se agrega la base de datos propia. Intregated Security es para utilizar Windows Authentication*/
        //String conexion = "Data Source=10.1.4.55; Initial Catalog=DB_GRUPO1; Integrated Security=SSPI";

        /*En Initial Catalog se agrega la base de datos propia. Intregated Security = false es para utilizar SQL SERVER Authentication*/
        String conexion = "Data Source=10.1.4.55;User ID=B50657;Password=B50657; Initial Catalog=DB_GRUPO1; Integrated Security=false";
        
        /**
         * Constructor de la clase
         */
        public AccesoBaseDatos(){
        }

        /**
         * Permite ejecutar una consulta SQL, los datos son devueltos en un SqlDataReader
         * Recibe: La consulta sql a ejecutar
         * Modifica: Obtiene las tuplas que corresponden a la consulta recibida
         * Retorna: El datareader con los resultados de la ejecución de la consulta
         */
        public SqlDataReader ejecutarConsulta(String consulta)
        {
            //Prepara una nueva conexión a la bd y la abre
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();

            SqlDataReader datos = null;
            SqlCommand comando = null;

            try
            {
                //Ejecuta la consulta sql recibida por parámetro y la carga en un datareader
                comando = new SqlCommand(consulta, sqlConnection);
                datos = comando.ExecuteReader();
            }
            catch (SqlException ex)
            {

            }
            return datos;
        }

        /**
         * Permite ejecutar una consulta SQL, los datos son devueltos en un DataTable
         * * Recibe: La consulta sql a ejecutar
         * Modifica: Obtiene las tuplas que corresponden a la consulta recibida
         * Retorna: El datatable con los resultados de la ejecución de la consulta
         */
        public DataTable ejecutarConsultaTabla(String consulta)
        {
            //Prepara una nueva conexión a la bd y la abre
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();

            SqlCommand comando = new SqlCommand(consulta, sqlConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable table = new DataTable();

            dataAdapter.Fill(table);
			
			return table;
        }

        /*Método para ejecutar un insert, update o delete 
         Recibe: la sentencia sql a ejecutar
         Modifica: realiza el cambio en la base de datos de acuerdo al tipo de sentencia sql
         Retorna: el tipo de error que generó la consulta o cero si la ejecución fue exitosa*/
        public int actualizarDatos(String consulta)
        {
            int error = 0;

            //Prepara una nueva conexión a la bd y la abre
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();

            SqlCommand cons = new SqlCommand(consulta, sqlConnection);

            try
            {
                //Ejecuta la consulta sql recibida por parámetro
                cons.ExecuteNonQuery();
            }
            catch(SqlException e)
            {
                error = e.Number;
                Debug.WriteLine("Error: " + error);
            }

            finally
            {
                sqlConnection.Close();
            }

            return error;
        }

        /*Método para llamar al procedimiento almacenado de eliminarEstudiante 
         Recibe: el nombre del o los estudiantes que se va a eliminar
         Modifica: Elimina las tuplas que coincidan con el nombre recibido por parámetro
         Retorna: el tipo de error que generó la consulta o cero si la ejecución fue exitosa*/
       

        /*Método para llamar al procedimiento almacenado que permite agregar un nuevo usuario 
         Recibe: el usuario y la contraseña del nuevo usuario así como la cédula del estudiante a quién se asocia ese usuario
         Modifica: Agrega en la base de datos un nuevo usuario
         Retorna: 1 si se pudo guardar el nuevo usuario, un número diferente a cero que corresponde al número de error
         si no se pudo insertar*/
        public SqlDataReader consultarProductos()
        {
            int error = 0;
            SqlConnection con = new SqlConnection(conexion);
            
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
            SqlCommand cmd = new SqlCommand("consultar_Todos_Productos", con);
                
            SqlDataReader datos = null;
            try
            {

                        cmd.CommandType = CommandType.StoredProcedure;

                        /*Se abre la conexión*/
                        con.Open();

                        //Se ejecuta el procedimiento almacenado
                        datos =  cmd.ExecuteReader();
                        
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/

                        
            }
            catch (SqlException ex)
            {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;

            }
            return datos;
        }


        public SqlDataReader consultarVenta(DateTime fecha)
        {
            int error = 0;
            SqlConnection con = new SqlConnection(conexion);

            /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
             * de segundo parámetro recibe el sqlConnection
            */

            SqlCommand cmd = new SqlCommand("consultar_Venta", con);
            SqlDataReader datos = null;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@momento", SqlDbType.DateTime).Value = fecha;
                /*Se abre la conexión*/
                con.Open();

                //Se ejecuta el procedimiento almacenado
                datos = cmd.ExecuteReader();

                /*Se convierte en un valor entero lo que se devuelve el procedimiento*/


            }
            catch (SqlException ex)
            {
                /*Se capta el número de error si no se pudo insertar*/
                error = ex.Number;

            }
            return datos;
        }

        public DataTable consultar_venta_entreFechas (DateTime fechaUno, DateTime fechaDos)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    try
                    {
                        dataAdapter.SelectCommand = new SqlCommand("consultar_Ventas_Entre_Fechas", con);
                        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        dataAdapter.SelectCommand.Parameters.Add("@fecha1", SqlDbType.DateTime).Value = fechaUno;
                        dataAdapter.SelectCommand.Parameters.Add("@fecha2", SqlDbType.DateTime).Value = fechaDos;

                        DataSet dataSet = new DataSet();
                        dataAdapter.Fill(dataSet, "result_table");

                        return dataSet.Tables["result_table"];
                        
                    }
                    catch (SqlException ex)
                    {
                        return null;
                    }
                }
            }
        }

        public int crearVenta(DateTime fecha, string cedula)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("insertar_Venta", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@momento", SqlDbType.DateTime).Value = fecha;
                        cmd.Parameters.Add("@cedulaE", SqlDbType.VarChar).Value = cedula;
                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@MontoT", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }

        public int agregarContiene(string producto, DateTime fecha, int cantidad)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("insertar_Contiene", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@nombreP", SqlDbType.VarChar).Value = producto;
                        cmd.Parameters.Add("@momentoV", SqlDbType.DateTime).Value = fecha;
                        cmd.Parameters.Add("@cantidad", SqlDbType.TinyInt).Value = cantidad;
                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }

        public int borrarContiene(string producto, DateTime fecha)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("eliminar_Contiene", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@nombreP", SqlDbType.VarChar).Value = producto;
                        cmd.Parameters.Add("@momento", SqlDbType.DateTime).Value = fecha;
                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }


        public DataTable consultarTodoContiene(DateTime fecha)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    try
                    {
                        dataAdapter.SelectCommand = new SqlCommand("consultar_Todos_Contiene", con);
                        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        dataAdapter.SelectCommand.Parameters.Add("@momento", SqlDbType.DateTime).Value = fecha;

                        DataSet dataSet = new DataSet();
                        dataAdapter.Fill(dataSet, "Factura");

                        return dataSet.Tables["Factura"];

                    }
                    catch (SqlException ex)
                    {
                        return null;
                    }
                }
            }
        }

        public int cancelarVenta(DateTime fecha)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("eliminar_Venta", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@momento", SqlDbType.DateTime).Value = fecha;
                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }
        /******************************************Cliente***********************************************************************************************/
        public int Insertar_Cliente(string tel, string nombre, string apellido, int deuda, int numReser)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("insertar_Cliente", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@tel", SqlDbType.VarChar).Value = tel;
                        cmd.Parameters.Add("@nomb", SqlDbType.VarChar).Value = nombre;
                        cmd.Parameters.Add("@ape", SqlDbType.VarChar).Value = apellido;
                        cmd.Parameters.Add("@deuda", SqlDbType.Int).Value = deuda;
                        cmd.Parameters.Add("@numReserv", SqlDbType.Int).Value = numReser;
                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }

        public int Modificar_Cliente(string tel1,string tel2, string nombre, string apellido, int deuda, int numReser)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("modificar_Cliente", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@telviejo", SqlDbType.VarChar).Value = tel1;
                        cmd.Parameters.Add("@telnuevo", SqlDbType.VarChar).Value = tel2;
                        cmd.Parameters.Add("@nomb", SqlDbType.VarChar).Value = nombre;
                        cmd.Parameters.Add("@ape", SqlDbType.VarChar).Value = apellido;
                        cmd.Parameters.Add("@deuda", SqlDbType.Int).Value = deuda;
                        cmd.Parameters.Add("@numReserv", SqlDbType.Int).Value = numReser;
                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }

        public int Eliminar_Cliente(String tel)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("eliminar_Cliente", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@tel", SqlDbType.VarChar).Value = tel;
                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }
        /*****************************************Frecuentes********************************************************************************************/
        public int Insertar_Frecuente(string tel, string num)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("insertar_Frecuente", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@tel", SqlDbType.VarChar).Value = tel;
                        cmd.Parameters.Add("@numR", SqlDbType.TinyInt).Value = num;
                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }

        public int Modificar_Frecuente(string tel1, string tel2, string num)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("modificar_Frecuente", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@telViejo", SqlDbType.VarChar).Value = tel1;
                        cmd.Parameters.Add("@telNuevo", SqlDbType.VarChar).Value = tel2;
                        cmd.Parameters.Add("@numR", SqlDbType.TinyInt).Value = num;
                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }

        public int Eliminar_Frecuente(string tel)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("eliminar_Frecuente", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@tel", SqlDbType.VarChar).Value = tel;
                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }
        /*******************************************Reservacion Normal******************************************************************************************/
        public int Insertar_ReservacionNormal(string tel1, string tel2, string num)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("modificar_Frecuente", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@telViejo", SqlDbType.VarChar).Value = tel1;
                        cmd.Parameters.Add("@telNuevo", SqlDbType.VarChar).Value = tel2;
                        cmd.Parameters.Add("@numR", SqlDbType.TinyInt).Value = num;
                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }

        public int Modificar_ReservacionNormal()
        {
            return 0;
        }

        public int Eliminar_ReservacionNormal()
        {
            return 0;
        }
        /********************************************Retos*****************************************************************************************/
        public int Insertar_Retos()
        {
            return 0;
        }

        public int Modificar_Retos()
        {
            return 0;
        }

        public int Eliminar_Retos()
        {
            return 0;
        }
        /*******************************************contenidos******************************************************************************************/
        public int Insertar_Contenidos(string producto, string fecha, string cantidad)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("insertar_Contiene", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@nombreP", SqlDbType.VarChar).Value = producto;
                        cmd.Parameters.Add("@momentoV", SqlDbType.DateTime).Value = fecha;
                        cmd.Parameters.Add("@cantidad", SqlDbType.TinyInt).Value = cantidad;
                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }

        public int Modificar_Contenidos(string producto1, string producto2, DateTime fecha1, DateTime fecha2, int cantidad)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("modificar_Contiene", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@nombrePViejo", SqlDbType.VarChar).Value = producto1;
                        cmd.Parameters.Add("@nombreP", SqlDbType.VarChar).Value = producto2;
                        cmd.Parameters.Add("@momentoV", SqlDbType.DateTime).Value = fecha1;
                        cmd.Parameters.Add("@momentoVViejo", SqlDbType.DateTime).Value = fecha2;
                        cmd.Parameters.Add("@cantidad", SqlDbType.TinyInt).Value =cantidad;
                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }

        public int Eliminar_Contenidos(string producto, string fecha)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("eliminar_Contiene", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@nombreP", SqlDbType.VarChar).Value = producto;
                        cmd.Parameters.Add("@momentoV", SqlDbType.DateTime).Value = fecha;
                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }
        /*******************************************Participantes******************************************************************************************/
        public int Insertar_Participantes()
        {
            return 0;
        }

        public int Modificar_Participantes()
        {
            return 0;
        }

        public int Eliminar_Participantes()
        {
            return 0;
        }
        /*******************************************Encargados******************************************************************************************/
        public int Insertar_Encargados()
        {
            return 0;
        }

        public int Modificar_Encargados()
        {
            return 0;
        }

        public int Eliminar_Encargados()
        {
            return 0;
        }
        /****************************************Productos*********************************************************************************************/
        public int Insertar_Producto(string nombre, string precio)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("insertar_Producto", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                        cmd.Parameters.Add("@precio", SqlDbType.Int).Value = precio;
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }

        public int Modificar_Producto()
        {
            return 0;
        }

        public int Eliminar_Producto(string nombre)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("eliminar_Producto", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }
        /****************************************Venta*********************************************************************************************/
        public int Insertar_Venta(string fecha, string cedula)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("insertar_Venta", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@momento", SqlDbType.DateTime).Value = fecha;
                        cmd.Parameters.Add("@cedulaE", SqlDbType.VarChar).Value = cedula;
                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@MontoT", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }

        public int Modificar_Venta(string fecha1, string fecha2, string cedula, string monto)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("insertar_Venta", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@momentoViejo", SqlDbType.DateTime).Value = fecha1;
                        cmd.Parameters.Add("@momento", SqlDbType.DateTime).Value = fecha2;
                        cmd.Parameters.Add("@cedulaE", SqlDbType.VarChar).Value = cedula;
                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@MontoT", SqlDbType.Int).Value = monto;
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }

        public int Eliminar_Venta(string fecha)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("eliminar_Venta", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@momento", SqlDbType.DateTime).Value = fecha;
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);

                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar*/
                        error = ex.Number;
                        return error;
                    }
                }
            }
        }
        /*************************************************************************************************************************************/
    }

}
