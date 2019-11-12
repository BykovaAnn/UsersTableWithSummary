//class for Users data from database
export class User {
    id:string;  
    userName:string; 
    userActive:boolean;

    constructor(userID: string, userName: string, userActive: boolean) {
        this.id = userID;
        this.userName = userName;
        this.userActive = userActive;
    }
}

