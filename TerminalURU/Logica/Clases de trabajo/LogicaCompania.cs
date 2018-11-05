using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaCompania : IlogicaCompania
    {
        private static LogicaCompania _instancia = null;

        private LogicaCompania() { }

        public static LogicaCompania GetInstancia()
        {

            if (_instancia == null)
            {
                _instancia = new LogicaCompania();
            }

            return _instancia;
        }

        public void AltaCompania(Compania C)
        {
            try
            {
                FabricaPersistencia.GetPersistenciaCompania().AltaCompania(C);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarCompania(Compania C)
        {
            try
            {
                FabricaPersistencia.GetPersistenciaCompania().ModificarCompania(C);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void BajaCompania(Compania C)
        {
            try
            {
                FabricaPersistencia.GetPersistenciaCompania().BajaCompania(C);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Compania> ListarCompanias()
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaCompania().ListarCompanias();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Compania BuscarCompaniaActivas(string c)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaCompania().BuscarCompaniaActivas(c);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}