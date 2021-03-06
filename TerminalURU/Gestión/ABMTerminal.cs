﻿using System;
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
    public partial class ABMTerminal : Form
    {
        private Terminal objTerminal = null;
        public ABMTerminal ()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Terminal_Load (object sender, EventArgs e)
        {
            this.ActivoPorDefecto();
        }

        private void ActivoPorDefecto ()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            errorProvider1.Clear();
            lblError.Text = "";
            txtCodigo.Enabled = true;
            txtCodigo.Text = "";
            txtCiudad.Text = "";
            txtPais.Text = "";
            txtFacilidad.Text = "";
            txtCodigo.Focus();
            lbFacilidades.Items.Clear();
            errorProvider1.Clear();
        }

        private void ActivoActualizacion ()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            errorProvider1.Clear();
            lblError.Text = "";

            txtCodigo.Enabled = false;
            txtCiudad.Text = objTerminal.ciudad;
            txtPais.Text = objTerminal.pais;
            foreach (string f in objTerminal.facilidades)
            {
                lbFacilidades.Items.Add(f);
            }
        }

        private void ActivoAgregar ()
        {
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            errorProvider1.Clear();
            lblError.Text = "";
            txtCodigo.Enabled = false;
            txtCiudad.Text = "";
            txtPais.Text = "";
            txtFacilidad.Text = "";
            lbFacilidades.DataSource = null;
        }

        private void btnAgregar_Click (object sender, EventArgs e)
        {
            List<string> lista = new List<string>();
            foreach (string f in lbFacilidades.Items)
            {
                lista.Add(f);
            }
            WebService WS = new WebService();
            objTerminal = new Terminal();
            objTerminal.codigo = txtCodigo.Text.ToUpper().Trim();
            objTerminal.ciudad = txtCiudad.Text;
            objTerminal.pais = txtPais.Text;
            objTerminal.facilidades = lista.ToArray();
            try
            {
                WS.AltaTerminal(objTerminal);

                ActivoPorDefecto();
                lblError.Text = "Alta con éxito.";
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
            WebService WS = new WebService();
            List<string> lista = new List<string>();

            foreach (string f in lbFacilidades.Items)
            { lista.Add(f); }

            objTerminal.ciudad = txtCiudad.Text;
            objTerminal.pais = txtPais.Text;
            objTerminal.facilidades = lista.ToArray();
            try
            {
                WS.ModificarTerminal(objTerminal);

                ActivoPorDefecto();
                lblError.Text = "Modificación con éxito.";
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

        private void btnEliminar_Click (object sender, EventArgs e)
        {
            WebService WS = new WebService();

            try
            {
                WS.BajaTerminal(objTerminal);

                ActivoPorDefecto();
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

        private void btnCancelar_Click (object sender, EventArgs e)
        {
            this.ActivoPorDefecto();
        }

        private void btnAgregarFacilidad_Click (object sender, EventArgs e)
        {
            bool repetidos = false;
            try
            {
                if (lbFacilidades.Items.Count == 0 && txtFacilidad.Text.Length > 0)
                {
                    lbFacilidades.Items.Add(txtFacilidad.Text.ToUpper().Trim());
                }
                else
                {
                    foreach (string l in lbFacilidades.Items)
                    {
                        if (l == txtFacilidad.Text.ToUpper().Trim() && txtFacilidad.Text.Length > 0)
                        {
                            repetidos = true;
                        }
                    }
                    if (repetidos == false)
                    {
                        lbFacilidades.Items.Add(txtFacilidad.Text.ToUpper().Trim());
                    }
                }
                txtFacilidad.Text = "";
            }
            catch (Exception ex)
            { lblError.Text = ex.Message; }
        }

        private void btnEliminarFacilidad_Click (object sender, EventArgs e)
        {
            try
            {
                if (lbFacilidades.SelectedIndex != -1)
                {
                    lbFacilidades.Items.RemoveAt(lbFacilidades.SelectedIndex);
                } 
            }
            catch (Exception ex)
            { lblError.Text = ex.Message; }
        }

        private void txtCodigo_Validating (object sender, CancelEventArgs e)
        {
            if (txtCodigo.Text == "" || txtCodigo.Text.Length != 3)
                errorProvider1.SetError(txtCodigo, lblError.Text = "Ingrese un código valido");

            else
            {
                bool numeros = true;
                for (int i = 0; i < txtCodigo.Text.Length; i++)
                {
                    //Comprueba el dato ingresado, verifica que sean letras
                    if (!Char.IsLetter(Convert.ToChar(txtCodigo.Text.Substring(i, 1))))
                    {
                        errorProvider1.SetError(txtCodigo, "Ingrese un código válido.");
                        numeros = false;
                    }
                }

                try
                {
                    WebService WS = new WebService();
                    if (numeros == true)
                    {
                        objTerminal = WS.BuscarTerminalActiva(txtCodigo.Text);
                        if (objTerminal != null)
                        {
                            ActivoActualizacion();
                        }
                        else
                        {
                            ActivoAgregar();
                        }
                        errorProvider1.Clear();
                        lblError.Text = "";
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
        }

        private void txtCiudad_Validating (object sender, CancelEventArgs e)
        {
            if (txtCiudad.Text == "")
                errorProvider1.SetError(txtCiudad, lblError.Text = "Debe ingresar una ciudad");

            else
            {
                errorProvider1.Clear();
                lblError.Text = "";
            }
        }

        private void txtPais_Validating (object sender, CancelEventArgs e)
        {
            if (txtPais.Text == "")
                errorProvider1.SetError(txtPais, lblError.Text = "Debe ingresar un país");

            else
            {
                errorProvider1.Clear();
                lblError.Text = "";
            }
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
