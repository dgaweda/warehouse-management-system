import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { User } from "src/_main/_models/user.model";

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

export enum UserApiUrl {
  login = '/User/Login'
}

@Injectable({
    providedIn: 'root'
})
export class apiUrlService {
    private httpClient: HttpClient;

    constructor(private http: HttpClient) {
        this.httpClient = http;
    }

    registerUser(user: User): any {
        const url = environment.apiUrl + 'User/Register';
        console.log(url);
        return this.http.post(url, user);
    }
}
