import { NgIf } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { Observable, throwIfEmpty } from 'rxjs';
import { User } from 'src/app/Models';
import { UserService } from 'src/app/Services/user.service';
import {ReactiveFormsModule, FormsModule} from '@angular/forms';
import { Route, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
  showPassword: boolean = false;

  formGroupLogin!: FormGroup;
  errorLogin!: string;
  @Input() emailProfile!:string;
  @Input() passProfile!:string;
  login?: boolean;
  constructor(private userService: UserService, private router:Router, private http: HttpClient) {

  }

  ngOnInit(): void {

    this.formGroupLogin= new FormGroup({
      email: new FormControl(''),
      password: new FormControl('')
    });


    this.formGroupLogin.valueChanges.subscribe(data=>{
      this.emailProfile=data.email;
      this.passProfile=data.pass;
      console.log('values: ', data);
    })

  }


  onSubmitForm():void
  {
    this.userService.getUsers({email: this.formGroupLogin.get('email')?.value, password: this.formGroupLogin.get('password')?.value })
    .subscribe({
      next: res=>{
        const token = res.token;
        localStorage.setItem("jwt", token);
        this.login=false;
        this.router.navigate(["/home"]).then(r=> console.log("Route student", r))
      },
      error: (err: any) =>{
        this.login=true;
        this.errorLogin= "Invalid email or password";
        console.log('Invalid email or password', err);
      }
    })


  }

  onModelChange(event:string):void
  {
    console.log('valoare', event);
    //this.ngModel=event;

  }



  showHidePassword() {
    this.showPassword = !this.showPassword;

  }
}

