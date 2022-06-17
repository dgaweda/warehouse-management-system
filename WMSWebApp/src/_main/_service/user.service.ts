import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
<<<<<<< Updated upstream:WMSWebApp/src/_main/_service/user.service.ts
import {User} from "../_models/user.model";
import {environment} from "../../environments/environment";
=======
import {User} from "../models/user.model";
>>>>>>> Stashed changes:WMSWebApp/src/_main/service/user.service.ts
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
