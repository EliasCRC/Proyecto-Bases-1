using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBases
{
    public partial class VentaForm : Form
    {
        //Venta venta;
        Producto producto;
        public VentaForm()
        {
            InitializeComponent();
            producto = new Producto();
            //venta = new Venta();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void gbVenta_Enter(object sender, EventArgs e)
        {

        }

        /*Método	para	llenar	un	combobox	con	datos	específicos
									Recibe:	Un	objeto	combobox	que	va	a	llenar	con	una	consulta	específica
									Modifica:	Llena	el	combobox	que	recibe	por	parámetro	con	el	nombre	de	todos los	estudiantes	que	se	encuentran	en	la	bd
									Retorna:	Ningún	valor*/
        private void llenarCombobox(ComboBox combobox)
        {
            //Se	obtiene	un	dataReader	con	todos	los	nombres	de	los	estudiantes	de	la  base    de datos

            SqlDataReader datos = producto.obtenerListaNombresProductos();
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

        private void FVenta_Load(object sender, EventArgs e)
        {
            llenarCombobox(cbAgregar);
        }
    }
}
