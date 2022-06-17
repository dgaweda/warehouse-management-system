import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {AddOrderRequest, EditOrderRequest, Order, OrderState, OrderStateColor} from "../_models/order.model";
import {BehaviorSubject, Observable} from "rxjs";
<<<<<<< Updated upstream:WMSWebApp/src/_main/_service/order.service.ts
import {ApiUrlService, OrderApiUrl} from "../_shared/apiUrl.service";
import { environment } from "src/environments/environment";
import {ResponseBody} from "../_shared/responseBody.model";
=======
import {ResponseBody} from "../shared/models/responseBody.model";
import {ApiService} from "../shared/service/api.service";
import {Config} from "../shared/models/config.model";
>>>>>>> Stashed changes:WMSWebApp/src/_main/service/order.service.ts

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private order$: BehaviorSubject<Order[]>;

  constructor(
    private httpClient: HttpClient,
    private apiService: ApiService,
    private config: Config
  ) {
    this.order$ = new BehaviorSubject<Order[]>([]);
  }

  getOrders(id?: number): Observable<ResponseBody<Order[]>> {
    const httpParam = this.apiService.createHttpParam('Id', id);
    return this.httpClient.get<ResponseBody<Order[]>>(`${this.config.baseApiUrl}${this.config.OrderApi.getOrders}`, { params: httpParam });
  }

  removeOrder(id: number): Observable<ResponseBody<Order>> {
    const httpParam = this.apiService.createHttpParam('Id', id);
    return this.httpClient.delete<ResponseBody<Order>>(`${this.config.baseApiUrl}${this.config.OrderApi.deleteOrder}`, { params : httpParam});
  }

  editOrder(body: EditOrderRequest): Observable<ResponseBody<Order>> {
    return this.httpClient.put<ResponseBody<Order>>(`${this.config.baseApiUrl}${this.config.OrderApi.editOrder}`, body);
  }

  addOrder(order: AddOrderRequest): Observable<ResponseBody<Order>> {
    return this.httpClient.post<ResponseBody<Order>>(`${this.config.baseApiUrl}${this.config.OrderApi.addOrder}`, order);
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
