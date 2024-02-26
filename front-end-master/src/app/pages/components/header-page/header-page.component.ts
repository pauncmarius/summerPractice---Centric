import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-header-page',
  templateUrl: './header-page.component.html',
  styleUrls: ['./header-page.component.scss']
})
export class HeaderPageComponent implements OnInit {

  constructor(private logoutService: UserService, router:Router) { }

  ngOnInit(): void {
  }

  logOut()
  {
    if(this.logoutService.register)
    {
      this.logoutService.logout();

    }
  }

}
