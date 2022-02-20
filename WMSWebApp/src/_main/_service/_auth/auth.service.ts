import {Injectable} from "@angular/core";
import {BehaviorSubject, map, Observable} from "rxjs";
import {User} from "../../_models/user.model";
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment";

@Injectable({providedIn: 'root'})
export class AuthenticationService {
  private currentUser: string;
  private userSubject: BehaviorSubject<User | null>;

  public user: Observable<User | null>

  constructor(private router: Router, private http: HttpClient) {
    this.currentUser = this.getUserFromLocalStorage();
    this.userSubject = new BehaviorSubject<User | null>(JSON.parse(this.currentUser));
    this.user = this.userSubject.asObservable();
  }

  public get userValue(): User | null {
    return this.userSubject.value;
  }

  login(username: string, password: string): any {
    return this.http.post<any>(environment.apiUrl + 'User/Authenticate', {username, password})
      .pipe(map(user => {
        user.authdata = window.btoa(`${username}:${password}`);
        console.log(`AuthData:${user.authdata}`);
        localStorage.setItem('user', JSON.stringify(user));
        this.userSubject.next(user);
        return user;
      }))
  }

  logout(): void {
    localStorage.removeItem('user');
    this.userSubject.next(null);
    this.router.navigate(['/login']);
  }

  private getUserFromLocalStorage(): string {
    const userData = localStorage.getItem('user');
    if(userData){
      return userData;
    }
    // TO DO
    return 'No user in local storage';
  }
}
