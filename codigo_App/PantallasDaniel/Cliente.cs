using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoBases
{
    class Cliente
    {
        AccesoBaseDatos bd;

        public Cliente()
        {
            bd = new AccesoBaseDatos();
        }

        /**
         * Recibe: nombre y apellido de los clientes a buscar
         * Retorna: El datatable con los resultados de la ejecución de la consulta
         */
        public DataTable obtenerClientes(string nombre, string apellido)
        {
            DataTable tabla = null;
            if (String.IsNullOrWhiteSpace(nombre) && !String.IsNullOrWhiteSpace(apellido))
            {
                tabla = bd.ejecutarConsultaTabla("Exec consultar_ClienteNombre null, '" + apellido + "'");
            }
            else if (String.IsNullOrWhiteSpace(apellido) && !String.IsNullOrWhiteSpace(nombre)) {
                tabla = bd.ejecutarConsultaTabla("Exec consultar_ClienteNombre '" + nombre + "', null");
            } else if (!String.IsNullOrWhiteSpace(apellido) && !String.IsNullOrWhiteSpace(nombre))
            {
                tabla = bd.ejecutarConsultaTabla("Exec consultar_ClienteNombre '" + nombre + "', '" + apellido + "'");
            }
            return tabla;
        }

        /**
         * Recibe: nombre y apellido de los clientes frecuentes a buscar
         * Retorna: El datatable con los resultados de la ejecución de la consulta
         */
        public DataTable obtenerFrecuentes(string nombre, string apellido)
        {
            DataTable tabla = null;
            if (String.IsNullOrWhiteSpace(nombre) && !String.IsNullOrWhiteSpace(apellido))
            {
                tabla = bd.ejecutarConsultaTabla("Exec consultar_Frecuente_PorNombre null, '" + apellido + "'");
            }
            else if (String.IsNullOrWhiteSpace(apellido) && !String.IsNullOrWhiteSpace(nombre))
            {
                tabla = bd.ejecutarConsultaTabla("Exec consultar_Frecuente_PorNombre '" + nombre + "', null");
            }
            else if (!String.IsNullOrWhiteSpace(apellido) && !String.IsNullOrWhiteSpace(nombre))
            {
                tabla = bd.ejecutarConsultaTabla("Exec consultar_Frecuente_PorNombre '" + nombre + "', '" + apellido + "'");
            }
            return tabla;
        }

        /**
         * Recibe: nombre y apellido de los clientes esporádicos a buscar
         * Retorna: El datatable con los resultados de la ejecución de la consulta
         */
        public DataTable obtenerEsporadicos(string nombre, string apellido)
        {
            DataTable tabla = null;
            if (String.IsNullOrWhiteSpace(nombre) && !String.IsNullOrWhiteSpace(apellido))
            {
                tabla = bd.ejecutarConsultaTabla("Exec consultar_EsporadicoNombre null, '" + apellido + "'");
            }
            else if (String.IsNullOrWhiteSpace(apellido) && !String.IsNullOrWhiteSpace(nombre))
            {
                tabla = bd.ejecutarConsultaTabla("Exec consultar_EsporadicoNombre '" + nombre + "', null");
            }
            else if (!String.IsNullOrWhiteSpace(apellido) && !String.IsNullOrWhiteSpace(nombre))
            {
                tabla = bd.ejecutarConsultaTabla("Exec consultar_EsporadicoNombre '" + nombre + "', '" + apellido + "'");
            }
            
            return tabla;
        }

        /**
         * Recibe: teléfono del cliente a buscar
         * Retorna: El datatable con los resultados de la ejecución de la consulta
         */
        public DataTable obtenerClientes(string telefono)
        {
            DataTable tabla = null;
            if (String.IsNullOrWhiteSpace(telefono)) { telefono = ""; }
            tabla = bd.ejecutarConsultaTabla("Exec consultar_ClienteTelefono '" + telefono + "'");
            return tabla;
        }

        /**
         * Recibe: teléfono del cliente esporádico a buscar
         * Retorna: El datatable con los resultados de la ejecución de la consulta
         */
        public DataTable obtenerEsporadicos(string telefono)
        {
            DataTable tabla = null;
            if (String.IsNullOrWhiteSpace(telefono)) { telefono = ""; }
            tabla = bd.ejecutarConsultaTabla("Exec consultar_EsporadicoTelefono '" + telefono + "'");
            return tabla;
        }

        /**
         * Recibe: teléfono del cliente frecuente a buscar
         * Retorna: El datatable con los resultados de la ejecución de la consulta
         */
        public DataTable obtenerFrecuentes(string telefono)
        {
            DataTable tabla = null;
            if (String.IsNullOrWhiteSpace(telefono)) { telefono = ""; }
            tabla = bd.ejecutarConsultaTabla("Exec consultar_FrecuenteTelefono  '" + telefono + "'");
            return tabla;
        }

        /**
         * Recibe: teléfono del cliente esporádico a cambiar de estado
         * Retorna: 0 en caso exitoso, código de error en caso contrario
         */
        public int hacerFrecuente(string telefono)
        {
            return bd.actualizarDatos("Exec hacerFrecuente " + telefono);
        }

        /**
         * Recibe: teléfono del cliente a eliminar
         * Retorna: 0 en caso exitoso, código de error en caso contrario
         */
        public int eliminarCliente(string telefono)
        {
            return bd.actualizarDatos("Exec borrar_Cliente " + telefono);
        }

        public int quitarEstadoFrecuente(string telefono)
        {
            return bd.actualizarDatos("Exec quitarfrecuente " + telefono);
        }

        public int agregarHorarioFrec(string horario, string telefono, string cedEncargado)
        {
            Console.WriteLine("Exec agregarHorarioFrec " + telefono + ", null, '" + horario + "' ," + cedEncargado);
            return bd.actualizarDatos("Exec agregarHorarioFrec " + telefono + ", null, '" + horario + "' ," + cedEncargado);
        }

        public int agregarCliente(string telefono, string nombre, string apellido)
        {
            if (String.IsNullOrWhiteSpace(apellido))
            {
                apellido = "";
            }
            return bd.actualizarDatos("Exec crear_Cliente " + telefono + ", '" + nombre + "', '" + apellido + "'");
        }

        public int aumentarDeuda(string telefono, string deuda)
        {
            return bd.actualizarDatos("Exec modificar_Deuda " + telefono + " ," + deuda);
        }

        public int reducirDeuda(string telefono, string deuda)
        {
            return bd.actualizarDatos("Exec modificar_Deuda " + telefono + " , -" + deuda);
        }

        public SqlDataReader obtenerHorariosFrec(string telefono)
        {
            DateTime hoy = DateTime.Today;
            SqlDataReader datos = null;
            try
            {
                datos = bd.ejecutarConsulta("Exec verHorarios " + telefono + ", '" + hoy.ToString() + "'");
            }
            catch (SqlException)
            {

            }
            return datos;
        }

        public int eliminarHorario(int dia, int hora, string telefono)
        {
            DateTime hoy = DateTime.Today;
            return bd.actualizarDatos("Exec eliminarHorarioFrecuente " + dia + ", " + hora + 
                ", '" + hoy.ToString() + "', " + telefono);
        }

        public int modificarCliente(string telViejo, string telNuevo, string nombre, string apellido)
        {
            if (String.IsNullOrWhiteSpace(apellido))
            {
                Console.WriteLine("aaa");
                return bd.actualizarDatos("Exec editar_Cliente " + telViejo + ", " + telNuevo + ", '" + nombre + "', ''");
            }
            else
            {
                return bd.actualizarDatos("Exec editar_Cliente " + telViejo + ", " + telNuevo + ", '" + nombre + "', '" + apellido + "'");
            }
            
        }

        public int reiniciarCanceladas(string telefono)
        { 
            return bd.actualizarDatos("Exec reiniciarCanceladas '" + telefono + "'");
        }

        public int reiniciarAutomaticas(string telefono)
        {
            return bd.actualizarDatos("Exec reiniciarCanceladasAuto '" + telefono + "'");
        }
    }
}
