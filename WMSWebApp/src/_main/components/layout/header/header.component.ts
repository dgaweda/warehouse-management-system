<<<<<<< Updated upstream
import { Component, OnInit } from '@angular/core';
import {Page} from "../../../_models/page.model";
import {AuthenticationService} from "../../../_auth/auth.service";
import { ActivatedRoute } from '@angular/router';
=======
import {Component, OnInit } from '@angular/core';
import {AuthenticationService} from "../../../auth/auth.service";
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import {Config} from "../../../shared/models/config.model";
import {Page} from "../../../shared/models/page.model";
>>>>>>> Stashed changes

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
<<<<<<< Updated upstream
export class HeaderComponent {
  pages: Page[] = [];

  constructor(
    private authenticationService: AuthenticationService,
    public activatedRoute: ActivatedRoute)
  {
    this.pages = [
      {route: '/order', name: 'Zamówienia'},
      {route: '/delivery', name: 'Dostawy'},
      {route: '/departure', name: 'Wyjazdy'},
      {route: '/invoice', name: 'Faktury'},
      {route: '/location', name: 'Lokacje'},
      {route: '/pallet', name: 'Palety'},
      {route: '/products', name: 'Produkty'}
    ];
    console.log(this.pages);
=======
export class HeaderComponent implements OnInit {
  pages: Page[] | Page = [];
  showLogoutButton: boolean = false;

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
    private config: Config
  )
  {
    this.pages = [];
    this.showLogoutButton = false;
  }

  ngOnInit(): void {
    this.router.events.pipe(
      filter((e: any): e is NavigationEnd  => e instanceof NavigationEnd)
    ).subscribe((e: NavigationEnd) => {
      this.pages = e.url.includes('login') ? this.config.NavigationConfig.loginPage : this.config.NavigationConfig.mainPages;
      this.showLogoutButton = e.url.includes('home');
    });
>>>>>>> Stashed changes
  }

  logout(): void {
    this.authenticationService.logout();
  }
}
