import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { userModel } from "src/models/user.model";

@Injectable({
    providedIn: 'root'
})
export class apiUrlService {
    private http: HttpClient;

    constructor(private httpClient: HttpClient) {
        this.http = httpClient;
    }

    registerUser(user: userModel): any {
        const body = environment.apiUrl + 'User/Register';
        console.log(body);
        return this.http.post(body, user);
    }
}