import { Aurelia, autoinject, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';
import { Submission } from '../../models/Submission';
import { Artwork } from "../../models/Artwork";
import { FetchData } from "../../services/fetchdata";
//import { Router, RouterConfiguration, RouteConfig } from "aurelia-router";

@autoinject
export class ViewSubmissions {


    public submissionsArr: Submission[];
    router: Router;

    constructor(private fetchdata: FetchData, router: Router ) {
        this.submissionsArr = [];
        this.getData();
        this.router = router;
    }

    getData() {
        this.fetchdata.getSubmissions().then((response: any) => {
            this.submissionsArr = response;
         
            console.log("===this.submissionsArr");
            console.log(this.submissionsArr);
            
        });
    }

    //unsure how to get "index" from html file
    //function to redirect to the View1Submission page
    RedirectToSingleSubmission(item: Submission) {
       
        //console.log("You Selected ");
        //console.log(item);
        //this.router.navigateToRoute('View1Submission', { item });
        let view1SubmissionRoute = this.router.routes.find(x => x.name === 'View1Submission');
        if (view1SubmissionRoute != null) {
            view1SubmissionRoute.settings.submission = item;
        }
        this.router.navigateToRoute('View1Submission', { id: item.submissionID });
    }


}