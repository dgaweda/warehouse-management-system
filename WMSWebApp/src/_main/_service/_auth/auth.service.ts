import {Injectable} from "@angular/core";
import {BehaviorSubject, map, Observable, pipe} from "rxjs";
import {User} from "../../_models/user.model";
import {Router} from "@angular/router";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {environment} from "../../../environments/environment";
import {UserApiUrl} from "../../api/apiUrl.service";

@Injectable({providedIn: 'root'})
export class AuthenticationService {
  private currentUser: string | null;
  private userSubject: BehaviorSubject<User>;

  constructor(private router: Router, private http: HttpClient) {
    this.currentUser = this.getUserFromLocalStorage();
    this.userSubject = this.setUserSubject();
  }

  get userValue(): User {
    return this.userSubject.value;
  }

  login(username: string, password: string): any {
    const header = new HttpHeaders();
    header.append('Content-Type', 'application/json; charset=UTF-8');
    return this.http.post(`${environment.apiUrl}${UserApiUrl.login}`, {
        Username: username,
        Password: password
      }, {
        headers: header
      })
      .pipe(
        map(user => {
          console.log(`user: ${user}`, user);
          localStorage.setItem('user', JSON.stringify(user));
      }))
  }

  logout(): void {
    localStorage.removeItem('user');
    this.userSubject.complete();
    this.router.navigate(['/login']);
  }

  private setUserSubject(): BehaviorSubject<any> {
    const localStorageUser = this.currentUser;
    if(localStorageUser) {
      return new BehaviorSubject<User>(JSON.parse(localStorageUser))
    }
    return new BehaviorSubject<null>(null);
  }

  private getUserFromLocalStorage(): string | null{
    const userAuthData = localStorage.getItem('user');
    if(userAuthData){
      return userAuthData;
    }
    return null;
  }

  private setAuthorizationHeader(username: string, password: string): HttpHeaders {
    const headers = new HttpHeaders();
    const base64Credentials = window.btoa(`${username}:${password}`);
    headers.append(`Authorization`, `Basic ${base64Credentials}`);
    return headers;
  }

}
