using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;
namespace Persistencia
{
    internal class PersistenciaNacionales : IPersistenciaNacionales
    {
        private static PersistenciaNacionales _instancia = null;

        private PersistenciaNacionales() { }

        public static PersistenciaNacionales GetInstancia()
        {

            if (_instancia == null)
            {
                _instancia = new PersistenciaNacionales();
            }

            return _instancia;
        }

        public Nacionales BuscarViajeNacional(int numero)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            Nacionales n = null;
            SqlCommand comando = new SqlCommand("BuscarViajeNacional", DBCS);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add(new SqlParameter("@Numero", numero));

            try
            {
                DBCS.Open();
                SqlDataReader r;

                r = comando.ExecuteReader();
                if (r.HasRows)
                {
                    r.Read();
                    n = new Nacionales(Convert.ToInt32(r.GetValue(0)),
                        Convert.ToInt32(r.GetValue(1)),
                        Convert.ToDateTime(r.GetValue(2)),
                        Convert.ToDateTime(r.GetValue(3)),
                        PersistenciaEmpleado.GetInstancia().BuscarEmpleadosTodos(Convert.ToInt32(r.GetValue(4))),
                        PersistenciaTerminal.GetInstancia().BuscarTerminalTodos(r.GetValue(5).ToString()),
                        PersistenciaCompania.GetInstancia().BuscarCompaniaTodas(r.GetValue(6).ToString()),
                        Convert.ToInt32(r.GetValue(7))
                        );
                }

                r.Close();

                return n;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBCS.Close();
            }

        }

        public void AltaViajeNacionales(Viajes V)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            Nacionales N = (Nacionales)V;
            SqlCommand comando = new SqlCommand("AltaViajeNacional", DBCS);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add(new SqlParameter("@Numero", N.numero));
            comando.Parameters.Add(new SqlParameter("@CantAsientos", N.cantAsientos));
            comando.Parameters.Add(new SqlParameter("@Partida", N.partida));
            comando.Parameters.Add(new SqlParameter("@Arribo", N.arribo.ToString("yyyyMMdd HH:mm")));
            comando.Parameters.Add(new SqlParameter("@CIEmpleado", N.e.ci));
            comando.Parameters.Add(new SqlParameter("@NomCompania", N.c.nombre));
            comando.Parameters.Add(new SqlParameter("@CodTerminal", N.t.codigo));
            comando.Parameters.Add(new SqlParameter("@Paradas", N.paradas));
            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);
            try
            {
                DBCS.Open();

                comando.ExecuteNonQuery();

                int r = Convert.ToInt32(retorno.Value);
                if (r == -1)
                {
                    throw new Exception("Ya existe un viaje con ese número");
                }

                if (r == -2)
                {
                    throw new Exception("El empleado ingresado no es correcto");
                }

                if (r == -3)
                {
                    throw new Exception("La terminal ingresada no es correcta.");
                }

                if (r == -4)
                {
                    throw new Exception("La compañía ingresada no es correcta");
                }

                if (r == -5)
                {
                    throw new Exception("No pueden existir viajes con menos de dos horas de diferencia al mismo destino");
                }

                if (r == -6)
                {
                    throw new Exception("Error al dar de alta el viaje.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBCS.Close();
            }
        }

        public void BajaViajeNacionales(Viajes V)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            Nacionales N = (Nacionales)V;
            SqlCommand comando = new SqlCommand("BajaViajeNacional", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Numero", N.numero));
            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);
            try
            {

                DBCS.Open();

                comando.ExecuteNonQuery();

                int r = Convert.ToInt32(retorno.Value);
                if (r == -1)
                {
                    throw new Exception("Error al eliminar el viaje.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBCS.Close();
            }
        }

        public void ModificarViajeNacionales(Viajes V)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            Nacionales N = (Nacionales)V;
            SqlCommand comando = new SqlCommand("ModificarViajeNacional", DBCS);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add(new SqlParameter("@Numero", N.numero));
            comando.Parameters.Add(new SqlParameter("@CantAsientos", N.cantAsientos));
            comando.Parameters.Add(new SqlParameter("@Partida", N.partida));
            comando.Parameters.Add(new SqlParameter("@Arribo", N.arribo));
            comando.Parameters.Add(new SqlParameter("@CIEmpleado", N.e.ci));
            comando.Parameters.Add(new SqlParameter("@NomCompania", N.c.nombre));
            comando.Parameters.Add(new SqlParameter("@CodTerminal", N.t.codigo));
            comando.Parameters.Add(new SqlParameter("@Paradas", N.paradas));
            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);
            try
            {
                DBCS.Open();
                comando.ExecuteNonQuery();

                int r = Convert.ToInt32(retorno.Value);
                if (r == -1)
                {
                    throw new Exception("No existe un viaje con ese número");
                }

                if (r == -2)
                {
                    throw new Exception("El empleado ingresado no es correcto");
                }

                if (r == -3)
                {
                    throw new Exception("La terminal ingresada no es correcta.");
                }

                if (r == -4)
                {
                    throw new Exception("La compañía ingresada no es correcta");
                }

                if (r == -5)
                {
                    throw new Exception("No pueden existir viajes con menos de dos horas de diferencia al mismo destino");
                }

                if (r == -6)
                {
                    throw new Exception("Error al modificar el viaje.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBCS.Close();
            }
        }

        public List<Viajes> ListarViajesNacionales()
        {
            List<Viajes> lista = new List<Viajes>();

            SqlConnection DBCS = Conexion.CrearCnn();
            Nacionales N = null;
            SqlCommand comando = new SqlCommand("ListarViajesNacionales", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader r;
            try
            {
                DBCS.Open();
                r = comando.ExecuteReader();
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        N = new Nacionales(Convert.ToInt32(r.GetValue(0)),
                        Convert.ToInt32(r.GetValue(1)),
                        Convert.ToDateTime(r.GetValue(2)),
                        Convert.ToDateTime(r.GetValue(3)),
                        PersistenciaEmpleado.GetInstancia().BuscarEmpleadosTodos(Convert.ToInt32(r.GetValue(4))),
                        PersistenciaTerminal.GetInstancia().BuscarTerminalTodos(r.GetValue(5).ToString()),
                        PersistenciaCompania.GetInstancia().BuscarCompaniaTodas(r.GetValue(6).ToString()),
                        Convert.ToInt32(r.GetValue(7))
                        );
                        lista.Add(N);
                    }
                }
                r.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBCS.Close();
            }
            return lista;
        }

        ////////////////////////////////////////////////////////////////////////

        public List<Viajes> ListarNacionalesTodos()
        {
            List<Viajes> lista = new List<Viajes>();

            SqlConnection DBCS = Conexion.CrearCnn();
            Nacionales N = null;
            SqlCommand comando = new SqlCommand("ListarNacionalesTodos", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader r;
            try
            {
                DBCS.Open();
                r = comando.ExecuteReader();
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        N = new Nacionales(Convert.ToInt32(r.GetValue(0)),
                        Convert.ToInt32(r.GetValue(1)),
                        Convert.ToDateTime(r.GetValue(2)),
                        Convert.ToDateTime(r.GetValue(3)),
                        PersistenciaEmpleado.GetInstancia().BuscarEmpleadosTodos(Convert.ToInt32(r.GetValue(4))),
                        PersistenciaTerminal.GetInstancia().BuscarTerminalTodos(r.GetValue(5).ToString()),
                        PersistenciaCompania.GetInstancia().BuscarCompaniaTodas(r.GetValue(6).ToString()),
                        Convert.ToInt32(r.GetValue(7))
                        );
                        lista.Add(N);
                    }
                }
                r.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBCS.Close();
            }
            return lista;
        }
    }
}
