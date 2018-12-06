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

    setValues(title: string, instructor: string, semester: string,
        course: string, medium: string, photo: File | null) {
        this.title = title;
        this.instructor = instructor;
        this.semester = semester;
        this.course = course;
        this.medium = medium;
        this.photo = photo;
    }
}