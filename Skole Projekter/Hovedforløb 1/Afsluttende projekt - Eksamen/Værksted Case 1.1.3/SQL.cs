using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Autorepairshop_Case
{
    class SQL
    {
        public static SqlConnection sqlConnection = new SqlConnection(@"Data Source=tcp:80.197.69.234;Initial Catalog=Autorepairshop;Persist Security Info=True;User ID=nimdA;Password=Changeme123"); // a string keeping the login info to sql the database (remote host)

        public static DataTable GetTable(string querySelect)
        {
            SqlCommand cmd = new SqlCommand(querySelect, sqlConnection); // fuses sql-connection to cmd-string
            DataTable table = new DataTable();
            sqlConnection.Open(); // opening the sql-connection
            try // non-crashing-method (microsoft says stop using 'try' and use 'using')
            {
                SqlDataReader reader = cmd.ExecuteReader(); // executing cmd on the sql-server (input)
                table.Load(reader); // loading the sql-reply into data-table (output)
            }
            catch (Exception)
            {
                throw;
            }
            finally { sqlConnection.Close(); }
            return table;
        }
        public static int SqlNonQuery(params SqlCommand[] cmds)
        {
            int rowsAffected = 0;
            
            sqlConnection.Open();
            try
            {
                for (int i = 0; i < cmds.Length; i++)
                {
                    cmds[i].Connection = sqlConnection;
                    rowsAffected += cmds[i].ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { sqlConnection.Close(); }
            return rowsAffected;
        }
    }
}
