import { HttpClient } from '@angular/common/http';
import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { bookData } from '../models/bookData';
import { BookServiceService } from '../services/book-service.service';
import { DatePipe } from '@angular/common'



@Component({
  selector: 'app-create-book',
  templateUrl: './create-book.component.html',
  styleUrls: ['./create-book.component.css']
})
export class CreateBookComponent implements OnInit {

  constructor(private _service:BookServiceService, private _router:Router, private http:HttpClient,public datepipe: DatePipe ) {}

  bookmodel:bookData = new bookData();
  
  _ImgPath:string='';
  isEdit:boolean=false;
  _ImgName:string='';
  uploadFile(files:any){
    if(files.length==0){
      return ;
    }

    let fileToUpload=<File>files[0];
    const formData=new FormData();
    this._ImgName = fileToUpload.name;
    formData.append('file',fileToUpload,fileToUpload.name);
    this._service.Upload(formData).subscribe(res=>{

      console.log(res);

      this._ImgPath=res.imgPath;

    },res=>console.log(res));

    
  }


  ngOnInit(): void {
  }
  ErrorMessage:any='';
  PostSuccess(input:any)
  {
    //this._router.navigate(['searchBook']);
  }

  //@Output("app-search-edit-book")
  editBook(input:any)
  {
    debugger;
    console.log("add page -->" + input);
    this.isEdit=true;
    let releashed_date =this.datepipe.transform(input.bookReleasedDate, 'yyyy-MM-dd')?.toString();
    this.bookmodel = input;
    this.bookmodel.bookReleasedDate = releashed_date;
    document.getElementById("addBookModelId")?.click();
  }

  // for book create
  saveBook(){
    if(this.bookmodel.bookTitle=="")
    {
      alert("Please enter Book Title");
      return;
    }

    if(this.bookmodel.bookCategory=="")
    {
      alert("Please enter Book Category");
      return;
    }
    if(this.bookmodel.bookPrice=="")
    {
      alert("Please enter Book Price");
      return;
    }
    if(this.bookmodel.bookPublisher=="")
    {
      alert("Please enter Book Publishers.");
      return;
    }
    if(this._ImgPath=="" && this.isEdit==false)
    {
      alert("Please select picture to upload.");
      return;
    }
    if(this.bookmodel.bookContent=="")
    {
      alert("Please enter content of book.");
      return;
    }
    this.bookmodel.bookImage = this._ImgPath;
    
    if(this.isEdit)
    {
      this._service.editBook(this.bookmodel).subscribe(res=>this.PostSuccess(res),res=>console.log(res));
    }
    else{
    this._service.createBook(this.bookmodel).subscribe(res=>
      {      
        console.log(this.bookmodel);
        //debugger;
        alert("Book added successfully");
        //this._router.navigate(['searchBook']);
      },res=>
      {
        console.log(res);
        this.ErrorMessage="Some error have occured";
        document.getElementById('btnErrorMsg')?.click();
      });
      
  }
  
  }



}
