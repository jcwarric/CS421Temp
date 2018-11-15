using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTchive.Models
{
    public class Artwork
    {
        private int ArtworkID;
        private string Title;
        private string Instructor;
        private string Semester;
        private string Course;
        private string Medium;
        private string photoURL;

        public Artwork(int ArtworkID,
            string Title,
            string Instructor,
            string Semester,
            string Course,
            string Medium,
            string photoURL)
        {
            this.ArtworkID = ArtworkID;
            this.Title = Title;
            this.Instructor = Instructor;
            this.Semester = Semester;
            this.Course = Course;
            this.Medium = Medium;
            this.photoURL = photoURL;
        }

        public int getArtworkID() { return ArtworkID; }
        public string getTitle() { return Title; }
        public string getInstructor() { return Instructor; }
        public string getCourse() { return Course; }
        public string getSemester() { return Semester; }
        public string getMedium() { return Medium; }
        public string getPhotoURL() { return photoURL; }
        
        public string toString()
        {
            return "ArtworkID: " + ArtworkID + " Title: " + Title
                + " Instructor: " + Instructor + " Course: " + Course
                + " Medium: " + Medium;
        }

        //private int ArtworkID { get; set; }
        //private string Title { get; set; }
        //private string Instructor { get; set; }
        //private string Semester { get; set; }
        //private string Course { get; set; }
        //private string Medium { get; set; }
        //private FileStyleUriParser photo { get; set; } //todo: figure out how to actually pass a photo between ts/c#
    }
       
}
