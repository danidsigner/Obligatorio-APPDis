using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Controles
{
    public class Horas : DropDownList
    {
        public Horas()
        {
            for (int horas = 0; horas <= 23; horas++)
            {
                this.Items.Add(horas.ToString());
            }
            DataBind();
        }

        public int SelectedHoras
        {
            get { return this.SelectedIndex; }
            set
            {
                if ((value >= 0) && (value <= 23))
                {
                    this.SelectedIndex = value;
                }
                else
                {
                    throw new InvalidCastException("Hora inválida");
                }
            }
        }
    }
}

