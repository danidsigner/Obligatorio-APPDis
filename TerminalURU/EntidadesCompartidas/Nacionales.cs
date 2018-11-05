using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]
    public class Nacionales : Viajes
    {
        private int Paradas;

        public int paradas
        {
            get { return Paradas; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Ingrese un cantidad de paradas válida");
                }
                else
                {
                    Paradas = value;
                }
            }
            
        }
        public Nacionales(int numero, int cantAsientos, DateTime partida, DateTime arribo , Empleado e,Terminal t,Compania c, int p):base(numero,cantAsientos,partida,arribo,e,t,c )
        {
            paradas = p;
        }

        public Nacionales()
        { }
    }
}
