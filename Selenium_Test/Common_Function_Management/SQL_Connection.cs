using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SAFINCA.Common_Function_Management
{
    public class SQL_Connection
    {
        //Opens the Test Server Connection and returns Connection Object
        public SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString =
                "Data Source=SEOSSQLAG01;" +
                "Initial Catalog=FlexNet_Tst;" +
                "User ID=flxadmin;" +
                "Password=2}/asX?z$h5f;";

                connection.Open();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return connection;
        }

        //Opens the Dev Server Connection and returns Connection Object
        public SqlConnection getDevConnection()
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString =
                "Data Source=seosco0004\\b2;" +
                "Initial Catalog=FlexNet_Dev;" +
                "User ID=flxadmin;" +
                "Password=2}/asX?z$h5f;";

                 connection.Open();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return connection;
        }

        //Closes the SQL Connection
        public void closeConnection(SqlConnection connection)
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // Executes SQL Query and return Data reader
        public SqlDataReader executeQuery(SqlConnection connection, String query)
        {
            SqlCommand sqlcommand = null;
            SqlDataReader reader = null;

            try
            {
                sqlcommand = new SqlCommand(query, connection);
                reader = sqlcommand.ExecuteReader();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return reader;
        }

        //count queries or singular value return sets
        public Object executeScalarQuery(SqlConnection connection, String query)
        {
            SqlCommand sqlcommand = null;
            Object returnValue = null;

            try
            {
                sqlcommand = new SqlCommand(query, connection);
                returnValue = sqlcommand.ExecuteScalar();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return returnValue;
        }
    }
}
