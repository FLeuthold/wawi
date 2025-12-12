using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wawi
{
    internal static class DBHelper
    {
        public static DataTable SelectDataBak(string selectquery)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(Globals.ConnStr))
            {
                conn.Open();
                using (SqlCommand sqlcmd = new SqlCommand())
                {
                    sqlcmd.Connection = conn;
                    sqlcmd.CommandText = selectquery;
                    SqlDataReader rd = sqlcmd.ExecuteReader();

                    dt.Load(rd);
                    //dgvPunkte.DataSource = dt;
                    rd.Close();
                }
            }

            return dt;
        }
    }
}
