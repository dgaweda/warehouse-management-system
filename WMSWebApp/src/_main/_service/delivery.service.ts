import { HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Delivery } from "src/_main/_models/delivery.model";
import {Observable} from "rxjs";
import {ApiService} from "../_api/api.service";

@Injectable({
  providedIn: 'root'
})
export class DeliveryService{
  deliveries: Delivery[];

  constructor(private apiService: ApiService) {
    this.deliveries = [];
  }

  getDeliveries(name?: string): Delivery[] {
    let filterParam = new HttpParams();
    let deliveries = this.deliveries;
    if(name) {
      filterParam = filterParam.set('Name', name);
    }

    this.apiService
      .getDeliveries(filterParam)
      .subscribe((deliveryData: Delivery[]) => {
        if(deliveryData){
          deliveries = deliveryData;
        }
      });
    console.log(deliveries);
    return deliveries;
  }
}
