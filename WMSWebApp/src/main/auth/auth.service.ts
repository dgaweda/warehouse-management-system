import {Injectable} from "@angular/core";
import {BehaviorSubject, map, Observable, tap} from "rxjs";
import {User} from "../models/user.model";
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {Config} from "../shared/models/config.model";
import {AuthenticationData} from "../shared/models/authentication.model";
import {UserService} from "../service/user.service";
import {ResponseBody} from "../shared/models/responseBody.model";

@Injectable({providedIn: 'root'})
export class AuthenticationService {
  private userSubject$: BehaviorSubject<User | null>;

  constructor(
    private router: Router,
    private http: HttpClient,
    private config: Config,
    private userService: UserService
  ) {
    this.userSubject$ = this.getUserSubject();
  }

  get currentUser(): User {
    return this.userSubject$.value as User;
  }

  login(authData: AuthenticationData): Observable<ResponseBody<User>> {
    return this.http.post<ResponseBody<User>>(`${this.config.baseApiUrl}${this.config.UserApi.login}`, authData).pipe(
      map((user: ResponseBody<User>) => {
        console.log(`User`, user);
        if(!localStorage.getItem('userId')){
          localStorage.setItem('userId', `${user.data.id}`);
        }
        this.userSubject$.next(user.data);
        return user;
        })
      );
  }

  logout(): void {
    localStorage.removeItem('user');
    this.userSubject$.next(null);
    this.router.navigate(['/login']);
  }

  private getUserSubject(): BehaviorSubject<User | null> {
    const userId = localStorage.getItem('userId');
    if (userId) {
      console.log(userId);
      this.userService.getUser(Number(userId)).pipe(
        map((user: User) => {
          console.log(user);
          return new BehaviorSubject<User>(user); // fix authent
        })
      );
    }
    return new BehaviorSubject<User | null>(null);
  }
}
