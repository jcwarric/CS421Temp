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
                    "SubmissionComments, Status, AdminComments, NotificationStatus)" +
                    "VALUES( @userID, @exhibitID, @artworkID, @submissionComments, " +
                    "@status, @adminComments, @notificationStatus)", connection);
         
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@exhibitID", exhibitID);
                cmd.Parameters.AddWithValue("@artworkID", artworkID);
                cmd.Parameters.AddWithValue("@submissionComments", submission.getSubmissionComments());
                cmd.Parameters.AddWithValue("@status", submission.getStatus());
                cmd.Parameters.AddWithValue("@adminComments", submission.getAdminComments());
                cmd.Parameters.AddWithValue("@notificationStatus", submission.getNotificationStatus());
                cmd.ExecuteNonQuery();
            }
        }

        //right now just assumes that the application supports 1 exhibit
        public List<Submission> getSubmissionsByExhibit(int ExhibitID)
        {
         
            List<Submission> submissions = new List<Submission>();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //sql command to get the user's first name, last name, email, title of the artwork, and status
                //for all submissions.
                SqlCommand cmd = new SqlCommand(
                "SELECT [User].UserID, [User].FirstName, [User].LastName, [User].Email, [User].PhoneNumber, [User].Address, " +
                    "[Artwork].ArtworkID, [Artwork].Title, [Artwork].Instructor, [Artwork].Semester, [Artwork].Course, [Artwork].Medium, [Artwork].StudentPhotoURL, " +
                    "[Submission].SubmissionID, [Submission].ExhibitID, [Submission].SubmissionComments, [Submission].AdminComments, [Submission].[Status], [Submission].[NotificationStatus] " +
                "FROM((Submission " +
                "INNER JOIN[User] ON Submission.UserID = [User].UserID)" +
                "INNER JOIN[Artwork] ON Submission.ArtworkID = [Artwork].ArtworkID); ", connection);
               
                SqlDataReader reader = cmd.ExecuteReader();

                //loop through the reader, storing each row's information in a row in the submissions array
                while (reader.Read())
                {
                    //create a user object from the database info
                    User user = new User(
                        (int)reader["UserID"],
                        (string)reader["FirstName"],
                        (string)reader["LastName"],
                        (string)reader["Email"],
                        (string)reader["PhoneNumber"],
                        (string)reader["Address"]);

                    //create an artwork object from the database info
                    Artwork artwork = new Artwork(
                        (int)reader["ArtworkID"],
                        (string)reader["Title"],
                        (string)reader["Instructor"],
                        (string)reader["Semester"],
                        (string)reader["Course"],
                        (string)reader["Medium"],
                        (string)reader["StudentPhotoURL"]);

                    //create a submission object from database info
                    Submission submissionTmp = new Submission(
                        (int)reader["SubmissionID"],
                        user,
                        ExhibitID,
                        artwork,
                        (string)reader["SubmissionComments"],
                        (string)reader["AdminComments"],
                        (string)reader["Status"],
                        (bool)reader["NotificationStatus"]);

                    //add submission to submissions list
                    submissions.Add(submissionTmp);

                    Console.WriteLine();
                    Console.WriteLine("=== Submission ===");
                    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(submissionTmp));
                    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(artwork));
                    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(user));
                    Console.WriteLine();


                }
                connection.Close();

            }
            return submissions;
        }


        //save the submission decision (whether the admin accepted or rejected the submission)
        //to the databse by updating the submission in the Submission table.
        public void SaveSubmissionDecision(Submission submission)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [Submission] " +
                    " SET[Status] = @status, [AdminComments] = @adminComments, [NotificationStatus] = @notificationStatus " +
                    " WHERE[SubmissionID] = @submissionID; ", connection);

                cmd.Parameters.AddWithValue("@submissionID" , submission.getSubmissionID());
                cmd.Parameters.AddWithValue("@status", submission.getStatus());
                cmd.Parameters.AddWithValue("@adminComments", submission.getAdminComments());
                cmd.Parameters.AddWithValue("@notificationStatus", submission.getNotificationStatus());
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            
        }

    }
}
