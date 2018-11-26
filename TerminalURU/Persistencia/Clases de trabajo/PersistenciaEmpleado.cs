using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;
namespace Persistencia
{
    internal class PersistenciaEmpleado : IPersistenciaEmpleado
    {
        private static PersistenciaEmpleado _instancia = null;

        private PersistenciaEmpleado() { }

        public static PersistenciaEmpleado GetInstancia()
        {

            if (_instancia == null)
            {
                _instancia = new PersistenciaEmpleado();
            }

            return _instancia;
        }

        public Empleado Logeo(int ci, string contraseña)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            SqlCommand comando = new SqlCommand("Logeo", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@CI", ci));
            comando.Parameters.Add(new SqlParameter("@Contraseña", contraseña));
            Empleado e = null;

            try
            {

                DBCS.Open();
                SqlDataReader r;

                r = comando.ExecuteReader();
                if (r.HasRows)
                {
                    r.Read();
                    e = new Empleado(Convert.ToInt32(r.GetValue(0)),
                        r.GetValue(1).ToString(),
                        r.GetValue(2).ToString()
                        );
                }
                return e;

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

        public void AltaEmpleado(Empleado E)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            SqlCommand comando = new SqlCommand("AltaEmpleado", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@CI", E.ci));
            comando.Parameters.Add(new SqlParameter("@NombreCompleto", E.nombreCompleto));
            comando.Parameters.Add(new SqlParameter("@Contraseña", E.contraseña));
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
                    throw new Exception("ExcepcionEX:Ya existe un empleado con esa cédula.FinExcepcionEX");
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

        public void ModificarEmpleado(Empleado E)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            SqlCommand comando = new SqlCommand("ModificarEmpleado", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@CI", E.ci));
            comando.Parameters.Add(new SqlParameter("@NombreCompleto", E.nombreCompleto));
            comando.Parameters.Add(new SqlParameter("@Contraseña", E.contraseña));
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
                    throw new Exception("ExcepcionEX:Error al modificar empleado.FinExcepcionEX");
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

        public void BajaEmpleado(Empleado E)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            SqlCommand comando = new SqlCommand("BajaEmpleado", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@CI", E.ci));
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
                    throw new Exception("ExcepcionEX:Error al eliminar empleado.FinExcepcionEX");
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

        public Empleado BuscarEmpleadosActivos(int ci)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            Empleado e = null;
            SqlCommand comando = new SqlCommand("BuscarEmpleadoActivo", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            comando.Parameters.Add(new SqlParameter("@CI", ci));

            try
            {
                DBCS.Open();
                SqlDataReader r;

                r = comando.ExecuteReader();
                if (r.HasRows)
                {
                    r.Read();
                    e = new Empleado(Convert.ToInt32(r.GetValue(0)),
                        r.GetValue(1).ToString(),
                        r.GetValue(2).ToString()
                        );
                }


                return e;

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

        internal Empleado BuscarEmpleadosTodos(int ci)
        {
            SqlConnection DBCS = Conexion.CrearCnn();
            Empleado e = null;
            SqlCommand comando = new SqlCommand("BuscarEmpleadosTodos", DBCS);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            comando.Parameters.Add(new SqlParameter("@CI", ci));

            try
            {
                DBCS.Open();
                SqlDataReader r;

                r = comando.ExecuteReader();
                if (r.HasRows)
                {
                    r.Read();
                    e = new Empleado(Convert.ToInt32(r.GetValue(0)),
                        r.GetValue(1).ToString(),
                        r.GetValue(2).ToString()
                        );
                }
                r.Close();

                return e;

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
