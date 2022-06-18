import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {User} from "../models/user.model";
import {Observable} from "rxjs";
import {Config} from "../shared/models/config.model";
import {ApiService} from "../shared/service/api.service";

@Injectable({providedIn: 'root'})
export class UserService {
  constructor(private http: HttpClient, private config: Config, private apiService: ApiService) {
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.config.baseApiUrl}/User/Get`);
  }

  getUser(id: number): Observable<User> {
    const httpParam = this.apiService.createHttpParam('id', id);
    return this.http.get<User>(`${this.config.baseApiUrl}${this.config.UserApi.getUser}`, { params: httpParam });
  }
}
