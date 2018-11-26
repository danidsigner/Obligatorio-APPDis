using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;


namespace Persistencia
{
    internal class PersistenciaCompania : IPersistenciaCompania
    {
        private static PersistenciaCompania _instancia = null;

        private PersistenciaCompania() { }

        public static PersistenciaCompania GetInstancia()
        {

            if (_instancia == null)
            {
                _instancia = new PersistenciaCompania();
            }

            return _instancia;
        }

        public void AltaCompania(Compania C)
        {
            //verificar el uso de los retornos
            SqlConnection DBCS = Conexion.CrearCnn();
            SqlCommand comando = new SqlCommand("AltaCompania", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Nombre", C.nombre));
            comando.Parameters.Add(new SqlParameter("@Direccion", C.direccion));
            comando.Parameters.Add(new SqlParameter("@Telefono", C.telefono));
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
                    throw new Exception("ExcepcionEX:Ya existe una compañía con ese nombre.FinExcepcionEX");
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

        public List<Compania> ListarCompanias()
        {
            List<Compania> lista = new List<Compania>();
            Compania c = null;

            SqlConnection DBCS = Conexion.CrearCnn();
            SqlCommand comando = new SqlCommand("ListarCompanias", DBCS);
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
                        c = new Compania(r.GetValue(0).ToString(),
                        r.GetValue(1).ToString(),
                        Convert.ToInt64(r.GetValue(2)));
                        lista.Add(c);
                    }
                }

                r.Close();
                return lista;

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

        public void BajaCompania(Compania C)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            SqlCommand comando = new SqlCommand("BajaCompania", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Nombre", C.nombre));
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
                    throw new Exception("ExcepcionEX:Error al eliminar la Compañía.FinExcepcionEX");
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

        public void ModificarCompania(Compania C)
        {

            SqlConnection DBCS = Conexion.CrearCnn();
            SqlCommand comando = new SqlCommand("ModificarCompania", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Nombre", C.nombre));
            comando.Parameters.Add(new SqlParameter("@Direccion", C.direccion));
            comando.Parameters.Add(new SqlParameter("@Telefono", C.telefono));
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
                    throw new Exception("ExcepcionEX:Error al modificar Compañía.FinExcepcionEX");
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

        public Compania BuscarCompaniaActivas(string nombre)
        {

            SqlConnection DBCS = Conexion.CrearCnn();
            Compania c = null;
            SqlCommand comando = new SqlCommand("BuscarCompaniaActiva", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Nombre", nombre));
            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);
            try
            {
                DBCS.Open();
                SqlDataReader r;

                r = comando.ExecuteReader();
                if (r.HasRows)
                {
                    r.Read();
                    c = new Compania(r.GetValue(0).ToString(),
                        r.GetValue(1).ToString(),
                        Convert.ToInt64(r.GetValue(2)));
                }


                return c;

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

        internal Compania BuscarCompaniaTodas(string nombre)
        {

            SqlConnection DBCS = Conexion.CrearCnn();
            Compania c = null;
            SqlCommand comando = new SqlCommand("BuscarCompaniaTodas", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Nombre", nombre));

            try
            {
                DBCS.Open();
                SqlDataReader r;

                r = comando.ExecuteReader();
                if (r.HasRows)
                {
                    r.Read();
                    c = new Compania(r.GetValue(0).ToString(),
                        r.GetValue(1).ToString(),
                        Convert.ToInt64(r.GetValue(2)));
                }
                r.Close();

                return c;

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
    }
}
