import {HttpErrorResponse, HttpResponseBase } from '@angular/common/http';
import {Component, OnInit, ViewChild} from '@angular/core';
import { NgbAlert } from '@ng-bootstrap/ng-bootstrap';
import {Delivery} from 'src/_main/_models/delivery.model';
import {DeliveryService} from 'src/_main/_service/delivery.service';
import {ResponseBody} from "../../_shared/responseBody.model";

@Component({
  selector: 'app-delivery',
  templateUrl: './delivery.component.html',
  styleUrls: ['./delivery.component.scss']
})
export class DeliveryComponent implements OnInit {
  deliveries: ResponseBody<Delivery[]>;

  constructor(private deliveryService: DeliveryService) {
    this.deliveries = {};
  }

  ngOnInit(): void {
    this.getDeliveries();
  }

  getDeliveries(name?: string): void {
    this.deliveryService.getDeliveries(name)
      .subscribe(
        (delivery: ResponseBody<Delivery[]>) => {
        console.log(delivery.error);
        this.deliveries = delivery;
      },
        (error: HttpErrorResponse) => {
          this.deliveries.error = error.error.errors.Name;
        }
      )
  }
}
