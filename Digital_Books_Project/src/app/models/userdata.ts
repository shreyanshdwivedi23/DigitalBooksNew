interface Dictionary<T> {
    [Key: string]: T;
}
export class UserData{
    userId:number=0;
    userName:string='';
    userPassword:string='';
    userFullname:string='';
    userType:string='';
    userEmail:string='';
    userMobileNo?:number=0;
    //selectedOption: Dictionary<string> = {};
    isRegister:boolean=false;
}