import { Component, OnInit } from '@angular/core';
import {Order, OrderStateColor} from "../../_models/order.model";
import {OrderService} from "../../_service/order.service";
import { OrderState} from "../../_models/order.model";

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
  orders: Order[];
  isReceived: boolean;
  orderQueue: Order[];


  constructor(
    private orderService: OrderService) {
    this.headers = [
      Headers.Lp,
      Headers.Barcode,
      Headers.OrderState,
      Headers.LinesCount
    ];
    this.orders = [];
    this.orderQueue = [];
    this.isReceived = false;
  }

  ngOnInit(): void {
    this.orderService.orders.subscribe((order: any) => {
      this.orders = order.data;
    })

    this.orderService.getOrders();
  }

  setStatus(state: string, orderRow: HTMLElement): string {
    orderRow.style.background = OrderStateColor[state as keyof typeof OrderStateColor];
    const translatedState = OrderState[state as keyof typeof OrderState];
    this.isReceived = OrderState.RECEIVED === translatedState;
    return translatedState;
  }

  addOrderToQueue(order: Order): void {
    console.log(order);
    this.orderQueue.push(order);
    console.log(this.orderQueue);
  }
}
