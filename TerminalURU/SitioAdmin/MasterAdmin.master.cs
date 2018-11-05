using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Persistencia;
using Logica;

public partial class MasterAdmin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Session["Empleado"] != null)
                {
                    Empleado E = (Empleado)Session["Empleado"];
                    LblUsuario.Text = E.nombreCompleto;
                }
                else
                {
                    Response.Redirect("Dafault.aspx");
                }
            }
            catch (Exception ex)
            {
                LblUsuario.Text = ex.Message;
            }

        }

    }
    protected void BtnCerrarSesion_Click(object sender, EventArgs e)
    {
        Session["Empleado"] = null;

        LblUsuario.Text = "";
        Response.Redirect("Default.aspx");
    }
}
