using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Persistencia
{
    internal class Conexion
    {
        public static string conn = "Data Source = .\\SQLEXPRESS ; Initial Catalog = TerminalURU; Integrated Security=true";

        internal static SqlConnection CrearCnn()
        {
                SqlConnection cnn = new SqlConnection(conn);
                return cnn;
        }
    }
}
