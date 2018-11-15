import { Artwork } from "../models/Artwork";
import { User } from "../models/User";

export class Submission {
    user: User;
    artwork: Artwork;
    comments: string;
    status: string;


    constructor() {
        this.user = new User();
        this.artwork = new Artwork();
        this.comments = "";
        this.status = "pending";
    }
}