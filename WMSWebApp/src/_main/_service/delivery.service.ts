import {HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import {ApiService, DeliveryApiUrl} from "../_api/api.service";
import {environment} from "../../environments/environment";
import {BehaviorSubject, Observable } from "rxjs";
import { Delivery } from "../_models/delivery.model";

@Injectable({
  providedIn: 'root'
})
export class DeliveryService{
  deliveries: BehaviorSubject<Delivery[]>;
  deliveries$: Observable<Delivery[]>;

  constructor(
    private apiService: ApiService,
    private httpClient: HttpClient
  ) {
    this.deliveries = new BehaviorSubject<Delivery[]>([]);
    this.deliveries$ = this.deliveries.asObservable();
  }

  setHttpParams(key: string, value: any): HttpParams {
    let params = new HttpParams();
    if(value) {
      params = params.set(key, value);
    }
    return params;
  }

  getDeliveries(name?: string): void {
    const param = this.setHttpParams('Name', name);
    this.httpClient.get<Delivery[]>(`${environment.apiUrl}${DeliveryApiUrl.getDeliveries}`, { params: param })
      .subscribe((response: Delivery[]) => {
        this.deliveries.next(response);
      });
  }
}
