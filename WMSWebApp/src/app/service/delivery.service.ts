import {HttpClient, HttpHeaderResponse, HttpHeaders, HttpParams} from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Injectable } from "@angular/core";
import { DeliveryApiUrl } from "src/app/api/apiUrl";
import { DeliveryModel } from "src/app/models/delivery.model";
import { Observable } from "rxjs";
import { SharedService } from "./shared.service";

@Injectable({
  providedIn: 'root'
})
export class DeliveryService extends SharedService {

  constructor(private httpClient: HttpClient){
    super(httpClient);
  }

  getDeliveries(name?: string): Observable<DeliveryModel[]> {
    let filterParam = new HttpParams();
    if (name) {
      filterParam.set('Name', name);
    }

    const url = this.combineUrl(DeliveryApiUrl.getDelivery);
    return this.http.get<DeliveryModel[]>(url, {params: filterParam});
  }

  addDelivery(delivery: DeliveryModel): any {
    const url = this.combineUrl(DeliveryApiUrl.getDelivery);
    return this.http.post(url, delivery);
  }
}
