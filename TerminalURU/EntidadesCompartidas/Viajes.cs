using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]
    public abstract class Viajes
    {
        private int Numero;
        private int CantAsientos;
        private DateTime Partida;
        private DateTime Arribo;
        private Empleado E;
        private Terminal T;
        private Compania C;

        public int numero
        {
            get { return Numero; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Error: Ingrese un número de viaje válido.");
                }
                else
                {
                    Numero = value;
                }
            }
        }


        public int cantAsientos
        {
            get { return CantAsientos; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Error: Ingrese una cantdad de asientos válida.");
                }
                else
                {
                    CantAsientos = value;
                }
            }
        }


        public DateTime partida
        {
            get { return Partida; }
            set
            {
                if (value==null)
                {
                    throw new Exception("Fecha de partida inválida.");
                }

                Partida = value;
            }
        }


        public DateTime arribo
        {
            get { return Arribo; }
            set
            {
                if (value==null)
                {
                    throw new Exception("Fecha de arribo inválida.");
                }
                Arribo = value;
            }
        }


        public Empleado e
        {
            get { return E; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Error: Ingrese un empleado válido.");
                }
                else
                {
                    E = value;
                }
            }
        }

        public Terminal t
        {
            get { return T; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Error: Ingrese una terminal válida.");
                }
                else
                {
                    T = value;
                }
            }
        }


        public Compania c
        {
            get { return C; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Error: Ingrese una compania válida.");
                }
                else
                {
                    C = value;
                }
            }
        }

        public Viajes(int _numero, int _cantAsientos, DateTime _partida, DateTime _arribo, Empleado _e, Terminal _t, Compania _c)
        {
            numero = _numero;
            cantAsientos = _cantAsientos;
            partida = _partida;
            arribo = _arribo;
            e = _e;
            t = _t;
            c = _c;
        }


        public Viajes() 
        { }
    }
}
