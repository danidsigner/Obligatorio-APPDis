using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
   public interface IPersistenciaInternacionales
    {
        void AltaViajeInternacionales(Viajes v);
        void BajaViajeInternacionales(Viajes v);
        void ModificarViajeInternacionales(Viajes v);
        Internacionales BuscarViajeInternacionales(int numero);
        List<Viajes> ListarViajesInternacionales();
        List<Viajes> ListarInternacionalesTodos();
    }
}
