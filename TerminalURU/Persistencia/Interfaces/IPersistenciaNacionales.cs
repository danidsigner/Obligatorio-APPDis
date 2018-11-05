using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaNacionales
    {
        void AltaViajeNacionales(Viajes V);
        void BajaViajeNacionales(Viajes V);
        void ModificarViajeNacionales(Viajes V);
        Nacionales BuscarViajeNacional(int numero);
        List<Viajes> ListarViajesNacionales();
        List<Viajes> ListarNacionalesTodos();
    }
}
