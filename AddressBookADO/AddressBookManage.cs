using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookADO
{
    class AddressBookManage
    {
        //Specifying the connection string from the sql server connection.
        public static string connectionString = @"Data Source=.;Initial Catalog=AddressBookADO;Integrated Security=True";
        // Establishing the connection using the Sqlconnection.  
        SqlConnection connection = new SqlConnection(connectionString);

        public void DataBaseConnection()
        {
            try
            {
                //create object DateTime class 
                DateTime now = DateTime.Now;
                // open connection
                connection.Open();
                //using SqlConnection
                using (connection)
                {
                    //print msg Connection is created Successful  with date and time
                    Console.WriteLine($"Connection is created Successful at {now}");
                }
                //close connection
                connection.Close();
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
        }
    }
}
