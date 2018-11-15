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

    constructor(private fetchdata: FetchData) {
        this.submissionData = new Submission();

        this.semesterSeasons = ["Fall", "Winter", "Spring/Summer"];
        this.semesterYears = ["2016", "2017", "2018", "2019"];

        this.semesterSeason = "";
        this.semesterYear = "";
    }

    //fn called when user hits "submit"
    submitApplication() {

        this.submissionData.artwork.semester = this.semesterSeason + " " + this.semesterYear;
        console.log(this.submissionData);

        //post the submission so that it can be reached in the C# class?
        this.fetchdata.postSubmission(this.submissionData).then((response: any) => {
            console.log(response);
        });
        
    }
}