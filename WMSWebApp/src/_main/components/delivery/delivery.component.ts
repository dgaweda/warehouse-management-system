import {HttpErrorResponse, HttpResponseBase } from '@angular/common/http';
import {Component, OnInit, ViewChild} from '@angular/core';
import { Router } from '@angular/router';
import { NgbAlert } from '@ng-bootstrap/ng-bootstrap';
import {Delivery} from 'src/_main/models/delivery.model';
import {DeliveryService} from 'src/_main/service/delivery.service';
import {ResponseBody} from "../../shared/models/responseBody.model";

@Component({
  selector: 'app-delivery',
  templateUrl: './delivery.component.html',
  styleUrls: ['./delivery.component.scss']
})
export class DeliveryComponent implements OnInit {
  deliveries: ResponseBody<Delivery[]>;

  constructor(private deliveryService: DeliveryService, private router: Router) {
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
        (error: HttpErrorResponse) => {
          this.deliveries.error = error.error.errors.Name;
        }
      )
  }
}
