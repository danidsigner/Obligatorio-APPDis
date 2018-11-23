using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]
    public class Compania
    {
        private string Nombre;
        private string Direccion;
        private long Telefono;


        public string nombre
        {
            get { return Nombre; }
            set
            {
                if (value.Length > 2 && value.Length < 50)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (Char.IsNumber(value[i]))
                        {
                            throw new Exception("ExcepcionEX: Error: Ingrese un nombre válido.FinExcepcionEX");
                        }
                    }
                    Nombre = value.ToUpper().Trim();
                }
            }
        }


        public string direccion
        {
            get { return Direccion; }
            set
            {
                if (value.Length > 0)
                {
                    Direccion = value;
                }
                else
                {
                    throw new Exception("ExcepcionEX: Error: Ingrese una dirección válida.FinExcepcionEX");
                }
            }
        }


        public long telefono
        {
            get { return Telefono; }
            set
            {
                if (value.ToString().Length < 7 || value.ToString().Length > 13)
                {
                    throw new Exception("ExcepcionEX: Error: Ingrese un teléfono válido.FinExcepcionEX");
                }
                else
                {
                    Telefono = value;
                }
            }

        }

        public Compania(string _n, string _d, long _t)
        {
            nombre = _n;
            direccion = _d;
            telefono = _t;
        }
        public Compania()
        { }
    }
}
