import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { bookData } from '../models/bookData';
//import { purchaseData } from '../models/purchaseData';
import { ReaderServiceService } from '../services/reader-service.service';

@Component({
  selector: 'app-my-books',
  templateUrl: './my-books.component.html',
  styleUrls: ['./my-books.component.css']
})
export class MyBooksComponent implements OnInit {

  constructor(private http:HttpClient,private _service:ReaderServiceService,private _router:Router,) { }
  bookModel: bookData = new bookData();
  bookModels: Array<bookData> = new Array<bookData>();
  //purchaseModel: purchaseData= new purchaseData();
  ErrorMessage:any='';
  getMyBooks(){
    this._service.getMyBooks(this.bookModel).subscribe(res=>this.Success(res)
    ,res=>
    {
      console.log(res);
      this.ErrorMessage="Some error have occured";
      document.getElementById('btnErrorMsg')?.click();
    });
  }

  Success(respnse:any){
    //debugger;
    console.log("search -->");
    console.log(respnse);
    this.bookModels = respnse;
  }

  refund(){

  }

  invoice(){

  }

  ngOnInit(): void {
    this.getMyBooks();
  }

}
