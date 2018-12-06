import { Aurelia, autoinject } from 'aurelia-framework';
import { Router, RouterConfiguration, NavigationInstruction, RouteConfig } from 'aurelia-router';
import { Submission } from "../../models/Submission";
import { FetchData } from "../../services/fetchdata";


@autoinject
export class View1Submission {
    
    //submission to store the submission data
    submission: Submission | undefined;
    selectedRadioBtn = true;

    //use router to navigate to view-submissions page after user
    //clicks submit (we'll want to change this later to display a
    //"submission successful message to the user)
    router: Router;

    constructor(private fetchdata: FetchData, router:Router) {
        this.router = router;
    }

    //activate function helps pass an object (ie, the selected submission) from the 
    //view-submissions page to the View1Submission page. 
    activate(params:any, routeConfig:RouteConfig, navigationInstruction:NavigationInstruction) {
        console.log(params, routeConfig, navigationInstruction);
       
        this.submission = routeConfig.settings.submission;
        console.log("you selected: ");
        console.log(this.submission);
    }


    //get the Admin comments and decision(ie, accept or reject) from the html form
    //and post the submission object to the submissionController to be saved to the
    //database. (Use case Accept/Reject Submission)
    submitDecision() {
        if (this.submission != undefined) {
            if (this.selectedRadioBtn) {
                this.submission.status = "accepted";
            }
            else {
                this.submission.status = "rejected";
            }
            console.log(this.submission);

            //send submission back to Submission controller to save the decision to the database. 
            this.fetchdata.postSubmissionDecision(this.submission).then((response: any) => {
                console.log(response);
                this.router.navigateToRoute('view-submissions');
            });
        }
    }

}