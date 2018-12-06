import { Artwork } from "../models/Artwork";
import { User } from "../models/User";

export class Submission {
    submissionID : number;
    user: User;
    exhibitID: number;
    artwork: Artwork;
    submissionComments: string;
    status: string;
    adminComments: string;
    notificationStatus: boolean;


    constructor() {
        this.submissionID = 0;
        this.user = new User();
        this.exhibitID = 12;
        this.artwork = new Artwork();
        this.submissionComments = "";
        this.status = "pending";
        this.adminComments = "";
        this.notificationStatus = false;
    }
    setValues(submissionID: number, user:User, artwork:Artwork, SubmissionComments:string, status:string, AdminComments:string, notificationStatus:boolean) {
        this.submissionID = submissionID;
        this.user = user;
        this.artwork = artwork;
        this.submissionComments = SubmissionComments;
        this.status = status;
        this.adminComments = AdminComments;
        this.notificationStatus = notificationStatus;
    }
}