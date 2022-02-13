import { Component, OnInit } from '@angular/core';
import { DeliveryModel } from 'src/models/delivery.model';
import { DeliveryService} from 'src/service/delivery.service';

@Component({
  selector: 'app-delivery-component',
  templateUrl: './delivery-component.component.html',
  styleUrls: ['./delivery-component.component.scss']
})
export class DeliveryComponent implements OnInit {
  deliveryService: DeliveryService;

  deliveries: DeliveryModel[];

  constructor(private DeliveryService: DeliveryService) {
    this.deliveryService = DeliveryService;
    this.deliveries = [];
   }

  ngOnInit() {
    this.getDeliveries('');
  }

  getDeliveries(name: string): void {
    console.log(`Name: ${name}`);
    console.log(`getDeliveries: ${this.deliveryService.getDeliveries(name)}`, this.deliveryService.getDeliveries(name));
    this.deliveryService.getDeliveries(name).subscribe(data => {
      console.log(`Data: ${data}`, data)
      this.deliveries.push(data);
    });
    console.log(`DeliveriesArray: ${this.deliveries}`, this.deliveries);
  }

}
