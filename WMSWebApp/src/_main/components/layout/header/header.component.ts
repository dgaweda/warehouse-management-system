import { Component, OnInit } from '@angular/core';
import {Page} from "../../../_models/page.model";
import {AuthenticationService} from "../../../_auth/auth.service";
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
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
  }

  logout(): void {
    this.authenticationService.logout();
  }
}
