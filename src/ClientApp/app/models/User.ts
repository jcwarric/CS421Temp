
export class User {

    firstName: string;
    lastName: string;
    email: string;
    phoneNumber: string;
    address: string;
    biography: string;

    constructor() {
        this.firstName = "";
        this.lastName = "";
        this.email = "";
        this.phoneNumber = "";
        this.address = "";
        this.biography = "biography";
    }

    setValues(firstName: string, lastName: string, email: string, phoneNumber: string,
        address: string, biography: string) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.address = address;
        this.biography = biography;
    }
}
