using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    


    class Connect
    {
        SqlConnection connection;

        public Connect()
        {
            connection = new SqlConnection("Data Source=COZMA\\SQLEXPRESS;Initial Catalog=db_telecom;Integrated Security=True");
        }


        public SqlConnection openConnection()
        {
            try
            {
                connection.Open();
            }
            catch (Exception)
            {}
            return connection;
        }

        public SqlConnection closeConnection()
        {
            try
            {
                connection.Close();
            }
            catch (Exception)
            {}
            return connection;
        }
    }
}
