import {Component, OnInit } from '@angular/core';
import {AuthenticationService} from "../../../auth/auth.service";
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import {Config} from "../../../common/models/config.model";
import {Page} from "../../../common/models/page.model";
import {BaseComponent} from "../../../common/components/base.component";
import {User} from "../../../models/user.model";
import {DropdownOption} from "../../../common/models/dropdownOption.model";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent extends BaseComponent implements OnInit {
  pages: Page[] = [];
  showLogoutButton: boolean = false;
  activePageIndex: number;
  mainPages: Page[];
  currentUser: User;
  dropdownOptions: DropdownOption[];
  isLoggedIn: boolean;

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
    private config: Config
  ) {
    super();
    this.pages = [];
    this.showLogoutButton = false;
    this.mainPages = this.config.NavigationConfig.mainPages;
    this.activePageIndex = 0;
    this.dropdownOptions = [];
    this.isLoggedIn = false;
  }

  ngOnInit(): void {
    this.subscribe(
      this.router.events.pipe(filter((e: any): e is NavigationEnd => e instanceof NavigationEnd)),{
        next: (e: NavigationEnd) => {
          this.activePageIndex = this.mainPages.findIndex((page: Page) => e.url.includes(page.route));

          if(this.isLoginPage(e)) {
            this.pages = this.config.NavigationConfig.loginPage;
            this.activePageIndex = 0;
            this.isLoggedIn = false;
          } else {
            this.isLoggedIn = true;
            this.dropdownOptions = [
              {
                value: 1,
                name: 'Wyloguj',
                icon: 'return',
                action: this.logout()
              }
            ];
            this.currentUser = this.authenticationService.currentUser;
            this.pages = this.mainPages;
          }

          this.showLogoutButton = this.isHomePage(e);
        }
      });
  }
  private isLoginPage = (e: NavigationEnd): boolean => e.url.includes('login');
  private isHomePage = (e: NavigationEnd): boolean => e.url.includes('home');

  onSelectTab(e: any): void {
    console.log(`onSelectTab`);
    this.router.navigate([e.itemData.route]);
    this.activePageIndex = e.itemData.id;
  }

  onItemSelect(e: any): void {
    e.itemData.action;
  }

  logout(): void {
    this.authenticationService.logout();
  }
}
