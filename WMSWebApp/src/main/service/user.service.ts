import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {User} from "../models/user.model";
import {Observable} from "rxjs";
import {Config} from "../shared/models/config.model";
import {ApiService} from "../shared/service/api.service";
import {BaseService} from "./base.service";

@Injectable({providedIn: 'root'})
export class UserService extends BaseService {
  constructor(private http: HttpClient, private config: Config, private apiService: ApiService) {
    super(http, config);
  }

  getUsers(id?: number): Observable<User> {
    const httpParams = this.apiService.createHttpParams([{key: 'id', value: id}]);
    return this.get<User>(this.config.UserApi.getUser, httpParams);
  }
}
