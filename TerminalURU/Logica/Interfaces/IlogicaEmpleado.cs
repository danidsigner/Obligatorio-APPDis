using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
namespace Logica
{
    public interface IlogicaEmpleado
    {
        Empleado Logeo(int ci, string contraseña);
        void AltaEmpleado(Empleado E);
        void BajaEmpleado(Empleado E);
        void ModificarEmpleado(Empleado E);
        Empleado BuscarEmpleadosActivos(int ci);
    }
}
