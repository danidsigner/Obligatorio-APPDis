using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ServicioWeb;

public partial class ConsultaIndividualDelViaje : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                Viajes v = (Viajes)Session["viajeElegido"];

                lblNumero.Text = v.numero.ToString();
                lblPartida.Text = v.partida.ToString();
                lblArribo.Text = v.arribo.ToString();
                lblCantAsientos.Text = v.cantAsientos.ToString();
                lblEmpleado.Text = v.e.nombreCompleto;

                if (v is Internacionales)
                {
                    Internacionales i = (Internacionales)v;
                    lblDocumentacion.Text = i.documentacion;
                    if (i.servAbordo == true)
                        lblServAbordo.Text = "Si";
                    else
                        lblServAbordo.Text = "No";
                    lblParadas.Text = "Valór no admitido.";
                }
                else
                {
                    Nacionales n = (Nacionales)v;
                    lblParadas.Text = n.paradas.ToString();
                    lblServAbordo.Text = "Valór no admitido.";
                    lblDocumentacion.Text = "Valór no admitido.";
                }

                lblNombre.Text = v.c.nombre;
                lblDireccion.Text = v.c.direccion;
                lblTelefono.Text = v.c.telefono.ToString();

                lblCodigo.Text = v.t.codigo;
                lblCiudad.Text = v.t.ciudad;
                lblPais.Text = v.t.pais;

                GDVFacilidades.DataSource = v.t.facilidades;
                GDVFacilidades.ShowHeader = false;
                GDVFacilidades.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
        Session["viajeElegido"] = null;
    }
}