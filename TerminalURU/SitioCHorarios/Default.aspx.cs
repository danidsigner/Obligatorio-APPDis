using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ServicioWeb;

public partial class ConsultaViajes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                Session["viajeElegido"] = null;
                WebService WS = new WebService();
                List<Viajes> v = WS.ListarViajes().ToList();

                RepeaterCViajes.DataSource = v;
                RepeaterCViajes.DataBind();

                Session["TodosLosViajes"] = v;
                List<Terminal> terminales = new List<Terminal>();
                List<Compania> companias = new List<Compania>();

                foreach (Viajes viajes in v)
                {
                    terminales.Add(viajes.t);
                    companias.Add(viajes.c);
                }

                var resultadoT = (from t in terminales group t by t.codigo into g
                                   select g.First().codigo + " - " + g.First().ciudad.ToString()).ToList<object>();

                foreach (var j in resultadoT)
                {
                    DDLDestino.Items.Add(j.ToString());
                }

                var resultadoC = ((from c in companias group c by c.nombre into a select a.Key)).ToList<object>();

                foreach (var q in resultadoC)
                {
                    DDLCompania.Items.Add(q.ToString());
                }
                DDLDestino.SelectedIndex = -1;
                DDLCompania.SelectedIndex = -1;

                Dias1.SelectedDia = DateTime.Today.Day;
                Meses1.SeleccionMes = DateTime.Today.Month;
                Años1.SelectedAños = DateTime.Today.Year;

                Dias2.SelectedDia = DateTime.Today.Day;
                Meses2.SeleccionMes = DateTime.Today.Month;
                Años2.SelectedAños = DateTime.Today.Year + 1;

                bloquearFiltros();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }

    protected void RepeaterCViajes_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        List<Viajes> v = (List<Viajes>)Session["TodosLosViajes"];
        if (e.CommandName == "Seleccionar")
        {
            foreach (Viajes j in v)
            {
                if (j.numero == Convert.ToInt32(((Label)(e.Item.Controls[1])).Text))
                {
                    Session["viajeElegido"] = j;
                    Response.Redirect("ConsultaIndividualDeViaje.aspx");
                }
            }
        }
    }

    protected void bntLimpiarFiltros_Click(object sender, EventArgs e)
    {
        DDLCompania.ClearSelection();
        DDLDestino.ClearSelection();
        Años1.ClearSelection();
        RepeaterCViajes.DataSource = (List<Viajes>)Session["TodosLosViajes"];
        RepeaterCViajes.DataBind();
        bloquearFiltros();
    }
    protected void btnFiltro_Click(object sender, EventArgs e)
    {
        try
        {
            List<Viajes> viajes = (List<Viajes>)Session["TodosLosViajes"];
            DateTime fecha1 = new DateTime(Años1.SelectedAños, Meses1.SeleccionMes, Dias1.SelectedDia, 0, 0, 0);
            DateTime fecha2 = new DateTime(Años2.SelectedAños, Meses2.SeleccionMes,Dias2.SelectedDia,23,59,59);
            List<Viajes> resultado = new List<Viajes>();

            if (DDLDestino.SelectedIndex != 0)
            {
                string destino = DDLDestino.SelectedValue.ToString();
                string a = destino.Substring(0,3);
                resultado = (from v in viajes where v.t.codigo.Contains(a) select v).ToList();
                DDLCompania.Enabled = true;
                Dias1.Enabled = true;
                Meses1.Enabled = true;
                Años1.Enabled = true;
                Dias2.Enabled = true;
                Meses2.Enabled = true;
                Años2.Enabled = true;
                if (DDLCompania.SelectedIndex != 0)
                {
                    string c = DDLCompania.SelectedValue.ToString();
                    resultado = (from v in resultado
                                 where v.c.nombre.Contains(c)
                                 select v).ToList();
                }
                if (fecha1 >= DateTime.Today && fecha2 > fecha1)
                {
                    resultado = (from v in resultado
                                 where (Convert.ToDateTime(v.partida.ToString("yyyy/MM/dd")) >= fecha1 &&
                                       Convert.ToDateTime(v.partida.ToString("yyyy/MM/dd")) <= fecha2)
                                 select v).ToList();
                }
            }
            

            RepeaterCViajes.DataSource = resultado;
            RepeaterCViajes.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void DDLDestino_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLDestino.SelectedIndex != -1)
        {
            btnFiltro.Enabled = true;
            
        }
    }

    public void bloquearFiltros()
    {
        btnFiltro.Enabled = false;
        DDLCompania.Enabled = false;
        Dias1.Enabled = false;
        Meses1.Enabled = false;
        Años1.Enabled = false;
        Dias2.Enabled = false;
        Meses2.Enabled = false;
        Años2.Enabled = false;
    }
}