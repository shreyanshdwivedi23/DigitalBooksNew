export class purchaseData{
    
    purchaseId:number = 0;
    orderNo :string= "";
    bookId : number =0;
    readerId : number= 1;
    purchaseDate :string = "";
    createdBy :number=0;
    createdDate:string="";
    tblLoginObj = new Login();
    
    tblBookObj = new Book();
    }

export class Login{
    userId:number=0;
    userName:string='';
    userPassword:string='';
    userFullname:string='';
    userType:string='';
    userEmail:string='';
    userMobileNo?:number=0;
    isRegister:boolean=false;
    }

export class Book{
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