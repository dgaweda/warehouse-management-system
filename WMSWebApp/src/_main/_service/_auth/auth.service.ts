import {Injectable} from "@angular/core";
import {BehaviorSubject, map} from "rxjs";
import {User} from "../../_models/user.model";
import {Router} from "@angular/router";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {environment} from "../../../environments/environment";
import {userApiUrl} from "../../_api/api.service";

@Injectable({providedIn: 'root'})
export class AuthenticationService {
  private userSubject: BehaviorSubject<User | null>;

  constructor(private router: Router, private http: HttpClient) {
    this.userSubject = this.setUserSubject();
  }

  private setUserSubject(): BehaviorSubject<any> {
    const localStorageUser = AuthenticationService.getUserFromLocalStorage();
    if(localStorageUser) {
      return new BehaviorSubject<User>(JSON.parse(localStorageUser))
    }
    return new BehaviorSubject<null>(null);
  }

  private static getUserFromLocalStorage(): string | null{
    const userAuthData = localStorage.getItem('user');
    if(userAuthData){
      return userAuthData;
    }
    return null;
  }

  get currentUser(): any{
    return this.userSubject.value;
  }

  login(username: string, password: string): any {
    const header = new HttpHeaders();
    header.append('Content-Type', 'application/json; charset=UTF-8');
    return this.http.post<any>(`${environment.apiUrl}${userApiUrl.login}`, {
        Username: username,
        Password: password
      }, {
        headers: header
      }).pipe(
        map(user => {
          const currentUser = user['data'];
          console.log(password);
          currentUser.authData = window.btoa(`${currentUser.userName}:${password}`);
          const localStorageUserData = {
            authData: currentUser.authData
          };

          localStorage.setItem('user', JSON.stringify(localStorageUserData));
          this.userSubject = this.setUserSubject();
          this.router.navigate(['/delivery']);
      }));
  }

  logout(): void {
    localStorage.removeItem('user');
    this.userSubject.next(null);
    this.router.navigate(['/login']);
  }
}
