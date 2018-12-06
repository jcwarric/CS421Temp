import { Aurelia, autoinject} from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';
import { Artwork } from "../../models/Artwork";
import { Submission } from "../../models/Submission";
import { User } from "../../models/User";
import { FetchData } from "../../services/fetchdata";

@autoinject
export class ApplicationForm {

    submissionData: Submission;

    //array to store the different semester seasons(ie Fall, Winter, Spring, Summer)
    semesterSeasons: string[];
    //array to store year
    semesterYears: string[];

    // track user selections
    semesterSeason: string;
    semesterYear: string;

    //use router to navigate to view-submissions page after user
    //clicks submit (we'll want to change this later to display a
    //"submission successful message to the user)
    router: Router;

    constructor(private fetchdata: FetchData, router:Router) {
        this.submissionData = new Submission();

        this.semesterSeasons = ["Fall", "Winter", "Spring/Summer"];
        this.semesterYears = ["2016","2017", "2018", "2019"];

        this.semesterSeason = "";
        this.semesterYear = "";
        this.router = router;
    }

    //fn called when user hits "submit"
    submitApplication() {
        console.log(this.submissionData);
        this.submissionData.artwork.semester = this.semesterSeason + " " + this.semesterYear;

        //post the submission so that it can be reached in the C# class
        this.fetchdata.postSubmission(this.submissionData).then((response: any) => {
            //console.log(response);
            this.router.navigateToRoute('view-submissions');
        });
        
    }
}