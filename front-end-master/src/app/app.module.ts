import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import {HttpClientModule} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { RegisterPageComponent } from './pages/register-page/register-page.component';
import { WelcomePageComponent } from './pages/welcome-page/welcome-page.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { CarSurveyPageComponent } from './pages/surveys/car-survey-page/car-survey-page.component';
import { TeacherSurveyPageComponent } from './pages/surveys/teacher-survey-page/teacher-survey-page.component';
import { FooterPageComponent } from './pages/components/footer-page/footer-page.component';
import { HeaderPageComponent } from './pages/components/header-page/header-page.component';
import { MainPageComponent } from './pages/components/main-page/main-page.component';
import { FoodSurveyPageComponent } from './pages/surveys/food-survey-page/food-survey-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ProfilePageComponent } from './pages/profile-page/profile-page.component';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { ViewSurveysPageComponent } from './pages/view-surveys-page/view-surveys-page.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    RegisterPageComponent,
    WelcomePageComponent,
    HomePageComponent,
    CarSurveyPageComponent,
    TeacherSurveyPageComponent,
    FooterPageComponent,
    HeaderPageComponent,
    MainPageComponent,
    FoodSurveyPageComponent,
    ProfilePageComponent,
    AdminPageComponent,
    ViewSurveysPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    HttpClientModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
