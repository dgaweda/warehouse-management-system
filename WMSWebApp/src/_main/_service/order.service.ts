import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Order} from "../_models/order.model";
import {BehaviorSubject, Observable} from "rxjs";
import {ApiService, OrderApiUrl} from "../_shared/api.service";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  orders: BehaviorSubject<Order[]>;

  constructor(
    private httpClient: HttpClient,
    private apiService: ApiService
  ) {
    this.orders = new BehaviorSubject<Order[]>([]);
  }

  getOrders(id?: number): void {
    const httpParam = this.apiService.createHttpParam('Id', id);
    this.httpClient.get<Order[]>(`${environment.apiUrl}${OrderApiUrl.getOrders}`, { params: httpParam })
      .subscribe((response: Order[]) => {
        this.orders.next(response);
    })
  }
}
