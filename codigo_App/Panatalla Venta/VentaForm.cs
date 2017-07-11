using System;
using System.Collections;
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
        Venta venta;
        Producto producto;
        Contiene contiene;
        DateTime fecha;
        public VentaForm()
        {
            InitializeComponent();
            fecha = DateTime.Now;
            producto = new Producto();
            venta = new Venta();
            contiene = new Contiene();
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
                //combobox.Items.Add("Seleccione");
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
                //combobox.Items.Add("Seleccione");
            }
            //Se	pone	por	defecto	la	primera	entrada	del	combobox	seleccionada
            combobox.SelectedIndex = 0;
        }

        private void FVenta_Load(object sender, EventArgs e)
        {
            fecha = DateTime.Now;
            venta.crearVenta(fecha,"1");/*Recordar poner el encargado real*/
            llenarCombobox(cbAgregar);
        }

        private void bttnIngresar_Click(object sender, EventArgs e)
        {
            int cantidad = (int)nudCantidad.Value;
            string producto = cbAgregar.Text;
            int errorHandler = contiene.agregar_Contiene(producto, fecha, cantidad);
            if(errorHandler!= 0)
            {
                contiene.modificarContiene(producto,producto,fecha,fecha, cantidad);
            }

            DataTable datos;
            datos = contiene.consultar_Contiene(fecha);
            llenarTabla(datos);
            txtMonto.Text = venta.getMontoTotal(fecha);
        }

        private void llenarTabla(DataTable datos)
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = datos;

            dataGVentas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dataGVentas.DataSource = bindingSource;
            //Ciclo	para	darle	un	ancho	a	cada	columna	del	datagridviewproporcionado

            for (int i = 0; i < dataGVentas.ColumnCount; i++)
            {
                dataGVentas.Columns[i].Width = 100;
            }

        }

        private void bttnTerminar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bttnCancelar_Click(object sender, EventArgs e)
        {
            venta.cancelarVenta(fecha);
            this.Hide();
        }

        private void bttnEliminar_Click(object sender, EventArgs e)
        {

               contiene.eliminarContiene(dataGVentas.SelectedRows[0].Cells[0].Value.ToString(), fecha);
                DataTable datos;
                datos = contiene.consultar_Contiene(fecha);
                llenarTabla(datos);
            txtMonto.Text = venta.getMontoTotal(fecha);
        }
    }
}
