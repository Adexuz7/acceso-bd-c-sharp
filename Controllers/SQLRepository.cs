using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    internal static class SQLRepository
    {
        public static DataTable ObtenerContratoFutbolista(string connectionString, string codDNIoNIE)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerContratoFutbolista", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIoNIE", SqlDbType.VarChar).Value = codDNIoNIE;

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable result = new DataTable();

                    result.Load(reader);

                    return result;
                }
            }
        }

    }
}
