using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Controles
{
    public class Minutos : DropDownList
    {
        public Minutos()
        {
            for (int minutos = 0; minutos < 60; minutos += 5)
            {
                this.Items.Add(minutos.ToString());
            }
            DataBind();
        }

        public int SelectedMinutos
        {
            get { return Convert.ToInt32(this.SelectedValue); }
            set
            {
                if ((value >= 0) && (value < 60))
                {
                    this.SelectedIndex = value / 5;
                }
                else
                {
                    throw new InvalidCastException("Minuto inválido");
                }
            }
        }
    }
}
