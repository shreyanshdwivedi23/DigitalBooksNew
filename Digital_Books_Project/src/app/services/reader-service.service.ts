import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ReaderServiceService {

  _viewBookDetailsUrl="https://localhost:44374/api/Reader/viewBookDetails/";
  _buyBookUrl = "https://localhost:44374/api/Reader/buyBook?id=";
  _getMyBooksUrl = "https://localhost:44374/api/Reader/getMyBooks?id=";
  userId = 0;
  constructor(private http:HttpClient) { }

  viewBookDetails(id:any)
  {

    return this.http.get<any>(this._viewBookDetailsUrl, {params:new HttpParams().append("id",id)});
  }

  BuyBook(id:any)
  {
    this.userId = Number(localStorage.getItem('userId'));
    return this.http.post<any>(this._buyBookUrl, id);
  }

  getMyBooks(id:any)
  {

    return this.http.get<any>(this._getMyBooksUrl, {params:new HttpParams().append("id",id)});
  }
  getToken(){
    return localStorage.getItem('token');
  }
}
