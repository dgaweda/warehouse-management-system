import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import {Observable} from "rxjs";
import {SharedService} from "../_service/shared.service";
import {Order} from "../_models/order.model";

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

export interface RequestData {
  headers?: HttpHeaders,
  params?: HttpParams
}

@Injectable({
    providedIn: 'root'
})
export class ApiService {
  basicHeaders: HttpHeaders;

  constructor(private httpClient: HttpClient, private sharedService: SharedService) {
    this.basicHeaders = this.sharedService.getBasicHeaders();
    console.log(this.basicHeaders);
  }

  setRequestData(httpParams?: HttpParams): RequestData {
    return {
      headers: this.basicHeaders,
      params: httpParams
    }
  }

  getDeliveries(httpParams: HttpParams): Observable<any> {
    return this.httpClient.get(`${environment.apiUrl}${DeliveryApiUrl.getDeliveries}`, this.setRequestData(httpParams));
  }

  getOrders(httpParams: HttpParams): Observable<Order[]> {
    return this.httpClient.get<Order[]>(`${environment.apiUrl}${OrderApiUrl.getOrders}`, this.setRequestData(httpParams))
  }
}
