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
    public partial class ABMEmpleado : Form
    {
        private Empleado objEmpleado = null;
        private Empleado empLogueado;


        public ABMEmpleado(Empleado emp)
        {
            InitializeComponent();
            empLogueado = emp;
        }

        private void ABMEmpleado_Load(object sender, EventArgs e)
        {
            this.ActivoPorDefecto();
        }

        private void ActivoPorDefecto()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

            txtCI.Enabled = true;
            txtCI.Text = "";
            txtNombre.Text = "";
            txtContraseña.Text = "";
        }

        private void ActivoActualizacion()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;

            txtNombre.Text = objEmpleado.nombreCompleto;
            txtContraseña.Text = objEmpleado.contraseña;
        }

        private void ActivoAgregar()
        {
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

            txtCI.Enabled = false;
            txtNombre.Text = "";
            txtContraseña.Text = "";
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (txtNombre.Text == "")
                errorProvider1.SetError(txtNombre, "Debe rellenar este campo");
            else
                errorProvider1.Clear();
        }

        private void txtCI_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                WebService WS = new WebService();
                int resultado = 0;
                Int32.TryParse(txtCI.Text,out resultado);
                if (resultado != 0)
                {
                    objEmpleado = WS.BuscarEmpleadosActivos(Convert.ToInt32(txtCI.Text));
                    errorProvider1.Clear();

                    if (objEmpleado == null)
                    ActivoAgregar();
                    else
                        ActivoActualizacion();
                }
                else
                {
                    errorProvider1.SetError(txtCI,"Ingrese una CI válida.");
                }
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                manejoErrorWS(ex.Message);
            }
            //catch (Exception ex)
            //{
            //    lblError.Text = ex.Message;
            //}
        }

        private void txtContraseña_Validating(object sender, CancelEventArgs e)
        {
            if (txtContraseña.Text == "")
                errorProvider1.SetError(txtContraseña, "Debe rellenar este campo");
            else
                errorProvider1.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                WebService WS = new WebService();
                objEmpleado = new Empleado();
                objEmpleado.ci = Convert.ToInt32(txtCI.Text);
                objEmpleado.contraseña = txtContraseña.Text;
                objEmpleado.nombreCompleto = txtNombre.Text;
                WS.AltaEmpleado(objEmpleado);

                lblError.Text = "Alta con éxito.";
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                WebService WS = new WebService();
                objEmpleado.ci = Convert.ToInt32(txtCI.Text);
                objEmpleado.contraseña = txtContraseña.Text;
                objEmpleado.nombreCompleto = txtNombre.Text;
                WS.ModificarEmpleado(objEmpleado);

                lblError.Text = "Modificación con éxito.";
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                WebService WS = new WebService();
                WS.BajaEmpleado(objEmpleado);
                if (objEmpleado.ci == empLogueado.ci)
                {
                    List<Form> LFA = new List<Form>();
                    LFA.Clear();
                    foreach (Form FRM in Application.OpenForms)
                    {
                        LFA.Add(FRM);
                    }
                    for (int X = 0; (X <= (LFA.Count - 1)); X++)
                    {
                        if (LFA[X].Name == "Logueo")
                            LFA[X].Show();
                        else
                            LFA[X].Close();
                    }

                    empLogueado = null;
                }

                lblError.Text = "Baja con éxito.";
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.ActivoPorDefecto();
        }

        private void manejoErrorWS(string ex)
        {
            string palabraClave = "ExcepcionEX:";
            string palabraClaveFin = "FinExcepcionEX";
            int posicion = ex.IndexOf(palabraClave);
            int posicionFin = ex.IndexOf(palabraClaveFin);
            string errorOriginal = "";

            if (posicion != 0 && posicionFin != 0)
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
