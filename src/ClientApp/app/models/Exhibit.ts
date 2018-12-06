export class Exhibit {
    id: number;
    title: string;
    description: string;
    featuredImg: File | null;
    thumbnailImg: File | null;

    exhibitStartDate: string;
    exhibitStartTime: string;
    exhibitEndDate: string;
    exhibitEndTime: string;

    registrationStartDate: string;
    registrationStartTime: string;
    registrationEndDate: string;
    registrationEndTime: string;

    receptionDate: string;
    receptionStartTime: string;
    receptionEndTime: string;

    additionalComments: string;

    constructor() {
        this.id = -1;
        this.title = "";
        this.description = "";
        this.featuredImg = null;
        this.thumbnailImg = null;

        this.exhibitStartDate = "";
        this.exhibitStartTime = "";
        this.exhibitEndDate = "";
        this.exhibitEndTime = "";

        this.registrationStartDate = "";
        this.registrationStartTime = "";
        this.registrationEndDate = "";
        this.registrationEndTime = "";

        this.receptionDate = "";
        this.receptionStartTime = "";
        this.receptionEndTime = "";

        this.additionalComments = "";

    }

    //printline for debugging
    print() {
        console.log("title: " + this.title);
        console.log("description: " + this.description);
        console.log("featuredImg: " + this.featuredImg);
        console.log("thumbnailImg: " + this.thumbnailImg);

        console.log("exhibitStartDate: " + this.exhibitStartDate);
        console.log("exhibitStartTime: " + this.exhibitStartTime);
        console.log("exhibitEndDate: " + this.exhibitEndDate);
        console.log("exhibitEndTime: " + this.exhibitEndTime);

        console.log("registrationStartDate: " + this.registrationStartDate);
        console.log("registrationStartTime: " + this.registrationStartTime);
        console.log("registrationEndDate: " + this.registrationEndDate);
        console.log("registrationEndTime: " + this.registrationEndTime);

        console.log("receptionDate: " + this.receptionDate);
        console.log("receptionStartTime: " + this.receptionStartTime);
        console.log("receptionEndTime: " + this.receptionEndTime);

        console.log("additionalComments: " + this.additionalComments);


    }
}