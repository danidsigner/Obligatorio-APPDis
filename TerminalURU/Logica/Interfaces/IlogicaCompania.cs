using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
namespace Logica
{
    public interface IlogicaCompania
    {
        void AltaCompania(Compania C);
        void BajaCompania(Compania C);
        void ModificarCompania(Compania C);
        Compania BuscarCompaniaActivas(string nombre);
        List<Compania> ListarCompanias();
    }
}
