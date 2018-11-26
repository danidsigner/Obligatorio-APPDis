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

        public ViajesNacionalesFrm (Empleado emp)
        {
            InitializeComponent();
            empLogueado = emp;
        }

        private void ViajesNacionalesFrm_Load (object sender, EventArgs e)
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
                cbTerminal.SelectedIndex = 0;
                cbCompañia.SelectedIndex = 0;
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

        private void ActivoPorDefecto ()
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
            cbTerminal.SelectedIndex = 0;
            cbCompañia.SelectedIndex = 0;
        }

        private void ActivoActualizacion ()
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

        private void ActivoAgregar ()
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

        private void txtNumero_Validating (object sender, CancelEventArgs e)
        {
            try
            {
                int salida = 0;
                WebService WS = new WebService();
                if (Int32.TryParse(txtNumero.Text, out salida))
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
                    errorProvider1.SetError(txtNumero, "Ingrese un número válido.");
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

        private void txtCantAsientos_Validating (object sender, CancelEventArgs e)
        {
            int salida = 0;
            if (!Int32.TryParse(txtCantAsientos.Text, out salida))
                errorProvider1.SetError(txtCantAsientos, "Ingrese una cantidad válida.");
            else
                errorProvider1.Clear();
        }

        private void dtpPartida_Validating (object sender, CancelEventArgs e)
        {
            if (dtpPartida.Value < DateTime.Now)
            {
                errorProvider1.SetError(dtpPartida, "La fecha debe ser igual o mayor a la fecha actual.");
            }
            else
                errorProvider1.Clear();
        }

        private void dtpArribo_Validating (object sender, CancelEventArgs e)
        {
            if (dtpArribo.Value < dtpPartida.Value || dtpArribo.Value < DateTime.Now)
            {
                errorProvider1.SetError(dtpArribo, "La fecha de arribo no puede ser menor a la fecha de partida.");
            }
            else
                errorProvider1.Clear();
        }

        private void txtCantParadas_Validating (object sender, CancelEventArgs e)
        {
            int salida = 0;
            if (!Int32.TryParse(txtCantParadas.Text, out salida))
                errorProvider1.SetError(txtCantParadas, "Ingrese una cantidad válida.");
            else
                errorProvider1.Clear();
        }

        private void btnAgregar_Click (object sender, EventArgs e)
        {
            try
            {
                int salida = 0;
                bool bandera = true;
                WebService WS = new WebService();
                objNacionales = new Nacionales();
                objNacionales.numero = Convert.ToInt32(txtNumero.Text);
                objNacionales.partida = dtpPartida.Value;
                objNacionales.arribo = dtpArribo.Value;
                objNacionales.e = empLogueado;

                if (Int32.TryParse(txtCantAsientos.Text, out salida))
                {
                    objNacionales.cantAsientos = salida;
                    bandera = true;
                }
                else
                {
                    lblError.Text = "Ingrese una cantidad de asientos válida.";
                    bandera = false;
                }

                foreach (Terminal t in listaT)
                {
                    if (t.codigo == cbTerminal.SelectedItem.ToString())
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

                if (Int32.TryParse(txtCantParadas.Text, out salida))
                {
                    objNacionales.paradas = salida;
                    bandera = true;
                }
                else
                {
                    lblError.Text = "Ingrese una cantidad de paradas válida.";
                    bandera = false;
                }
                if (bandera == true)
                {
                    WS.AltaViaje(objNacionales);

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

        private void btnEliminar_Click (object sender, EventArgs e)
        {
            try
            {
                WebService WS = new WebService();
                WS.BajaViaje(objNacionales);

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

        private void btnModificar_Click (object sender, EventArgs e)
        {
            try
            {
                int salida = 0;
                bool bandera = true;
                WebService WS = new WebService();
                objNacionales = new Nacionales();
                objNacionales.numero = Convert.ToInt32(txtNumero.Text);
                objNacionales.partida = dtpPartida.Value;
                objNacionales.arribo = dtpArribo.Value;
                objNacionales.e = empLogueado;

                if (Int32.TryParse(txtCantAsientos.Text, out salida))
                {
                    objNacionales.cantAsientos = salida;
                    bandera = true;
                }
                else
                {
                    lblError.Text = "Ingrese una cantidad de asientos válida.";
                    bandera = false;
                }

                foreach (Terminal t in listaT)
                {
                    if (t.codigo == cbTerminal.SelectedItem.ToString())
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
                if (Int32.TryParse(txtCantParadas.Text, out salida))
                {
                    objNacionales.paradas = salida;
                    bandera = true;
                }
                else
                {
                    lblError.Text = "Ingrese una cantidad de paradas válida.";
                    bandera = false;
                }
                if (bandera == true)
                {
                    WS.ModificarViaje(objNacionales);

                    this.ActivoPorDefecto();
                    lblError.Text = "Modificacion con éxito.";
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

        private void btnCancelar_Click (object sender, EventArgs e)
        {
            this.ActivoPorDefecto();
        }

        private void manejoErrorWS (string ex)
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
