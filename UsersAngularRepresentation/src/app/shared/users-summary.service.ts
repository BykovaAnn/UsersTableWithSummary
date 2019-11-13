import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UsersSummary } from '../model/users-summary';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UsersSummaryService {

  constructor(private http: HttpClient) { }

  //getting total user count and active user count with api
  getUsersSummary(): Observable<UsersSummary> {

    return this.http.get<UsersSummary>(environment.apiBaseURI + 'UsersSummary');
  }
}
