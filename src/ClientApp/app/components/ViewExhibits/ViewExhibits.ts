import { Aurelia, autoinject, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';
import { FetchData } from "../../services/fetchdata";
import { Exhibit } from "../../models/Exhibit";
import { inject } from 'aurelia-framework';
import { HttpClient } from 'aurelia-fetch-client';

@autoinject
export class ViewExhibits {
    public exhibitsArr: Exhibit[];
    router: Router;

    constructor(private fetchdata: FetchData, router: Router) {
        this.exhibitsArr = [];
        this.getData();
        this.router = router;
    }

    //get request to get the exhibits from the server
    getData() {
        
        this.fetchdata.getExhibits().then((response: any) => {
            this.exhibitsArr = response;
            console.log("=== this.exhibits ====");
            console.log(this.exhibitsArr);
        });
    }

    //redirect to the single exhibit page to update it. 
    RedirectToUpdateExhibit(exhibit: Exhibit) {
        console.log("in redirect to update exhibit:");
        console.log(exhibit);

        let view1ExhibitRoute = this.router.routes.find(x => x.name === 'UpdateExhibit');
        if (view1ExhibitRoute != null) {
            view1ExhibitRoute.settings.exhibit = exhibit;
        }
        this.router.navigateToRoute('UpdateExhibit', { id: exhibit.id });
    }

    DeleteSelectedExhibit(exhibit: Exhibit) {
      

        if (exhibit != undefined) {
            this.fetchdata.postExhibitForDeletion(exhibit).then((response: any) => {
                console.log(response);
                
              
            });
            
        }

        this.router.navigateToRoute('ViewExhibits');
    }

}

