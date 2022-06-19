import {Component, OnInit } from '@angular/core';
import {AuthenticationService} from "../../../auth/auth.service";
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import {Config} from "../../../shared/models/config.model";
import {Page} from "../../../shared/models/page.model";
import {BaseComponent} from "../../base.component";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent extends BaseComponent implements OnInit {
  pages: Page[] = [];
  showLogoutButton: boolean = false;

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
    private config: Config
  ) {
    super();
    this.pages = [];
    this.showLogoutButton = false;
  }

  ngOnInit(): void {
    this.addSubscription(
      this.router.events.pipe(
        filter((e: any): e is NavigationEnd => e instanceof NavigationEnd)
      ).subscribe((e: NavigationEnd) => {
        this.pages = e.url.includes('login') ? this.config.NavigationConfig.loginPage : this.config.NavigationConfig.mainPages;
        this.showLogoutButton = e.url.includes('home');
      })
    );
  }

  logout(): void {
    this.authenticationService.logout();
  }
}
