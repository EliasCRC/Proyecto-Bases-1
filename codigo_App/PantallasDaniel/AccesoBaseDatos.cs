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
        String conexion = "Data Source=10.1.4.55;User ID = B54621; Password=B54621; Initial Catalog = DB_GRUPO1; Integrated Security = false";

        /*En Initial Catalog se agrega la base de datos propia. Intregated Security = false es para utilizar SQL SERVER Authentication*/
        //string conexion = "Data Source=10.1.4.55;User ID=Gaudy;Password=xxxxx; Initial Catalog=gaudyblanco; Integrated Security=false";
        
        /**
         * Constructor de la clase
         */
        public AccesoBaseDatos(){
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
    }
}
