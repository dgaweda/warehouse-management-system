import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Injectable } from "@angular/core";
import { DeliveryApiUrl } from "src/api/apiUrl";
import { deliveryModel } from "src/models/delivery.model";

@Injectable({
    providedIn: 'root'
})
export class deliveryService {
    private apiUrl = environment.apiUrl;
    private http: HttpClient;

    constructor(private httpClient: HttpClient){
        this.http = httpClient;
    }

    getDelivery(name?: string): deliveryModel {
        return this.http.get<deliveryModel>(this.apiUrl + DeliveryApiUrl.getDelivery);
    }
}