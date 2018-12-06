
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTchive.Models
{
    public class Submission
    {

        public int submissionID;
        public User user;
        public int exhibitID;
        public Artwork artwork;
        public string submissionComments;
        public string status;
        public string adminComments;
        public bool notificationStatus;

        //constructor to initialize private member variables
        public Submission(
            int SubmissionID,
            User user,
            int ExhibitID,
            Artwork artwork,
            string SubmissionComments,
            string AdminComments,
            string Status,
            bool NotificationStatus
            )
        {
            this.submissionID = SubmissionID;
            this.user = user;
            this.exhibitID = ExhibitID;
            this.artwork = artwork;
            this.submissionComments = SubmissionComments;
            this.adminComments = AdminComments;
            this.status = Status;
            this.notificationStatus = NotificationStatus;
        }

        //getters for private member variables
        public int getSubmissionID() { return submissionID; }
        public User getUser() { return user; }
        public int getExhibitID() { return exhibitID; }
        public Artwork getArtwork() { return artwork; }
        public string getSubmissionComments() { return submissionComments; }
        public string getStatus() { return status; }
        public string getAdminComments() { return adminComments; }
        public bool getNotificationStatus() { return notificationStatus; }
        
        public void setStatus(string Status)
        {
            this.status = Status;
        }
        
        public void setAdminComments(string AdminComments)
        {
            this.adminComments = AdminComments;
        }

        public void setNotificationStatus(bool NotificationStatus)
        {
            this.notificationStatus = NotificationStatus;
        }

        //todo:remove!!
        public void setArtwork(Artwork a)
        {
            this.artwork = a;
        }

        //todo:remove!!
        public void setUser(User u)
        {
            this.user = u;
        }

        public string toString()
        {
            return "SubmissionID: " + submissionID +
                " UserID: " + user.getUserID() +
                " ArtworkID: " + artwork.getArtworkID() +
                " ExhibitID: " + exhibitID +
                " AdminComments: " + adminComments;
        }

    }
}
