import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeliveryComponent } from './delivery/delivery.component';
import {LoginComponent} from "./login/login.component";
import {MainComponent} from "./layout/main/main.component";
import {AuthGuard} from "./_service/_auth/auth.guard";
import {OrderComponent} from "./order/order.component";


const routes: Routes = [
  {
    path: 'order',
    component: OrderComponent
  },
  {
    path: 'delivery',
    component: DeliveryComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'login',
    component: LoginComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
