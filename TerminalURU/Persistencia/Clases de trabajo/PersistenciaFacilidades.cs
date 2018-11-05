using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;
namespace Persistencia
{
    internal class PersistenciaFacilidades
    {
        internal static List<string> BuscarFacilidades(string cod)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            List<string> l = new List<string>();
            SqlCommand comando = new SqlCommand("BuscarFacilidad", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            comando.Parameters.Add(new SqlParameter("@Codigo", cod));

            try
            {
                DBCS.Open();
                SqlDataReader r;

                r = comando.ExecuteReader();
                if (r.HasRows)
                {


                    while (r.Read())
                    {

                        l.Add(r.GetValue(1).ToString());
                    }
                }
                r.Close();

                return l;

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

        internal static void AltaFacilidades(Terminal T, string facilidad, SqlTransaction transaccion)
        {
            SqlCommand comando = new SqlCommand("AltaFacilidad", transaccion.Connection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@CodigoF", T.codigo));
            comando.Parameters.Add(new SqlParameter("@Facilidad", facilidad));
            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);
            try
            {
                comando.Transaction = transaccion;
                int r = Convert.ToInt32(retorno.Value);

                comando.ExecuteNonQuery();

                if (r == -1)
                {
                    throw new Exception("La facilidad " + facilidad + " es inválida");
                }
                else if (r == -2)
                {
                    throw new Exception("Terminal invalida");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void BajaFacilidades(Terminal T, SqlTransaction _miTransaccion)
        {
            SqlCommand comando = new SqlCommand("EliminarFacilidad", _miTransaccion.Connection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@CodigoF", T.codigo));
            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);
            try
            {
                comando.Transaction = _miTransaccion;
                comando.ExecuteNonQuery();

                int r = Convert.ToInt32(retorno.Value);
                if (r != 1)
                {
                    throw new Exception("Error al eliminar las facilidades.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
