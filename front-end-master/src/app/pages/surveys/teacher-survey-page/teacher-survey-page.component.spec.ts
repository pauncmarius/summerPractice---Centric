import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherSurveyPageComponent } from './teacher-survey-page.component';

describe('TeacherSurveyPageComponent', () => {
  let component: TeacherSurveyPageComponent;
  let fixture: ComponentFixture<TeacherSurveyPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeacherSurveyPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TeacherSurveyPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
