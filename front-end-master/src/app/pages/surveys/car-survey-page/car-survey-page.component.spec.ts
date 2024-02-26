import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarSurveyPageComponent } from './car-survey-page.component';

describe('CarSurveyPageComponent', () => {
  let component: CarSurveyPageComponent;
  let fixture: ComponentFixture<CarSurveyPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarSurveyPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarSurveyPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
