﻿using System;
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
        VistaMenuPrincipal prevForm;
        public VistaAdministrador(VistaMenuPrincipal prevForm)
        {
            InitializeComponent();
            bd = new AccesoBaseDatos();
            this.prevForm = prevForm;
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

            datos = bd.ejecutarConsultaTabla("SELECT RE.MomentoReservado, RE.HoraInicioReal, RE.HoraFinalizacionReal, RE.TelefonoReferencia, RE.CedulaEncargado, C.Nombre, C.Telefono, P.EsCreador FROM((Reto R left outer JOIN Reservacion RE ON R.MomentoReservado = RE.MomentoReservado)left outer JOIN Participa_En P ON R.MomentoReservado = P.MomentoReservado) left JOIN Cliente C ON P.TelefonoCliente = C.Telefono");
            dgRetos = llenarTabla(dgRetos, datos);
            dgRetos.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";

            datos = bd.ejecutarConsultaTabla("SELECT * FROM Contiene");
            dgCont = llenarTabla(dgCont, datos);
            dgCont.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";

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
            try
            {
                string telefono = dataGridCliente.SelectedRows[0].Cells[0].Value.ToString();
                string nombre = dataGridCliente.SelectedRows[0].Cells[1].Value.ToString();
                string apellido = dataGridCliente.SelectedRows[0].Cells[2].Value.ToString();
                int deuda = Convert.ToInt32(dataGridCliente.SelectedRows[0].Cells[3].Value.ToString());
                int numreservadas = Convert.ToInt32(dataGridCliente.SelectedRows[0].Cells[4].Value.ToString());
                bd.Insertar_Cliente(telefono, nombre, apellido, deuda, numreservadas);
            }
            catch (Exception error)
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
            try
            {
                string telefono = dataGridCliente.SelectedRows[0].Cells[0].Value.ToString();
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
            try
            {
                String telefono = dataGridCliente.SelectedRows[0].Cells[0].Value.ToString();
                String nombre = dataGridCliente.SelectedRows[0].Cells[1].Value.ToString();
                String apellido = dataGridCliente.SelectedRows[0].Cells[2].Value.ToString();
                int deuda = Convert.ToInt32(dataGridCliente.SelectedRows[0].Cells[3].Value.ToString());
                int numreservadas = Convert.ToInt32(dataGridCliente.SelectedRows[0].Cells[4].Value.ToString());
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
            try
            {
                string telefono = dgFrecuente.SelectedRows[0].Cells[0].Value.ToString();
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
            try
            {
                String telefono = dgFrecuente.SelectedRows[0].Cells[0].Value.ToString();
                int numR = Convert.ToInt32(dgFrecuente.SelectedRows[0].Cells[1].Value.ToString());
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
            try
            {
                string telefono = dgFrecuente.SelectedRows[0].Cells[0].Value.ToString();
                int numR = Convert.ToInt32(dgFrecuente.SelectedRows[0].Cells[1].Value.ToString());
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
            try
            {
                string producto = dgCont.SelectedRows[0].Cells[0].Value.ToString();
                DateTime fecha = Convert.ToDateTime(dgCont.SelectedRows[0].Cells[1].Value.ToString());
                int cantidad = Convert.ToInt32(dgCont.SelectedRows[0].Cells[2].Value.ToString());
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
            try
            {
                String producto = dgCont.SelectedRows[0].Cells[0].Value.ToString();
                DateTime momento = Convert.ToDateTime(dgCont.SelectedRows[0].Cells[1].Value.ToString());
                int cantidad = Convert.ToInt32(dgCont.SelectedRows[0].Cells[2].Value.ToString());
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
            try
            {
                string producto = dgCont.SelectedRows[0].Cells[0].Value.ToString();
                DateTime momento = Convert.ToDateTime(dgCont.SelectedRows[0].Cells[1].Value.ToString());
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
            try
            {
                DateTime fecha = Convert.ToDateTime(dgVentas.SelectedRows[0].Cells[0].Value.ToString());
                string encargado = dgCont.SelectedRows[0].Cells[2].Value.ToString();
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
            try
            {
                DateTime momento = Convert.ToDateTime(dgVentas.SelectedRows[0].Cells[0].Value.ToString());
                String encargado = dgVentas.SelectedRows[0].Cells[2].Value.ToString();
                int cantidad = Convert.ToInt32(dgVentas.SelectedRows[0].Cells[1].Value.ToString());
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
            try
            {
                DateTime momento = Convert.ToDateTime(dgVentas.SelectedRows[0].Cells[0].Value.ToString());
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
            try
            {
                string producto = dgProductos.SelectedRows[0].Cells[0].Value.ToString();
                int precio = Convert.ToInt32(dgProductos.SelectedRows[0].Cells[1].Value.ToString());
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
            try
            {
                string producto = dgProductos.SelectedRows[0].Cells[0].Value.ToString();
                int precio = Convert.ToInt32(dgProductos.SelectedRows[0].Cells[1].Value.ToString());
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
            try
            {
                string producto = dgProductos.SelectedRows[0].Cells[0].Value.ToString();
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
            try
            {
                string cedula = dgEncargados.SelectedRows[0].Cells[0].Value.ToString();
                string nombre = dgEncargados.SelectedRows[0].Cells[1].Value.ToString();
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
            try
            {
                string cedula = dgEncargados.SelectedRows[0].Cells[0].Value.ToString();
                string nombre = dgEncargados.SelectedRows[0].Cells[1].Value.ToString();
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
            try
            {
                string cedula = dgEncargados.SelectedRows[0].Cells[0].Value.ToString();
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
            try
            {
                DateTime momento = Convert.ToDateTime(dgReservN.SelectedRows[0].Cells[0].Value.ToString());
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

            DateTime momento = pickerDate.Value.Date + pickerHour.Value.TimeOfDay;
            string telref = txtTelr.Text;
            string cedula = txtCed.Text;
            Boolean auto = checkAuto.Checked;
            string tel = txtTelCliente.Text;
            try
            {
                bd.Modificar_ReservacionNormal(Convert.ToDateTime(llave1),momento, telref, cedula, auto, tel);
            }
            catch (Exception error)
            {

            }

            DataTable datos;
            datos = bd.ejecutarConsultaTabla("	SELECT R.MomentoReservado, R.HoraInicioReal, R.HoraFinalizacionReal, R.TelefonoReferencia, R.CedulaEncargado, D.EsAutomatica, D.TelefonoCliente FROM DeEquipoCompleto D inner join Reservacion R on D.MomentoReservado = R.MomentoReservado ");
            dgReservN = llenarTabla(dgReservN, datos);
            dgReservN.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";
        }

        private void VistaAdministrador_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }

        private void dgReservN_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgReservN.SelectedRows.Count == 1)
            {
                dgReservN.SelectedRows[0].Cells[1].Value = DBNull.Value;
                dgReservN.SelectedRows[0].Cells[2].Value = DBNull.Value;
            }
        }

        private void btnIReservN_Click_1(object sender, EventArgs e)
        {
            DateTime momento = pickerDate.Value.Date + pickerHour.Value.TimeOfDay;
            string telref = txtTelr.Text;
            string cedula = txtCed.Text;

            Boolean auto = checkAuto.Checked;
            string tel = txtTelCliente.Text;
            try
            {
                bd.Insertar_ReservacionNormal(momento, telref, cedula, auto, tel);
            }
            catch (Exception error)
            {

            }

            DataTable datos;
            datos = bd.ejecutarConsultaTabla("	SELECT R.MomentoReservado, R.HoraInicioReal, R.HoraFinalizacionReal, R.TelefonoReferencia, R.CedulaEncargado, D.EsAutomatica, D.TelefonoCliente FROM DeEquipoCompleto D inner join Reservacion R on D.MomentoReservado = R.MomentoReservado ");
            dgReservN = llenarTabla(dgReservN, datos);
            dgReservN.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";
        }

        private void dgReservN_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                llave1 = dgReservN.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception error)
            {

            }
        }

        private void btnERetos_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime momento = Convert.ToDateTime(dgRetos.SelectedRows[0].Cells[0].Value.ToString());
                bd.Eliminar_ReservacionNormal(momento);
            }
            catch (Exception error)
            {

            }
            DataTable datos;
            datos = bd.ejecutarConsultaTabla("SELECT RE.MomentoReservado, RE.HoraInicioReal, RE.HoraFinalizacionReal, RE.TelefonoReferencia, RE.CedulaEncargado, C.Nombre, C.Telefono, P.EsCreador FROM((Reto R left outer JOIN Reservacion RE ON R.MomentoReservado = RE.MomentoReservado)left outer JOIN Participa_En P ON R.MomentoReservado = P.MomentoReservado) left JOIN Cliente C ON P.TelefonoCliente = C.Telefono");
            dgRetos = llenarTabla(dgRetos, datos);
            dgRetos.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";
        }

        private void tabReto_Click(object sender, EventArgs e)
        {

        }

        private void btnIRetos_Click(object sender, EventArgs e)
        {

            DateTime momento = dtpFechaRetos.Value.Date + dtpHoraReto.Value.TimeOfDay;
            string telref = txtTelReto.Text;
            string cedula = txtCedulaReto.Text;
            string tel = txtTelCReto.Text;
            try
            {
                bd.Insertar_Retos(momento, telref, cedula, tel);
            }
            catch (Exception error)
            {

            }

            DataTable datos;
            datos = bd.ejecutarConsultaTabla("SELECT RE.MomentoReservado, RE.HoraInicioReal, RE.HoraFinalizacionReal, RE.TelefonoReferencia, RE.CedulaEncargado, C.Nombre, C.Telefono, P.EsCreador FROM((Reto R left outer JOIN Reservacion RE ON R.MomentoReservado = RE.MomentoReservado)left outer JOIN Participa_En P ON R.MomentoReservado = P.MomentoReservado) left JOIN Cliente C ON P.TelefonoCliente = C.Telefono");
            dgRetos = llenarTabla(dgRetos, datos);
            dgRetos.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";
        }

        private void btnMRetos_Click(object sender, EventArgs e)
        {
            DateTime momento = dtpFechaRetos.Value.Date + dtpHoraReto.Value.TimeOfDay;
            string telref = txtTelReto.Text;
            string cedula = txtCedulaReto.Text;
            string tel = txtTelCReto.Text;
            try
            {
                bd.Modificar_Retos(Convert.ToDateTime(llave1),momento, telref, cedula, tel);
            }
            catch (Exception error)
            {

            }

            DataTable datos;
            datos = bd.ejecutarConsultaTabla("SELECT RE.MomentoReservado, RE.HoraInicioReal, RE.HoraFinalizacionReal, RE.TelefonoReferencia, RE.CedulaEncargado, C.Nombre, C.Telefono, P.EsCreador FROM((Reto R left outer JOIN Reservacion RE ON R.MomentoReservado = RE.MomentoReservado)left outer JOIN Participa_En P ON R.MomentoReservado = P.MomentoReservado) left JOIN Cliente C ON P.TelefonoCliente = C.Telefono");
            dgRetos = llenarTabla(dgRetos, datos);
            dgRetos.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss.fff";
        }

        private void dgRetos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                llave1 = dgRetos.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception error)
            {

            }
        }
    }
}
