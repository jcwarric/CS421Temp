import { Aurelia, autoinject } from 'aurelia-framework';
import { Router, RouterConfiguration, RouteConfig, NavigationInstruction } from 'aurelia-router';
import { FetchData } from "../../services/fetchdata";
import { Exhibit } from "../../models/Exhibit"


@autoinject
export class UpdateExhibit {

    exhibit: Exhibit | undefined;
    router: Router;

    constructor(private fetchdata: FetchData, router: Router) {
        this.router = router;
    }

    //activate function helps pass an object (ie, the selected submission) from the
    //view-submissions page to the View1Submission page. 
    activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
        console.log(params, routeConfig, navigationInstruction);
        console.log(routeConfig.settings.exhibit);
        this.exhibit = routeConfig.settings.exhibit;
        console.log("you selected the exhibit: ");
        console.log(this.exhibit);
    }

    submitExhibitForUpdate() {
        if (this.exhibit != undefined) {
            this.fetchdata.postExhibitForUpdate(this.exhibit).then((response: any) => {
                console.log(response);

                //after update successful, for now return to view-exhibits page
                //TODO: learn how to use dialogs - we'll want to change this line to 
                //display a "update successful" message to the user
                this.router.navigateToRoute('ViewExhibits');
            });
        }
    }

}