using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Controles
{
    public class Dias:DropDownList
    {
        public Dias()
        {
            for (int dias = 1; dias <= 31; dias++)
            {
                this.Items.Add(dias.ToString());
            }
            //DataBind();
        }

        public int SelectedDia
        {
            get { return this.SelectedIndex + 1; }
            set
            {
                if ((value > 0) && (value <= 31))
                {
                    this.SelectedIndex = value - 1;
                }
                else
                {
                    throw new InvalidCastException("Día inválido");
                }
            }
        }
    }
}
