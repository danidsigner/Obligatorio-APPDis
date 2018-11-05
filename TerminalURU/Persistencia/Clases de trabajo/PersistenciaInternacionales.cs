using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;


namespace Persistencia
{
    internal class PersistenciaInternacionales : IPersistenciaInternacionales
    {
        private static PersistenciaInternacionales _instancia = null;

        private PersistenciaInternacionales() { }

        public static PersistenciaInternacionales GetInstancia()
        {

            if (_instancia == null)
            {
                _instancia = new PersistenciaInternacionales();
            }

            return _instancia;
        }

        public Internacionales BuscarViajeInternacionales(int numero)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            Internacionales i = null;
            SqlCommand comando = new SqlCommand("BuscarViajeInternacional", DBCS);
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
                    i = new Internacionales(Convert.ToInt32(r.GetValue(0)),
                        Convert.ToInt32(r.GetValue(1)),
                        Convert.ToDateTime(r.GetValue(2)),
                        Convert.ToDateTime(r.GetValue(3)),
                        PersistenciaEmpleado.GetInstancia().BuscarEmpleadosTodos(Convert.ToInt32(r.GetValue(4))),
                        PersistenciaTerminal.GetInstancia().BuscarTerminalTodos(r.GetValue(5).ToString()),
                        PersistenciaCompania.GetInstancia().BuscarCompaniaTodas(r.GetValue(6).ToString()),
                        Convert.ToBoolean(r.GetValue(7)), r.GetValue(8).ToString()
                        );
                }

                r.Close();
                return i;
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

        public void AltaViajeInternacionales(Viajes v)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            Internacionales I = (Internacionales)v;
            SqlCommand comando = new SqlCommand("AltaViajeInternacional", DBCS);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add(new SqlParameter("@Numero", I.numero));
            comando.Parameters.Add(new SqlParameter("@CantAsientos", I.cantAsientos));
            comando.Parameters.Add(new SqlParameter("@Partida", I.partida));
            comando.Parameters.Add(new SqlParameter("@Arribo", I.arribo));
            comando.Parameters.Add(new SqlParameter("@CIEmpleado", I.e.ci));
            comando.Parameters.Add(new SqlParameter("@NomCompania", I.c.nombre));
            comando.Parameters.Add(new SqlParameter("@CodTerminal", I.t.codigo));
            comando.Parameters.Add(new SqlParameter("@ServAbordo", I.servAbordo));
            comando.Parameters.Add(new SqlParameter("@Documentacion", I.documentacion));
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
                    throw new Exception("Ya existe un viaje con ese número.");
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

        public void BajaViajeInternacionales(Viajes v)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            Internacionales I = (Internacionales)v;
            SqlCommand comando = new SqlCommand("BajaViajeInternacional", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Numero", I.numero));
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
                    throw new Exception("Error al eliminar viaje.");
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

        public void ModificarViajeInternacionales(Viajes v)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            Internacionales I = (Internacionales)v;
            SqlCommand comando = new SqlCommand("ModificarViajeInternacional", DBCS);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add(new SqlParameter("@Numero", I.numero));
            comando.Parameters.Add(new SqlParameter("@CantAsientos", I.cantAsientos));
            comando.Parameters.Add(new SqlParameter("@Partida", I.partida));
            comando.Parameters.Add(new SqlParameter("@Arribo", I.arribo));
            comando.Parameters.Add(new SqlParameter("@CIEmpleado", I.e.ci));
            comando.Parameters.Add(new SqlParameter("@NomCompania", I.c.nombre));
            comando.Parameters.Add(new SqlParameter("@CodTerminal", I.t.codigo));
            comando.Parameters.Add(new SqlParameter("@ServAbordo", I.servAbordo));
            comando.Parameters.Add(new SqlParameter("@Documentacion", I.documentacion));
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

        public List<Viajes> ListarViajesInternacionales()
        {
            List<Viajes> lista = new List<Viajes>();
            SqlConnection DBCS = Conexion.CrearCnn();
            Internacionales I = null;
            SqlCommand comando = new SqlCommand("ListarViajesInternacionales", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            try
            {
                DBCS.Open();
                SqlDataReader r;

                r = comando.ExecuteReader();
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        I = new Internacionales(Convert.ToInt32(r.GetValue(0)),
                            Convert.ToInt32(r.GetValue(1)),
                            Convert.ToDateTime(r.GetValue(2)),
                            Convert.ToDateTime(r.GetValue(3)),
                            PersistenciaEmpleado.GetInstancia().BuscarEmpleadosTodos(Convert.ToInt32(r.GetValue(4))),
                            PersistenciaTerminal.GetInstancia().BuscarTerminalTodos(r.GetValue(5).ToString()),
                            PersistenciaCompania.GetInstancia().BuscarCompaniaTodas(r.GetValue(6).ToString()),
                            Convert.ToBoolean(r.GetValue(7)), r.GetValue(8).ToString());
                        lista.Add(I);
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

        public List<Viajes> ListarInternacionalesTodos()
        {
            List<Viajes> lista = new List<Viajes>();
            SqlConnection DBCS = Conexion.CrearCnn();
            Internacionales I = null;
            SqlCommand comando = new SqlCommand("ListarInternacionalesTodos", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            try
            {
                DBCS.Open();
                SqlDataReader r;

                r = comando.ExecuteReader();
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        I = new Internacionales(Convert.ToInt32(r.GetValue(0)),
                            Convert.ToInt32(r.GetValue(1)),
                            Convert.ToDateTime(r.GetValue(2)),
                            Convert.ToDateTime(r.GetValue(3)),
                            PersistenciaEmpleado.GetInstancia().BuscarEmpleadosTodos(Convert.ToInt32(r.GetValue(4))),
                            PersistenciaTerminal.GetInstancia().BuscarTerminalTodos(r.GetValue(5).ToString()),
                            PersistenciaCompania.GetInstancia().BuscarCompaniaTodas(r.GetValue(6).ToString()),
                            Convert.ToBoolean(r.GetValue(7)), r.GetValue(8).ToString());
                        lista.Add(I);
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
