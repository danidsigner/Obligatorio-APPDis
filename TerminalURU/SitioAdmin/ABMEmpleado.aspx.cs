using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABMEmpleado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            Empleado E = new Empleado(Convert.ToInt32(txtBuscar.Text), txtNom.Text, txtPass.Text);
            FabricaLogica.GetLogicaEmpleado().AltaEmpleado(E);
            lblError.Text = "Empleado registrado con éxito.";
            txtPass.Text = "";
            txtPass.Enabled = false;
            txtNom.Text = "";
            txtNom.Enabled = false;
            txtBuscar.Text = "";
            txtBuscar.ReadOnly = false;
            btnAlta.Enabled = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnModificarC_Click(object sender, EventArgs e)
    {
        try
        {
            Empleado E = (Empleado)Session["EmpleadoEncontrado"];
            FabricaLogica.GetLogicaEmpleado().ModificarEmpleado(E);
            lblError.Text = "Empleado modificado con éxito.";
            txtBuscar.ReadOnly = false;
            txtBuscar.Text = "";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Empleado E;
            txtNom.Enabled = true;
            txtPass.Enabled = true;
            txtBuscar.ReadOnly = true;
            lblError.Text = "";
            E = FabricaLogica.GetLogicaEmpleado().BuscarEmpleadosActivos(Convert.ToInt32(txtBuscar.Text));
            if (E != null)
            {
                txtNom.Text = E.nombreCompleto;
                txtPass.Text = E.contraseña;
                btnEliminar.Enabled = true;
                btnModificarC.Enabled = true;
                btnAlta.Enabled = false;
                Session["EmpleadoEncontrado"] = E;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnModificarC.Enabled = false;
                btnAlta.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Empleado E = (Empleado)Session["EmpleadoEncontrado"];
            Empleado ELogueado = (Empleado)Session["Empleado"];
            FabricaLogica.GetLogicaEmpleado().BajaEmpleado(E);
            btnModificarC.Enabled = false;
            txtNom.Text = "";
            txtNom.Enabled = false;
            txtPass.Text = "";
            txtPass.Enabled = false;
            txtBuscar.Text = "";
            txtBuscar.ReadOnly = false;
            btnEliminar.Enabled = false;
            lblError.Text = "Empleado eliminado con éxito.";
            if (E.ci==ELogueado.ci)
            {
                Session["Empleado"]=null;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        btnEliminar.Enabled = false;
        btnAlta.Enabled = false;
        btnModificarC.Enabled = false;
        txtPass.Enabled = false;
        txtNom.Enabled = false;
        lblError.Text = "";
        txtBuscar.Text = "";
        txtBuscar.ReadOnly = false;
        txtNom.Text = "";
        txtPass.Text = "";
    }
}

