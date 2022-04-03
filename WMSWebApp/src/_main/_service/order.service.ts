import {Injectable} from "@angular/core";
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {Order} from "../_models/order.model";
import {Observable} from "rxjs";
import {AuthenticationService} from "../_auth/auth.service";
import {ApiService} from "../_shared/api.service";

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  constructor(
    private http: HttpClient,
    private authenticationService: AuthenticationService,
    private apiService: ApiService
  ) {
  }

  getOrders(id?: number): Observable<Order[]> {
    let params = new HttpParams();
    if (id) {
      params = params.set('Id', id);
    }
    return this.apiService.getOrders(params);
  }
}
