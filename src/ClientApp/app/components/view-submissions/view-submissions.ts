import { Aurelia, autoinject, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';
import { Submission } from '../../models/Submission';
import { Artwork } from "../../models/Artwork";
import { FetchData } from "../../services/fetchdata";

@autoinject
export class ViewSubmissions {

    //private submissions: Submission[] = [];
    //string[,]
    public submissionsArr: any;

    constructor(private fetchdata: FetchData) {
        this.getData();
    }

    getData() {
        this.fetchdata.getSubmissions().then((response: any) => {
            debugger;
            console.log(response);
            this.submissionsArr = response;
        });
    }

}