using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class ConsultaIndividualDelViaje : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                Viajes v = (Viajes)Session["viajeElegido"];

                lblNumero.Text = "Numero: " + v.numero.ToString();
                lblPartida.Text = "Partida: " + v.partida.ToString();
                lblArribo.Text = "Arribo" + v.arribo.ToString();
                lblCantAsientos.Text = "Cantidad de Asientos: " + v.cantAsientos.ToString();
                lblEmpleado.Text = "Nombre del Empleado: " + v.e.nombreCompleto;

                if (v is Internacionales)
                {
                    Internacionales i = (Internacionales)v;
                    lblDocumentacion.Text = i.documentacion;
                    if (i.servAbordo == true)
                        lblServAbordo.Text = "Servicio Abordo: Si";
                    else
                        lblServAbordo.Text = "Servicio Abordo: No";
                }
                else
                {
                    Nacionales n = (Nacionales)v;
                    lblParadas.Text = "Cantidad de paradas: " + n.paradas.ToString();
                }

                lblNombre.Text = "Nombre: " + v.c.nombre;
                lblDireccion.Text = "Dirección " + v.c.direccion;
                lblTelefono.Text = "Teléfono: " + v.c.telefono.ToString();

                lblCodigo.Text = "Código: " + v.t.codigo;
                lblCiudad.Text = "Ciudad: " + v.t.ciudad;
                lblPais.Text = "País: " + v.t.pais;

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