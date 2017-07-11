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
        String conexion = "Data Source=10.1.4.55; Initial Catalog=DB_GRUPO1; Integrated Security=SSPI";

        /*En Initial Catalog se agrega la base de datos propia. Intregated Security = false es para utilizar SQL SERVER Authentication*/
        //string conexion = "Data Source=10.1.4.55;User ID=Gaudy;Password=xxxxx; Initial Catalog=gaudyblanco; Integrated Security=false";
        
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
        /**public int agregarUsuario(string usuario, string password, string cedula)
        {
            int error = 0;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                /*El sqlCommand recibe como primer parámetro el nombre del procedimiento almacenado, 
                 * de segundo parámetro recibe el sqlConnection
                /
                using (SqlCommand cmd = new SqlCommand("agregarUsuario", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //Se preparan los parámetros que recibe el procedimiento almacenado
                        cmd.Parameters.Add("@pLogin", SqlDbType.VarChar).Value = usuario;
                        cmd.Parameters.Add("@pPassword", SqlDbType.VarChar).Value = password;
                        cmd.Parameters.Add("@cedula", SqlDbType.VarChar).Value = cedula;

                        //se prepara el parámetro de retorno del procedimiento almacenado
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                        /*Se abre la conexión
                        con.Open();

                        //Se ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();

                        /*Se convierte en un valor entero lo que se devuelve el procedimiento
                        return Convert.ToInt32(cmd.Parameters["@estado"].Value);
                        
                    }
                    catch (SqlException ex)
                    {
                        /*Se capta el número de error si no se pudo insertar
                        error = ex.Number;
                        return error;
                    }
                }
            }

        }
    **/

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
        

    }
}
