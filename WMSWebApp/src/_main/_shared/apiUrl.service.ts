import {HttpParams} from "@angular/common/http";
import { Injectable } from "@angular/core";

export enum DeliveryApiUrl {
  getDeliveries = '/Delivery/Get',
  addDelivery = '/Delivery/Add',
  removeDelivery = '/Delivery/Remove',
  editDelivery = '/Delivery/Edit'
}

export enum DepartureApiUrl {
  getDeparture = '/Departure/Get',
  addDeparture = '/Departure/Add',
  editDeparture = '/Departure/Edit',
  removeDeparture = '/Departure/Remove'
}

export enum InvoiceApiUrl {
  getInvoice = '/Invoice/Get',
  addInvoice = '/Invoice/Add',
  removeInvoice = '/Invoice/Remove',
  editInvoice = '/Invoice/Edit'
}

export enum LocationApiUrl {
  getLocation = '/Location/Get',
  addLocation = '/Location/Add',
  editLocation = '/Location/Edit',
  changeLocationCurrentAmount = '/Location/Edit/CurrentAmount',
  setLocation = '/Location/Set',
  removeLocation = '/Location/Remove'
}

export enum OrderApiUrl {
  getOrders = '/Order/Get'
}

export enum userApiUrl {
  login = '/User/Login'
}

@Injectable({
    providedIn: 'root'
})
export class ApiUrlService {

  createHttpParam(key: string, value: any): HttpParams {
    let params = new HttpParams();
    if(value) {
      params = params.set(key, value);
    }
    return params;
  }
}
