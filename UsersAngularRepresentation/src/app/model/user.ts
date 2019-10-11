//class for Users data from database
export class User {
    userID:number;  
    userName:string; 
    userActive:boolean;

    constructor(userID: number, userName: string, userActive: boolean) {
        this.userID = userID;
        this.userName = userName;
        this.userActive = userActive;
    }
}

