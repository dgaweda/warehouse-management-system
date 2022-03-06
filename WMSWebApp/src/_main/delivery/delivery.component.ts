import { Component, OnInit } from '@angular/core';
import { DeliveryModel } from 'src/_main/_models/delivery.model';
import { DeliveryService} from 'src/_main/_service/delivery.service';
import {SharedService} from "../_service/shared.service";

@Component({
  selector: 'app-delivery',
  templateUrl: './delivery.component.html',
  styleUrls: ['./delivery.component.scss']
})
export class DeliveryComponent {
  deliveries: DeliveryModel[];

  constructor(
    private deliveryService: DeliveryService) {
    this.deliveries = [];
   }

  getDeliveries(name?: string): void {
    this.deliveryService.getDeliveries(name).subscribe((deliveries: any) => {
      this.deliveries = deliveries['data'];
    });
  }
}
