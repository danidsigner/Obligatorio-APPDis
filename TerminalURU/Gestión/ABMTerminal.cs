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
    public partial class ABMTerminal : Form
    {
        private Terminal objTerminal = null;
        public ABMTerminal()
        {
            InitializeComponent();
        }

        private void Terminal_Load(object sender, EventArgs e)
        {
            this.ActivoPorDefecto();
        }

        private void ActivoPorDefecto()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

            txtCodigo.Enabled = true;
            txtCodigo.Text = "";
            txtCiudad.Text = "";
            txtPais.Text = "";
            txtFacilidad.Text = "";
            lbFacilidades.DataSource = null;
        }

        private void ActivoActualizacion()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;

            txtCodigo.Enabled = false;
            txtCiudad.Text = objTerminal.ciudad;
            txtPais.Text = objTerminal.pais;
            lbFacilidades.DataSource = objTerminal.facilidades;
        }

        private void ActivoAgregar()
        {
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

            txtCodigo.Enabled = false;
            txtCiudad.Text = "";
            txtPais.Text = "";
            txtFacilidad.Text = "";
            lbFacilidades.DataSource = null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lista = new List<string>();
                foreach (string f in lbFacilidades.Items)
                {
                    lista.Add(f);
                }
                WebService WS = new WebService();
                objTerminal = new Terminal();
                objTerminal.codigo = txtCodigo.Text;
                objTerminal.ciudad = txtCiudad.Text;
                objTerminal.pais = txtPais.Text;
                objTerminal.facilidades = lista.ToArray();

                WS.AltaTerminal(objTerminal);

                lblError.Text = "Alta con éxito.";
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
                List<string> lista = new List<string>();
                foreach (string f in lbFacilidades.Items)
                {
                    lista.Add(f);
                }
                WebService WS = new WebService();
                objTerminal.codigo = txtCodigo.Text;
                objTerminal.ciudad = txtCiudad.Text;
                objTerminal.pais = txtPais.Text;
                objTerminal.facilidades = lista.ToArray();

                WS.ModificarTerminal(objTerminal);

                lblError.Text = "Modificación con éxito.";
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
                WS.BajaTerminal(objTerminal);

                lblError.Text = "Baja con éxito.";
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

        private void btnAgregarFacilidad_Click(object sender, EventArgs e)
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
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                lblError.Text = ex.Message;
            }
            catch (Exception ex)
            { lblError.Text = ex.Message; }
        }

        private void btnEliminarFacilidad_Click(object sender, EventArgs e)
        {
            try
            {
                lbFacilidades.Items.Remove(lbFacilidades.SelectedItem);
            }
            catch (Exception ex)
            { lblError.Text = ex.Message; }
        }
    }
}
