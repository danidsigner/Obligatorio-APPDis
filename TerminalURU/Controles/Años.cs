using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;


namespace Controles
{
    public class Años : DropDownList
    {
        public Años()
        {
            for (int anio = DateTime.Now.Year - 1; anio <= DateTime.Now.Year + 1; anio++)
            {
                this.Items.Add(anio.ToString());
            }
            //DataBind();
        }

        public int SelectedAños
        {
            get { return this.SelectedIndex + (DateTime.Now.Year - 1); }
            set
            {
                if ((value <= DateTime.Now.Year + 1) && (value >= DateTime.Now.Year - 1))
                {
                    this.SelectedIndex = value - DateTime.Now.Year +1;
                }
                //else
                //{
                //    throw new InvalidCastException("Año inválido");
                //}
            }
        }
    }
}
