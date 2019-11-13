import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserLoginService {

  constructor(private http: HttpClient) { }

  login(formData) {
    return this.http.post(environment.apiBaseURI + 'UsersAccount/Login', formData);
  }
}
