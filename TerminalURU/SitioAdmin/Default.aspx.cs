using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class Logueo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["Empleado"] = null;
        }
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            Empleado E = FabricaLogica.GetLogicaEmpleado().Logeo(Convert.ToInt32(txtUser.Text), txtPass.Text);

            if (E != null)
            {
                lblerror.Text = "";
                Session["Empleado"] = E;
                Response.Redirect("ABMEmpleado.aspx");
            }
            else
            {
                throw new Exception("Usuario y/o contraseña incorrecta.");
            }
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
        }
    }
}