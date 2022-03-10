import {Injectable} from "@angular/core";
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {Order} from "../_models/order.model";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import {AuthenticationService} from "./_auth/auth.service";
import {orderApiUrl} from "../_api/api.service";

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  orders: Order[];
  constructor(private http: HttpClient, private authenticationService: AuthenticationService) {
    this.orders = [];
  }

  getOrders(id?: number): Observable<Order[]> {
    let params = new HttpParams();
    if(id){
      params = params.set('Id', id);
    }
    const user = this.authenticationService.currentUser;
    const url = environment.apiUrl + orderApiUrl.getOrders;
    return this.http.get<Order[]>(url, {params: params});
  }
}
