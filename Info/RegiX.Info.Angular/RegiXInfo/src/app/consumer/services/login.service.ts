import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { OidcSecurityService } from 'angular-auth-oidc-client';


@Injectable({
  providedIn: 'root'
})
export class LoginService {
  //public user: UsersModel = null;
  private boundAuthroizeEvent: any;
 public consumerProfileId: number;


  constructor(private router: Router,
              public oidcSecurityService: OidcSecurityService) {}

  public login(username: string, password: string) {
   // this.user = new UsersModel({ userName: username, isLockedOut: false });
  }

  public getConsumerProfileId(): number {
    this.oidcSecurityService.userData$.subscribe(userData => {
      if (userData) {
        this.consumerProfileId = userData.ConsumerProfileId;
      }
    });
    return this.consumerProfileId;
  }

  public logout() {
    //this.user = null;
    this.oidcSecurityService.logoff();
  }
}
