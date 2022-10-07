import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginServiceService } from './login-service.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthguardService {

  constructor(private _auth:LoginServiceService,private _router:Router,private jwt: JwtHelperService) { }
  name ='';
  Id = 0;
  type='';
  
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    if(this._auth.logginIn()){
      return true;
    }
    else{
      this._router.navigate(['']);
      return false;
    }
  }

  getCurrentUserId():number{
    this.Id=this.jwt.decodeToken(this._auth.getToken()?.toString()).unique_name;
    console.log(this.jwt.decodeToken(this._auth.getToken()?.toString()));
    return Number(this.Id);
  }

  getCurrentUserName():string{
    this.name=this.jwt.decodeToken(this._auth.getToken()?.toString()).email;
    return this.name;
  }

  getCurrentUserType():string{
    this.type=this.jwt.decodeToken(this._auth.getToken()?.toString()).gender;
    return this.type;
  }
}
