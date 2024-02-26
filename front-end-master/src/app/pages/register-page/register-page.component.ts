import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { AddUser } from 'src/app/Models/userProfile';
import { UserService } from 'src/app/Services/user.service';
import { LoginPageComponent } from '../login-page/login-page.component';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent implements OnInit {
  FormGroupRegister!: FormGroup;
  constructor(private addUserService: UserService, private router: Router, private http: HttpClient) { }

  ngOnInit(): void {

    this.FormGroupRegister= new FormGroup(
      {
        username: new FormControl(''),
        firstName: new FormControl(''),
        lastName: new FormControl(''),
        email: new FormControl(''),
        phoneNumber: new FormControl(''),
        hashed_password: new FormControl(''),
      }
    );

    this.FormGroupRegister.valueChanges.subscribe(data=>{
      console.log('values: ', data);
    })
  }

  onSubmitFormRegister(user: AddUser):void
  {

    console.log(user);
    this.http.post("https://localhost:44365/api/user", user)
    .subscribe({
     next: res=>{
      console.log(res);
      this.router.navigate(["/login"]);

     }

    });

    /*this.addUserService.addUsers({
      Username: this.FormGroupRegister.get('username')?.value,
      First_Name: this.FormGroupRegister.get('firstName')?.value,
      Last_Name: this.FormGroupRegister.get('lastName')?.value,
      Email: this.FormGroupRegister.get('email')?.value,
      Phone_Number: this.FormGroupRegister.get('PhoneNumber')?.value,
      Hashed_password: this.FormGroupRegister.get('password')?.value,
      isAdmin: false

    }).subscribe({
      next: res=>{
        this.router.navigate(["/login"]);
      }
    })
  }*/
  }


}

