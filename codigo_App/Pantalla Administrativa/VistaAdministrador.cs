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

            datos = bd.ejecutarConsultaTabla("	SELECT R.MomentoReservado, R.HoraInicioReal, R.HoraFinalizacionReal, R.TelefonoReferencia, R.CedulaEncargado, D.EsAutomatica, D.TelefonoCliente FROM DeEquipoCompleto D inner join Reservacion R on D.MomentoReservado = R.MomentoReservado ");
            dgReservN = llenarTabla(dgReservN, datos);
            dgReservN.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";

            datos = bd.ejecutarConsultaTabla("SELECT * FROM Reto");
            dgRetos = llenarTabla(dgRetos, datos);

            datos = bd.ejecutarConsultaTabla("SELECT * FROM Contiene");
            dgCont = llenarTabla(dgCont, datos);
            dgCont.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";
            datos = bd.ejecutarConsultaTabla("SELECT * FROM Participa_En");
            dgPartR = llenarTabla(dgPartR, datos);

            datos = bd.ejecutarConsultaTabla("SELECT * FROM Encargado");
            dgEncargados = llenarTabla(dgEncargados, datos);

            datos = bd.ejecutarConsultaTabla("SELECT * FROM Producto");
            dgProductos = llenarTabla(dgProductos, datos);

            datos = bd.ejecutarConsultaTabla("SELECT * FROM Venta");
            dgVentas = llenarTabla(dgVentas, datos);
            dgVentas.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";

        }

        private void btnICliente_Click(object sender, EventArgs e)
        {
            string telefono = dataGridCliente.SelectedRows[0].Cells[0].Value.ToString();
            string nombre = dataGridCliente.SelectedRows[0].Cells[1].Value.ToString();
            string apellido = dataGridCliente.SelectedRows[0].Cells[2].Value.ToString();
            int deuda = Convert.ToInt32(dataGridCliente.SelectedRows[0].Cells[3].Value.ToString());
            int numreservadas = Convert.ToInt32(dataGridCliente.SelectedRows[0].Cells[4].Value.ToString());
            try
            {
                bd.Insertar_Cliente(telefono, nombre, apellido, deuda, numreservadas);
            }catch(Exception error)
            {

            }
            DataTable datos;
            datos = bd.ejecutarConsultaTabla(" SELECT * FROM Cliente");
            dataGridCliente = llenarTabla(dataGridCliente, datos);
        }

        private void llenarllaves(string llave1, string llave2)
        {
            this.llave1 = llave1;
            this.llave2 = llave2;
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

        private void dataGridCliente_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                llave1 = dataGridCliente.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch(Exception error)
            {

            }
        }

        private void btnMCliente_Click(object sender, EventArgs e)
        {
            String telefono = dataGridCliente.SelectedRows[0].Cells[0].Value.ToString();
            String nombre = dataGridCliente.SelectedRows[0].Cells[1].Value.ToString();
            String apellido = dataGridCliente.SelectedRows[0].Cells[2].Value.ToString();
            int deuda = Convert.ToInt32(dataGridCliente.SelectedRows[0].Cells[3].Value.ToString());
            int numreservadas = Convert.ToInt32(dataGridCliente.SelectedRows[0].Cells[4].Value.ToString());
            try
            {
                bd.Modificar_Cliente(llave1, telefono, nombre, apellido, deuda, numreservadas);
            }catch(Exception error)
            {

            }

            DataTable datos;
            datos = bd.ejecutarConsultaTabla(" SELECT * FROM Cliente");
            dataGridCliente = llenarTabla(dataGridCliente, datos);
        }

        private void btnEFrecuente_Click(object sender, EventArgs e)
        {
            string telefono = dgFrecuente.SelectedRows[0].Cells[0].Value.ToString();
            try
            {

                bd.Eliminar_Frecuente(telefono);
            }
            catch (Exception error)
            {

            }
            DataTable datos;
            datos = bd.ejecutarConsultaTabla("	SELECT * FROM  Frecuente ");
            dgFrecuente = llenarTabla(dgFrecuente, datos);
        }



        private void btnMFrecuente_Click(object sender, EventArgs e)
        {
            String telefono = dgFrecuente.SelectedRows[0].Cells[0].Value.ToString();
            int numR = Convert.ToInt32(dgFrecuente.SelectedRows[0].Cells[1].Value.ToString());
            
            try
            {
                bd.Modificar_Frecuente(llave1, telefono,numR);
            }
            catch (Exception error)
            {

            }

            DataTable datos;
            datos = bd.ejecutarConsultaTabla("	SELECT * FROM  Frecuente ");
            dgFrecuente = llenarTabla(dgFrecuente, datos);
        }

        private void btnIFrecuente_Click(object sender, EventArgs e)
        {
            string telefono = dgFrecuente.SelectedRows[0].Cells[0].Value.ToString();
            int numR = Convert.ToInt32(dgFrecuente.SelectedRows[0].Cells[1].Value.ToString());
            try
            {
                bd.Insertar_Frecuente(telefono, numR);
            }
            catch (Exception error)
            {

            }
            DataTable datos;
            datos = bd.ejecutarConsultaTabla("	SELECT * FROM  Frecuente ");
            dgFrecuente = llenarTabla(dgFrecuente, datos);
        }

        private void btnICont_Click(object sender, EventArgs e)
        {
            string producto = dgCont.SelectedRows[0].Cells[0].Value.ToString();
            DateTime fecha = Convert.ToDateTime(dgCont.SelectedRows[0].Cells[1].Value.ToString());
            int cantidad = Convert.ToInt32(dgCont.SelectedRows[0].Cells[2].Value.ToString());
            try
            {
                bd.Insertar_Contenidos(producto,fecha,cantidad);
            }
            catch (Exception error)
            {

            }
            DataTable datos;
            datos = bd.ejecutarConsultaTabla("SELECT * FROM Contiene");
            dgCont = llenarTabla(dgCont, datos);
            dgCont.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";
        }

        private void btnMCont_Click(object sender, EventArgs e)
        {
            String producto = dgCont.SelectedRows[0].Cells[0].Value.ToString();
            DateTime momento = Convert.ToDateTime(dgCont.SelectedRows[0].Cells[1].Value.ToString());
            int cantidad = Convert.ToInt32(dgCont.SelectedRows[0].Cells[2].Value.ToString());
            try
            {
                bd.Modificar_Contenidos(producto,producto,momento,momento,cantidad);
            }
            catch (Exception error)
            {

            }

            DataTable datos;
            datos = bd.ejecutarConsultaTabla("SELECT * FROM Contiene");
            dgCont = llenarTabla(dgCont, datos);
            dgCont.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";
        }

        private void btnECont_Click(object sender, EventArgs e)
        {
            string producto = dgCont.SelectedRows[0].Cells[0].Value.ToString();
            DateTime momento = Convert.ToDateTime( dgCont.SelectedRows[0].Cells[1].Value.ToString());
            try
            {

                bd.Eliminar_Contenidos(producto,momento);
            }
            catch (Exception error)
            {

            }
            DataTable datos;
            datos = bd.ejecutarConsultaTabla("SELECT * FROM Contiene");
            dgCont = llenarTabla(dgCont, datos);
            dgCont.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";
        }

        private void btnIVentas_Click(object sender, EventArgs e)
        {
            DateTime fecha = Convert.ToDateTime(dgVentas.SelectedRows[0].Cells[0].Value.ToString());
            string encargado = dgCont.SelectedRows[0].Cells[2].Value.ToString();

            try
            {
                bd.Insertar_Venta(fecha,encargado);
            }
            catch (Exception error)
            {

            }
            DataTable datos;
            datos = bd.ejecutarConsultaTabla("SELECT * FROM Venta");
            dgVentas = llenarTabla(dgVentas, datos);
            dgVentas.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";
        }

        private void btnMVentas_Click(object sender, EventArgs e)
        {
            DateTime momento = Convert.ToDateTime(dgVentas.SelectedRows[0].Cells[0].Value.ToString());
            String encargado = dgVentas.SelectedRows[0].Cells[2].Value.ToString();
            int cantidad = Convert.ToInt32(dgVentas.SelectedRows[0].Cells[1].Value.ToString());
            try
            {
                bd.Modificar_Venta(Convert.ToDateTime(llave1), momento, encargado ,cantidad);
            }
            catch (Exception error)
            {

            }

            DataTable datos;
            datos = bd.ejecutarConsultaTabla("SELECT * FROM Venta");
            dgVentas = llenarTabla(dgVentas, datos);
            dgVentas.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";
        }

        private void btnEVentas_Click(object sender, EventArgs e)
        {
            DateTime momento = Convert.ToDateTime(dgVentas.SelectedRows[0].Cells[0].Value.ToString());
            try
            {

                bd.Eliminar_Venta(momento);
            }
            catch (Exception error)
            {

            }
            DataTable datos;
            datos = bd.ejecutarConsultaTabla("SELECT * FROM Venta");
            dgVentas = llenarTabla(dgVentas, datos);
            dgVentas.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";
        }

        private void dgVentas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
               llave1 = dgVentas.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception error)
            {

            }
           
        }

        private void btnIProductos_Click(object sender, EventArgs e)
        {
            string producto = dgProductos.SelectedRows[0].Cells[0].Value.ToString();
            int precio = Convert.ToInt32(dgProductos.SelectedRows[0].Cells[1].Value.ToString());
            try
            {
                bd.Insertar_Producto(producto, precio);
            }
            catch (Exception error)
            {

            }
            DataTable datos;
            datos = bd.ejecutarConsultaTabla("SELECT * FROM Producto");
            dgProductos = llenarTabla(dgProductos, datos);
        }

        private void btnMProductos_Click(object sender, EventArgs e)
        {
            string producto = dgProductos.SelectedRows[0].Cells[0].Value.ToString();
            int precio = Convert.ToInt32(dgProductos.SelectedRows[0].Cells[1].Value.ToString());
            try
            {
                bd.Modificar_Producto(llave1, producto, precio);
            }
            catch (Exception error)
            {

            }
            DataTable datos;
            datos = bd.ejecutarConsultaTabla("SELECT * FROM Producto");
            dgProductos = llenarTabla(dgProductos, datos);
        }

        private void btnEProductos_Click(object sender, EventArgs e)
        {
            string producto = dgProductos.SelectedRows[0].Cells[0].Value.ToString();           
            try
            {
                bd.Eliminar_Producto(producto);
            }
            catch (Exception error)
            {

            }
            DataTable datos;
            datos = bd.ejecutarConsultaTabla("SELECT * FROM Producto");
            dgProductos = llenarTabla(dgProductos, datos);
        }

        private void dgProductos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                llave1 = dgProductos.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception error)
            {

            }

        }

        private void dgFrecuente_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                llave1 = dgFrecuente.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception error)
            {

            }
        }

        private void btnIEncargados_Click(object sender, EventArgs e)
        {
            string cedula = dgEncargados.SelectedRows[0].Cells[0].Value.ToString();
            string nombre = dgEncargados.SelectedRows[0].Cells[1].Value.ToString();
            try
            {

                bd.Insertar_Encargados(cedula,nombre);
            }
            catch (Exception error)
            {

            }
            DataTable datos;
            datos = bd.ejecutarConsultaTabla("SELECT * FROM Encargado");
            dgEncargados = llenarTabla(dgEncargados, datos);
        }

        private void btnMEncargados_Click(object sender, EventArgs e)
        {
            string cedula = dgEncargados.SelectedRows[0].Cells[0].Value.ToString();
            string nombre = dgEncargados.SelectedRows[0].Cells[1].Value.ToString();
            try
            {

                bd.Modificar_Encargados(llave1,cedula,nombre);
            }
            catch (Exception error)
            {

            }
            DataTable datos;
            datos = bd.ejecutarConsultaTabla("SELECT * FROM Encargado");
            dgEncargados = llenarTabla(dgEncargados, datos);
        }

        private void btnEEncargados_Click(object sender, EventArgs e)
        {
            string cedula = dgEncargados.SelectedRows[0].Cells[0].Value.ToString();
            try
            {

                bd.Eliminar_Encargados(cedula);
            }
            catch (Exception error)
            {

            }
            DataTable datos;
            datos = bd.ejecutarConsultaTabla("SELECT * FROM Encargado");
            dgEncargados = llenarTabla(dgEncargados, datos);
        }

        private void dgEncargados_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                llave1 = dgEncargados.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception error)
            {

            }
        }

        private void btnEReservN_Click(object sender, EventArgs e)
        {
            DateTime momento = Convert.ToDateTime(dgReservN.SelectedRows[0].Cells[0].Value.ToString());
            try
            {

                bd.Eliminar_ReservacionNormal(momento);
            }
            catch (Exception error)
            {

            }
            DataTable datos;
            datos = bd.ejecutarConsultaTabla("	SELECT R.MomentoReservado, R.HoraInicioReal, R.HoraFinalizacionReal, R.TelefonoReferencia, R.CedulaEncargado, D.EsAutomatica, D.TelefonoCliente FROM DeEquipoCompleto D inner join Reservacion R on D.MomentoReservado = R.MomentoReservado ");
            dgReservN = llenarTabla(dgReservN, datos);
            dgReservN.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";
        }

        private void btnMReservN_Click(object sender, EventArgs e)
        {
            DataTable datos;
            datos = bd.ejecutarConsultaTabla("	SELECT R.MomentoReservado, R.HoraInicioReal, R.HoraFinalizacionReal, R.TelefonoReferencia, R.CedulaEncargado, D.EsAutomatica, D.TelefonoCliente FROM DeEquipoCompleto D inner join Reservacion R on D.MomentoReservado = R.MomentoReservado ");
            dgReservN = llenarTabla(dgReservN, datos);
            dgReservN.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";
        }

        private void btnIReservN_Click(object sender, EventArgs e)
        {

            DateTime momento = Convert.ToDateTime(dgReservN.SelectedRows[0].Cells[0].Value.ToString());
            string telref = dgReservN.SelectedRows[0].Cells[3].Value.ToString();
            string cedula = dgReservN.SelectedRows[0].Cells[4].Value.ToString();
            /**No sirve**/Boolean auto = Convert.ToBoolean(dgReservN.SelectedRows[0].Cells[5].Value.ToString());
            string tel = dgReservN.SelectedRows[0].Cells[6].Value.ToString();
            try
            {

                bd.Insertar_ReservacionNormal(momento,telref,cedula,auto,tel);
            }
            catch (Exception error)
            {

            }

            DataTable datos;
            datos = bd.ejecutarConsultaTabla("	SELECT R.MomentoReservado, R.HoraInicioReal, R.HoraFinalizacionReal, R.TelefonoReferencia, R.CedulaEncargado, D.EsAutomatica, D.TelefonoCliente FROM DeEquipoCompleto D inner join Reservacion R on D.MomentoReservado = R.MomentoReservado ");
            dgReservN = llenarTabla(dgReservN, datos);
            dgReservN.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";
        }
    }
}
