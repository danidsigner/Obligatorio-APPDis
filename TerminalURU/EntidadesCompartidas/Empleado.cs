﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]
    public class Empleado
    {
        private int CI;
        private string NombreCompleto;
        private string Contraseña;

        public int ci
        {
            get { return CI; }
            set
            {
                if (value.ToString().Length != 8)
                {
                    throw new Exception("ExcepcionEX: Error: Ingrese una cédula válida.FinExcepcionEX");
                }
                else
                {
                    for (int i = 0; i < value.ToString().Length; i++)
                    {
                        //Comprueba el dato ingresado, verifica que sean letras
                        if (Char.IsLetter(Convert.ToChar(value.ToString().Substring(i, 1))))
                        {
                            throw new Exception("ExcepcionEX:Error: Ingrese una cédula válida.FinExcepcionEX");
                        }
                        else
                        {
                            CI = value;
                        }
                    }
                }
            }
        }


        public string nombreCompleto
        {
            get { return NombreCompleto; }
            set
            {
                if (value.Trim().ToString().Length < 7 || value.Trim().ToString().Length >= 30)
                {
                    throw new Exception("ExcepcionEX: Error: Ingrese un nombre válido.FinExcepcionEX");
                }
                else
                {
                    NombreCompleto = value;
                }
            }
        }


        public string contraseña
        {
            get { return Contraseña; }
            set
            {
                if (value.ToString().Length != 6)
                {
                    throw new Exception("ExcepcionEX: Error: Ingrese una contraseña válida.FinExcepcionEX");
                }
                else
                {
                    Contraseña = value;
                }
            }

        }
        public Empleado(int cedula, string nc, string pass)
        {
            ci = cedula;
            nombreCompleto = nc;
            contraseña = pass;
        }

        public Empleado()
        { }
    }
}
