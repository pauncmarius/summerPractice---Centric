import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSurveysPageComponent } from './view-surveys-page.component';

describe('ViewSurveysPageComponent', () => {
  let component: ViewSurveysPageComponent;
  let fixture: ComponentFixture<ViewSurveysPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewSurveysPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewSurveysPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
