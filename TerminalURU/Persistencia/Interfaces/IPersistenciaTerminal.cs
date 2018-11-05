using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
namespace Persistencia
{
    public interface IPersistenciaTerminal
    {
        void AltaTerminal(Terminal T);
        void BajaTerminal(Terminal T);
        void ModificarTerminal(Terminal T);
        List<Terminal> ListarTerminales();
        //Terminal BuscarTerminalTodos(string codigo);
        Terminal BuscarTerminalActiva(string codigo);
    }
}
