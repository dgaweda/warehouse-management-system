import {Component, OnInit, Renderer2, RendererFactory2} from '@angular/core';
import { Delivery } from 'src/_main/_models/delivery.model';
import { DeliveryService} from 'src/_main/_service/delivery.service';
import panzoom from "panzoom";
import {Renderer} from "@angular/compiler-cli/ngcc/src/rendering/renderer";

@Component({
  selector: 'app-delivery',
  templateUrl: './delivery.component.html',
  styleUrls: ['./delivery.component.scss']
})
export class DeliveryComponent {
  degrees: number;
  renderer: Renderer2;
  deliveries: Delivery[];

  constructor(
    private deliveryService: DeliveryService,
    private rendererFactory: RendererFactory2
  ) {
    this.renderer = rendererFactory.createRenderer(null, null);
    this.degrees = 0;
    this.deliveries = this.getDeliveries();
   }

  getDeliveries(name?: string): Delivery[] {
    return this.deliveryService.getDeliveries(name);
  }

  initImage(image: HTMLImageElement): void {
    panzoom(image, {
      bounds: true,
      maxZoom: 3,
      minZoom: 0.5,
      boundsPadding: 0.3,
      smoothScroll: true,
      pinchSpeed: 1,
      zoomSpeed: 0.05,
      transformOrigin: {x: 0.5, y: 0.5},

    });
  }

  rotateImage(image: HTMLImageElement):void {
    this.degrees += 90;
    this.renderer.setStyle(
      image,
      'transform',
      `rotate(${this.degrees}})deg`
    );
  }
}
