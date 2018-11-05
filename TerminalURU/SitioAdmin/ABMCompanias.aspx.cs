using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using EntidadesCompartidas;

public partial class ABMCompanias : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Compania c;
            txtNombre.ReadOnly = true;
            txttel.Enabled = true;
            txtDir.Enabled = true;
            lblError.Text = "";
            c = FabricaLogica.GetLogicaCompania().BuscarCompaniaActivas(txtNombre.Text);
            if (c != null)
            {
                btnEliminar.Enabled = true;
                btnRegistrar.Enabled = false;
                btnModificarC.Enabled = true;
                lblTitulo.Text = "Modificar Compañía";
                txtDir.Text = c.direccion;
                txttel.Text = c.telefono.ToString();
                Session["Compania"] = c;
            }

            else
            {
                lblTitulo.Text = "Registrar Compañía";
                btnEliminar.Enabled = false;
                btnRegistrar.Enabled= true;
                btnModificarC.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }


    }

    protected void btnAccion_Click(object sender, EventArgs e)
    {
        Compania C;
        try
        {
            C = new Compania(txtNombre.Text, txtDir.Text, Convert.ToInt64(txttel.Text));

            FabricaLogica.GetLogicaCompania().AltaCompania(C);
            lblError.Text = "Compania registrada con éxito";
            btnEliminar.Enabled = false;
            btnModificarC.Enabled = false;
            btnRegistrar.Enabled = false;
            txtDir.Text = "";
            txtNombre.Text = "";
            txttel.Text = "";
            txttel.Enabled = false;
            txtDir.Enabled = false;
            txtNombre.ReadOnly = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnModificarC_Click(object sender, EventArgs e)
    {
        Compania C;
        try
        {
            C = (Compania)Session["Compania"];

            FabricaLogica.GetLogicaCompania().ModificarCompania(C);
            lblError.Text = "Compania modificada con éxito";
            btnEliminar.Enabled = false;
            btnModificarC.Enabled = false;
            txttel.Enabled = false;
            txtDir.Enabled = false;
            txtNombre.ReadOnly = false;
            txtDir.Text = "";
            txttel.Text = "";
            txtNombre.Text = "";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        Compania C;
        try
        {
            C = (Compania)Session["Compania"];
            FabricaLogica.GetLogicaCompania().BajaCompania(C);
            lblError.Text = "Compania eliminada con éxito";
            btnModificarC.Enabled = false;
            btnRegistrar.Enabled = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        btnRegistrar.Enabled = false;
        btnModificarC.Enabled = false;
        btnEliminar.Enabled = false;
        txttel.Enabled = false;
        txtDir.Enabled = false;
        txtDir.Text = "";
        txttel.Text = "";
        txtNombre.Text = "";
        txtNombre.ReadOnly = false;
        lblError.Text = "";
    }
}