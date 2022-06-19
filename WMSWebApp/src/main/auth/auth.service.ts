import {Injectable} from "@angular/core";
import {BehaviorSubject, map, Observable } from "rxjs";
import {User} from "../models/user.model";
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {Config} from "../shared/models/config.model";
import {AuthenticationData} from "../shared/models/authentication.model";
import {ResponseBody} from "../shared/models/responseBody.model";
import * as CryptoJS from 'crypto-js';
import {BaseService} from "../service/base.service";

@Injectable({providedIn: 'root'})
export class AuthenticationService extends BaseService{
  private userSubject$: BehaviorSubject<User | null>;

  constructor(
    private router: Router,
    private http: HttpClient,
    private config: Config
  ) {
    super(http, config);
    this.userSubject$ = this.getUserSubject();
  }

  get currentUser(): User {
    return this.userSubject$.value as User;
  }

  login(authData: AuthenticationData): Observable<ResponseBody<User>> {
    return this.post<ResponseBody<User>>(this.config.UserApi.login, authData).pipe(
      map((user: ResponseBody<User>) => {
        localStorage.setItem('user', this.codeUserData(user.data));
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
    const userData = localStorage.getItem('user');
    if(userData) {
      return new BehaviorSubject<User | null>(this.decodeUserData(userData));
    }
    return new BehaviorSubject<User | null>(null);
  }

  private codeUserData(userData: User): any {
    try {
      const data = CryptoJS.AES.encrypt(JSON.stringify(userData), this.config.secretKey).toString();
      console.log(data);
      return data
    } catch (e) {
      console.error(e);
    }
  }

  private decodeUserData(userData: string): any {
    try {
      const data = CryptoJS.AES.decrypt(userData, this.config.secretKey).toString(CryptoJS.enc.Utf8);
      if(data) {
        return JSON.parse(data);
      }
      return userData;
    } catch (e) {
      console.error(e);
    }
  }
}
