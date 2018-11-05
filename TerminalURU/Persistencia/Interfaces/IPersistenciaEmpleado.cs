using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaEmpleado
    {
        Empleado Logeo(int ci, string contraseña);
        void AltaEmpleado(Empleado E);
        void BajaEmpleado(Empleado E);
        void ModificarEmpleado(Empleado E);
        //Empleado BuscarEmpleadosTodos(int ci);
        Empleado BuscarEmpleadosActivos(int ci);
    }
}
