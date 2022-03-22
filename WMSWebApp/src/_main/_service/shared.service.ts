import {Injectable, OnInit} from "@angular/core";
import {AuthenticationService} from "./_auth/auth.service";
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {User} from "../_models/user.model";
import {environment} from "../../environments/environment";
import {filter, Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  currentUser: any;
  headers: HttpHeaders;

  constructor(private httpClient: HttpClient,private authenticationService: AuthenticationService) {
    this.headers = new HttpHeaders();
    this.currentUser = this.authenticationService.currentUser;
    console.log(this.currentUser);
    if(this.currentUser) {
      this.setBasicHeaders();
    }
    console.log(`CurrentUSer: ${this.currentUser}`, this.currentUser);
  }

  getBasicHeaders(): HttpHeaders {
    return this.headers;
  }

  private setBasicHeaders(): void {
    console.log('CurrentUserData', this.currentUser);
    this.headers = this.headers.set('Authorization', `Basic ${this.currentUser.authData}`);
    this.headers = this.headers.set('Content-Type', 'application/json; charset=UTF-8')
  }
}
