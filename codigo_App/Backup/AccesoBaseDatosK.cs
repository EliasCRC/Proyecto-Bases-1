using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Configuration;
// Namespace de acceso a base de datos
using System.Data;
using System.Data.SqlClient;

namespace AccesoK
{
    class AccesoBaseDatosK
    {
        string conexion = "Data Source=10.1.4.55; User ID=B55519; Password=B55519; Initial Catalog=DB_GRUPO1; Integrated Security=false";

        public AccesoBaseDatosK() { } //Constructor

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
            catch(SqlException e)
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
    }
}
