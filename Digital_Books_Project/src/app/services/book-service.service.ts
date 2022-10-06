import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BookServiceService {

  _createBookUrl="https://localhost:44396/api/Books/addBook";
  _editBookUrl="https://localhost:44396/api/Books/editBook";
  _deleteBookUrl="https://localhost:44396/api/Books/deleteBook";
  _searchBookUrl="https://localhost:44396/api/Books/searchBook";
  _getAllBookUrl="https://localhost:44396/api/Books/getAllBooks";
  _FileUploadUrl="https://localhost:44396/api/Books/Upload";
  _BookDeleteUrl="https://localhost:44396/api/Books/deleteBooks?id=";
  _searchAllBooksUrl="https://localhost:44396/api/Books/searchAllBooks";
  constructor(private http:HttpClient) { }

  Bookdelete(id:any)
  {
    console.log(id);
    return this.http.delete<any>(this._BookDeleteUrl+id);
  }

  Upload(file:FormData)
  {
    return this.http.post<any>(this._FileUploadUrl,file);
  }

  createBook(book:any){
    console.log("login model -->", book)
    return this.http.post<any>(this._createBookUrl,book);
  }

  // for book search
  getBook(book:any){
    console.log("login model -->", book)
    return this.http.get<any>(this._getAllBookUrl);
  }

  // for book edit
  editBook(book:any){
    console.log("login model -->", book)
    return this.http.put<any>(this._editBookUrl,book);
  }  

  // for book delete
  deleteBook(book:any){
    console.log("login model -->", book)
    return this.http.post<any>(this._deleteBookUrl,book);
  } 

  SearchAllBooks(book:any){
    console.log("login model -->", book)
    return this.http.post<any>(this._searchAllBooksUrl, book);
  }
  
  getToken(){
    return localStorage.getItem('token');
  }
}
