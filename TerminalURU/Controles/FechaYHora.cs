using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
namespace Controles
{
    public class FechaYHora : WebControl, INamingContainer
    {
        private Dias dias;
        private Meses meses;
        private Años años;
        private Horas horas;
        private Minutos minutos;
        private Panel panel;

        public DateTime Fecha
        {
            get
            {
                try
                {
                    return (new DateTime(años.SelectedAños,meses.SeleccionMes,dias.SelectedDia,horas.SelectedHoras,minutos.SelectedMinutos,0));
                }
                catch
                {
                    throw new Exception("Los valores seleccionados no pertenecen a una fecha real");
                }
            }
            set
            {
                //try
                //{
                EnsureChildControls();
                años.SelectedAños = value.Year;
                meses.SeleccionMes = value.Month;
                dias.SelectedDia = value.Day;
                horas.SelectedHoras = value.Hour;
                minutos.SelectedMinutos = value.Minute;

                //}
                //catch
                //{
                //    throw new Exception("Los valores seleccionados no pertenecen a una fecha real");
                //}
            }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            dias = new Dias();
            meses = new Meses();
            años = new Años();
            horas = new Horas();
            minutos = new Minutos();
            panel = new Panel();


            panel.Controls.Add(dias);
            panel.Controls.Add(meses);
            panel.Controls.Add(años);
            panel.Controls.Add(horas);
            panel.Controls.Add(minutos);

            this.Controls.Add(panel);
        }

    }
}
