
using Microsoft.Data.SqlClient;
using System.Data;

namespace QLCP.DAL
{
    public class DBConnection
    {
        protected SqlConnection conn = new SqlConnection(
            @"Data Source=LAPTOP-D9JNFIV7\SQLEXPRESS;Initial Catalog=QLCP;Integrated Security=True;Trust Server Certificate=True");

        protected DataTable LayDuLieu(string sql, params SqlParameter[] ps)
        {
            using var cmd = new SqlCommand(sql, conn);
            if (ps != null) cmd.Parameters.AddRange(ps);

            var dt = new DataTable();
            new SqlDataAdapter(cmd).Fill(dt);
            return dt;
        }

        protected int ThucThi(string sql, params SqlParameter[] ps)
        {
            try
            {
                conn.Open();
                using var cmd = new SqlCommand(sql, conn);
                if (ps != null) cmd.Parameters.AddRange(ps);
                return cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
