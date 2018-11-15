using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTchive.Models
{
    public class Submission
    {

        private int SubmissionID;
        private User user;
        private int ExhibitID;
        private Artwork artwork;
        private string Comments;
        private string Status;
        private string AdminComments;

        //constructor to initialize private member variables
        public Submission(
            int SubmissionID,
            User user,
            int ExhibitID,
            Artwork artwork,
            string Comments)
        {
            this.SubmissionID = SubmissionID;
            this.user = user;
            this.ExhibitID = ExhibitID;
            this.artwork = artwork;
            this.Comments = Comments;
            
            //status and adminComments are updated when the administrator
            //makes his/her decision. They are null when the student initially
            //submits their submission form.
            this.Status = "";
            this.AdminComments = "";
        }

        //getters for private member variables
        public int getSubmissionID() { return SubmissionID; }
        public User getUser() { return user; }
        public int getExhibitID() { return ExhibitID; }
        public Artwork getArtwork() { return artwork; }
        public string getComments() { return Comments; }
        public string getStatus() { return Status; }
        public string getAdminComments() { return AdminComments; }
        
        public void setStatus(string Status)
        {
            this.Status = Status;
        }
        
        public void setAdminComments(string AdminComments)
        {
            this.AdminComments = AdminComments;
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
            return "SubmissionID: " + SubmissionID +
                " UserID: " + user.getUserID() +
                " ArtworkID: " + artwork.getArtworkID() +
                " ExhibitID: " + ExhibitID +
                " AdminComments: " + AdminComments;
        }
        //private string firstName;
        //private string lastName;
        //private string email;
        //private string phoneNum;
        //private string address;
        //private string comments;
        //private string status;


        //public Submission() { }

        //public Submission(string firstName, string lastName, string email, string phoneNum, string address, string comments, string status)
        //{
        //    this.firstName = firstName;
        //    this.lastName = lastName;
        //    this.email = email;
        //    this.phoneNum = phoneNum;
        //    this.address = address;
        //    this.comments = comments;
        //    this.status = status;
        //}

        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Email { get; set; }
        //public string PhoneNum { get; set; }
        //public string Address { get; set; }
        //public Artwork Art1 { get; set; }
        //public string Comments { get; set; }
        //public string Status { get; set; }

    }
}
