export class bookData{
    
    PurchaseId:number = 0;
    OrderNo :string= "";
    BookId : number =0;
    ReaderId : number= 1;
    PurchaseDate :string = "";
    CreatedBy :number=0;
    CreatedDate:string="";
    loginObj = new TblLogin();
    
    bookObj = new TblBook();
    }

export class TblLogin{
    userId:number=0;
    userName:string='';
    userPassword:string='';
    userFullname:string='';
    userType:string='';
    userEmail:string='';
    userMobileNo?:number=0;
    isRegister:boolean=false;
    }

export class TblBook{
    bookId:number=0;
    bookTitle:string='';
    bookCategory:string='';
    bookImage:string='';
    bookPrice:string='';
    bookPublisher:string='';
    bookContent?:string='';
    bookIsActive:boolean=true;
    bookCreatedBy:number=0;
    bookAuthor:string='';
    //bookCreatedDate:string='';
    bookModifiedBy:number=0;
    bookReleasedDate?:string;
    bookIsDelete:boolean=false;
    bookIsBlock:boolean=false;
    bookUserName:string='';
}