//class for Users data from database
export class User {
    UserID:number;  
    UserName:string; 
    UserActive:boolean;

    constructor(userID: number, userName: string, userActive: boolean) {
        this.UserID = userID;
        this.UserName = userName;
        this.UserActive = userActive;
    }
}

