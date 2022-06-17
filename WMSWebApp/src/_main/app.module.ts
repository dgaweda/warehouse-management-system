import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/layout/header/header.component';
import { FooterComponent } from './components/layout/footer/footer.component';
import { LoginComponent } from './components/login/login.component';
import { DeliveryComponent } from './components/delivery/delivery.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { UserDetailsComponent } from "./components/user/details/user.details.component";
import { MainComponent } from "./components/layout/main/main.component";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { OrderComponent } from './components/order/order.component';
<<<<<<< Updated upstream
import {BasicAuthInterceptor} from "./_auth/auth.interceptor";
import { ErrorInterceptor } from './_auth/error.interceptor';
=======
import {BasicAuthInterceptor} from "./auth/auth.interceptor";
import { ErrorInterceptor } from './auth/error.interceptor';
import { HomeComponent } from './components/home/home.component';
import {Config} from "./shared/models/config.model";
import {environment} from "../environments/environment";
>>>>>>> Stashed changes

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MainComponent,
    FooterComponent,
    LoginComponent,
    UserDetailsComponent,
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
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: Config, useValue: environment}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
