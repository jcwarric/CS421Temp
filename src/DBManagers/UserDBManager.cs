using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ARTchive.Models;

namespace ARTchive.DBManagers
{
    
    public class UserDBManager: DBManager
    {
        public UserDBManager() { }

        //this function inserts a new user into the database and returns
        //the user's UserID.
        public int Insert(User user)
        {
            int userID = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
               
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[User]([FirstName], [LastName], [Email], [PhoneNumber], [Address], [Biography]) " +
                    "VALUES( @firstName, @lastName, @email, @phoneNumber, @address, @biography)", connection);
                cmd.Parameters.AddWithValue("@firstName", user.getFirstName());
                cmd.Parameters.AddWithValue("@lastName", user.getLastName());
                cmd.Parameters.AddWithValue("@email", user.getEmail());
                cmd.Parameters.AddWithValue("@phoneNumber", user.getPhoneNumber());
                cmd.Parameters.AddWithValue("@address", user.getAddress());
                cmd.Parameters.AddWithValue("@biography", user.getBiography());
                cmd.ExecuteNonQuery();

                //**TODO: rebuild User table so that email is NOT NULL **
                SqlCommand cmdGetNewUserID = new SqlCommand("SELECT [UserID] FROM [dbo].[User] WHERE Email = @email;", connection);
                cmdGetNewUserID.Parameters.AddWithValue("@email", user.getEmail());
                userID = (int) cmdGetNewUserID.ExecuteScalar();
                connection.Close();
            }

            return userID;
        }
    }
}
