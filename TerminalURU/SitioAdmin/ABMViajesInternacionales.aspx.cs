using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABMViajesInternacionales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Viajes v = FabricaLogica.GetLogicaViajes().BuscarViaje(Convert.ToInt32(txtBusqueda.Text));
            Panel2.Enabled = true;
            txtBusqueda.Enabled = false;
            txtEmpleado.Enabled = false;
            lblError.Text = "";
            if (v is Internacionales)
            {
                Internacionales I = (Internacionales)v;

                Session["ViajeInternacional"] = I;
                FechaYHora1.Fecha = I.partida;
                FechaYHora2.Fecha = I.arribo;
                BtnEliminar.Enabled = true;
                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;

                txtAsiento.Text = I.cantAsientos.ToString();
                txtDocumentacion.Text = I.documentacion;
                txtEmpleado.Text = I.e.ci.ToString();
                txtDestino.Text = I.t.codigo.ToString();
                txtCompania.Text = I.c.nombre;
                rblSAbordo.SelectedValue = I.servAbordo.ToString();
            }
            else if (v is Nacionales)
            {
                throw new Exception("El numero ingresado corresponde a un viaje Nacional.");
            }
            else
            {
                Empleado E = (Empleado)Session["Empleado"];
                txtEmpleado.Text = E.ci.ToString();
                txtAsiento.Text = "";
                txtDestino.Text = "";
                txtCompania.Text = "";
                BtnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnAgregar.Enabled = true;
                txtDocumentacion.Text = "";
                rblSAbordo.SelectedIndex = 1;
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
            Internacionales I = (Internacionales)Session["ViajeInternacional"];

            if (I.c.nombre != txtCompania.Text)
            {
                I.c = FabricaLogica.GetLogicaCompania().BuscarCompaniaActivas(txtCompania.Text);
            }
            if (I.t.codigo != txtDestino.Text)
            {
                I.t = FabricaLogica.GetLogicaTerminal().BuscarTerminalActiva(txtDestino.Text);
            }
            I.e = (Empleado)Session["Empleado"];
            I.cantAsientos = Convert.ToInt32(txtAsiento.Text);
            I.documentacion = txtDocumentacion.Text;
            I.servAbordo = Convert.ToBoolean(rblSAbordo.SelectedValue);
            I.partida = FechaYHora1.Fecha;
            I.arribo = FechaYHora2.Fecha;

            FabricaLogica.GetLogicaViajes().ModificarViaje(I);
            Panel2.Enabled = false;
            BtnEliminar.Enabled = false;
            txtBusqueda.Enabled = true;
            txtBusqueda.Text = "";
            txtAsiento.Text = "";
            txtCompania.Text = "";
            txtDestino.Text = "";
            txtDocumentacion.Text = "";
            txtEmpleado.Text = "";
            rblSAbordo.ClearSelection();
            lblError.Text = "Viaje modificado con éxito";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            Compania C = FabricaLogica.GetLogicaCompania().BuscarCompaniaActivas(txtCompania.Text);
            Empleado E = (Empleado)Session["Empleado"];
            Terminal T = FabricaLogica.GetLogicaTerminal().BuscarTerminalActiva(txtDestino.Text);
            Internacionales I = new Internacionales(Convert.ToInt32(txtBusqueda.Text), Convert.ToInt32(txtAsiento.Text), FechaYHora1.Fecha, FechaYHora2.Fecha, E, T, C, Convert.ToBoolean(rblSAbordo.SelectedValue), txtDocumentacion.Text);
            FabricaLogica.GetLogicaViajes().AltaViaje(I);
            Panel2.Enabled = false;
            BtnEliminar.Enabled = false;
            txtBusqueda.Enabled = true;
            txtBusqueda.Text = "";
            txtAsiento.Text = "";
            txtCompania.Text = "";
            txtDestino.Text = "";
            txtDocumentacion.Text = "";
            txtEmpleado.Text = "";
            rblSAbordo.ClearSelection();
            lblError.Text = "Viaje registrado con éxito.";
        }

        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Internacionales I = (Internacionales)Session["ViajeInternacional"];

            FabricaLogica.GetLogicaViajes().BajaViaje(I);
            Panel2.Enabled = false;
            BtnEliminar.Enabled = false;
            txtBusqueda.Enabled = true;
            txtBusqueda.Text = "";
            txtAsiento.Text = "";
            txtCompania.Text = "";
            txtDestino.Text = "";
            txtDocumentacion.Text = "";
            txtEmpleado.Text = "";
            rblSAbordo.ClearSelection();
            lblError.Text = "Viaje eliminado con éxito.";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Panel2.Enabled = false;
        BtnEliminar.Enabled = false;
        txtBusqueda.Enabled = true;
        txtBusqueda.Text = "";
        txtAsiento.Text = "";
        txtCompania.Text = "";
        txtDestino.Text = "";
        txtDocumentacion.Text = "";
        txtEmpleado.Text = "";
        rblSAbordo.ClearSelection();
        lblError.Text = "";
    }
}