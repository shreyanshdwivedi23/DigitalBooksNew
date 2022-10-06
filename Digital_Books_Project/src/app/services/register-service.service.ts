import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RegisterServiceService {
  _registerUrl="https://localhost:44396/api/Login/register-user";
  constructor(private http:HttpClient) { }

  registerUser(login:any){
    console.log("login model -->", login)
    return this.http.post<any>(this._registerUrl,login);
  }
  getToken(){
    return localStorage.getItem('token');
  }
}
