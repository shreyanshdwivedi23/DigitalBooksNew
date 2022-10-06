import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateBookComponent } from './create-book/create-book.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { SearchEditBookComponent } from './search-edit-book/search-edit-book.component';

const routes: Routes = [];

@NgModule({
  imports: [  RouterModule.forRoot([
    {path: 'home', component: HomeComponent},
    {path: '', component: HomeComponent},
    {path: 'login', component: LoginComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'addBook', component: CreateBookComponent},
    {path: 'searchBook', component: SearchEditBookComponent}
  ]),],
  exports: [RouterModule]
})
export class AppRoutingModule { }
