import { Component, OnInit } from '@angular/core';
import {Order} from "../_models/order.model";
import {OrderService} from "../_service/order.service";

export enum Headers {
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
  lp: number;
  headers: string[];
  orders: Order[];
  constructor(private orderService: OrderService) {
    this.headers = [
      Headers.OrderState,
      Headers.Barcode,
      Headers.LinesCount
    ];
    this.orders = [];
    this.lp = 1;
  }

  ngOnInit() {
    this.getOrders();
  }

  getOrders(id?: number): void {
    this.orderService.getOrders(id)
      .subscribe((order: Order[]) => {
        this.orders = order;
      });
  }
}
