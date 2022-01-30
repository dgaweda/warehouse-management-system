import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { MainComponent } from './main/main.component';
import { FooterComponent } from './footer/footer.component';
import { BreadcrumbComponent } from './main/breadcrumb/breadcrumb.component';
import { LoginPanelComponent } from './main/login-panel/login-panel.component';

@NgModule({
  declarations: [		
    AppComponent,
    HeaderComponent,
    MainComponent,
    FooterComponent,
    BreadcrumbComponent,
    LoginPanelComponent
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
