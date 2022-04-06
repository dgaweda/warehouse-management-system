import {Component, ElementRef, ViewChild} from '@angular/core';
import {Page} from "../../../_main/_models/page.model";
import {AuthenticationService} from "../../../_main/_auth/auth.service";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbutton.component.html',
  styleUrls: ['./navbutton.component.scss']
})
export class NavbuttonComponent {
  pages: Page[];

  constructor(private authenticationService: AuthenticationService) {
    this.pages = [];
    this.setPages();
    console.log(this.pages);
  }

  private setPages(): void {
    const pagesArray = [
      {route: '/order', name: 'zamówienia'},
      {route: '/delivery', name: 'dostawy'},
      {route: '/departure', name: 'wyjazdy'},
      {route: '/invoice', name: 'faktury'},
      {route: '/location', name: 'lokacje'},
      {route: '/pallet', name: 'palety'},
      {route: '/products', name: 'produkty'},
    ];
    this.pages.push(...pagesArray);
  }

  logout(): void {
    this.authenticationService.logout();
  }
}
