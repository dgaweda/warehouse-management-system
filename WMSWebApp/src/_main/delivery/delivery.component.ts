import {Component, OnInit} from '@angular/core';
import { Delivery } from 'src/_main/_models/delivery.model';
import { DeliveryService} from 'src/_main/_service/delivery.service';
import panzoom, {PanZoom} from "panzoom";
import { HttpParams } from '@angular/common/http';
import {ApiService} from "../_shared/api.service";

@Component({
  selector: 'app-delivery',
  templateUrl: './delivery.component.html',
  styleUrls: ['./delivery.component.scss']
})
export class DeliveryComponent {
  deliveries: Delivery[];

  constructor(
    public deliveryService: DeliveryService,
  ) {
    this.deliveries = [];

    deliveryService.deliveries.subscribe((delivery: any) => {
      this.deliveries = delivery.data;
      console.log(`deliveries:`, this.deliveries);
    });
   }
}
