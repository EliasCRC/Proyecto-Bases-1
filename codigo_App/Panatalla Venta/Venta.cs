using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Venta
    {
        AccesoBaseDatos bd;
        public Venta()
        {
            bd = new AccesoBaseDatos();
        }

        private void llenarCombobox(ComboBox combobox)
        {
            //Se	obtiene	un	dataReader	con	todos	los	nombres	de	los	estudiantes	de	la  base    de datos

            SqlDataReader datos = estudiante.obtenerListaNombresEstudiantes();
            /*Si	existen	datos	en	la	base	de	datos	se	carga	como	primer	elemento	del	
combobox	un	dato	"Seleccione"
            y	luego	se	cargan	todos	los	datos	de	la	base	de	datos*/
            if (datos != null)
            {
                combobox.Items.Add("Seleccione");
                while (datos.Read())
                {
                    combobox.Items.Add(datos.GetValue(0));
                }
            }
            /*Si	no	hay	tuplas	en	la	base	de	datos	se	limpia el	combobox	y	se	carga	
unicamente	el	valor	"Seleccione"*/
            else
            {
                combobox.Items.Clear();
                combobox.Items.Add("Seleccione");
            }
            //Se	pone	por	defecto	la	primera	entrada	del	combobox	seleccionada
            combobox.SelectedIndex = 0;
        }
    }
}
