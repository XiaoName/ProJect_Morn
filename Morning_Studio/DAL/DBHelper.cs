using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBHelper
    {
        // private static string conStr = "Data Source=.;Initial Catalog=MorningStudio;Integrated Security=True";
        private static string conStr = ConfigurationManager.ConnectionStrings["sqlConnction"].ConnectionString;
        public static DataTable Select(string sql)
        {
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adp.Fill(table);
            conn.Close();
            return table;

        }

        public static int NonQuery(string sql)
        {
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int rs = cmd.ExecuteNonQuery();
            conn.Close();
            return rs;

        }
    }
}

