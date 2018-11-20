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
            this.CenterToScreen();
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
                lblError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}
