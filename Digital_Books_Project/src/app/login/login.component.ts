import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { UserData } from '../models/userdata';
import { LoginServiceService } from '../services/login-service.service';
import { Router } from '@angular/router';
import { AuthguardService } from '../services/authguard.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  // loginModel={
  //   userName:String,
  //   userPassword:String,
  //   userEmail:String
  // }

  // profileForm = new FormGroup({
  //   firstName: new FormControl(''),
  //   lastName: new FormControl(''),
  // });
  userId = 0;
  userName = '';
  userType = '';
  constructor(private _service:LoginServiceService,private _router:Router, private _authservice:AuthguardService) { }
  ErrorMessage:any='';
  UserDataModel:UserData=new UserData();
  ngOnInit(): void {
    
  }

  loginUser(){
    if(this.UserDataModel.userName=="")
    {
      alert("Please enter user name.");
      return;
    }
    if(this.UserDataModel.userPassword=="")
    {
      alert("Please enter password to login.");
      return;
    }
    

    this._service.loginUser(this.UserDataModel).subscribe(res=>{
      
      
      localStorage.setItem('token',res.token);
      //console.log(res.user);
      
      debugger;
      this.userId = this._authservice.getCurrentUserId();
      this.userName = this._authservice.getCurrentUserName();
      this.userType = this._authservice.getCurrentUserType();
      
      localStorage.setItem('userType',this.userType);
      localStorage.setItem('userName',this.userName);
      localStorage.setItem('userId',this.userId.toString());
      alert("Login successfull!");
      window.location.href="home";
      this._router.navigate(['home']);
      //window.location.reload();
    },res=>
    {
      console.log(res);
      this.ErrorMessage="Some error have occured";
      document.getElementById('btnErrorMsg')?.click();
    });
  }

}
