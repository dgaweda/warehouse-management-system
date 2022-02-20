import { Component, OnInit } from '@angular/core';
import { DeliveryModel } from 'src/_main/_models/delivery.model';
import { DeliveryService} from 'src/_main/_service/delivery.service';

@Component({
  selector: 'app-delivery',
  templateUrl: './delivery.component.html',
  styleUrls: ['./delivery.component.scss']
})
export class DeliveryComponent implements OnInit {
  deliveryService: DeliveryService;

  deliveries: DeliveryModel[];

  constructor(private DeliveryService: DeliveryService) {
    this.deliveryService = DeliveryService;
    this.deliveries = [];
   }

  ngOnInit() {
  }

  getDeliveries(name?: string): void {
    this.deliveryService.getDeliveries(name).subscribe((deliveries: any) => {
      this.deliveries = deliveries['data'];
    });
  }
}
