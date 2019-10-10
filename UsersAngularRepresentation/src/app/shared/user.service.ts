import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from '../model/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  //getting Users from database with api
  getUsers(): Observable<User[]> {  
    return this.http.get<User[]>(environment.apiBaseURI + 'Users')  
  }

  //changing User data in database
  putUser(user : User)  {   
    //const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
    //const data = JSON.stringify(user); 
    var json = JSON.parse('{"userID":' + user.UserID + 
                          ',"userName":"' + user.UserName + 
                          '","userActive":'+ user.UserActive + '}');  
    return this.http.put(environment.apiBaseURI + 'Users/' + user.UserID, json).subscribe((response) => {
      //showing the response in console
      console.log("Response is: ", response);
   },
   (error) => {
      //catch the error
      console.error("An error occurred, ", error);
   });;
  }    
}
