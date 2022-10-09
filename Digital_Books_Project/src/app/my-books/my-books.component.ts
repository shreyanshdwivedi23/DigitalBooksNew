import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { bookData } from '../models/bookData';
import { purchaseData } from '../models/purchaseData';
import { ReaderServiceService } from '../services/reader-service.service';

@Component({
  selector: 'app-my-books',
  templateUrl: './my-books.component.html',
  styleUrls: ['./my-books.component.css']
})
export class MyBooksComponent implements OnInit {

  constructor(private http:HttpClient,private _service:ReaderServiceService,private _router:Router) { }

  purchaseModel :purchaseData = new purchaseData();
  invoiceModel :purchaseData = new purchaseData();
  bookModel: bookData = new bookData();
  purchaseModels: Array<purchaseData> = new Array<purchaseData>();
  
  //purchaseModel: purchaseData= new purchaseData();
  ErrorMessage:any='';
  getMyBooks(){
    this._service.getMyBooks().subscribe(res=>this.Success(res)
    ,res=>
    {
      console.log(res);
      this.ErrorMessage="Some error have occured";
      document.getElementById('btnErrorMsg')?.click();
    });
  }

  Success(response:any){
    //debugger;
    console.log("my books -->");
    console.log(response);
    this.purchaseModels = response;
    console.log("purchase model");
    console.log(this.purchaseModels);
  }

  refund(obj:any){
    this._service.refundBook(obj).subscribe(res=>{

    }
    ,res=>
    {
      console.log(res);
      this.ErrorMessage="Some error have occured";
      document.getElementById('btnErrorMsg')?.click();
    });
  }

  invoice(obj:any){
    debugger;
    document.getElementById('invoiceModelId')?.click();
    this.invoiceModel = obj;
  }

  ngOnInit(): void {
    this.getMyBooks();
  }

}
