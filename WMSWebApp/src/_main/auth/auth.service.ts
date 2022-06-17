import {Injectable} from "@angular/core";
import {BehaviorSubject, map} from "rxjs";
import {User} from "../models/user.model";
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Config} from "../shared/models/config.model";

@Injectable({providedIn: 'root'})
export class AuthenticationService {
  private userSubject$: BehaviorSubject<User | null>;

  constructor(
    private router: Router,
    private http: HttpClient,
    private config: Config
  ) {
    this.userSubject$ = this.getUserSubject();
  }

  get currentUser(): User {
    return this.userSubject$.value as User;
  }

  private getUserSubject(): BehaviorSubject<User | null> {
    const localStorageUser = this.getUserFromLocalStorage();
    if(localStorageUser) {
      return new BehaviorSubject<User | null>(JSON.parse(localStorageUser))
    }
    return new BehaviorSubject<User | null>(null);
  }

  private getUserFromLocalStorage(): string | null{
    const userAuthData = localStorage.getItem('user');
    if(userAuthData){
      return userAuthData;
    }
    return null;
  }

  login(username: string, password: string): any {
    return this.http.post<any>(`${this.config.baseApiUrl}${this.config.UserApi.login}`, {
      Username: username,
      Password: password
    }).pipe(
      map((user: User) => {
        user.authData = window.btoa(username + ':' + password);
        localStorage.setItem('user', JSON.stringify(user));
        this.userSubject$.next(user);
        return user;
      }));
  }

  logout(): void {
    localStorage.removeItem('user');
    this.userSubject$.next(null);
    this.router.navigate(['/login']);
  }
}
