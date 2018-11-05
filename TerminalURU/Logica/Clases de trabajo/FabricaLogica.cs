using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class FabricaLogica
    {
        public static IlogicaCompania GetLogicaCompania()
        {
            return (LogicaCompania.GetInstancia());
        }
        public static IlogicaEmpleado GetLogicaEmpleado()
        {
            return (LogicaEmpleado.GetInstancia());
        }

        public static IlogicaTerminal GetLogicaTerminal()
        {
            return (LogicaTerminal.GetInstancia());
        }

        public static IlogicaViajes GetLogicaViajes()
        {
            return (LogicaViaje.GetInstancia());
        }
    }
}
