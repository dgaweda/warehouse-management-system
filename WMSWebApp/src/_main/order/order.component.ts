import { Component, OnInit } from '@angular/core';
import {Order} from "../_models/order.model";
import {OrderService} from "../_service/order.service";
import { OrderState} from "../_models/order.model";

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

  constructor(
    private orderService: OrderService) {
    this.headers = [
      Headers.Lp,
      Headers.Barcode,
      Headers.OrderState,
      Headers.LinesCount
    ];
    this.orders = [];

    this.orderService.orders.subscribe((order: any) => {
      this.orders = order.data;
    })
  }

  setStatus(state: string): string {
    return OrderState[state as keyof typeof OrderState];
  }

  ngOnInit(): void {
    this.orderService.getOrders();
  }
}
