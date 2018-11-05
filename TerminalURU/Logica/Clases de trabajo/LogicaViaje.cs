using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    internal class LogicaViaje : IlogicaViajes
    {

        private static LogicaViaje _instancia = null;

        private LogicaViaje() { }

        public static LogicaViaje GetInstancia()
        {

            if (_instancia == null)
            {
                _instancia = new LogicaViaje();
            }

            return _instancia;
        }

        public void AltaViaje(Viajes v)
        {
            try
            {

                if (v.partida >= DateTime.Now && v.partida < v.arribo)
                {
                    List<Viajes> lista = new List<Viajes>();
                    lista.AddRange(FabricaPersistencia.GetPersistenciaInternacionales().ListarViajesInternacionales());
                    lista.AddRange(FabricaPersistencia.GetPersistenciaNacionales().ListarViajesNacionales());

                    foreach (Viajes viaje in lista)
                    {
                        TimeSpan diferencia = viaje.partida.Subtract(v.partida);
                        if (viaje.t.codigo == v.t.codigo && (diferencia.TotalMinutes < 120 && diferencia.TotalMinutes > -120))
                        {
                            throw new Exception("Deben de haber un minimo de dos horas entre dos viajes con mismo destino");
                        }
                    }

                    if (v is Nacionales)
                    {
                        FabricaPersistencia.GetPersistenciaNacionales().AltaViajeNacionales(v);
                    }
                    else if (v is Internacionales)
                    {
                        FabricaPersistencia.GetPersistenciaInternacionales().AltaViajeInternacionales(v);
                    }
                }
                else
                {
                    throw new Exception("Fecha de partida o de arribo incorrecta.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void BajaViaje(Viajes v)
        {
            try
            {
                if (v is Nacionales)
                {
                    FabricaPersistencia.GetPersistenciaNacionales().BajaViajeNacionales(v);
                }
                else if (v is Internacionales)
                {
                    FabricaPersistencia.GetPersistenciaInternacionales().BajaViajeInternacionales(v);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarViaje(Viajes v)
        {
            try
            {
                if (v is Nacionales)
                {
                    FabricaPersistencia.GetPersistenciaNacionales().ModificarViajeNacionales(v);
                }
                else if (v is Internacionales)
                {
                    FabricaPersistencia.GetPersistenciaInternacionales().ModificarViajeInternacionales(v);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Viajes BuscarViaje(int numero)
        {
            try
            {
                Viajes v = FabricaPersistencia.GetPersistenciaNacionales().BuscarViajeNacional(numero);

                if (v == null)
                {
                    v = FabricaPersistencia.GetPersistenciaInternacionales().BuscarViajeInternacionales(numero);
                }
                return v;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Viajes> ListarViajes()
        {
            try
            {
                List<Viajes> lista = new List<Viajes>();
                lista.AddRange(FabricaPersistencia.GetPersistenciaInternacionales().ListarViajesInternacionales());
                lista.AddRange(FabricaPersistencia.GetPersistenciaNacionales().ListarViajesNacionales());

                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Viajes> ListarViajesTodos()
        {
            try
            {
                List<Viajes> lista = new List<Viajes>();
                lista.AddRange(FabricaPersistencia.GetPersistenciaInternacionales().ListarInternacionalesTodos());
                lista.AddRange(FabricaPersistencia.GetPersistenciaNacionales().ListarNacionalesTodos());

                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
