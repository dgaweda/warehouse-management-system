import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app.component';
import { HeaderComponent } from './components/header/header.component';
import { MainComponent } from './components/main/main.component';
import { FooterComponent } from './components/footer/footer.component';
import { LoginPanelComponent } from './components/main/login/login-panel.component';
import { OrderListComponent } from './components/main/order-list/order-list.component';
import { UserDetailsComponent } from './components/main/user-details/user-details.component';
import { UserOptionsComponent } from './components/header/user-options/user-options.component';
import { DeliveryComponent } from './components/main/delivery-component/delivery-component.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [		
    AppComponent,
    HeaderComponent,
    MainComponent,
    FooterComponent,
    LoginPanelComponent,
    OrderListComponent,
    UserDetailsComponent,
    UserOptionsComponent,
    DeliveryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
