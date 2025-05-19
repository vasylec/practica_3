using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
            }
            catch (Exception e)
            { 
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return connection;
        }

        public SqlConnection closeConnection()
        {
            try
            {
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return connection;
        }
    }
}
