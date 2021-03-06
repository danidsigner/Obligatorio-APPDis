﻿using System;
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

        private void ViajesInternacionales_Load(object sender, EventArgs e)
        {
            try
            {
                
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

        private void ActivoPorDefecto()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

            cbCompañia.SelectedIndex = 0;
            cbTerminal.SelectedIndex = 0;
            txtNumero.Enabled = true;
            txtNumero.Text = "";
            txtEmpleado.Text = empLogueado.nombreCompleto;
            txtCantAsientos.Text = "";
            dtpPartida.Value = DateTime.Now;
            dtpArribo.Value = DateTime.Now;
            cbServAbordo.Checked = false;
            txtDocumentacion.Text = "";
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

            txtNumero.Enabled = false;
            txtCantAsientos.Text = objViajeInter.cantAsientos.ToString();
            dtpPartida.Value = objViajeInter.partida;
            dtpArribo.Value = objViajeInter.arribo;
            cbCompañia.SelectedItem = objViajeInter.c.nombre;
            cbTerminal.SelectedItem = objViajeInter.t.codigo;
            if (objViajeInter.servAbordo == true)
            {
                cbServAbordo.Checked = true;
            }
            else
            {
                cbServAbordo.Checked = false;
            }
            
            txtDocumentacion.Text = objViajeInter.documentacion;
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
            try
            {
                bool bandera = true;
                int salida = 0;
                WebService WS = new WebService();
                objViajeInter = new Internacionales();
                objViajeInter.numero = Convert.ToInt32(txtNumero.Text);
                if (Int32.TryParse(txtCantAsientos.Text, out salida))
                {
                    objViajeInter.cantAsientos = salida;
                    bandera = true;
                }
                else
                {
                    lblError.Text = "Ingrese una cantidad de asientos válida.";
                    bandera = false;
                }
                objViajeInter.partida = dtpPartida.Value;
                objViajeInter.arribo = dtpArribo.Value;

                objViajeInter.e = empLogueado;
                foreach (Terminal t in listaT)
                {
                    if (t.codigo == cbTerminal.SelectedItem.ToString())
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
                if (bandera == true)
                {
                    WS.AltaViaje(objViajeInter);

                    this.ActivoPorDefecto();
                    lblError.Text = "Alta con éxito.";
                    errorProvider1.Clear();
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                bool bandera = true;
                int salida = 0;
                WebService WS = new WebService();
                objViajeInter = new Internacionales();
                objViajeInter.numero = Convert.ToInt32(txtNumero.Text);

                if (Int32.TryParse(txtCantAsientos.Text, out salida))
                {
                    objViajeInter.cantAsientos = salida;
                    bandera = true;
                }
                else
                {
                    lblError.Text = "Ingrese una cantidad de asientos válida.";
                    bandera = false;
                }
                objViajeInter.partida = dtpPartida.Value;
                objViajeInter.arribo = dtpArribo.Value;

                objViajeInter.e = empLogueado;

                foreach (Terminal t in listaT)
                {
                    if (t.codigo == cbTerminal.SelectedItem.ToString())
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
                if (bandera == true)
                {
                    WS.ModificarViaje(objViajeInter);

                    this.ActivoPorDefecto();
                    lblError.Text = "Modificación con éxito.";
                    errorProvider1.Clear();

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                WebService WS = new WebService();
                WS.BajaViaje(objViajeInter);

                this.ActivoPorDefecto();
                lblError.Text = "Baja con éxito.";
                errorProvider1.Clear();

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
