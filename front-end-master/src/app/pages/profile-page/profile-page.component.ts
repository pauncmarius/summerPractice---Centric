import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AddUser } from 'src/app/Models/userProfile';
import { UserService } from 'src/app/Services/user.service';
import { LoginPageComponent } from '../login-page/login-page.component';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.scss']
})
export class ProfilePageComponent implements OnInit {
  user : AddUser[]=[];

  email?:string;
  password?:string;
  constructor(private http: HttpClient, private userService: UserService) {
  }

  ngOnInit(): void {
    //this.getUsers();
    this.getEmail();

  }
  getEmail()
  {



  }

  getUsers()
  {
    this.http.get<any>("https://localhost:44365/Api/User").subscribe(
      response =>{
        console.log(response);
        this.user=response;
      }
    )
  }

}
