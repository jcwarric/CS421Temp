/*
 * Submission controller handles backend processing for:
 *  SubmitRegistration
 *  ViewAllSubmissions
 *  View1Submission
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ARTchive.Models;
using ARTchive.DBManagers;

namespace ARTchive.Controllers
{

    [Route("api/submission")]
    public class SubmissionController : Controller
    {
        [HttpPost("[action]")]
        public void SubmitArt([FromBody] Submission submissionData) // data from user submission form
        {
            //exhibit to be implemented in a future sprint, for now hardcoding a value
            //for the exhibitID
            int exhibitID = 12;

            Submission submission = submissionData;

            //get the user from the submission - to be removed in a future sprint because
            //the user will be loggged in
            User user = submission.getUser();

            //save user and get user id
            UserDBManager userDBManager = new UserDBManager();
            int userID = userDBManager.Insert(user);

            //save artwork and get artwork id
            Artwork artwork = submission.getArtwork();
            ArtworkDBManager artworkDBManager = new ArtworkDBManager();
            int artID = artworkDBManager.Insert(artwork, userID, exhibitID);


            //save submission
            SubmissionDBManager submissionDbMgr = new SubmissionDBManager();
            submissionDbMgr.Insert(submission, userID, exhibitID, artID);

        }

        //get request to get the row data from the database for the AdminViewAllSubmissions page
        [HttpGet("[action]")]
        public string GetAllSubmissions()
        {
            int ExhibitID = 12;
            //get array of table fields from the database
            SubmissionDBManager submissionDBManager = new SubmissionDBManager();
            List<Submission> submissions = submissionDBManager.getSubmissionsByExhibit(ExhibitID);

            Console.WriteLine("=====Submissions JSON =========");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(submissions));

            return Newtonsoft.Json.JsonConvert.SerializeObject(submissions);
        }

        [HttpPost("[action]")]
        public void SaveSubmissionDecision([FromBody] Submission submission) // data from user submission form
        {
            Console.WriteLine("=== submission data: ");
            Console.WriteLine(submission);
            SubmissionDBManager submissionDBManager = new SubmissionDBManager();
            submissionDBManager.SaveSubmissionDecision(submission);

        }
    }
}