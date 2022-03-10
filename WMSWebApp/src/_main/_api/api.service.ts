import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import {Observable} from "rxjs";
import {SharedService} from "../_service/shared.service";

export enum deliveryApiUrl {
  getDeliveries = '/Delivery/Get',
  addDelivery = '/Delivery/Add',
  removeDelivery = '/Delivery/Remove',
  editDelivery = '/Delivery/Edit'
}

export enum departureApiUrl {
  getDeparture = '/Departure/Get',
  addDeparture = '/Departure/Add',
  editDeparture = '/Departure/Edit',
  removeDeparture = '/Departure/Remove'
}

export enum invoiceApiUrl {
  getInvoice = '/Invoice/Get',
  addInvoice = '/Invoice/Add',
  removeInvoice = '/Invoice/Remove',
  editInvoice = '/Invoice/Edit'
}

export enum locationApiUrl {
  getLocation = '/Location/Get',
  addLocation = '/Location/Add',
  editLocation = '/Location/Edit',
  changeLocationCurrentAmount = '/Location/Edit/CurrentAmount',
  setLocation = '/Location/Set',
  removeLocation = '/Location/Remove'
}

export enum orderApiUrl {
  getOrders = '/Order/Get'
}

export enum userApiUrl {
  login = '/User/Login'
}

@Injectable({
    providedIn: 'root'
})
export class ApiService {
  basicHeaders: HttpHeaders;

  constructor(private httpClient: HttpClient, private sharedService: SharedService) {
    this.basicHeaders = this.sharedService.getBasicHeaders();
  }

  getDeliveries(httpParams: HttpParams): Observable<any> {
    return this.httpClient.get(`${environment.apiUrl}${deliveryApiUrl.getDeliveries}`, {headers: this.basicHeaders, params: httpParams});
  }


}
