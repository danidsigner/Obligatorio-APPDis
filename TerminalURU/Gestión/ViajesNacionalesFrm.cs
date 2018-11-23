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
    public partial class ViajesNacionalesFrm : Form
    {
        private Nacionales objNacionales = null;
        private Empleado empLogueado;
        private Array listaT;
        private Array listaC;

        public ViajesNacionalesFrm(Empleado emp)
        {
            InitializeComponent();
            empLogueado = emp;
        }

        private void ViajesNacionalesFrm_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActivoPorDefecto();
                WebService WS = new WebService();
                listaT = WS.ListarTerminales();
                listaC = WS.ListarCompanias();
                foreach (Terminal t in listaT)
                {
                    cbTerminal.Items.Add(t.codigo);
                }
                foreach (Compania c in listaC)
                {
                    cbCompañia.Items.Add(c.nombre);
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

        private void ActivoPorDefecto()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

            txtNumero.Enabled = true;
            txtEmpleado.Text = empLogueado.nombreCompleto;
            txtCantAsientos.Text = "";
            txtCantParadas.Text = "";
            txtNumero.Text = "";
            errorProvider1.Clear();
            lblError.Text = "";
            dtpPartida.Value = DateTime.Now;
            dtpArribo.Value = DateTime.Now;
            cbTerminal.SelectedIndex = -1;
            cbCompañia.SelectedIndex = -1;
        }

        private void ActivoActualizacion()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            errorProvider1.Clear();
            lblError.Text = "";

            txtNumero.Enabled = false;
            txtCantAsientos.Text = objNacionales.cantAsientos.ToString();
            txtCantParadas.Text = objNacionales.cantAsientos.ToString();
            txtEmpleado.Text = objNacionales.e.nombreCompleto;
            dtpPartida.Value = objNacionales.partida;
            dtpArribo.Value = objNacionales.arribo;
            cbCompañia.SelectedItem = objNacionales.c.nombre;
            cbTerminal.SelectedItem = objNacionales.t.codigo;
        }

        private void ActivoAgregar()
        {
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            errorProvider1.Clear();
            lblError.Text = "";

            txtNumero.Enabled = false;
            txtCantAsientos.Text = "";
            txtCantParadas.Text = "";
            txtEmpleado.Text = empLogueado.nombreCompleto;
            dtpPartida.Value = DateTime.Now;
            dtpArribo.Value = DateTime.Now;
        }

        private void txtNumero_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                WebService WS = new WebService();
                if (txtNumero.Text.Length != 0)
                {
                    errorProvider1.Clear();
                    Viajes viaje = WS.BuscarViaje(Convert.ToInt32(txtNumero.Text));
                    if (viaje is Internacionales)
                    {
                        errorProvider1.SetError(txtNumero, "Este viaje es de tipo Internacional.");
                    }
                    else
                    {
                        objNacionales = (Nacionales)viaje;
                        if (objNacionales == null)
                        {
                            this.ActivoAgregar();
                        }
                        else
                        {
                            this.ActivoActualizacion();
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtNumero, "Debe rellenar este campo.");
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

        private void txtCantAsientos_Validating(object sender, CancelEventArgs e)
        {
            if (txtCantAsientos.Text == "")
                errorProvider1.SetError(txtCantAsientos, "Debe rellenar este campo.");
            else
                errorProvider1.Clear();
        }

        private void dtpPartida_Validating(object sender, CancelEventArgs e)
        {
            if (dtpPartida.Value < DateTime.Now)
            {
                errorProvider1.SetError(dtpPartida, "La fecha debe ser igual o mayor a la fecha actual.");
            }
            else
                errorProvider1.Clear();
        }

        private void dtpArribo_Validating(object sender, CancelEventArgs e)
        {
            if (dtpArribo.Value < dtpPartida.Value)
            {
                errorProvider1.SetError(dtpArribo, "La fecha de arribo no puede ser menor a la fecha de partida.");
            }
            else
                errorProvider1.Clear();
        }

        private void cbTerminal_Validating(object sender, CancelEventArgs e)
        {
            if (cbTerminal.SelectedIndex == -1)
                errorProvider1.SetError(cbTerminal, "Debe seleccionar una terminal.");
            else
                errorProvider1.Clear();
        }

        private void cbCompañia_Validating(object sender, CancelEventArgs e)
        {
            if (cbCompañia.SelectedIndex == -1)
                errorProvider1.SetError(cbCompañia, "Debe seleccionar una compañía.");
            else
                errorProvider1.Clear();
        }

        private void txtCantParadas_Validating(object sender, CancelEventArgs e)
        {
            if (txtCantParadas.Text == "")
                errorProvider1.SetError(txtCantParadas, "Debe rellenar este campo.");
            else
                errorProvider1.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                WebService WS = new WebService();
                objNacionales = new Nacionales();
                objNacionales.numero = Convert.ToInt32(txtNumero);
                objNacionales.cantAsientos = Convert.ToInt32(txtCantAsientos.Text);
                objNacionales.partida = dtpPartida.Value;
                objNacionales.arribo = dtpArribo.Value;
                objNacionales.e = empLogueado;
                foreach (Terminal t in listaT)
                {
                    if (t.ciudad == cbTerminal.SelectedItem.ToString())
                    {
                        objNacionales.t = t;
                    }
                }
                foreach (Compania c in listaC)
                {
                    if (c.nombre == cbCompañia.SelectedItem.ToString())
                    {
                        objNacionales.c = c;
                    }
                }
                objNacionales.cantAsientos = Convert.ToInt32(txtCantAsientos.Text);

                WS.AltaViaje(objNacionales);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                WebService WS = new WebService();
                WS.BajaViaje(objNacionales);
                lblError.Text = "Baja con éxito.";
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
                objNacionales.numero = Convert.ToInt32(txtNumero);
                objNacionales.cantAsientos = Convert.ToInt32(txtCantAsientos.Text);
                objNacionales.partida = dtpPartida.Value;
                objNacionales.arribo = dtpArribo.Value;
                objNacionales.e = empLogueado;
                foreach (Terminal t in listaT)
                {
                    if (t.ciudad == cbTerminal.SelectedItem.ToString())
                    {
                        objNacionales.t = t;
                    }
                }
                foreach (Compania c in listaC)
                {
                    if (c.nombre == cbCompañia.SelectedItem.ToString())
                    {
                        objNacionales.c = c;
                    }
                }
                objNacionales.cantAsientos = Convert.ToInt32(txtCantAsientos.Text);

                WS.ModificarViaje(objNacionales);

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
