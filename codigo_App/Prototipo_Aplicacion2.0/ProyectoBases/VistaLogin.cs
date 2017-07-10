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
    public partial class VistaLogin : Form
    {
        private Encargado encargado;
        public VistaLogin()
        {
            InitializeComponent();
            this.encargado = new Encargado();
            this.CenterToScreen();
        }

        public void clearPassword ()
        {
            txtbContrasena.Clear();
        }

        /** 
         * Habilita el boton hasta que ambos campos estén llenos 
         */
        private void txtbUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtbContrasena.Text != "" && txtbUsuario.Text != "")
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }
        }

        /** 
         * Habilita el boton hasta que ambos campos estén llenos 
         */
        private void txtbContrasena_TextChanged(object sender, EventArgs e)
        {
            if (txtbContrasena.Text != "" && txtbUsuario.Text != "")
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }
        }

        /** 
         * Click para login
         */
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtbContrasena.Text != "" && txtbUsuario.Text != "")
            {
                if (encargado.login(txtbUsuario.Text, txtbContrasena.Text) == true)
                {
                    UsuarioActual.setName(txtbUsuario.Text);
                    VistaMenuPrincipal menuPrincipal = new VistaMenuPrincipal(this, encargado.esAdmin(txtbUsuario.Text));
                    menuPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario y/o incorrecto, por favor intente de nuevo", "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /**
         * Enter para Login en campo de usuario
         */
        private void txtbUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }

        /**
         * Enter para Login en campo de contraseña
         */
        private void txtbContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }
    }
}
