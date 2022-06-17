import {HttpClient} from "@angular/common/http";
import { Injectable } from "@angular/core";
import {ResponseBody} from "../shared/models/responseBody.model";
import { Observable } from "rxjs";
import {Config} from "../shared/models/config.model";
import {ApiService} from "../_shared/api.service";
import {Delivery} from "../models/delivery.model";

@Injectable({
  providedIn: 'root'
})
export class DeliveryService {

  constructor(
    private apiService: ApiService,
    private httpClient: HttpClient,
    private config: Config
  ) {}

  getDeliveries(deliveryName?: string): Observable<ResponseBody<Delivery[]>> {
    const name = this.apiService.createHttpParam('Name', deliveryName);
    return this.httpClient.get<ResponseBody<Delivery[]>>(`${this.config.baseApiUrl}${this.config.DeliveryApi.getDeliveries}`, {params: name});
  }
}
