import {HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import {ApiService, DeliveryApiUrl} from "../_shared/api.service";
import {environment} from "../../environments/environment";
import {BehaviorSubject, Observable } from "rxjs";
import { Delivery } from "../_models/delivery.model";

@Injectable({
  providedIn: 'root'
})
export class DeliveryService {
  deliveries: BehaviorSubject<Delivery[]>;

  constructor(
    private apiService: ApiService,
    private httpClient: HttpClient
  ) {
    this.deliveries = new BehaviorSubject<Delivery[]>([]);
  }

  getDeliveries(name?: string): void {

    const param = this.apiService.createHttpParam('Name', name);
    console.log(param);
    this.httpClient.get<Delivery[]>(`${environment.apiUrl}${DeliveryApiUrl.getDeliveries}`, { params: param })
      .subscribe((response: Delivery[]) => {
        this.deliveries.next(response);
      });
  }
}
