using System;
using System.Collections.Generic;
using System.Configuration;
// Namespace de acceso a base de datos
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

/*Cambiar el namespace para que funcione!!*/
namespace ProyectoBases
{
    class AccesoBaseDatos
    {
        /*En Initial Catalog se agrega la base de datos propia. Intregated Security es para utilizar Windows Authentication*/
        String conexion = "Data Source=10.1.4.55; Initial Catalog=DB_GRUPO1; Integrated Security=SSPI";

        /*En Initial Catalog se agrega la base de datos propia. Intregated Security = false es para utilizar SQL SERVER Authentication*/
        //string conexion = "Data Source=10.1.4.55;User ID=Gaudy;Password=xxxxx; Initial Catalog=gaudyblanco; Integrated Security=false";
        
        /**
         * Constructor de la clase
         */
        public AccesoBaseDatos(){
        }

        /**
        * Metodo para llamar al Procedimiento almacenado de Login
        */
        public bool login(string usuario, string password)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("Login", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@pLoginName", SqlDbType.VarChar).Value = usuario;
                        cmd.Parameters.Add("@pPassword", SqlDbType.VarChar).Value = password;

                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@isInDB", SqlDbType.Bit).Direction = ParameterDirection.Output;

                        /*Se abre la conexión*/
                        con.Open();

                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();

                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        int value = Convert.ToInt32(cmd.Parameters["@isInDB"].Value);

                        /*Si el procedimiento devuelve 1 es que si se encuentra en la BD*/
                        if (value == 1)
                        {
                            return true;
                        }

                        /*Si devuelve 0 es que no se encuentra en la BD*/
                        else
                        {
                            return false;
                        }

                    }
                    catch (SqlException ex)
                    {
                        return false;
                    }
                }
            }

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
         * Recibe: La consulta sql a ejecutar
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

            try
            {
                dataAdapter.Fill(table);
            }
            catch (SqlException)
            {

            }


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

        public DataTable ConsultarReserv(DateTime Momento, bool tipo)
        {
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand comando;

            if (tipo) //Es reto
                comando = new SqlCommand("consultar_reto_participantes", con);
            else //Es equipo completo
                comando = new SqlCommand("consultar_cliente_equipocompleto", con);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@Momento", SqlDbType.DateTime).Value = Momento;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
            //SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "ret");
            DataTable table = ds.Tables["ret"];
            return table;
        }

        public void EliminarReserv(DateTime Momento, string tel, bool tipo, bool auto, bool contar)
        {
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd;
            if (tipo) //Es reto
            {
                cmd = new SqlCommand("cancelar_reservacion", con);
            }
            else //Equipo completo
            {
                if (auto) //Puede ser automatica
                    cmd = new SqlCommand("cancelar_reservacion_automatica", con);
                else
                    cmd = new SqlCommand("cancelar_reservacion", con);
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@momento", SqlDbType.DateTime).Value = Momento;
            cmd.Parameters.Add("@telefonoCliente", SqlDbType.VarChar).Value = tel;
            cmd.Parameters.Add("@aumentarContador", SqlDbType.Bit).Value = contar;

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Deleted: " + Momento);
            }
            catch (SqlException e)
            {
                int error = e.Number;
                Console.WriteLine("Error: " + error);
            }

            finally
            {
                con.Close();
            }
        }

        public void FinalReserv(DateTime Momento, TimeSpan Actual, bool fin)
        {
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd;
            string par2;
            if (fin) //Termina la reserva
            {
                cmd = new SqlCommand("final_reservacion", con);
                par2 = "@horaFinal";
            }
            else //Esta empezando
            {
                cmd = new SqlCommand("inicio_reservacion", con);
                par2 = "@horaInicio";
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@momento", SqlDbType.DateTime).Value = Momento;
            cmd.Parameters.Add(par2, SqlDbType.Time).Value = Actual;
            cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                int error = e.Number;
                Console.WriteLine("Error: " + error);
            }

            finally
            {
                con.Close();
            }
        }

        public void AgPart(DateTime Momento, string Telefono)
        {
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("agregar_participante_reto", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = Telefono;
            cmd.Parameters.Add("@momento", SqlDbType.DateTime).Value = Momento;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                int error = e.Number;
                Console.WriteLine("Error: " + error);
            }

            finally
            {
                con.Close();
            }
        }

        public void QuitPart(DateTime Momento)
        {
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("quitar_participante_reto", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@momento", SqlDbType.DateTime).Value = Momento;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                int error = e.Number;
                Console.WriteLine("Error: " + error);
            }

            finally
            {
                con.Close();
            }
        }

        /**
         * Metodo para llamar al Procedimiento almacenado para consultar las ventas entre dos fechas
         */
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

        /**
         * Metodo para llamar al Procedimiento almacenado para consultar las reservaciones entre dos fechas
         */
        public DataTable consultar_reservaciones(DateTime fechaUno, DateTime fechaDos)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    try
                    {
                        dataAdapter.SelectCommand = new SqlCommand("consultar_reservaciones", con);
                        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        dataAdapter.SelectCommand.Parameters.Add("@momentoBase", SqlDbType.DateTime).Value = fechaUno;
                        dataAdapter.SelectCommand.Parameters.Add("@momentoTop", SqlDbType.DateTime).Value = fechaDos;

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

        /**
         * Metodo para llamar al Procedimiento almacenado para consultar las reservaciones
         * de equipo completo entre dos fechas
         */
        public DataTable consultar_EquipoCompleto_Intervalo(DateTime fechaUno, DateTime fechaDos)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    try
                    {
                        dataAdapter.SelectCommand = new SqlCommand("consultar_EquipoCompleto_Intervalo", con);
                        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        dataAdapter.SelectCommand.Parameters.Add("@momentoBase", SqlDbType.DateTime).Value = fechaUno;
                        dataAdapter.SelectCommand.Parameters.Add("@momentoTop", SqlDbType.DateTime).Value = fechaDos;

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

        /**
         * Metodo para llamar al Procedimiento almacenado para consultar los retos entre dos fechas
         */
        public DataTable consultar_Reto_Intervalo(DateTime fechaUno, DateTime fechaDos)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    try
                    {
                        dataAdapter.SelectCommand = new SqlCommand("consultar_Reto_Intervalo", con);
                        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        dataAdapter.SelectCommand.Parameters.Add("@momentoBase", SqlDbType.DateTime).Value = fechaUno;
                        dataAdapter.SelectCommand.Parameters.Add("@momentoTop", SqlDbType.DateTime).Value = fechaDos;

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

        public bool UsuarioEsAdmin(string usuario)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("UsuarioEsAdmin", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@pLoginName", SqlDbType.VarChar).Value = usuario;

                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@esAdmin", SqlDbType.Bit).Direction = ParameterDirection.Output;

                        /*Se abre la conexión*/
                        con.Open();

                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();

                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        int value = Convert.ToInt32(cmd.Parameters["@esAdmin"].Value);

                        /*Si el procedimiento devuelve 1 es que si se encuentra en la BD*/
                        if (value == 1)
                        {
                            return true;
                        }

                        /*Si devuelve 0 es que no se encuentra en la BD*/
                        else
                        {
                            return false;
                        }

                    }
                    catch (SqlException ex)
                    {
                        return false;
                    }
                }
            }
        }

        public string obtenerCedulaUsuario()
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("obtenerCedulaUsuario", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = UsuarioActual.UserName;

                        //se prepara el parámetro de retorno del procedimiento almacenado
                        var outParam = new SqlParameter("@cedula", SqlDbType.VarChar);
                        outParam.Size = 20;
                        outParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outParam);

                        /*Se abre la conexión*/
                        con.Open();
                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();

                        /*Se convierte en un valor entero lo que se devuelve el procedimiento*/
                        string cedula = Convert.ToString(cmd.Parameters["@cedula"].Value);
                        Console.WriteLine(cedula);
                        return cedula;

                    }
                    catch (SqlException ex)
                    {
                        return null;
                    }
                }
            }
        }

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
        public int Insertar_Cliente(String tel, String nombre, String apellido, int deuda, int numReser)
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

        public int Modificar_Cliente(String tel1, String tel2, String nombre, String apellido, int deuda, int numReser)
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
                        cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = nombre;
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
        public int Insertar_Frecuente(string tel, int num)
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

        public int Modificar_Frecuente(string tel1, string tel2, int num)
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
        public int Insertar_ReservacionNormal(DateTime momento, string telref, string cedula, Boolean auto, string tel)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("insertar_DeEquipoCompleto", con))
                {
                    try
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@momento", SqlDbType.DateTime).Value = momento;
                        cmd.Parameters.Add("@horaInicioReal", SqlDbType.Time).Value = DBNull.Value;
                        cmd.Parameters.Add("@horaFinalizacionReal", SqlDbType.Time).Value = DBNull.Value;
                        cmd.Parameters.Add("@telReferencia", SqlDbType.VarChar).Value = telref;
                        cmd.Parameters.Add("@cedulaEncargado", SqlDbType.VarChar).Value = cedula;
                        cmd.Parameters.Add("@auto", SqlDbType.Bit).Value = auto;
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

        public int Modificar_ReservacionNormal(DateTime momentoV, DateTime momentoN, string telref, string cedula, Boolean auto, string tel)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("modificar_DeEquipoCompleto", con))
                {
                    try
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@momentoV", SqlDbType.DateTime).Value = momentoV;
                        cmd.Parameters.Add("@momentoN", SqlDbType.DateTime).Value = momentoN;
                        cmd.Parameters.Add("@horaInicioReal", SqlDbType.Time).Value = DBNull.Value;
                        cmd.Parameters.Add("@horaFinalizacionReal", SqlDbType.Time).Value = DBNull.Value;
                        cmd.Parameters.Add("@telReferencia", SqlDbType.VarChar).Value = telref;
                        cmd.Parameters.Add("@cedulaEncargado", SqlDbType.VarChar).Value = cedula;
                        cmd.Parameters.Add("@auto", SqlDbType.Bit).Value = auto;
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

        public int Eliminar_ReservacionNormal(DateTime momento)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("eliminar_Reservacion", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@momento", SqlDbType.DateTime).Value = momento;
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
        /********************************************Retos*****************************************************************************************/
        public int Insertar_Retos(DateTime momento, string telr, string cedula, string telC)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("insertar_Reto", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@momento", SqlDbType.DateTime).Value = momento;
                        cmd.Parameters.Add("@horaInicioReal", SqlDbType.Time).Value = DBNull.Value;
                        cmd.Parameters.Add("@horaFinalizacionReal", SqlDbType.Time).Value = DBNull.Value;
                        cmd.Parameters.Add("@telReferencia", SqlDbType.VarChar).Value = telr;
                        cmd.Parameters.Add("@cedulaEncargado", SqlDbType.VarChar).Value = cedula;
                        cmd.Parameters.Add("@telCliente", SqlDbType.VarChar).Value = telC;
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

        public int Modificar_Retos(DateTime momentoV, DateTime momentoN, string telr, string cedula, string telC)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("modificar_Reto", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@momentoV", SqlDbType.DateTime).Value = momentoV;
                        cmd.Parameters.Add("@momentoN", SqlDbType.DateTime).Value = momentoN;
                        cmd.Parameters.Add("@horaInicioReal", SqlDbType.Time).Value = DBNull.Value;
                        cmd.Parameters.Add("@horaFinalizacionReal", SqlDbType.Time).Value = DBNull.Value;
                        cmd.Parameters.Add("@telReferencia", SqlDbType.VarChar).Value = telr;
                        cmd.Parameters.Add("@cedulaEncargado", SqlDbType.VarChar).Value = cedula;
                        cmd.Parameters.Add("@telCliente", SqlDbType.VarChar).Value = telC;
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
        /*******************************************contenidos******************************************************************************************/
        public int Insertar_Contenidos(string producto, DateTime fecha, int cantidad)
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

        public int Eliminar_Contenidos(string producto, DateTime fecha)
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
        public int Insertar_Encargados(string cedula, string nombre)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("insertar_Encargado", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@cedula", SqlDbType.VarChar).Value = cedula;
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

        public int Modificar_Encargados(string cedula1, string cedula2, string nombre)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("modificar_Encargado", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@cedulaVieja", SqlDbType.VarChar).Value = cedula1;
                        cmd.Parameters.Add("@cedulaNueva", SqlDbType.VarChar).Value = cedula2;
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

        public int Eliminar_Encargados(string cedula)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                */
                using (SqlCommand cmd = new SqlCommand("eliminar_Encargado", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@cedula", SqlDbType.VarChar).Value = cedula;
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
        /****************************************Productos*********************************************************************************************/
        public int Insertar_Producto(string nombre, int precio)
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

        public int Modificar_Producto(string nombreV, string nombre, int precio)
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
                        cmd.Parameters.Add("@nombreViejo", SqlDbType.VarChar).Value = nombreV;
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
        public int Insertar_Venta(DateTime fecha, string cedula)
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

        public int Modificar_Venta(DateTime fecha1, DateTime fecha2, string cedula, int monto)
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

        public int Eliminar_Venta(DateTime fecha)
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

    }
}
