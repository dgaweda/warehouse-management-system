import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeliveryComponent } from './components/delivery/delivery.component';
import {LoginComponent} from "./components/login/login.component";
import {AuthGuard} from "./_auth/auth.guard";
import {OrderComponent} from "./components/order/order.component";


const routes: Routes = [
  {
    path: 'order',
    component: OrderComponent,
    canActivate: [AuthGuard]
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
