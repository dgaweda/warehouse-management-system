import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Order, OrderState, OrderStateColor} from "../_models/order.model";
import {BehaviorSubject, Observable} from "rxjs";
import {ApiUrlService, OrderApiUrl} from "../_shared/apiUrl.service";
import { environment } from "src/environments/environment";
import {ResponseBody} from "../_shared/responseBody.model";

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(
    private httpClient: HttpClient,
    private apiUrlService: ApiUrlService
  ) {}

  getOrders(id?: number): Observable<ResponseBody<Order[]>> {
    const httpParam = this.apiUrlService.createHttpParam('Id', id);
    return this.httpClient.get<ResponseBody<Order[]>>(`${environment.apiUrl}${OrderApiUrl.getOrders}`, { params: httpParam });
  }

  getReadableOrderStatus(state: string): string {
    return OrderState[state as keyof typeof OrderState];
  }

  getOrderRowStatusColor(state: string): string {
    return OrderStateColor[state as keyof typeof OrderStateColor]
  }

  getOrderStateKeyByValue(value: string): string {
    return Object.entries(OrderState).find(([key, val]) => val === value)?.[0] ?? '';
  }
}
