import { Component, OnInit, ViewChild } from '@angular/core';
import {Order, OrderStateColor} from "../../_models/order.model";
import {OrderService} from "../../_service/order.service";
import { OrderState} from "../../_models/order.model";
import {ResponseBody} from "../../_shared/responseBody.model";
import { HttpErrorResponse } from '@angular/common/http';

export enum Headers {
  Lp = 'Lp.',
  OrderState = 'Stan zamówienia',
  Barcode = 'Kod kreskowy',
  LinesCount = 'Ilość linii'
}

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {
  headers: string[];
  orders: ResponseBody<Order[]>;
  isReceived: boolean;
  orderQueue: Order[];
  OrderState = OrderState;


  constructor(
    public orderService: OrderService
  ) {
    this.orders = {data: []};
    this.orderQueue = [];
    this.isReceived = false;
  }

  ngOnInit(): void {
    this.getOrders();
    this.headers = [
      Headers.Lp,
      Headers.Barcode,
      Headers.OrderState,
      Headers.LinesCount
    ];
  }

  getOrders(id?: number): void {
    this.orderService.getOrders(id)
      .subscribe(
        (orders: ResponseBody<Order[]>) => {
          this.orders = orders;
          this.orders.data.forEach((order: Order) => order.readableOrderState = this.orderService.getReadableOrderStatus(order.orderState))
        },
        (error: HttpErrorResponse) => {
          this.orders.error = error.error.errors.Name
        }
      );
  }

  addOrderToQueue(order: Order, orderRow: HTMLElement): void {
    this.setOrderStatus(OrderState.IN_PROGRESS, order, orderRow);
    this.orderQueue.push(order);
  }

  setOrderStatus(status: string, order: Order, orderRow: HTMLElement): void {
    const orderStateKey = this.orderService.getOrderStateKeyByValue(status);
    order.orderState = orderStateKey;
    order.readableOrderState = status;
    orderRow.style.background = this.orderService.getOrderRowStatusColor(orderStateKey);
  }
}
