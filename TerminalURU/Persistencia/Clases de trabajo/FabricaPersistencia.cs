using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    public class FabricaPersistencia
    {
        public static IPersistenciaCompania GetPersistenciaCompania()
        {
            return (PersistenciaCompania.GetInstancia());
        }

        public static IPersistenciaEmpleado GetPersistenciaEmpleado()
        {
            return (PersistenciaEmpleado.GetInstancia());
        }

        public static IPersistenciaTerminal GetPersistenciaTerminal()
        {
            return (PersistenciaTerminal.GetInstancia());
        }

        public static IPersistenciaNacionales GetPersistenciaNacionales()
        {
            return (PersistenciaNacionales.GetInstancia());
        }

        public static IPersistenciaInternacionales GetPersistenciaInternacionales()
        {
            return (PersistenciaInternacionales.GetInstancia());
        }
    }
}
    