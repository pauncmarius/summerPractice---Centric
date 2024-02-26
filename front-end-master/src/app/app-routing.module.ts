import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { RegisterPageComponent } from './pages/register-page/register-page.component';
import { WelcomePageComponent } from './pages/welcome-page/welcome-page.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { MainPageComponent } from './pages/components/main-page/main-page.component';
import { FoodSurveyPageComponent } from './pages/surveys/food-survey-page/food-survey-page.component';
import { CarSurveyPageComponent } from './pages/surveys/car-survey-page/car-survey-page.component';
import { TeacherSurveyPageComponent } from './pages/surveys/teacher-survey-page/teacher-survey-page.component';
import { LoginGuard } from './guard/login.guard';
import { ProfilePageComponent } from './pages/profile-page/profile-page.component';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { ViewSurveysPageComponent } from './pages/view-surveys-page/view-surveys-page.component';

const routes: Routes = [
  {
  path: 'register',
  component: RegisterPageComponent,
},
{
  path: 'login',
  component: LoginPageComponent,

},
{
  path: 'welcome',
  component: WelcomePageComponent,

},
{
  path: '',
  component: WelcomePageComponent,
},

{
  path: 'profile',
  component: ProfilePageComponent,
},
{
  path: 'admin',
  component: AdminPageComponent,
},
{
  path: 'view-surveys',
  component: ViewSurveysPageComponent
},

{
  path: 'home',
  canActivate: [LoginGuard],
  component: HomePageComponent,
  children: [
    {
        path: '',
        component: FoodSurveyPageComponent
    },
    {
      path: 'car',
      component: CarSurveyPageComponent
  },
  {
    path: 'teacher',
    component: TeacherSurveyPageComponent
}
  ]
},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
