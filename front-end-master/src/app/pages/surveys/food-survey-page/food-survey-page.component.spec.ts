import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FoodSurveyPageComponent } from './food-survey-page.component';

describe('FoodSurveyPageComponent', () => {
  let component: FoodSurveyPageComponent;
  let fixture: ComponentFixture<FoodSurveyPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FoodSurveyPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FoodSurveyPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
