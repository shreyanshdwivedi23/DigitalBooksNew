import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ReaderServiceService {

  //gatewayUrl = "https://localhost:44322/api/gateway/";
  _viewBookDetailsUrl="https://localhost:44322/api/gateway/Reader/viewBookDetails";
  _buyBookUrl ="https://localhost:44322/api/gateway/Reader/buyBook?id=";
  _getMyBooksUrl = "https://localhost:44322/api/gateway/Reader/getMyBooks";
  _refundBooksUrl = "https://localhost:44322/api/gateway/Reader/refundBook?";
  _readerSearchAllBooksUrl = "https://localhost:44322/api/gateway/Reader/readerSearchAllBooks?"
  userId = 0;
  constructor(private http:HttpClient) { }


  viewBookDetails(id:any)
  {

    return this.http.get<any>(this._viewBookDetailsUrl, {params:new HttpParams().append("id",id)});
  }

  BuyBook(purchaseObj:any)
  {
    debugger;
    console.log("purchase");
    console.log(purchaseObj);
    //this.userId = Number(localStorage.getItem('userId'));
    return this.http.post<any>(this._buyBookUrl, purchaseObj);
  }

  getMyBooks()
  {
    debugger;
    
    this.userId = Number(localStorage.getItem('userId'));
    //obj.loginObj.userId = this.userId;
    //console.log("mybooks");
    //console.log(obj);
    return this.http.get<any>(this._getMyBooksUrl, {params:new HttpParams().append("id",this.userId)});
  }

  refundBook(obj:any){
    console.log( obj)
    return this.http.post<any>(this._refundBooksUrl, {params:new HttpParams().append("obj",obj)});
  }
  
  getToken(){
    return localStorage.getItem('token');
  }

  readerSearchAllBooksUrl(book:any){
    //console.log("login model -->", book)
    return this.http.post<any>(this._readerSearchAllBooksUrl, book);
  }
}
