using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ARTchive.Models;

namespace ARTchive.DBManagers
{
    public class ExhibitDBManager : DBManager
    {
        public ExhibitDBManager() { }

        //function to store a new exhibit in the database
        public void Insert(Exhibit exhibit)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Exhibit" +
                    "(Title, [Description], FeaturedImg, ThumbnailImg," +
                    "ExhibitStartDate, ExhibitStartTime, ExhibitEndDate, ExhibitEndTime," +
                    "RegistrationStartDate, RegistrationStartTime, RegistrationEndDate, RegistrationEndTime," +
                    "ReceptionDate, ReceptionStartTime, ReceptionEndTime, AdditionalComments) " +
                    "VALUES(@title, @description, @featuredImg, @thumbnailImg," +
                    "@exhibitStartDate, @exhibitStartTime, @exhibitEndDate, @exhibitEndTime," +
                    "@registrationStartDate, @registrationStartTime, @registrationEndDate, @registrationEndTime," +
                    "@receptionDate, @receptionStartTime, @receptionEndTime, @additionalComments)",
                    connection);

                cmd.Parameters.AddWithValue("@title", exhibit.getTitle());
                cmd.Parameters.AddWithValue("@description", exhibit.getDescription());
                cmd.Parameters.AddWithValue("@featuredImg", exhibit.getFeaturedImg());
                cmd.Parameters.AddWithValue("@thumbnailImg", exhibit.getThumbnailImg());

                cmd.Parameters.AddWithValue("@exhibitStartDate", exhibit.getExhibitStartDate());
                cmd.Parameters.AddWithValue("@exhibitStartTime", exhibit.getExhibitStartTime());
                cmd.Parameters.AddWithValue("@exhibitEndDate", exhibit.getExhibitEndDate());
                cmd.Parameters.AddWithValue("@exhibitEndTime", exhibit.getExhibitEndTime());

                cmd.Parameters.AddWithValue("@registrationStartDate", exhibit.getRegistrationStartDate());
                cmd.Parameters.AddWithValue("@registrationStartTime", exhibit.getRegistrationStartTime());
                cmd.Parameters.AddWithValue("@registrationEndDate", exhibit.getRegistrationEndDate());
                cmd.Parameters.AddWithValue("@registrationEndTime", exhibit.getExhibitEndTime());

                cmd.Parameters.AddWithValue("@receptionDate", exhibit.getReceptionDate());
                cmd.Parameters.AddWithValue("@receptionStartTime", exhibit.getReceptionStartTime());
                cmd.Parameters.AddWithValue("@receptionEndTime", exhibit.getReceptionEndTime());

                cmd.Parameters.AddWithValue("@additionalComments", exhibit.getAdditionalComments());

                cmd.ExecuteNonQuery();
            }
        }

        //function returns a list of all of the exhibits in the Exhibit database table.
        //TODO: add pagination if number of exhibits gets too large.
        public List<Exhibit> getExhibits()
        {
            List <Exhibit> exhibits = new List<Exhibit> ();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //sql command to get the exhibits
                SqlCommand cmd = new SqlCommand("SELECT * FROM Exhibit",connection);

                SqlDataReader reader = cmd.ExecuteReader();

                //variables to use in the while loop to temporarily store each exhibit's values
                int id;
                string  title, description, featuredImg, thumbnailImg,
                       exhibitStartDate, exhibitStartTime, exhibitEndDate, exhibitEndTime,
                       registrationStartDate, registrationStartTime, registrationEndDate, registrationEndTime,
                       receptionDate, receptionStartTime, receptionEndTime,
                       additionalComments;

                //loop through the reader, storing each row's information in an exhibit in the list
                while (reader.Read())
                {
                    id = (int) reader["ExhibitID"];
                    title = (string) reader["Title"];
                    description = (string)reader["Description"];
                    featuredImg = (string)reader["FeaturedImg"];
                    thumbnailImg = (string)reader["ThumbnailImg"];

                    exhibitStartDate = (string)reader["ExhibitStartDate"];
                    exhibitStartTime = (string)reader["ExhibitStartTime"];
                    exhibitEndDate = (string)reader["ExhibitEndDate"];
                    exhibitEndTime = (string)reader["ExhibitEndTime"];

                    registrationStartDate = (string)reader["RegistrationStartDate"];
                    registrationStartTime = (string)reader["RegistrationStartTime"];
                    registrationEndDate = (string)reader["RegistrationEndDate"];
                    registrationEndTime = (string)reader["RegistrationEndTime"];

                    receptionDate = (string)reader["ReceptionDate"];
                    receptionStartTime = (string)reader["ReceptionStartTime"];
                    receptionEndTime = (string)reader["ReceptionEndTime"];

                    additionalComments = (string)reader["AdditionalComments"];

                    //create a new exhibit using the sql information
                    Exhibit exhibit = new Exhibit(id, title, description, featuredImg, thumbnailImg,
                        exhibitStartDate, exhibitStartTime, exhibitEndDate, exhibitEndTime,
                        registrationStartDate, registrationStartTime, registrationEndDate, registrationEndTime,
                        receptionDate, receptionStartTime, receptionEndTime, additionalComments);

                    //add the exhibit to the list
                    exhibits.Add(exhibit);

                }
                connection.Close();

                return exhibits;
            }
        }


        //ToDo: save exhibit info to the database
        public void Update(Exhibit exhibit)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    " UPDATE Exhibit " +
                    " SET Title = @title, [Description] = @description, FeaturedImg = @featuredImg, ThumbnailImg = @thumbnailImg, " +
                    " ExhibitStartDate = @exhibitStartDate, ExhibitStartTime = @exhibitStartTime, ExhibitEndDate = @exhibitEndDate, ExhibitEndTime = @exhibitEndTime, " +
                    " RegistrationStartDate = @registrationStartDate, RegistrationStartTime = @registrationStartTime, RegistrationEndDate = @registrationEndDate, RegistrationEndTime = @registrationEndTime, " +
                    " ReceptionDate = @receptionDate, ReceptionStartTime = @receptionStartTime, ReceptionEndTime = @receptionEndTime, " +
                    " AdditionalComments = @additionalComments " +
                    " WHERE ExhibitID = @exhibitID",
                    connection);
                cmd.Parameters.AddWithValue("@exhibitID", exhibit.getId());
                cmd.Parameters.AddWithValue("@title", exhibit.getTitle());
                cmd.Parameters.AddWithValue("@description", exhibit.getDescription());
                cmd.Parameters.AddWithValue("@featuredImg", exhibit.getFeaturedImg());
                cmd.Parameters.AddWithValue("@thumbnailImg", exhibit.getThumbnailImg());
                cmd.Parameters.AddWithValue("@exhibitStartDate", exhibit.getExhibitStartDate());
                cmd.Parameters.AddWithValue("@exhibitStartTime", exhibit.getExhibitStartTime());
                cmd.Parameters.AddWithValue("@exhibitEndDate", exhibit.getExhibitEndDate());
                cmd.Parameters.AddWithValue("@exhibitEndTime", exhibit.getExhibitEndTime());
                cmd.Parameters.AddWithValue("@registrationStartDate", exhibit.getRegistrationStartDate());
                cmd.Parameters.AddWithValue("@registrationStartTime", exhibit.getRegistrationStartTime());
                cmd.Parameters.AddWithValue("@registrationEndDate", exhibit.getRegistrationEndDate());
                cmd.Parameters.AddWithValue("@registrationEndTime", exhibit.getExhibitEndTime());
                cmd.Parameters.AddWithValue("@receptionDate", exhibit.getReceptionDate());
                cmd.Parameters.AddWithValue("@receptionStartTime", exhibit.getReceptionStartTime());
                cmd.Parameters.AddWithValue("@receptionEndTime", exhibit.getReceptionEndTime());
                cmd.Parameters.AddWithValue("@additionalComments", exhibit.getAdditionalComments());
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Delete(int exhibitID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // check submission table for this exhibit ID
                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) AS C FROM [Submission] WHERE ExhibitID = @exhibitID", connection);
                cmd1.Parameters.AddWithValue("@exhibitID", exhibitID);

                int count = 1;

                SqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    count = (int)reader["C"];
                }
                reader.Close();

                if (count == 0)
                {
                    SqlCommand cmdDelete = new SqlCommand("DELETE FROM Exhibit " +
                    "WHERE ExhibitID = @exhibitID", connection);
                    cmdDelete.Parameters.AddWithValue("@exhibitID", exhibitID);

                    cmdDelete.ExecuteNonQuery();
                }

                connection.Close();

            }

        }
    }
}
