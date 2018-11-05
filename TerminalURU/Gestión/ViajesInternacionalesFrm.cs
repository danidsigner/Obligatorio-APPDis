using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestión.ServicioWeb;
using System.Xml;
using System.Web.Services.Protocols;

namespace Gestión
{
    public partial class ViajesInternacionalesFrm : Form
    {
        private Internacionales objViajeInter = null;
        private Empleado empLogueado;
        private Array listaT;
        private Array listaC;

        public ViajesInternacionalesFrm(Empleado emp)
        {
            InitializeComponent();
            empLogueado = emp;
        }
        //comentario para ver cambios de github
	//comentario git biran
        private void ViajesInternacionales_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActivoPorDefecto();
                WebService WS = new WebService();
                listaT = WS.ListarTerminales();
                listaC = WS.ListarCompanias();
                foreach (Terminal t in listaT)
                {
                    cbTerminal.Items.Add(t.ciudad);
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
            dtpPartida.Value = DateTime.Now;
            dtpArribo.Value = DateTime.Now;
            cbServAbordo.Checked = false;
            txtDocumentacion.Text = "";
            lblError.Text = "";
        }

        private void ActivoActualizacion()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;

            txtNumero.Enabled = false;
            txtCantAsientos.Text = objViajeInter.cantAsientos.ToString();
            dtpPartida.Value = objViajeInter.partida;
            dtpArribo.Value = objViajeInter.arribo;
            txtDocumentacion.Text = "";
        }

        private void ActivoAgregar()
        {
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

            txtNumero.Enabled = false;
            txtCantAsientos.Text = "";
            dtpPartida.Value = DateTime.Now;
            dtpArribo.Value = DateTime.Now;
            cbServAbordo.Checked = false;
            txtDocumentacion.Text = "";
            txtEmpleado.Text = empLogueado.nombreCompleto;
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

                    if (viaje is Nacionales)
                    {
                        errorProvider1.SetError(txtNumero, "Este viaje es de tipo Nacional.");
                    }
                    else
                    {
                        objViajeInter = (Internacionales)viaje;
                        if (objViajeInter == null)
                        {
                            this.ActivoAgregar();
                        }
                        else
                        {
                            this.ActivoActualizacion();
                            txtEmpleado.Text = objViajeInter.e.nombreCompleto;
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
                lblError.Text = ex.Message;
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

        private void txtDocumentacion_Validating(object sender, CancelEventArgs e)
        {
            if (txtDocumentacion.Text.Length == 0)
                errorProvider1.SetError(txtDocumentacion, "Debe rellenar este campo.");
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //
            //
            //consultar si puede haber mas de una terminal en la misma ciudad
            //
            //
            try
            {
                WebService WS = new WebService();
                objViajeInter = new Internacionales();
                objViajeInter.numero = Convert.ToInt32(txtNumero);
                objViajeInter.cantAsientos = Convert.ToInt32(txtCantAsientos.Text);
                objViajeInter.partida = dtpPartida.Value;
                objViajeInter.arribo = dtpArribo.Value;
                objViajeInter.e = empLogueado;
                foreach (Terminal t in listaT)
                {
                    if (t.ciudad == cbTerminal.SelectedItem.ToString())
                    {
                        objViajeInter.t = t;
                    }
                }
                foreach (Compania c in listaC)
                {
                    if (c.nombre == cbCompañia.SelectedItem.ToString())
                    {
                        objViajeInter.c = c;
                    }
                }
                objViajeInter.servAbordo = cbServAbordo.Checked;
                objViajeInter.documentacion = txtDocumentacion.Text;

                WS.AltaViaje(objViajeInter);
                lblError.Text = "Alta con éxito.";
                this.ActivoPorDefecto();
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                WebService WS = new WebService();
                objViajeInter.numero = Convert.ToInt32(txtNumero);
                objViajeInter.cantAsientos = Convert.ToInt32(txtCantAsientos.Text);
                objViajeInter.partida = dtpPartida.Value;
                objViajeInter.arribo = dtpArribo.Value;
                objViajeInter.e = empLogueado;
                foreach (Terminal t in listaT)
                {
                    if (t.ciudad == cbTerminal.SelectedItem.ToString())
                    {
                        objViajeInter.t = t;
                    }
                }
                foreach (Compania c in listaC)
                {
                    if (c.nombre == cbCompañia.SelectedItem.ToString())
                    {
                        objViajeInter.c = c;
                    }
                }
                objViajeInter.servAbordo = cbServAbordo.Checked;
                objViajeInter.documentacion = txtDocumentacion.Text;

                WS.ModificarViaje(objViajeInter);
                lblError.Text = "Modificación con éxito.";
                this.ActivoPorDefecto();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                WebService WS = new WebService();
                WS.BajaViaje(objViajeInter);
                lblError.Text = "Baja con éxito.";
                this.ActivoPorDefecto();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.ActivoPorDefecto();
        }
    }
}
