using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoBases
{
    class Venta
    {
        AccesoBaseDatos bd;
        public Venta()
        {
            bd = new AccesoBaseDatos();
        }

    }
}
