import {Component, ElementRef, ViewChild} from '@angular/core';
import {Page} from "../../../_models/page.model";
import {AuthenticationService} from "../../../_service/_auth/auth.service";

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
      {route: '/', name: 'początek'},
      {route: '/delivery', name: 'dostawy'},
      {route: '/order', name: 'zamówienia'},
    ];
    this.pages.push(...pagesArray);
  }

  logout(): void {
    this.authenticationService.logout();
  }
}
