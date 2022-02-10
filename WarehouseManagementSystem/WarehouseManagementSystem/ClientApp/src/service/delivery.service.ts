import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Injectable } from "@angular/core";
import { DeliveryApiUrl } from "src/api/apiUrl";
import { deliveryModel } from "src/models/delivery.model";
import { AnyCatcher } from "rxjs/internal/AnyCatcher";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class deliveryService {
    private apiUrl = environment.apiUrl;
    private http: HttpClient;

    constructor(private httpClient: HttpClient){
        this.http = httpClient;
    }

    getDelivery(): Observable<deliveryModel> {
        return this.http.get<deliveryModel>(this.apiUrl + DeliveryApiUrl.getDelivery);
    }

    addDelivery(delivery: deliveryModel): any {
        return this.http.post(this.apiUrl + DeliveryApiUrl.addDelivery, delivery);
    }
}