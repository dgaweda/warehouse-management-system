import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from '../layout/header/header.component';
import { FooterComponent } from '../layout/footer/footer.component';
import { LoginComponent } from './login/login.component';
import { DeliveryComponent } from './delivery/delivery.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { UserDetailsComponent } from "./user/details/user.details.component";
import { NavbuttonComponent } from "../layout/header/navbutton/navbutton.component";
import { MainComponent } from "../layout/main/main.component";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { OrderComponent } from './order/order.component';
import {BasicAuthInterceptor} from "./_auth/auth.interceptor";
import { ErrorInterceptor } from './_auth/error.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MainComponent,
    FooterComponent,
    LoginComponent,
    UserDetailsComponent,
    NavbuttonComponent,
    DeliveryComponent,
    OrderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: BasicAuthInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
