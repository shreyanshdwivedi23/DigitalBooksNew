import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { bookData } from '../models/bookData';
import { UserData } from '../models/userdata';
import { ReaderServiceService } from '../services/reader-service.service';
@Component({
  selector: 'app-viewbookdetails',
  templateUrl: './viewbookdetails.component.html',
  styleUrls: ['./viewbookdetails.component.css']
})
export class ViewbookdetailsComponent implements OnInit {

  constructor(private route: ActivatedRoute, private _readerservice: ReaderServiceService) { }
  
  bookId = 0;
  bookModel: bookData = new bookData();
  userModel:UserData = new UserData();
  ngOnInit(): void {
    //debugger;
    //alert("reached");
    let sub = this.route.params.subscribe(params => {
      //debugger;
      console.log(params['bookId']);
      if(params['bookId']){
        //debugger;
        this.bookId = Number(atob(params['bookId']));
        console.log("book id passed " + this.bookId.toString())
      }
    });

    this._readerservice.viewBookDetails(this.bookId).subscribe(res=>this.PostSuccess(res),res=>console.log(res));
   }

   PostSuccess(res:any){
    //debugger;
    this.bookModel = res;
   }
   

    buyBook(){
      
          debugger;
         let obj : any ={ 
          
          "BookId" : this.bookModel.bookId,
          "TblLoginObj" : {
            "userEmail" : this.userModel.userEmail,
            "userName" : this.userModel.userName
          }
      };
      this._readerservice.BuyBook(obj).subscribe(res=>
        this.PostBuySuccess(res),res=>
        {
          console.log(res);
          alert("some error occured");
          //document.getElementById('btnErrorMsg')?.click();
        });
    }

    PostBuySuccess(res:any){
      console.log(res);
      //alert(res);
      alert("Order placed successfully with order number - " + res.status);
     }

}
