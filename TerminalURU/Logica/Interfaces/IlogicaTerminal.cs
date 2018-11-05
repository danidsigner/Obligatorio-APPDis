using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
namespace Logica
{
     public interface IlogicaTerminal
    {
        void AltaTerminal(Terminal T);
        void BajaTerminal(Terminal T);
        void ModificarTerminal(Terminal T);
        Terminal BuscarTerminalActiva(string codigo);
        List<Terminal> ListarTerminales();
    }
}
