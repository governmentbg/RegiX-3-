import { Component, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Router, ActivatedRoute } from '@angular/router';
import { LocalStorageService } from '@tl/tl-common';

@Component({
  selector: 'app-e-delivery-login',
  templateUrl: './e-delivery-login.component.html',
  styleUrls: ['./e-delivery-login.component.scss'],
})
export class EDeliveryLoginComponent implements OnInit {
  constructor(
    private oidcSecurityService: OidcSecurityService,
    private router: Router,
    private storageService: LocalStorageService
  ) {}

  ngOnInit(): void {
    console.log(window.location.search);
    const urlParams = new URLSearchParams(window.location.search);
    const eDeliveryToken = urlParams.get('etoken');
    if (eDeliveryToken) {
      this.storageService.write('redirect', 'admin');
      this.oidcSecurityService.authorize({
        customParams: {
          token: eDeliveryToken,
        },
      });
    } else {
      this.router.navigate(['/']);
    }
  }
}
