using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBases
{
    public partial class VistaAdministrador : Form
    {
        AccesoBaseDatos bd;
        string llave1;
        string llave2;
        public VistaAdministrador()
        {
            InitializeComponent();
            bd = new AccesoBaseDatos();
        }
        private DataGridView llenarTabla(DataGridView interfaz, DataTable datos)
        {


            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = datos;

            interfaz.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            interfaz.DataSource = bindingSource;
            //Ciclo	para	darle	un	ancho	a	cada	columna	del	datagridview	


            for (int i = 0; i < interfaz.ColumnCount; i++)
            {
                interfaz.Columns[i].Width = 100;
            }
            return interfaz;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPageClientes_Click(object sender, EventArgs e)
        {
          
        }

        private void tabCliente_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void tabFrecuente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void VistaAdministrador_Load(object sender, EventArgs e)
        {
            DataTable datos;
            datos = bd.ejecutarConsultaTabla(" SELECT * FROM Cliente");
            dataGridCliente = llenarTabla(dataGridCliente, datos);


            datos = bd.ejecutarConsultaTabla("	SELECT * FROM  Frecuente ");
            dgFrecuente = llenarTabla(dgFrecuente, datos);

            datos = bd.ejecutarConsultaTabla("	SELECT * FROM Reservacion ");
            dgReservN = llenarTabla(dgReservN, datos);

            datos = bd.ejecutarConsultaTabla("SELECT * FROM Reto");
            dgRetos = llenarTabla(dgRetos, datos);

            datos = bd.ejecutarConsultaTabla("SELECT * FROM Contiene");
            dgCont = llenarTabla(dgCont, datos);

            datos = bd.ejecutarConsultaTabla("SELECT * FROM Participa_En");
            dgPartR = llenarTabla(dgPartR, datos);

            datos = bd.ejecutarConsultaTabla("SELECT * FROM Encargado");
            dgEncargados = llenarTabla(dgEncargados, datos);

            datos = bd.ejecutarConsultaTabla("SELECT * FROM Producto");
            dgProductos = llenarTabla(dgProductos, datos);

            datos = bd.ejecutarConsultaTabla("SELECT * FROM Venta");
            dgVentas = llenarTabla(dgVentas, datos);

        }

        private void btnICliente_Click(object sender, EventArgs e)
        {
            string telefono = dataGridCliente.SelectedRows[0].Cells[0].Value.ToString();
            string nombre = dataGridCliente.SelectedRows[0].Cells[1].Value.ToString();
            string apellido = dataGridCliente.SelectedRows[0].Cells[0].Value.ToString();
            int deuda = Convert.ToInt32(dataGridCliente.SelectedRows[0].Cells[0].Value.ToString());
            int numreservadas = Convert.ToInt32(dataGridCliente.SelectedRows[0].Cells[0].Value.ToString());
             bd.Insertar_Cliente(telefono,nombre,apellido,deuda,numreservadas);
            DataTable datos;
            datos = bd.ejecutarConsultaTabla(" SELECT * FROM Cliente");
            dataGridCliente = llenarTabla(dataGridCliente, datos);
        }

        private void llenarllaves(string llave1, string llave2)
        {
            this.llave1 = llave1;
            this.llave2 = llave2;
        }

        private void dataGridCliente_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void btnECliente_Click(object sender, EventArgs e)
        {
            string telefono = dataGridCliente.SelectedRows[0].Cells[0].Value.ToString();
            try
            {
                bd.Eliminar_Cliente(telefono);
            }
            catch (Exception error)
            {

            }
            DataTable datos;
            datos = bd.ejecutarConsultaTabla(" SELECT * FROM Cliente");
            dataGridCliente = llenarTabla(dataGridCliente, datos);
        }
    }
}
