import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LoginServiceService } from './services/login-service.service';
import { RegisterComponent } from './register/register.component';
import { CreateBookComponent } from './create-book/create-book.component';
import { SearchEditBookComponent } from './search-edit-book/search-edit-book.component';
import { DatePipe } from '@angular/common';
import { ReadersearchComponent } from './readersearch/readersearch.component';
import { AuthguardService } from './services/authguard.service';
import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';
import { ViewbookdetailsComponent } from './viewbookdetails/viewbookdetails.component';
import { MyBooksComponent } from './my-books/my-books.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    LoginComponent,
    RegisterComponent,
    CreateBookComponent,
    SearchEditBookComponent,
    ReadersearchComponent,
    ViewbookdetailsComponent,
    MyBooksComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  
  ],
  providers: [LoginServiceService, DatePipe, AuthguardService,{provide:JWT_OPTIONS,useValue:JWT_OPTIONS},JwtHelperService],
  bootstrap: [AppComponent]
})
export class AppModule { }
