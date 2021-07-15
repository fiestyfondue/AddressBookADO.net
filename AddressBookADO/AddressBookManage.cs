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
        // UC2:- Ability to create a Address Book Table with its attributes 
        public void GetAllContact()
        {
            AddressBook model = new AddressBook();
            try
            {
                using (connection)
                {
                    // Query for getting all the data from the table
                    string query = "select * from AddressBook";
                    // Impementing the command on the connection fetched database table
                    // Create a command object  
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();  //Open the connection.
                    // executing the sql data reader to fetch the records
                    // Call ExecuteReader to return a SQlDataReader  
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {

                        // Loop through all the rows in the DataTableReader
                        // Mapping the data to the employee model class object
                        while (reader.Read())
                        {

                            model.firstName = reader.GetString(0);
                            model.lastName = reader.GetString(1);
                            model.address = reader.GetString(2);
                            model.city = reader.GetString(3);
                            model.state = reader.GetString(4);
                            model.zipcode = reader.GetInt32(5);
                            model.phoneNumber = reader.GetInt64(6);
                            model.email = reader.GetString(7);
                            model.Name = reader.GetString(8);
                            model.TypeOf = reader.GetString(9);
                            model.TYPE = reader.GetString(10);
                            //prinitng the output
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", model.firstName, model.lastName,
                                model.address, model.city, model.state, model.zipcode, model.phoneNumber, model.email, model.Name, model.TypeOf,model.TYPE);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Records Found Address Book System Table");
                    }
                    reader.Close();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                //  closing the connection
                connection.Close();
            }

        }
    }
}
