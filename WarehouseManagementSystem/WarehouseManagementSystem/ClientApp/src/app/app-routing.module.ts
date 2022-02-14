import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeliveryComponent } from './components/main/delivery-component/delivery-component.component';
import { OrderListComponent } from './components/main/order-list/order-list.component';

const routes: Routes = [
  { 
    path: 'delivery', 
    component: DeliveryComponent
  },
  {
    path: 'orders',
    component: OrderListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
