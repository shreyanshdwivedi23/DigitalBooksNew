import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { bookData } from '../models/bookData';
import { BookServiceService } from '../services/book-service.service';
import { Component,EventEmitter, Input, OnInit, Output } from '@angular/core';
import { LoginServiceService } from '../services/login-service.service';

@Component({
  selector: 'app-readersearch',
  templateUrl: './readersearch.component.html',
  styleUrls: ['./readersearch.component.css']
})
export class ReadersearchComponent implements OnInit {

  constructor(private http:HttpClient,private _service:BookServiceService,private _router:Router,private _loginservice:LoginServiceService) { }
  bookModel: bookData = new bookData();
  bookModels: Array<bookData> = new Array<bookData>();
  ErrorMessage:any='';
  isEdit:boolean=false;
  Success(input:any){
    //debugger;
    console.log("search -->");
    console.log(input);
    this.bookModels = input;
  }

  searchBook(){
    this._service.SearchAllBooks(this.bookModel).subscribe(res=>this.Success(res)
    ,res=>
    {
      console.log(res);
      this.ErrorMessage="Some error have occured";
      document.getElementById('btnErrorMsg')?.click();
    });
  }


  viewBookDetails(bookId:any){

    if (this._loginservice.logginIn()){
      debugger;
      console.log("book id ->" + bookId);
      console.log(btoa(bookId));
      this._router.navigate(['bookDetails', btoa(bookId)]);
      //this._service.Bookdelete(bookId).subscribe(res=>this.PostSuccess(res),res=>console.log(res));
    }
    else{
      alert("Please sign up to proceed.!");
      this._router.navigate(['register']);
    }

    
  }

  
  PostSuccess(input:any)
  {
    //this.searchBook();
  }

  IsAuthor(Input:boolean):boolean{
    if(Input){
      return this._loginservice.IsAuthor();
    }
    else{
      return !this._loginservice.IsAuthor();
    }
  }
  
  ngOnInit(): void {
    //debugger;
    this.searchBook();
  }

}
