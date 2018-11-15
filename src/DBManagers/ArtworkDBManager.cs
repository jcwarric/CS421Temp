using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ARTchive.Models;

namespace ARTchive.DBManagers
{
    public class ArtworkDBManager : DBManager
    {
        public ArtworkDBManager() { }
        //This function creates a submission in the database. 
        public int Insert(Artwork artwork, int userID, int exhibitID)
        {
            int artworkID = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Artwork]( [UserID], [ExhibitID], [Title], " +
                    "[Semester], [Instructor], [Course], [Medium], [StudentPhotoURL], [ArchivistPhotoURL])" +
                    "VALUES( @userID, @exhibitID, @title, @semester, @instructor, @course, " +
                    "@medium, @studentPhoto, @archivistPhoto)", connection);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@exhibitID", exhibitID);
                cmd.Parameters.AddWithValue("@title", artwork.getTitle());
                cmd.Parameters.AddWithValue("@semester", artwork.getSemester());
                cmd.Parameters.AddWithValue("@instructor", artwork.getInstructor());
                cmd.Parameters.AddWithValue("@course", artwork.getCourse());
                cmd.Parameters.AddWithValue("@medium", artwork.getMedium());
                //photo-saving to be implemented in a future sprint
                cmd.Parameters.AddWithValue("@studentPhoto", "");
                cmd.Parameters.AddWithValue("@archivistPhoto", "");
                cmd.ExecuteNonQuery();

                //right now we only support 1 artwork per submission. Later will have to query UserID + Exhibit pair to find the 
                //ArtworkID
                SqlCommand cmdGetNewArtworkID = new SqlCommand("SELECT [ArtworkID] FROM [dbo].[Artwork] WHERE UserID = @userID;", connection);
                cmdGetNewArtworkID.Parameters.AddWithValue("@userID", userID);
                artworkID = (int)cmdGetNewArtworkID.ExecuteScalar();
                connection.Close();
            }

            return artworkID;
        }

        //DBManager manager = new DBManager();

        //string server;
        //private int port;
        //SqlConnection Connection;

        //public ArtworkDBManager(int userID, int exhibitID, Artwork artwork)
        //{
        //    //server = manager.getServerName();
        //    //port = getPortNumber();

        //    Connection = new SqlConnection("Server=" + server + "Authentication=Windows Authentication" + "database=Artwork");

        //    try
        //    {
        //        Connection.Open();

        //        SqlParameter myParam = new SqlParameter("@UserID", SqlDbType.Int, 4);
        //        myParam.Value = userID;

        //        SqlParameter myParam2 = new SqlParameter("@ExhibitID", SqlDbType.Int, 4);
        //        myParam2.Value = exhibitID;

        //        SqlParameter myParam4 = new SqlParameter("@Title", SqlDbType.VarChar, 50);
        //        //myParam4.Value = artwork.title;

        //        SqlParameter myParam5 = new SqlParameter("@Semester", SqlDbType.VarChar, 10);
        //        //myParam5.Value = artwork.semester;

        //        SqlParameter myParam6 = new SqlParameter("@Instructor", SqlDbType.VarChar, 50);
        //        //myParam6.Value = artwork.instructor;

        //        SqlParameter myParam7 = new SqlParameter("@Course", SqlDbType.VarChar, 50);
        //        //myParam7.Value = artwork.course;

        //        SqlParameter myParam8 = new SqlParameter("@Medium", SqlDbType.VarChar, 50);
        //        //myParam8.Value = artwork.medium;

        //        SqlParameter myParam9 = new SqlParameter("@StudentPhotoURL", SqlDbType.VarChar, 1000);
        //        //myParam9.Value = artwork.studentPhotoURL;

        //        SqlParameter myParam10 = new SqlParameter("@ArchivistPhotoURL", SqlDbType.VarChar, 1000);
        //        //myParam10.Value = artwork.archivistPhotoURL;


        //        SqlCommand myCommand = new SqlCommand("INSERT INTO table (UserID, ExhibitID, Title, Semester, Instructor, Course, Medium, StudentPhotoURL, ArchivistPhotoURL) " +
        //                             "Values (@UserID, @ExhibitID, @Title, @Semester, @Instructor, @Course, @Medium, @StudentPhotoURL, @ArchivistPhotoURL)", Connection);

        //        myCommand.ExecuteNonQuery();

        //        Connection.Close();

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }
        //}
    }
}
