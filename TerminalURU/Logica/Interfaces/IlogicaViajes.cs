using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
namespace Logica
{
    public interface IlogicaViajes
    {
        void AltaViaje(Viajes V);
        void BajaViaje(Viajes V);
        void ModificarViaje(Viajes V);
        Viajes BuscarViaje(int numero);
        List<Viajes> ListarViajes();
        List<Viajes> ListarViajesTodos();
    }
}
