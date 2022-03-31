import {Injectable} from "@angular/core";
import {BehaviorSubject, map, Observable} from "rxjs";
import {User} from "../../_models/user.model";
import {ActivatedRoute, Router} from "@angular/router";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {environment} from "../../../environments/environment";
import {userApiUrl} from "../../_api/api.service";

@Injectable({providedIn: 'root'})
export class AuthenticationService {
  private userSubject: BehaviorSubject<User>;
  public user: Observable<User>;

  constructor(
    private router: Router,
    private http: HttpClient,
  ) {
    this.userSubject = this.getUserSubject();
    this.user = this.userSubject.asObservable();
  }

  get currentUser(): User {
    return this.userSubject.value;
  }

  private getUserSubject(): BehaviorSubject<User> {
    const localStorageUser = this.getUserFromLocalStorage();
    if(localStorageUser) {
      return new BehaviorSubject<User>(JSON.parse(localStorageUser))
    }
    return new BehaviorSubject<User>({} as User);
  }

  private getUserFromLocalStorage(): string | null{
    const userAuthData = localStorage.getItem('user');
    if(userAuthData){
      return userAuthData;
    }
    return null;
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
          this.userSubject = this.getUserSubject();
          this.router.navigate(['/delivery']);
      }));
  }

  login2(username: string, password: string): any {
    return this.http.post<any>(`${environment.apiUrl}${userApiUrl.login}`, {
      Username: username,
      Password: password
    }).pipe(
      map((user: User) => {
        user.data.authData = window.btoa(username + ':' + password);
        localStorage.setItem('user', JSON.stringify(user));
        this.userSubject.subscribe(console.log);
        this.userSubject.next(user);
        console.log(`im in login2:${username} ${password}`, user, user.data.authData, this.user)
        return user;
      }));
  }

  logout(): void {
    localStorage.removeItem('user');
    this.userSubject.next({} as User); // emits new value - null
    this.router.navigate(['/login']);
  }
}
