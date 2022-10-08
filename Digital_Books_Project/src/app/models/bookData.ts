export class bookData{
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