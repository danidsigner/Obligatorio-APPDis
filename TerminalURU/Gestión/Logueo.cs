using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestión.ServicioWeb;

namespace Gestión
{
    public partial class Logueo : Form
    {
        public Menu MenuFrm = null;
        public Logueo()
        {
            InitializeComponent();
        }

        private void Logueo_Load(object sender, EventArgs e)
        {
           
        }

        private void controlLogin1_loguearse(string u, string c)
        {
            try
            {
                WebService WS = new WebService();
                Empleado emp = new Empleado();

                //
                //recordar quitar el user por defecto  ↓
                //
                //usuario manual
                emp = WS.Logeo(46181064, "pablo1");
                if (emp == null)
                {
                    lblError.Text = "Usuario y/o contraseña incorrecto.";
                }
                else
                {
                    lblError.Text = "";
                    MenuFrm = new Menu(emp);
                    MenuFrm.Show();
                    this.Hide();
                }

                //fin usuario manual
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                manejoErrorWS(ex.Message);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void manejoErrorWS(string ex)
        {
            string palabraClave = "ExcepcionEX:";
            string palabraClaveFin = "FinExcepcionEX";
            int posicion = ex.IndexOf(palabraClave);
            int posicionFin = ex.IndexOf(palabraClaveFin);
            string errorOriginal = "";

            if (posicion != -1 && posicionFin != -1)
            {
                errorOriginal = ex.Substring(posicion + palabraClave.Length, (posicionFin - posicion) - 13);
                lblError.Text = errorOriginal;
            }
            else
            {
                errorOriginal = "Error de conexión.";
                MessageBox.Show(errorOriginal);
            }
        }
    }
}
