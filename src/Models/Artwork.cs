using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTchive.Models
{
    public class Artwork
    {
        //note: model member variables must be public to convert to JSON format. 
        public int artworkID;
        public string title;
        public string instructor;
        public string semester;
        public string course;
        public string medium;
        public string photoURL;

        public Artwork(int ArtworkID,
            string Title,
            string Instructor,
            string Semester,
            string Course,
            string Medium,
            string photoURL)
        {
            this.artworkID = ArtworkID;
            this.title = Title;
            this.instructor = Instructor;
            this.semester = Semester;
            this.course = Course;
            this.medium = Medium;
            this.photoURL = photoURL;
        }

        public int getArtworkID() { return artworkID; }
        public string getTitle() { return title; }
        public string getInstructor() { return instructor; }
        public string getCourse() { return course; }
        public string getSemester() { return semester; }
        public string getMedium() { return medium; }
        public string getPhotoURL() { return photoURL; }
        
        public string toString()
        {
            return "ArtworkID: " + artworkID + " Title: " + title
                + " Instructor: " + instructor + " Course: " + course
                + " Medium: " + medium;
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
