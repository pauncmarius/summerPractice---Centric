import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Survey } from 'src/app/Models/survey.model';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss']
})
export class AdminPageComponent implements OnInit {
  addSurveyGroup!: FormGroup;
  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {

    this.addSurveyGroup=new FormGroup(
      {
        idTopic: new FormControl(''),
        name: new FormControl(''),
        description: new FormControl(''),
        opening_Time: new FormControl(''),
        closing_Time: new FormControl(''),
        created_By: new FormControl(''),
        modified_By: new FormControl(''),
      }
    );
    this.addSurveyGroup.valueChanges.subscribe(data=>{
      console.log('values: ', data);
    })
  }

  onSubmitFormSurvey(survey: Survey):void
  {

    console.log(survey);
    this.http.post("https://localhost:44365/api/Survey", survey)
    .subscribe({
     next: res=>{
      console.log(res);
      this.router.navigate(["/view-surveys"]);

     }

    });

}



}
