export class bookData{
    bookId:number=0;
    bookTitle:string='';
    bookCategory:string='';
    bookImage:string='';
    bookPrice:string='';
    bookPublisher:string='';
    bookContent?:string='';
    bookIsActive:boolean=true;
    //bookCreatedBy:number=0;
    //bookCreatedDate:string='';
    bookReleasedDate?:string;
    bookIsDelete:boolean=false;
    bookIsBlock:boolean=false;
}