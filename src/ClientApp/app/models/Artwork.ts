export class Artwork {
    title: string;
    instructor: string;
    semester: string;
    course: string;
    medium: string;
    photo: File | null;


    constructor() {
        this.title = "";
        this.instructor = "";
        this.semester = "";
        this.course = "";
        this.medium = "";
        this.photo = null;
    }
}