import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { userModel } from "src/app/models/user.model";

@Injectable({
    providedIn: 'root'
})
export class apiUrlService {
    private httpClient: HttpClient;

    constructor(private http: HttpClient) {
        this.httpClient = http;
    }

    registerUser(user: userModel): any {
        const body = environment.apiUrl + 'User/Register';
        console.log(body);
        return this.http.post(body, user);
    }
}
