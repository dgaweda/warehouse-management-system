import { HttpClient} from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Injectable } from "@angular/core";
import { DeliveryApiUrl } from "src/api/apiUrl";
import { DeliveryModel } from "src/models/delivery.model";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class DeliveryService {
    private apiUrl = environment.apiUrl;
    private http: HttpClient;

    constructor(private httpClient: HttpClient){
        this.http = httpClient;
    }

    getDeliveries(name: string): Observable<DeliveryModel> {
        let filter = '';
        if(name !== '') {
            filter = '?Name=' + name;
        }
        
        console.log(`URL: ${this.apiUrl + DeliveryApiUrl.getDelivery + filter}`);
        return this.http.get<DeliveryModel>(this.apiUrl + DeliveryApiUrl.getDelivery);
    }

    addDelivery(delivery: DeliveryModel): any {
        return this.http.post(this.apiUrl + DeliveryApiUrl.addDelivery, delivery);
    }
}