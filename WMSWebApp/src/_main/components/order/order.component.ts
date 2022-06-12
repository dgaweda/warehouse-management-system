import { Component, OnInit, ViewChild } from '@angular/core';
import {Order, OrderStateColor} from "../../models/order.model";
import {OrderService} from "../../service/order.service";
import { OrderState} from "../../models/order.model";
import {ResponseBody} from "../../shared/responseBody.model";
import { HttpErrorResponse } from '@angular/common/http';
import {UserService} from "../../service/user.service";
import {AuthenticationService} from "../../auth/auth.service";
import {Roles} from "../../models/role.model";

export enum Headers {
  Lp = 'Lp.',
  OrderState = 'Stan zamówienia',
  Barcode = 'Numer zamówienia',
  LinesCount = 'Ilość linii'
}

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {
  OrderState = OrderState;

  headers: string[];

  orders: ResponseBody<Order[]>;
  orderQueue: Order[];

  isReceived: boolean;
  isAdmin: boolean;

  constructor(
    public orderService: OrderService,
    private authService: AuthenticationService
  ) {
    this.orders = {data: []};
    this.orderQueue = [];
    this.isReceived = false;
    this.isAdmin = this.authService.currentUser.roleKey === Roles.ADMIN;
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
          this.orders.data.forEach((order: Order) => order.readableOrderState = this.orderService.getOrderStateValue(order.orderState))
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
