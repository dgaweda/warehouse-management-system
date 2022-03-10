import { HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { DeliveryModel } from "src/_main/_models/delivery.model";
import {Observable} from "rxjs";
import {ApiService} from "../_api/api.service";

@Injectable({
  providedIn: 'root'
})
export class DeliveryService{
  deliveries: DeliveryModel[];

  constructor(private apiService: ApiService) {
    this.deliveries = [];
  }

  getDeliveries(name?: string): DeliveryModel[] {
    let filterParam = new HttpParams();
    if(name) {
      filterParam = filterParam.set('Name', name);
    }

    this.apiService
      .getDeliveries(filterParam)
      .subscribe((deliveries: any) => {
        if(deliveries){
          this.deliveries = deliveries['data'];
        }
      });

    return this.deliveries;
  }
}
