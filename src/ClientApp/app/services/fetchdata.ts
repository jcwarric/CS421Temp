import { HttpClient, json } from 'aurelia-fetch-client';
import { autoinject } from "aurelia-framework";
import { inject } from 'aurelia-framework';
import { Submission } from '../models/Submission';
import { Exhibit } from '../models/Exhibit';

@autoinject
    //Fetchdata is responsible for the GET and POST methods used by the
    //application
export class FetchData {

    constructor(private httpClient: HttpClient) {
        httpClient.configure((config) => {
            config
                .useStandardConfiguration()
                .withDefaults({
                    credentials: "same-origin",
                    headers: {
                        "Content-Type": "application/json",
                    },
                });
        });
    }

    //post-request function - "posts" data so that it can be accessed in the back-end
    //c# classes
    public PostRequest(url: string, payload: any) {
        const str = JSON.stringify(payload); //json(payload);
        console.log(str);
        return this.httpClient.fetch(url, {
            method: "POST",
            body: str
        }).then((result) => {
            if (result != null) {
                return result;
            }
        }).catch((error) => {
            this.handleError(error, url);
        })
    }
    //public PostRequest(url: string, payload: any) {
    //    const str = JSON.stringify(payload); //json(payload);
    //    return this.httpClient.fetch(url, {
    //        method: "POST",
    //        body: str
    //    }).then((result) => {
    //        if (result != null) {
    //            return result.json() as Promise<any>;
    //        }
    //    }).catch((error) => {
    //        this.handleError(error, url);
    //    })
    //}




    public GetRequest(url: string) {
        return this.httpClient.fetch(url)
            .then((result) => {
                return result.json() as Promise<any>;
            }).catch((error) => {
                this.handleError(error, url);
            });
    }

    public handleError(error: any, url: string) {
        throw error;
    }


    //==== POST requests ===============================

    //post request to send submission data to C# for when the SVSU_User submits a
    //registration form for an exhibit.
    public postSubmission(submission: Submission) {
        //"submitArt" is the function in the C# class (SubmissionController) that we're
        //passing the submission object to
        return this.PostRequest("api/submission/submitArt", submission);
    }

    //post request to send exhibit data to c# for when the admin wants to create a
    //new exhibit
    //public postExhibit(exhibit: Exhibit) {
    //    return this.PostRequest("api/exhibit/CreateExhibit", exhibit);
    //}

    public postExhibit(exhibit : Exhibit) {
        console.log("in postExhibit in fetchdata");
        console.log("body: " + JSON.stringify(exhibit));
        return this.httpClient.fetch("api/exhibit/createExhibit", {
            method: "POST",
            //mode: "cors",
            //credentials: "same-origin",
            body: JSON.stringify(exhibit)
            
        }).then((result) => {
            if (result != null) {
                console.log(result);
              
                return result;
                //return result.json() as Promise<any>;
            }
        }).catch((error) => {
            this.handleError(error, "api/exhibit/CreateExhibit");
        })
    }

    public postSubmissionDecision(submission: Submission) {
        //"submitArt" is the function in the C# class (SubmissionController) that we're
        //passing the submission object to
        return this.PostRequest("api/submission/SaveSubmissionDecision", submission);
    }

    //post request to update an exhibit
    public postExhibitForUpdate(exhibit: Exhibit) {
        console.log("in postExhibit in fetchdata");
        console.log("body: " + JSON.stringify(exhibit));
        return this.httpClient.fetch("api/exhibit/updateExhibit", {
            method: "POST",
            body: JSON.stringify(exhibit)
        }).then((result) => {
            if (result != null) {
                console.log(result);
                return result;
            }
        }).catch((error) => {
            this.handleError(error, "api/exhibit/UpdateExhibit");
        })
    }

    //post request to delete an exhibit
    public postExhibitForDeletion(exhibit: Exhibit) {
        console.log("in postExhibit in fetchdata");
        console.log("body: " + JSON.stringify(exhibit));
        return this.httpClient.fetch("api/exhibit/DeleteExhibit", {
            method: "POST",
            body: JSON.stringify(exhibit)
        }).then((result) => {
            if (result != null) {
                console.log(result);
                return result;
            }
        }).catch((error) => {
            this.handleError(error, "api/exhibit/DeleteExhibit");
        })
    }

    //public postExhibit(exhibit: Exhibit) {
    //    return this.PostRequest("api/exhibit/createExhibit", exhibit);
    //}


    //==== GET requests ================================

    //used to get a list of submissions from the C# submissionsController class
    //so that it can be displayed on the front-end (ie View All Submisions page)
    public getSubmissions() {
        //name of the function in Submission Controller
       
        return this.httpClient.fetch("api/submission/GetAllSubmissions")
            .then((result) => {
                var temp = result.json();
                //console.log("in getSubmissions in fetchdata, result.json=");
                //console.log(result.json());
                console.log(temp);
                return temp;
            }).catch((error) => {
                this.handleError(error, "api/submission/GetAllSubmissions");
            });
    }

    //used to get a list of exhibits from the C# exhibitsController class
    //so that it can be displayed on the front-end (ie, View all exhibits
    //admin page)
    public getExhibits() {
        
        return this.httpClient.fetch("api/exhibit/GetAllExhibits")
            .then((result) => {
                var temp = result.json();
                //return result.json() as Promise<any>;
                return temp;
            }).catch((error) => {
                this.handleError(error, "api/exhibit/GetAllExhibits");
            });
    }

}

