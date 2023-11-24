using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNego;
using CapaEntidad;
namespace ProyectoFinal
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            //aqui llamariamos a la clase usuario desde la clase entidad y negocio
            // despues lo siguien que usamos es usar la expresiones lambda que nos permite llamar funciones sin necesidad de llamar agrumentos
            Usuario ousuario = new CN_Usuario().Listar().Where(u => u.Documento == txtdocumento.Text && u.Clave == txtclave.Text).FirstOrDefault();

            //aqui en esta parte es declarando que si no encontro usuario pues que sea nulo negandole el acceso
            if (ousuario != null)
            {

                MenuInicio form = new MenuInicio(ousuario);

                form.Show();
                this.Hide();

                form.FormClosing += frm_closing;

            }
            else
            {
                MessageBox.Show("no se encontro el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



        }
        private void frm_closing (object sender, FormClosingEventArgs e)
        {
            txtdocumento.Text = "";
            txtclave.Text = "";
            

            this.Show();

        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
