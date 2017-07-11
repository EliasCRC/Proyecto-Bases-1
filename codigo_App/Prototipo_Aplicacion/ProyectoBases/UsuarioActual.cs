using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBases
{
    /* Clase estática para indicar el usuario actual en uso */
    public class UsuarioActual
    {
        public static string UserName;

        public static void setName(string name) { UserName = name; }
    }
}
