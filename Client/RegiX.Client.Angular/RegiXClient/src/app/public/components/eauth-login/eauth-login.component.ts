import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LocalStorageService } from '@tl/tl-common';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
  selector: 'app-eauth-login',
  templateUrl: './eauth-login.component.html',
  styleUrls: ['./eauth-login.component.scss']
})
export class EauthLoginComponent implements OnInit {
  constructor(
    private oidcSecurityService: OidcSecurityService,
    private router: Router,
    private route: ActivatedRoute,
    private storageService: LocalStorageService
  ) {}

  ngOnInit(): void {
    const redirectUrl = this.route.snapshot.queryParams.redirectUrl;
    if (redirectUrl) {
      this.storageService.write('redirect', redirectUrl);
    } else {
      this.storageService.write('redirect', 'admin');
    }

    this.oidcSecurityService.authorize({
      customParams: {
        eauth: 'yes',
        'ngsw-bypass': 'yes'
      },
    });
  }

}
