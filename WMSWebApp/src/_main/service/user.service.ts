import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {User} from "../models/user.model";
import {Observable} from "rxjs";
import {Config} from "../shared/models/config.model";

@Injectable({providedIn: 'root'})
export class UserService {
  constructor(private http: HttpClient, private config: Config) {
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.config.baseApiUrl}/User/Get`);
  }
}
