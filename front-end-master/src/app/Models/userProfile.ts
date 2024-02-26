import {AbstractControl} from "@angular/forms";

export interface AddUser{
  Username? : string,
  First_Name?:string,
  Last_Name?:string,
  Email?:string,
  Phone_Number?:string,
  Hashed_password?:string,
  isAdmin?: boolean
}
