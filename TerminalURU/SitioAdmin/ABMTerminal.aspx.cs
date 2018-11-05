using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Persistencia;
using Logica;
public partial class ABMTerminal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        Terminal T;
        List<string> f = new List<string>();
        try
        {
            foreach (ListItem i in lbFacilidades.Items)
            {
                f.Add(i.ToString());
            }

            T = new Terminal(txtBuscar.Text.ToUpper().Trim(), txtCiudad.Text, txtPais.Text, f);

            FabricaLogica.GetLogicaTerminal().AltaTerminal(T);
            Panel2.Enabled = false;
            btnBaja.Enabled = false;
            txtBuscar.Enabled = true;
            txtFacilidad.Text = "";
            txtPais.Text = "";
            txtCiudad.Text = "";
            txtBuscar.Text = "";
            lblInfo.Text = "Se ha registrado con éxito la terminal";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
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
                foreach (ListItem l in lbFacilidades.Items)
                {
                    if (l.Value == txtFacilidad.Text.ToUpper().Trim() && txtFacilidad.Text.Length > 0)
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
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        lbFacilidades.Items.Remove(lbFacilidades.SelectedItem);
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        List<string> l = new List<string>();
        try
        {
            Terminal T = FabricaLogica.GetLogicaTerminal().BuscarTerminalActiva(txtBuscar.Text);
            lbFacilidades.ClearSelection();
            Panel2.Enabled = true;
            if (T != null)
            {
                btnBaja.Enabled = true;
                txtBuscar.Enabled = false;
                btnRegistrar.Enabled = false;
                Panel2.Enabled = true;
                lblError.Text = "";
                txtCiudad.Text = T.ciudad;
                txtPais.Text = T.pais;

                foreach (string s in T.facilidades)
                {
                    lbFacilidades.Items.Add(s);
                }
                Session["Terminal"] = T;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnRegistrar.Enabled = true;
                lblError.Text = "La terminal no existe";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Terminal T = (Terminal)Session["Terminal"];
            T.ciudad = txtCiudad.Text;
            T.pais = txtPais.Text;
            if (lbFacilidades.Items.Count >= 0)
            {
                T.facilidades.Clear();

                foreach (ListItem l in lbFacilidades.Items)
                {
                    T.facilidades.Add(l.ToString());
                }
            }
            FabricaLogica.GetLogicaTerminal().ModificarTerminal(T);
            Panel2.Enabled = false;
            btnBaja.Enabled = false;
            txtBuscar.Enabled = true;
            txtBuscar.Text = "";
            txtCiudad.Text = "";
            txtPais.Text = "";
            txtFacilidad.Text = "";
            lbFacilidades.Items.Clear();
            lblInfo.Text = "La terminal ha sido modificada con éxito";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            Terminal T = (Terminal)Session["Terminal"];
            FabricaLogica.GetLogicaTerminal().BajaTerminal(T);
            Panel2.Enabled = false;
            btnBaja.Enabled = false;
            txtBuscar.Enabled = true;
            txtBuscar.Text = "";
            txtCiudad.Text = "";
            txtPais.Text = "";
            txtFacilidad.Text = "";
            lblInfo.Text = "La terminal ha sido dada de baja correctamente";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Panel2.Enabled = false;
        btnBaja.Enabled = false;
        txtBuscar.Enabled = true;
        txtBuscar.Text = "";
        txtCiudad.Text = "";
        txtPais.Text = "";
        txtFacilidad.Text = "";
        lbFacilidades.Items.Clear();
        lblError.Text = "";
    }
}