import { Aurelia, autoinject } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';
import { FetchData } from "../../services/fetchdata";
import { Exhibit } from "../../models/Exhibit"
//import { DialogService } from 'aurelia-dialog';
//import { Prompt } from './prompt';


@autoinject
export class CreateExhibit {
  
    exhibit: Exhibit;
    router: Router;

    constructor(private fetchdata: FetchData, router:Router) {
        this.exhibit = new Exhibit();
        this.router = router;
       
    }

    submitExhibit() {

        this.fetchdata.postExhibit(this.exhibit).then((response: any) => {
            console.log(response);

            //after submission successful, for now return to view-submissions page
            //TODO: learn how to use dialogs - we'll want to change this line to 
            //display a "submission successful" message to the user
            this.router.navigateToRoute('ViewExhibits');
        });
    }

}