using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;
namespace Persistencia
{
    internal class PersistenciaTerminal : IPersistenciaTerminal
    {
        private static PersistenciaTerminal _instancia = null;

        private PersistenciaTerminal() { }

        public static PersistenciaTerminal GetInstancia()
        {

            if (_instancia == null)
            {
                _instancia = new PersistenciaTerminal();
            }

            return _instancia;
        }

        public Terminal BuscarTerminalActiva(string c)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            Terminal T = null;
            List<string> lista = new List<string>();
            string codigo = "";
            string ciudad = "";
            string pais = "";
            SqlCommand comando = new SqlCommand("BuscarTerminalActiva", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            comando.Parameters.Add(new SqlParameter("@Codigo", c));
            try
            {

                DBCS.Open();
                SqlDataReader r;

                r = comando.ExecuteReader();
                if (r.HasRows)
                {
                    r.Read();
                    codigo = r.GetValue(0).ToString();
                    ciudad = r.GetValue(1).ToString();
                    pais = r.GetValue(2).ToString();
                    lista = PersistenciaFacilidades.BuscarFacilidades(c);
                    T = new Terminal(codigo, ciudad, pais, lista);
                }

                r.Close();


                return T;

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

        internal Terminal BuscarTerminalTodos(string c)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            Terminal T = null;
            List<string> lista = new List<string>();
            string codigo = "";
            string ciudad = "";
            string pais = "";
            SqlCommand comando = new SqlCommand("BuscarTerminalTodos", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            comando.Parameters.Add(new SqlParameter("@Codigo", c));
            try
            {
                DBCS.Open();
                SqlDataReader r;

                r = comando.ExecuteReader();
                if (r.HasRows)
                {
                    r.Read();
                    codigo = r.GetValue(0).ToString();
                    ciudad = r.GetValue(1).ToString();
                    pais = r.GetValue(2).ToString();
                    lista = PersistenciaFacilidades.BuscarFacilidades(c);
                    T = new Terminal(codigo, ciudad, pais, lista);
                }

                r.Close();
                return T;
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

        public List<Terminal> ListarTerminales()
        {
            List<Terminal> lista = new List<Terminal>();
            List<string> listaF = new List<string>();
            string codigo = "";
            string ciudad = "";
            string pais = "";
            Terminal T = null;

            SqlConnection DBCS = Conexion.CrearCnn();
            SqlCommand comando = new SqlCommand("ListarTerminales", DBCS);
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
                        codigo = r.GetValue(0).ToString();
                        ciudad = r.GetValue(1).ToString();
                        pais = r.GetValue(2).ToString();
                        listaF = PersistenciaFacilidades.BuscarFacilidades(codigo);
                        T = new Terminal(codigo, ciudad, pais, listaF);
                        lista.Add(T);
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

        public void AltaTerminal(Terminal T)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            SqlCommand comando = new SqlCommand("AltaTerminal", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            comando.Parameters.Add(new SqlParameter("@Codigo", T.codigo));
            comando.Parameters.Add(new SqlParameter("@Ciudad", T.ciudad));
            comando.Parameters.Add(new SqlParameter("@Pais", T.pais));

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            SqlTransaction _miTransaccion = null;
            try
            {
                DBCS.Open();

                _miTransaccion = DBCS.BeginTransaction();
                comando.Transaction = _miTransaccion;
                comando.ExecuteNonQuery();

                int r = Convert.ToInt32(retorno.Value);
                if (r == -1)
                    throw new Exception("Esta terminal ya existe");

                foreach (string s in T.facilidades)
                {
                    PersistenciaFacilidades.AltaFacilidades(T, s, _miTransaccion);
                }
                
                _miTransaccion.Commit();
            }
            catch (Exception ex)
            {
                _miTransaccion.Rollback();
                throw ex;
            }
            finally
            {
                DBCS.Close();
            }

        }

        public void ModificarTerminal(Terminal T)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            SqlCommand comando = new SqlCommand("ModificarTerminal", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            comando.Parameters.Add(new SqlParameter("@Codigo", T.codigo));
            comando.Parameters.Add(new SqlParameter("@Ciudad", T.ciudad));
            comando.Parameters.Add(new SqlParameter("@Pais", T.pais));
            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);
            SqlTransaction _miTransaccion = null;
            comando.Transaction = _miTransaccion;

            try
            {
            DBCS.Open();
            _miTransaccion = DBCS.BeginTransaction();
            comando.Transaction = _miTransaccion;
            comando.ExecuteNonQuery();

            int r = Convert.ToInt32(retorno.Value);
            if (r == -1)
                throw new Exception("La terminal no existe.");

            PersistenciaFacilidades.BajaFacilidades(T, _miTransaccion);

            foreach (string s in T.facilidades)
            {
                PersistenciaFacilidades.AltaFacilidades(T, s, _miTransaccion);
            }

            _miTransaccion.Commit();
            }
            catch (Exception ex)
            {
                _miTransaccion.Rollback();
                throw ex;
            }
            finally
            {
                DBCS.Close();
            }
        }

        public void BajaTerminal(Terminal T)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            SqlCommand comando = new SqlCommand("BajaTerminal", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Codigo", T.codigo));
            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            try
            {
                DBCS.Open();
                comando.ExecuteNonQuery();

                int r = Convert.ToInt32(retorno.Value);
                if (r == -1)
                    throw new Exception("Error al eliminar la terminal.");
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
