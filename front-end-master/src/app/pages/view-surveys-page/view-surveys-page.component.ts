import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Survey } from 'src/app/Models/survey.model';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-view-surveys-page',
  templateUrl: './view-surveys-page.component.html',
  styleUrls: ['./view-surveys-page.component.scss']
})
export class ViewSurveysPageComponent implements OnInit {
  survey: Survey[]=[];
  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.getSurveys();

  }

  getSurveys(){
    this.http.get<any>("https://localhost:44365/Api/Survey").subscribe(
      response => {
        console.log(response);
        this.survey=response;
      }
    )
  }

  deleteSurvey(name: any)
  {
    this.http.delete(`${environment.apiURL}/${'Survey'}/${name}`)
    .subscribe(
      {
        next: res=>{
          console.log(res);

        }
      });
  }

}
