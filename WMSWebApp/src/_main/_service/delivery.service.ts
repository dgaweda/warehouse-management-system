import {HttpClient} from "@angular/common/http";
import { Injectable } from "@angular/core";
import {ApiUrlService, DeliveryApiUrl} from "../_shared/apiUrl.service";
import {environment} from "../../environments/environment";
import { Delivery } from "../_models/delivery.model";
import {ResponseBody} from "../_shared/responseBody.model";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class DeliveryService {

  constructor(
    private apiService: ApiUrlService,
    private httpClient: HttpClient
  ) {}

  getDeliveries(deliveryName?: string): Observable<ResponseBody<Delivery[]>> {
    const name = this.apiService.createHttpParam('Name', deliveryName);
    return this.httpClient.get<ResponseBody<Delivery[]>>(`${environment.apiUrl}${DeliveryApiUrl.getDeliveries}`, {params: name});
  }
}
