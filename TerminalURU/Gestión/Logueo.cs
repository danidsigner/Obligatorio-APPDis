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

                emp = WS.Logeo(53272348,"manya1");
                if (emp == null)
                {
                    lblError.Text = "Usuario y/o contraseña incorrecto.";
                }
                else
                {
                    lblError.Text = "";
                    Menu MenuFrm = new Menu(emp);
                    MenuFrm.Show();
                    this.Hide();
                }
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
