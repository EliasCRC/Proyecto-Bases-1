using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBases
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ResumenVentas(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)));
            //Application.Run(new ResumenReservaciones(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)));
            Application.Run(new VistaLogin());
        }
    }
}
