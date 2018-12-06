using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTchive.Models
{

    public class Exhibit
    {
        public int id;
        public string title;
        public string description;
        public string featuredImg;
        public string thumbnailImg;

        public string exhibitStartDate;
        public string exhibitStartTime;
        public string exhibitEndDate;
        public string exhibitEndTime;

        public string registrationStartDate;
        public string registrationStartTime;
        public string registrationEndDate;
        public string registrationEndTime;

        public string receptionDate;
        public string receptionStartTime;
        public string receptionEndTime;

        public string additionalComments;

        ////constructor to initialize all private member variable's values when the exhibit
        ////id isn't known (ie before it is saved to the database).
        //public Exhibit(
        //    string title,
        //    string description,
        //    string featuredImg,
        //    string thumbnailImg,
        //    string exhibitStartDate,
        //    string exhibitStartTime,
        //    string exhibitEndDate,
        //    string exhibitEndTime,
        //    string registrationStartDate,
        //    string registrationStartTime,
        //    string registrationEndDate,
        //    string registrationEndTime,
        //    string receptionDate,
        //    string receptionStartTime,
        //    string receptionEndTime,
        //    string additionalComments
        //    )
        //{
        //    this.id = -1;
        //    this.title = title;
        //    this.description = description;
        //    this.featuredImg = featuredImg;
        //    this.thumbnailImg = thumbnailImg;

        //    this.exhibitStartDate = exhibitStartDate;
        //    this.exhibitStartTime = exhibitStartTime;
        //    this.exhibitEndDate = exhibitEndDate;
        //    this.exhibitEndTime = exhibitEndTime;

        //    this.registrationStartDate = registrationStartDate;
        //    this.registrationStartTime = registrationStartTime;
        //    this.registrationEndDate = registrationEndDate;
        //    this.registrationEndTime = registrationEndTime;

        //    this.receptionDate = receptionDate;
        //    this.receptionStartTime = receptionStartTime;
        //    this.receptionEndTime = receptionEndTime;

        //    this.additionalComments = additionalComments;
        //}

        //constructor to initialize all private member variable's values when the
        //id is known (ie has already been saved to the database).
        public Exhibit(
            int id,
            string title,
            string description,
            string featuredImg,
            string thumbnailImg,
            string exhibitStartDate,
            string exhibitStartTime,
            string exhibitEndDate,
            string exhibitEndTime,
            string registrationStartDate,
            string registrationStartTime,
            string registrationEndDate,
            string registrationEndTime,
            string receptionDate,
            string receptionStartTime,
            string receptionEndTime,
            string additionalComments
            )
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.featuredImg = featuredImg;
            this.thumbnailImg = thumbnailImg;

            this.exhibitStartDate = exhibitStartDate;
            this.exhibitStartTime = exhibitStartTime;
            this.exhibitEndDate = exhibitEndDate;
            this.exhibitEndTime = exhibitEndTime;

            this.registrationStartDate = registrationStartDate;
            this.registrationStartTime = registrationStartTime;
            this.registrationEndDate = registrationEndDate;
            this.registrationEndTime = registrationEndTime;

            this.receptionDate = receptionDate;
            this.receptionStartTime = receptionStartTime;
            this.receptionEndTime = receptionEndTime;

            this.additionalComments = additionalComments;
        }

        //getters
        public int getId() { return id; }
        public string getTitle() { return title; }
        public string getDescription() { return description;}
        public string getFeaturedImg() { return featuredImg; }
        public string getThumbnailImg() { return thumbnailImg; }
        
        public string getExhibitStartDate() { return exhibitStartDate; }
        public string getExhibitStartTime() { return exhibitStartTime; }
        public string getExhibitEndDate() { return exhibitEndDate; }
        public string getExhibitEndTime() { return exhibitEndTime; }

        public string getRegistrationStartDate() { return registrationStartDate; }
        public string getRegistrationStartTime() { return registrationStartTime; }
        public string getRegistrationEndDate() { return registrationEndDate; }
        public string getRegistrationEndTime() { return registrationEndTime; }

        public string getReceptionDate() { return receptionDate; }
        public string getReceptionStartTime() { return receptionStartTime; }
        public string getReceptionEndTime() { return receptionEndTime; }

        public string getAdditionalComments() { return additionalComments; }

        //setters
        public void setTitle(string title) { this.title = title; }
        public void setDescription(string description) { this.description = description; }
        public void setFeaturedImg(string featuredImg) { this.featuredImg = featuredImg; }
        public void setThumbnailImg(string thumbnailImg) { this.thumbnailImg = thumbnailImg; }
        
        public void setExhibitStartDate(string date) { exhibitStartDate = date; }
        public void setExhibitStartTime(string time) { exhibitStartTime = time; }
        public void setExhibitEndDate(string date) { exhibitEndDate = date; }
        public void setExhibitEndTime(string time) { exhibitEndTime = time; }

        public void setRegistrationStartDate(string date) { registrationStartDate = date; }
        public void setRegistrationStartTime(string time) { registrationStartTime = time; }
        public void setRegistrationEndDate(string date) { registrationEndDate = date; }
        public void setRegistrationEndTime(string time) { registrationEndTime = time; }

        public void setAdditionalComments(string comments) { additionalComments = comments; }

    }



}
