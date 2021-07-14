﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookADO
{
    class AddressBook
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipcode { get; set; }
        public long phoneNumber { get; set; }
        public string email { get; set; }

        public bool AddContact(AddressBook contact)
        {
            string connectionString = @"Data Source=s;Initial Catalog=AddressBookADO;Integrated Security=True;Pooling=False";
            SqlConnection connection = new SqlConnection(connectionString);
            int result = 0;
            try
            {
                using (connection)
                {
                    string spName = "dbo.SpInsertNewContact";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@firstName", contact.firstName);
                    command.Parameters.AddWithValue("@lastName", contact.lastName);
                    command.Parameters.AddWithValue("@address", contact.address);
                    command.Parameters.AddWithValue("@city", contact.city);
                    command.Parameters.AddWithValue("@state", contact.state);
                    command.Parameters.AddWithValue("@zip", contact.zipcode);
                    command.Parameters.AddWithValue("@phoneNumber", contact.phoneNumber);
                    command.Parameters.AddWithValue("@email", contact.email);
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
                return result == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
    }
}
