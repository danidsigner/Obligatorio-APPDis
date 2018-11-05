using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]
    public class Terminal
    {
        private string Codigo;
        private string Ciudad;
        private string Pais;
        private List<string> Facilidades;



        public string codigo
        {
            get { return Codigo; }
            set
            {
                if (value.Length == 3)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        //Comprueba el dato ingresado, verifica que sean letras
                        if (!Char.IsLetter(Convert.ToChar(value.Substring(i, 1))))
                        {
                            throw new Exception("Error el código solo pueden ser tres letras.");
                        }
                    }
                    Codigo = value;
                }
                else
                {
                    throw new Exception("Error el código solo pueden ser tres letras.");
                }
            }

        }



        public string ciudad
        {
            get { return Ciudad; }
            set
            {
                if (value.ToString().Length < 5)
                {
                    throw new Exception("Error: Ingrese una ciudad válida.");
                }
                else
                {
                    Ciudad = value;
                }
            }
        }

        public string pais
        {
            get { return Pais; }
            set 
            {
                if (value.ToUpper().Trim() == "URUGUAY" || value.ToUpper().Trim() == "BRASIL" || value.ToUpper().Trim() == "ARGENTINA" ||
                    value.ToUpper().Trim() == "PARAGUAY" || value.ToUpper().Trim() == "VENEZUELA")
                {
                    Pais = value;
                }
                else
                {
                    throw new Exception("Solamente pueden registrarse paises del Mercosur.");
                }
            }
        }
        public List<string> facilidades
        {
            get { return Facilidades; }
            set
            {
                Facilidades = value;
              
            }
        }
        public Terminal(string cod,string c,string p,List<string> f)
        {
            codigo = cod;
            ciudad = c;
            pais = p;
            facilidades=f;
        }

        public Terminal()
        { }
    }
}
