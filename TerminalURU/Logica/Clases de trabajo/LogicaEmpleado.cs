using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaEmpleado : IlogicaEmpleado
    {
        private static LogicaEmpleado _instancia = null;

        private LogicaEmpleado() { }

        public static LogicaEmpleado GetInstancia()
        {

            if (_instancia == null)
            {
                _instancia = new LogicaEmpleado();
            }

            return _instancia;
        }

        public Empleado Logeo(int ci, string contraseña)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaEmpleado().Logeo(ci, contraseña);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Empleado BuscarEmpleadosActivos(int ci)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaEmpleado().BuscarEmpleadosActivos(ci);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AltaEmpleado(Empleado E)
        {
            try
            {
                FabricaPersistencia.GetPersistenciaEmpleado().AltaEmpleado(E);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarEmpleado(Empleado E)
        {
            try
            {
                FabricaPersistencia.GetPersistenciaEmpleado().ModificarEmpleado(E);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void BajaEmpleado(Empleado E)
        {
            try
            {
                FabricaPersistencia.GetPersistenciaEmpleado().BajaEmpleado(E);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
