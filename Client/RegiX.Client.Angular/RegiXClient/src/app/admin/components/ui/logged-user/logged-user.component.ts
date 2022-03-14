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
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { ConfigurationService } from '@tl/tl-common';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-logged-user',
  templateUrl: './logged-user.component.html',
  styleUrls: ['./logged-user.component.scss']
})
export class LoggedUserComponent implements OnInit {
  user = 'Test';
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
    private loginService: LoginService,
    private oidcSecurityService: OidcSecurityService,
    configureService: ConfigurationService) {
      this.stsURI = configureService.getStsServiceUrl();
    }

  ngOnInit() {
    this.oidcSecurityService.userData$.subscribe(userData => {
      if ('PUBLIC' === userData.role) {
        // Information for public user is not displayed
        this.user = '';
      } else {
        this.user = userData.FullName;
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

  onUserSettings() {
    this.router.navigate(['admin', 'manageUser']);
  }

  onMyProfile() {
    this.router.navigate(['admin', 'my-profile']);
  }
}
