import { HttpClient, HttpHeaderResponse, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { DeliveryModel } from "src/_main/_models/delivery.model";
import {filter, first, Observable} from "rxjs";
import {environment} from "../../environments/environment";
import {AuthenticationService} from "./_auth/auth.service";
import {DeliveryApiUrl} from "../api/apiUrl.service";
import {SharedService} from "./shared.service";

@Injectable({
  providedIn: 'root'
})
export class DeliveryService{
  basicHeaders: HttpHeaders;
  constructor(
    private sharedService: SharedService,
    private httpClient: HttpClient) {
      this.basicHeaders = this.sharedService.getBasicHeaders();
  }

  getDeliveries(name?: string): Observable<DeliveryModel> {
    let filterParam = new HttpParams();
    if(name) {
      filterParam = filterParam.set('Name', name);
    }
    return this.httpClient.get<DeliveryModel>(`${environment.apiUrl}${DeliveryApiUrl.getDeliveries}`, {
      headers: this.basicHeaders,
      params: filterParam
    });
  }
}
