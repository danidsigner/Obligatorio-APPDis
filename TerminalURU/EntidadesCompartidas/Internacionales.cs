using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]
    public class Internacionales : Viajes
    {
        private bool ServAbordo;
        private string Documentacion;



        public bool servAbordo
        {
            get { return ServAbordo; }
            set
            {
                /*if (value != null)
                {
                    throw new Exception("Error: Ingrese un servicio a bordo válido.");
                }
                else
                {*/
                    ServAbordo = value;
                /*}*/
            }
        }


        public string documentacion
        {
            get { return Documentacion; }
            set
            {
                if (value.ToString().Length < 5 || value.ToString().Length > 200)
                {
                    throw new Exception("Error: Ingrese una documentación válida.");
                }
                else
                {
                    Documentacion = value;
                }
            }
        }
        public Internacionales (int numero, int cantAsientos, DateTime partida, DateTime arribo , Empleado e,Terminal t,Compania c, bool serv,string doc):base(numero,cantAsientos,partida,arribo,e,t,c )
        {
            servAbordo = serv;
            documentacion = doc;
        }

        public Internacionales()
        { }
    }
}
