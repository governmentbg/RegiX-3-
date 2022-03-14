import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(public oidcSecurityService: OidcSecurityService) {}

  public logout() {
    this.oidcSecurityService.logoff();
  }
}
