import { AppConfig } from "src/config/configuration";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { userModel } from "src/models/user.model";

@Injectable({
    providedIn: 'root'
})
export class userService {
    private apiService: AppConfig
    private apiURL : string;
    private http: HttpClient;

    constructor(private api: AppConfig, private httpClient: HttpClient) {
        this.apiService = api;
        this.apiURL = this.apiService.getAPIUrl();
        this.http = httpClient;
    }

    registerUser(user: userModel): any {
        const body = this.apiURL + 'User/Register';
        console.log(body);
        return this.http.post(body, user);
    }
}