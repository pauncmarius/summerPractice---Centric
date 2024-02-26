import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, from, Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../Models';
import { Survey } from '../Models/survey.model';
import { AddUser } from '../Models/userProfile';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl = 'https://localhost:44365/Api/User';
  url ="auth/login";
  register="User";
  user!:string;
  constructor(private http : HttpClient, private router:Router) { }

  isUserAuthenticated(){
    const token=localStorage.getItem("jwt");
    return !!token;
  }
  logout()
  {
    localStorage.removeItem("jwt");
    this.router.navigate([''])
  }
  getUsers(credentials: User): Observable<any>{
    return this.http.post<User>(`${environment.apiURL}/${this.url}`, credentials);

  }

  addUsers(credentials: AddUser): Observable<any>{
    return this.http.post<AddUser>(this.baseUrl, credentials)

  }

  addSurvey(credentials: Survey): Observable<any>{
    return this.http.post<Survey>("https://localhost:44365/Api/Survey", credentials);
  }


}
