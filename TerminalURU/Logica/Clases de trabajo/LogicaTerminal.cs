using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;
using System.Data.SqlClient;

namespace Logica
{
    internal class LogicaTerminal : IlogicaTerminal
    {
        private static LogicaTerminal _instancia = null;

        private LogicaTerminal() { }

        public static LogicaTerminal GetInstancia()
        {

            if (_instancia == null)
            {
                _instancia = new LogicaTerminal();
            }

            return _instancia;
        }

        public Terminal BuscarTerminalActiva(string c)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaTerminal().BuscarTerminalActiva(c);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Terminal> ListarTerminales()
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaTerminal().ListarTerminales();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AltaTerminal(Terminal T)
        {
            try
            {
                FabricaPersistencia.GetPersistenciaTerminal().AltaTerminal(T);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void BajaTerminal(Terminal T)
        {
            try
            {
                FabricaPersistencia.GetPersistenciaTerminal().BajaTerminal(T);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarTerminal(Terminal T)
        {
            try
            {
                FabricaPersistencia.GetPersistenciaTerminal().ModificarTerminal(T);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
