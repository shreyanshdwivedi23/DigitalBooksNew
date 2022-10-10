import { HttpClient } from '@angular/common/http';
//import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { bookData } from '../models/bookData';
import { BookServiceService } from '../services/book-service.service';
import { Component,EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-search-edit-book',
  templateUrl: './search-edit-book.component.html',
  styleUrls: ['./search-edit-book.component.css']
})
export class SearchEditBookComponent implements OnInit {

  constructor(private http:HttpClient,private _service:BookServiceService,private _router:Router) { }
  bookModel: bookData = new bookData();
  bookModels: Array<bookData> = new Array<bookData>();
  ErrorMessage:any='';
  isEdit:boolean=false;
  Success(input:any){
    debugger;
    console.log("search -->");
    console.log(input);
    this.bookModels = input;
  }

  searchBook(){
    debugger;
    if (Number(localStorage.getItem('userId')) != null) {
      this.bookModel.bookCreatedBy = Number(localStorage.getItem('userId'));
    }
    this._service.SearchAllBooks(this.bookModel).subscribe(res=>this.Success(res)
    ,res=>
    {
      console.log(res);
      this.ErrorMessage="Some error have occured";
      document.getElementById('btnErrorMsg')?.click();
    });
  }


  deleteBook(bookId:any){
    this._service.Bookdelete(bookId).subscribe(res=>this.PostSuccess(res),res=>console.log(res));
  }

  @Output() onEditBook:EventEmitter<any>=new EventEmitter<any>(); 
  editBook(input:any)
  {
    //this.isEdit=true;
    debugger;
    this.bookModel = input;
    console.log('input search-->' + this.bookModel);
    this.onEditBook.emit(this.bookModel);
    this._router.navigate(['addBook']);
    //document.getElementById("AddBookDet")?.click();
  }
  PostSuccess(input:any)
  {
    //this.searchBook();
  }
  
  ngOnInit(): void {
    debugger;
    this.searchBook();
  }

}
