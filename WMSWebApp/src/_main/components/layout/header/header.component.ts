import {Component, OnDestroy, OnInit } from '@angular/core';
import {DefaultPages, LoginPage, Page} from "../../../shared/models/page.model";
import {AuthenticationService} from "../../../auth/auth.service";
import { NavigationEnd, Router, RouterEvent } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  pages: Page[] = [];
  showLogoutButton: boolean = false;

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router
  )
  {
    this.pages = [];
    this.showLogoutButton = false;
  }

  ngOnInit(): void {
    this.router.events.pipe(
      filter((e: any): e is NavigationEnd  => e instanceof NavigationEnd)
    ).subscribe((e: NavigationEnd) => {
      if(e.url.includes('login')) {

      }
      this.pages = e.url.includes('login') ? LoginPage : DefaultPages;
      this.showLogoutButton = e.url.includes('home');
    });
  }

  logout(): void {
    this.authenticationService.logout();
  }
}
