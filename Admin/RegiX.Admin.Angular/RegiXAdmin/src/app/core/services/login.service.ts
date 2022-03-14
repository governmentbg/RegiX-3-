import { Injectable } from '@angular/core';
import { UsersModel } from '../models/dto/users.model';
import { Router } from '@angular/router';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  public user: UsersModel = null;
  private boundAuthroizeEvent: any;

  constructor(private router: Router,
              public oidcSecurityService: OidcSecurityService) {}

  public login(username: string, password: string) {
    this.user = new UsersModel({ userName: username, isLockedOut: false });
  }

  public logout() {
    this.user = null;
    this.oidcSecurityService.logoff();
  }
}
