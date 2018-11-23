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
    public partial class ABMCompañia : Form
    {
        private Compania objCompañia = null;

        public ABMCompañia(Empleado emp)
        {
            InitializeComponent();
        }

        private void ActivoPorDefecto()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            txtNombre.Enabled = true;
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            errorProvider1.Clear();
            lblError.Text = "";
        }

        private void ActivoActualizacion()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            errorProvider1.Clear();
            lblError.Text = "";

            txtDireccion.Text = objCompañia.direccion;
            txtTelefono.Text = objCompañia.telefono.ToString();
        }

        private void ActivoAgregar()
        {
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            txtNombre.Enabled = false;
            errorProvider1.Clear();

            lblError.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }

        private void ABMCompañia_Load(object sender, EventArgs e)
        {
            //if (emp == null)
            //{
            //    Logueo l = new Logueo();
            //    this.Close();
            //    l.Show();
            //}
            this.ActivoPorDefecto();
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                WebService WS = new WebService();
                if (txtNombre.Text.Length != 0)
                {
                    objCompañia = WS.BuscarCompañia(txtNombre.Text);

                    errorProvider1.Clear();
                    if (objCompañia == null)
                    {
                        this.ActivoAgregar();
                    }
                    else
                    {
                        this.ActivoActualizacion();
                    }
                }
                else
                {
                    errorProvider1.SetError(txtNombre, "Debe rellenar este campo.");
                }
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                WebService WS = new WebService();
                objCompañia = new Compania();
                objCompañia.nombre = txtNombre.Text;
                objCompañia.direccion = txtDireccion.Text;
                objCompañia.telefono = Convert.ToInt64(txtTelefono.Text);

                WS.AltaCompania(objCompañia);

                lblError.Text = "Alta con éxito.";

                this.ActivoPorDefecto();
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
                objCompañia.nombre = txtNombre.Text;
                objCompañia.direccion = txtDireccion.Text;
                objCompañia.telefono = Convert.ToInt64(txtTelefono.Text);

                WS.ModificarCompania(objCompañia);

                lblError.Text = "Modificación con éxito.";

                this.ActivoPorDefecto();

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
                WS.BajaCompania(objCompañia);

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

        private void txtDireccion_Validating(object sender, CancelEventArgs e)
        {
            if (txtDireccion.Text == "")
                errorProvider1.SetError(txtDireccion, "Debe rellenar este campo.");
            else
                errorProvider1.Clear();
        }

        private void txtTelefono_Validating(object sender, CancelEventArgs e)
        {
            if (txtDireccion.Text == "")
                errorProvider1.SetError(txtTelefono, "Debe rellenar este campo.");
            else
                errorProvider1.Clear();
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
