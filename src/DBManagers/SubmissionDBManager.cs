using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ARTchive.Models;


namespace ARTchive.DBManagers
{
    public class SubmissionDBManager : DBManager
    {
        public SubmissionDBManager(){}
        //todo:fix getters and setters
        //This function creates a submission in the database. 
        public void Insert(  Submission submission, int userID, int exhibitID, int artworkID)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Submission( UserID, ExhibitID, ArtworkID, " +
                    "SubmissionComments, Status, AdminComments)" +
                    "VALUES( @userID, @exhibitID, @artworkID, @submissionComments, " +
                    "@status, @adminComments)", connection);
         
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@exhibitID", exhibitID);
                cmd.Parameters.AddWithValue("@artworkID", artworkID);
                cmd.Parameters.AddWithValue("@submissionComments", submission.getComments());
                cmd.Parameters.AddWithValue("@status", submission.getStatus());
                cmd.Parameters.AddWithValue("@adminComments", submission.getAdminComments());
                cmd.ExecuteNonQuery();
            }
        }

        //right now just assumes that the application supports 1 exhibit
        public string[,] getSubmissionsByExhibit(int ExhibitID)
        {
            //2d array to hold the data for the AdminViewAllSubmissions GUI table.
            //each row contains the FirstName, LastName, Email,Title of Artwork, and Status of the submission
            string[,] submissions;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //get the number of submissions for the exhibit
                SqlCommand cmdGetNumSubmissions = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Submission];", connection);
                int numSubmissions = (int) cmdGetNumSubmissions.ExecuteScalar();
                int numFields = 5; 
                submissions = new string[numSubmissions, numFields];
                int submissionIndex = 0;

                //sql command to get the user's first name, last name, email, title of the artwork, and status
                //for all submissions.
                SqlCommand cmd = new SqlCommand("Select [User].FirstName, [User].LastName, [User].Email, [Artwork].Title, [Submission].[Status] " +
                "FROM((Submission " +
                "INNER JOIN[User] ON Submission.UserID = [User].UserID)" +
                "INNER JOIN[Artwork] ON Submission.ArtworkID = [Artwork].ArtworkID); ", connection);
               
                SqlDataReader reader = cmd.ExecuteReader();

                //loop through the reader, storing each row's information in a row in the submissions array
                while (reader.Read())
                {
                    //save the submission's user's first name
                    submissions[submissionIndex, 0] = (string)reader["FirstName"];

                    //save the submission's user's last name
                    submissions[submissionIndex, 1] = (string)reader["LastName"];

                    //save the submission's user's email
                    submissions[submissionIndex, 2] = (string)reader["Email"];

                    //save the submission's Artwork's title
                    submissions[submissionIndex, 3] = (string)reader["Title"];

                    //save the submission's status
                    submissions[submissionIndex, 4] = (string)reader["Status"];
                    submissionIndex++;
                }
                connection.Close();

            }
            return submissions;
        }

        


    }
}
