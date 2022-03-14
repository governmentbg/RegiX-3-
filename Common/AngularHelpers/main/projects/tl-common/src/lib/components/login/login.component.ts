import { Component, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { NGXLogger } from 'ngx-logger';

@Component({
  selector: 'tl-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class TLLoginComponent implements OnInit{

  constructor(
    public oidcSecurityService: OidcSecurityService,
    protected logger: NGXLogger
  ) {}

  ngOnInit() {
    if (!window.location.search) {
      this.logger.debug('Calling authorize from login component')
      this.oidcSecurityService.authorize();
    }
  }
}
