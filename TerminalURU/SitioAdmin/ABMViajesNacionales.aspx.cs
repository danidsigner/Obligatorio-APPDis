using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABMViajesNacionales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Viajes v = FabricaLogica.GetLogicaViajes().BuscarViaje(Convert.ToInt32(txtBusqueda.Text));
            txtBusqueda.Enabled = false;
            txtEmpleado.Enabled = false;
            Panel2.Enabled = true;
            lblError.Text = "";
            if (v is Nacionales)
            {
                Nacionales n = (Nacionales)v;
                Panel2.Visible = true;
                Session["ViajeNacional"] = n;
                FechaYHora3.Fecha = n.partida;
                FechaYHora4.Fecha = n.arribo;

                txtAsiento.Text = n.cantAsientos.ToString();
                txtParadas.Text = n.paradas.ToString();
                txtEmpleado.Text = n.e.ci.ToString();
                txtDestino.Text = n.t.codigo.ToString();
                txtCompania.Text = n.c.nombre;

                BtnEliminar.Enabled = true;
                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
            }
            else if (v is Internacionales)
            {
                txtBusqueda.Enabled = true;
                Panel2.Enabled = false;
                throw new Exception("El numero ingresado corresponde a un viaje Internacional.");
            }
            else
            {
                Empleado E = (Empleado)Session["Empleado"];
                txtEmpleado.Text = E.ci.ToString();
                txtAsiento.Text = "";
                txtParadas.Text = "";
                txtDestino.Text = "";
                txtCompania.Text = "";
                btnModificar.Enabled = false;
                btnAgregar.Enabled = true;
            }
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
            Nacionales N = new Nacionales(Convert.ToInt32(txtBusqueda.Text), Convert.ToInt32(txtAsiento.Text), FechaYHora3.Fecha, FechaYHora4.Fecha, E, T, C, Convert.ToInt32(txtParadas.Text));
            FabricaLogica.GetLogicaViajes().AltaViaje(N);
            Panel2.Enabled = false;
            txtBusqueda.Enabled = true;
            txtBusqueda.Text = "";
            txtAsiento.Text = "";
            txtParadas.Text = "";
            txtDestino.Text = "";
            txtCompania.Text = "";
            lblError.Text = "Viaje registrado con éxito.";
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
            Nacionales n = (Nacionales)Session["ViajeNacional"];

            if (n.c.nombre != txtCompania.Text)
            {
                n.c = FabricaLogica.GetLogicaCompania().BuscarCompaniaActivas(txtCompania.Text);
            }
            if (n.t.codigo != txtDestino.Text)
            {
                n.t = FabricaLogica.GetLogicaTerminal().BuscarTerminalActiva(txtDestino.Text);
            }
            n.e = (Empleado)Session["Empleado"];
            n.cantAsientos = Convert.ToInt32(txtAsiento.Text);
            n.paradas = Convert.ToInt32(txtParadas.Text);
            n.partida = FechaYHora3.Fecha;
            n.arribo = FechaYHora4.Fecha;

            Panel2.Enabled = false;
            txtBusqueda.Enabled = true;
            txtBusqueda.Text = "";
            txtAsiento.Text = "";
            txtParadas.Text = "";
            txtDestino.Text = "";
            txtCompania.Text = "";
            BtnEliminar.Enabled = false;
            FabricaLogica.GetLogicaViajes().ModificarViaje(n);
            lblError.Text = "Viaje modificado con éxito";
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
            Nacionales n = (Nacionales)Session["ViajeNacional"];
            FabricaLogica.GetLogicaViajes().BajaViaje(n);
            Panel2.Visible = false;
            BtnEliminar.Visible = false;
            lblError.Text = "Viaje eliminado con éxito.";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }
}