using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTchive.Models
{
    public class User
    {
        //private member variables are binded to html elements with
        //the same ids
        public int userID;
        public string firstName;
        public string lastName;
        public string email;
        public string phoneNumber;
        public string address;
        public string biography;
        //TODO: add photo for profile

        public User(int userID,
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string address)
        {
            this.userID = userID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address;
            //for now, we aren't worrying about the biography. To be added in "Profile"
            //in a future sprint.
            this.biography = "";
        }

        //getters for User information
        public int getUserID() { return userID; }
        public string getFirstName() { return firstName; }
        public string getLastName() { return lastName; }
        public string getEmail() { return email; }
        public string getPhoneNumber() { return phoneNumber; }
        public string getAddress() { return address; }
        public string getBiography() { return biography; }

        public void setUserID(int userID) { this.userID = userID; }

    }
}
