using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_System
{


   public class Connection
    {
        private static string constring = "Data Source=.;Initial Catalog=Banking System;Integrated Security=True";
        public static SqlConnection con = new SqlConnection(constring);

        public Connection()
        {
        }

        public static object ExecuteNonQuery(string strSql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(strSql, con);
                cmd.ExecuteNonQuery();

                
                return true;
            }
            catch (SqlException ex)
            {
                return ex;

            }
            finally
            {
                con.Close();
            }
        }

       


    }
}
