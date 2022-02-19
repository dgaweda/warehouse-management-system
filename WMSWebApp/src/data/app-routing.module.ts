import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeliveryComponent } from './delivery/delivery.component';
import {LoginComponent} from "./login/login.component";

const routes: Routes = [
  {
    path: 'delivery',
    component: DeliveryComponent
  },
  {
    path: 'login',
    component: LoginComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
