import { Component, OnInit, Inject } from '@angular/core';
import {
  ConnectedPositioningStrategy,
  HorizontalAlignment,
  VerticalAlignment,
  NoOpScrollStrategy
} from 'igniteui-angular';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/core/services/login.service';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { ConfigurationService } from '@tl/tl-common';
import { DOCUMENT } from '@angular/common';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: 'app-logged-user',
  templateUrl: './logged-user.component.html',
  styleUrls: ['./logged-user.component.scss']
})
export class LoggedUserComponent implements OnInit {
  public routes = ROUTES;
  user = 'Test';
  stsURI: any;

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
    private loginService: LoginService,
    private oidcSecurityService: OidcSecurityService,
    configureService: ConfigurationService) {
      this.stsURI = configureService.getStsServiceUrl();
    }

    ngOnInit() {
      this.oidcSecurityService.userData$.subscribe(userData => {
        if (userData) {
          this.user = userData.given_name;
        }
      });
    }

  onLogOut() {
    this.loginService.logout();
  }

  onUserMenuSelected(event: any) {}

  onChangePassword() {
    console.log(`${this.stsURI}/Password/Change`);
    this.document.location.href = `${this.stsURI}/Password/Change?returnUrl=${encodeURIComponent(this.document.location.href)}`;
  }
}
