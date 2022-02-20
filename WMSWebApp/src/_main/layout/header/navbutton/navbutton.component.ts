import { Component } from '@angular/core';
import {Page} from "../../../_models/page.model";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbutton.component.html',
  styleUrls: ['./navbutton.component.scss']
})
export class NavbuttonComponent {
  pages: Page[];
  constructor() {
    this.pages = [];
    this.setPages();
    console.log(this.pages);
  }

  private setPages(): void {
    const pagesArray = [
      {route: '/', name: 'Początek'},
      {route: '/login', name: 'Logowanie'},
      {route: '/delivery', name: 'Dostawy'},
    ];
    this.pages.push(...pagesArray);
  }
}
