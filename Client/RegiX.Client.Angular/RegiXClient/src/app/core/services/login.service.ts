import { Injectable } from '@angular/core';
import { UsersModel } from '../models/dto/users.model';
import { Router } from '@angular/router';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  // public user: UsersModel = null;
  private boundAuthroizeEvent: any;

  constructor(private router: Router,
              public oidcSecurityService: OidcSecurityService) {}

  // public login(username: string, password: string) {
  //   this.user = new UsersModel({ userName: username, isLockedOut: false });
  // }

   public logout() {
     this.oidcSecurityService.logoff();
   }
  //   //this.user = null;
  //   console.log('Adding event listener for logout');
  //   this.boundAuthroizeEvent = this.onCustomEvent.bind(this);
  //   window.addEventListener('oidc-logout-message', this.boundAuthroizeEvent);
  //   this.oidcSecurityService.logoff((logoutUrl) => {
  //     // handle the authorrization URL
  //     console.log(logoutUrl);

  //     // Fixes dual-screen position                         Most browsers      Firefox
  //     const dualScreenLeft = window.screenLeft !== undefined ? window.screenLeft : window.screenX;
  //     const dualScreenTop = window.screenTop !== undefined ? window.screenTop : window.screenY;

  //     const w = 400;
  //     const h = 500;
  //     const width =
  //       window.innerWidth ?
  //         window.innerWidth :
  //         document.documentElement.clientWidth ?
  //           document.documentElement.clientWidth :
  //           screen.width;

  //     const height =
  //       window.innerHeight ?
  //         window.innerHeight :
  //           document.documentElement.clientHeight ?
  //             document.documentElement.clientHeight :
  //             screen.height;

  //     const systemZoom = width / window.screen.availWidth;
  //     const left = (width - w) / 2 / systemZoom + dualScreenLeft;
  //     const top = (height - h) / 2 / systemZoom + dualScreenTop;

  //     window.open(logoutUrl, '_blank', `toolbar=0,menubar=0,left=${left},top=${top},width=${w},height=${h}`);
  //   });
  //   this.router.navigate(['loggedout']);
  // }

  // public onCustomEvent(e: CustomEvent): void {
  //   console.log('Event detail');
  //   console.log(e.detail);
  //   console.log('Service');
  //   console.log(this.oidcSecurityService);
  //   window.removeEventListener('oidc-logout-message', this.boundAuthroizeEvent);
  // }
}
