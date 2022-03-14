import { Component, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import {
  ConfigurationService,
  HeaderDrawerItem,
  ReferenceDrawerItem,
} from '@tl/tl-common';
import { CONSUMER_ROUTES } from '../../routes/consumer-static-routes';

@Component({
  selector: 'app-consumer-layout',
  templateUrl: './consumer-layout.component.html',
  styleUrls: ['./consumer-layout.component.scss'],
})
export class ConsumerLayoutComponent implements OnInit {
  public applicationTitle: string;

  public drawerItems = [];

  constructor(
    private oidcSecurityService: OidcSecurityService,
    configurationService: ConfigurationService
  ) {
    this.applicationTitle = configurationService.getApplicationName();
    this.drawerItems = [
      new HeaderDrawerItem('Профил на консуматор', []),
      new ReferenceDrawerItem(CONSUMER_ROUTES.SYSTEMS),
      new ReferenceDrawerItem(CONSUMER_ROUTES.CERTIFICATES),
      new ReferenceDrawerItem(CONSUMER_ROUTES.REQUESTS),
      new ReferenceDrawerItem(CONSUMER_ROUTES.CONSUMER_PROFILE_USERS_APPROVED),
    ];
  }

  ngOnInit(): void {}

  onLogout(): void {
    this.oidcSecurityService.logoff();
  }
}
