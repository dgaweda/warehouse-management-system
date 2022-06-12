import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {User} from "../models/user.model";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";

@Injectable({providedIn: 'root'})
export class UserService {
  constructor(private http: HttpClient) {
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${environment.apiUrl}/User/Get`);
  }
}
