import { HttpClient, json } from 'aurelia-fetch-client';
import { autoinject } from "aurelia-framework";
import { inject } from 'aurelia-framework';
import { Submission } from '../models/Submission';

@autoinject
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

    //post request to send submission data to C#
    public postSubmission(submission: Submission) {
        return this.PostRequest("api/submission/submitArt", submission);
    }

    public PostRequest(url: string, payload: any) {
        const str = JSON.stringify(payload); //json(payload);
        return this.httpClient.fetch(url, {
            method: "POST",
            body: str
        }).then((result) => {
            if (result != null) {
                return result.json() as Promise<any>;
            }
            }).catch((error) => {
                this.handleError(error, url);
            })
    }

    public getSubmissions() {
        //name of the function in Submission Controller
        return this.GetRequest("api/submission/GetAllSubmissions");
    }

    //get request to get the table row information for view submissions
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
}

