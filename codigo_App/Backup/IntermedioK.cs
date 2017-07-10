using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoK;
// Namespace de acceso a base de datos
using System.Data;
using System.Data.SqlClient;

namespace ProyectoBases
{
    class IntermedioK
    {
        AccesoBaseDatosK abd;


        public IntermedioK() 
        {
            abd = new AccesoBaseDatosK();
        }

        public void CargarReserv(DateTime Momento, bool tipo, DataGridView dgv)
        {
            DataTable dt = abd.ConsultarReserv(Momento, tipo);
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = dt;
            dgv.Refresh();
        }

        public void Cancelacion(DateTime Momento, string tel, bool tipo, bool auto, bool contar)
        {
            abd.EliminarReserv(Momento, tel, tipo, auto, contar);
            if(contar)
                MessageBox.Show("La reserva ha sido cancelada y contada en las veces canceladas", "Cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
               MessageBox.Show("La reserva ha sido cancelada, pero no ha sido tomada en cuenta", "Cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void InicioFin(DateTime Momento, bool fin)
        {
            abd.FinalReserv(Momento, DateTime.Now.TimeOfDay, fin);
        }

        public void Participante(DateTime Momento,  string tel, bool quitar)
        {
            if (quitar)
                abd.QuitPart(Momento);
            else //Va a agregarlo
                abd.AgPart(Momento, tel);
        }
    }
}
