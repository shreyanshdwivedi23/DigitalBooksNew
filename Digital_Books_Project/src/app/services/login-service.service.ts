import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {

  _loginUrl="https://localhost:44396/api/login/login-user";
  usertype:string='';
  
  constructor(private http:HttpClient, private _router:Router) { }

  loginUser(login:any){
    return this.http.post<any>(this._loginUrl,login);
  }
  logginIn(){
    return !!localStorage.getItem('token');
  }

  IsAuhtor(){
    if(localStorage.getItem('userType') == "Author"){
      return true;
    }else{
      return false;
    }
  }

  logoutUser(){
    localStorage.removeItem('token');
    localStorage.removeItem('userFullname');
    localStorage.removeItem('userType');
    window.location.href="";
    this._router.navigate(['']);
  }


  getToken(){
    return localStorage.getItem('token');
  }
}
