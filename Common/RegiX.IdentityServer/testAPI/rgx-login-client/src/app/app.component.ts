import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { filter, take } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'rgx-login-client';
  isAuthenticated: boolean;
  userData: any;
  res: any;
  constructor(public oidcSecurityService: OidcSecurityService, public router: Router, public httpClient: HttpClient) {
          if (this.oidcSecurityService.moduleSetup) {
              this.doCallbackLogicIfRequired();
          } else {
              this.oidcSecurityService.onModuleSetup.subscribe(() => {
                  this.doCallbackLogicIfRequired();
              });
          }
      }

      ngOnInit() {
          this.oidcSecurityService.getIsAuthorized().subscribe(auth => {
              this.isAuthenticated = auth;
          });

          this.oidcSecurityService.getUserData().subscribe(userData => {
              this.userData = userData;
          });

      }

      ngOnDestroy(): void {}

      login() {
          this.oidcSecurityService.authorize();
      }

      logout() {
          // this.oidcSecurityService.logoff(
          //    url => {
          //      this.httpClient.get(url).subscribe();
          //   }
          // );
          this.oidcSecurityService.logoff();
      }

      callIdentity() {
        this.httpClient.get('https://localhost:5001/identity').subscribe(
          res => this.res = res,
          err => this.res = err
        );
      }

      callAdmin() {
        this.httpClient.get('https://localhost:5001/identity/administrationID').subscribe(
          res => this.res = res,
          err => this.res = err
        );
      }

      private doCallbackLogicIfRequired() {
          // Will do a callback, if the url has a code and state parameter.
          this.oidcSecurityService.authorizedCallbackWithCode(window.location.toString());
      }
}
