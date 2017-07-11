using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBases
{
    class Encargado
    {
        private AccesoBaseDatos controlAcceso;

        /**
         * Constructor de la clase, inicializa el acceso a la base
         */
        public Encargado()
        {
            controlAcceso = new AccesoBaseDatos();
        }

        /**
         * Metodo para verificar si usuario es admin
         */
        public bool esAdmin(string usuario)
        {
            return controlAcceso.UsuarioEsAdmin(usuario);
        }

        /**
         * Metodo para hacer el login a un usuario
         */
        public bool login (string usuario, string contrasena)
        {
            return controlAcceso.login(usuario, contrasena);
        }

        public string getCedula()
        {
            return controlAcceso.obtenerCedulaUsuario();
        }
    }
}
