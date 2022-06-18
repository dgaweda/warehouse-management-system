import {HttpErrorResponse, HttpResponseBase } from '@angular/common/http';
import {Component, OnInit, ViewChild} from '@angular/core';
import { Router } from '@angular/router';
import {DeliveryService} from 'src/main/service/delivery.service';
import {ResponseBody} from "../../shared/models/responseBody.model";
import {Delivery} from "../../models/delivery.model";

@Component({
  selector: 'app-delivery',
  templateUrl: './delivery.component.html',
  styleUrls: ['./delivery.component.scss']
})
export class DeliveryComponent implements OnInit {
  deliveries: ResponseBody<Delivery[]>;

  constructor(private deliveryService: DeliveryService) {
    this.deliveries = {data: []};
  }

  ngOnInit(): void {
    this.getDeliveries();
  }

  getDeliveries(name?: string): void {
    this.deliveryService.getDeliveries(name)
      .subscribe(
        (delivery: ResponseBody<Delivery[]>) => {
        this.deliveries = delivery;
      },
        (response: HttpErrorResponse) => {
          this.deliveries.error = response.error.errors.Name;
        }
      )
  }
}
