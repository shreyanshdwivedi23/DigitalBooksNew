import { Component, OnInit } from '@angular/core';
import { UserData } from '../models/userdata';

import { Router } from '@angular/router';
import { RegisterServiceService } from '../services/register-service.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private _service:RegisterServiceService,private _router:Router) { }
  ErrorMessage:any='';
  UserDataModel:UserData=new UserData();
  
  // selectedOption = 0;
  //   actions = [{ id: 0, userType: 'Select User Type' },
  //   { userType: "Author", userTypeName: 'Author' },
  //   { userType: "Reader", userTypeName: 'Reader' }]

  ngOnInit(): void {
  }

  registerUser(){
    this.UserDataModel.isRegister=true;
    this._service.registerUser(this.UserDataModel).subscribe(res=>{
      //document.getElementById('alertid').className='visiblediv';
      alert("Congratulations, you have been registered successfuly.");
      this._router.navigate(['login']);
    },res=>
    {
      console.log(res);
      this.ErrorMessage="Some error have occured";
      document.getElementById('btnErrorMsg')?.click();
    });
  }

}
