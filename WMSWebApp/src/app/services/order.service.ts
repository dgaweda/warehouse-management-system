import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {AddOrderRequest, EditOrderRequest, Order, OrderState, OrderStateColor} from "../models/order.model";
import {BehaviorSubject, Observable} from "rxjs";
import {ResponseBody} from "../common/models/responseBody.model";
import {Config} from "../common/models/config.model";
import {ApiService} from "../common/service/api.service";
import {BaseService} from "./base.service";

@Injectable({
  providedIn: 'root'
})
export class OrderService extends BaseService {
  private order$: BehaviorSubject<Order[]>;

  constructor(
    private http: HttpClient,
    private apiService: ApiService,
    private config: Config
  ) {
    super(http, config);
    this.order$ = new BehaviorSubject<Order[]>([]);
  }

  getOrders(id?: number): Observable<ResponseBody<Order[]>> {
    const httpParam = this.apiService.createHttpParams([{key: 'Id',value: id}]);
    return this.get<ResponseBody<Order[]>>(this.config.OrderApi.getOrders, httpParam);
  }

  removeOrder(id: number): Observable<ResponseBody<Order>> {
    const httpParams = this.apiService.createHttpParams([{key: 'Id',value: id}]);
    return this.delete<ResponseBody<Order>>(this.config.OrderApi.deleteOrder, httpParams);
  }

  editOrder(body: EditOrderRequest): Observable<ResponseBody<Order>> {
    return this.put<ResponseBody<Order>>(this.config.OrderApi.editOrder, body);
  }

  addOrder(order: AddOrderRequest): Observable<ResponseBody<Order>> {
    return this.post<ResponseBody<Order>>(this.config.OrderApi.addOrder, order);
  }

  getOrderStateValue(state: string): string {
    return OrderState[state as keyof typeof OrderState];
  }

  getOrderRowStatusColor(state: string): string {
    return OrderStateColor[state as keyof typeof OrderStateColor]
  }

  getOrderStateKeyByValue(value: string): string {
    return Object.entries(OrderState).find(([key, val]) => val === value)?.[0] ?? '';
  }
}
