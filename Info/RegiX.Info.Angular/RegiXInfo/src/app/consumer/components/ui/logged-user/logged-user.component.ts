import { Component, OnInit, Inject } from '@angular/core';
import {  Router } from '@angular/router';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { CONSUMER_ROUTES } from 'src/app/consumer/routes/consumer-static-routes';
import { DOCUMENT } from '@angular/common';
import { ConfigurationService } from '@tl/tl-common';
import { ConnectedPositioningStrategy, HorizontalAlignment, VerticalAlignment, NoOpScrollStrategy } from 'igniteui-angular';

@Component({
  selector: 'app-logged-user',
  templateUrl: './logged-user.component.html',
  styleUrls: ['./logged-user.component.scss']
})
export class LoggedUserComponent implements OnInit {
  public routes = CONSUMER_ROUTES;
  public user: string;
  public consumerProfileId: number;
  public consumerUserId: number;
  stsURI: string;

  public menuOverlaySettings = {
    positionStrategy: new ConnectedPositioningStrategy({
      horizontalDirection: HorizontalAlignment.Left,
      horizontalStartPoint: HorizontalAlignment.Right,
      verticalStartPoint: VerticalAlignment.Bottom
    }),
    scrollStrategy: new NoOpScrollStrategy()
  };

  constructor(
    @Inject(DOCUMENT)
    private document: Document,
    private router: Router,
    private oidcSecurityService: OidcSecurityService,
    configureService: ConfigurationService
  ) {
    this.stsURI = configureService.getStsServiceUrl();
  }

  ngOnInit() {
    this.oidcSecurityService.userData$.subscribe(userData => {
      if (userData) {
        this.user = userData.given_name;
        this.consumerProfileId = userData.ConsumerProfileId;
        this.consumerUserId = userData.sub;
      }
    });
  }

  onChangePassword() {
    console.log(`${this.stsURI}/Password/Change`);
    this.document.location.href = `${this.stsURI}/Password/Change?returnUrl=${encodeURIComponent(this.document.location.href)}`;
  }

  onLogOut() {
    this.oidcSecurityService.logoff();
  }

  onUserMenuSelected(event: any) {}
}
