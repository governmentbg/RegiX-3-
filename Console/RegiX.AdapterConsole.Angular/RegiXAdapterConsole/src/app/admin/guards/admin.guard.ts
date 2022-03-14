import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
  CanActivateChild,
  Router
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { LoginService } from 'src/app/core/services/login.service';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate, CanActivateChild {
  constructor(
    private loginService: LoginService,
    private router: Router,
    private oidcSecurityService: OidcSecurityService) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean | Observable<boolean> | Promise<boolean> {
    return this.canActivateImpl(state);
  }

  canActivateChild(
    childRoute: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean | Observable<boolean> | Promise<boolean> {
    return this.canActivateImpl(state);
  }

  canActivateImpl(state: RouterStateSnapshot):  Observable<boolean> {
    return this.oidcSecurityService.getIsAuthorized().pipe(
      map(isAuth => {
        console.log(`${isAuth}`);
        return isAuth;
      })
    );
    //return of(true);
  }
}
