import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { User } from "src/_main/_models/user.model";

@Injectable({
    providedIn: 'root'
})
export class apiUrlService {
    private httpClient: HttpClient;

    constructor(private http: HttpClient) {
        this.httpClient = http;
    }

    registerUser(user: User): any {
        const url = environment.apiUrl + 'User/Register';
        console.log(url);
        return this.http.post(url, user);
    }
}
