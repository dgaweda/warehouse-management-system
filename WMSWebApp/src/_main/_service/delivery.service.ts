import { HttpClient, HttpHeaderResponse, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { DeliveryApiUrl } from "src/_main/api/apiUrl.service";
import { DeliveryModel } from "src/_main/_models/delivery.model";
import { Observable} from "rxjs";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class DeliveryService {

  constructor(
    private http: HttpClient){
  }

  getDeliveries(name?: string): Observable<DeliveryModel> {
    let filterParam = new HttpParams();
    if(name) {
      filterParam = filterParam.set('Name', name);
    }
    const url = `${environment.apiUrl}${DeliveryApiUrl.getDeliveries}`;
    return this.http.get<DeliveryModel>(url, {params: filterParam});
  }
}
