import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Survey } from 'src/app/Models/survey.model';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {
  survey:Survey[]=[];
  constructor(private userService: UserService, private http: HttpClient) { }

  ngOnInit(): void {
    this.getSurveys();
  }

  getSurveys(){
    this.http.get<any>('https://localhost:44365/api/Survey').subscribe(
      response => {
        console.log(response);
        this.survey = response;
      }
    );
  }

}
