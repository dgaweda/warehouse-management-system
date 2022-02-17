import { Component, OnInit } from '@angular/core';
import { DeliveryModel } from 'src/app/models/delivery.model';
import { DeliveryService} from 'src/app/service/delivery.service';

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
    this.deliveryService.getDeliveries(name).subscribe(
      (data: DeliveryModel[]) =>
          
    );
    console.log(`${this.deliveries} Length ${this.deliveries.length}`, this.deliveries);
  }

}
