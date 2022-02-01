import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { MainComponent } from './main/main.component';
import { FooterComponent } from './footer/footer.component';
import { LoginPanelComponent } from './main/login/login-panel.component';
import { OrderListComponent } from './main/order-list/order-list.component';
import { UserDetailsComponent } from './main/user-details/user-details.component';
import { UserOptionsComponent } from './header/user-options/user-options.component';

@NgModule({
  declarations: [		
    AppComponent,
    HeaderComponent,
    MainComponent,
    FooterComponent,
    LoginPanelComponent,
    OrderListComponent,
    UserDetailsComponent,
    UserOptionsComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
