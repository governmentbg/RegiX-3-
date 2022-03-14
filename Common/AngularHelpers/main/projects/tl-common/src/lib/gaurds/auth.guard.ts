import { Injectable } from '@angular/core';
import {
  Router,
  CanLoad,
  Route,
  UrlSegment
} from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { map, take } from 'rxjs/operators';
import { AUTH_PATHS } from '../modules/auth-paths';
import { LocalStorageService } from '../services/local-storage.service';
import { NGXLogger } from 'ngx-logger';

@Injectable({
  providedIn: 'root'
})
export class TLAuthGuard implements CanLoad {

  private loader$ = new Subject<boolean>();
  public loader = false;

  constructor(
    private router: Router,
    private localStorageService: LocalStorageService,
    private oidcSecurityService: OidcSecurityService, 
    private logger: NGXLogger) {
    this.loader$.subscribe(loader => {
        this.loader = loader;
      }
    );
  }
  canLoad(
    route: Route,
    segments: UrlSegment[]): boolean | Observable<boolean> | Promise<boolean> {
      const navigation = this.router.getCurrentNavigation();
      let url = '/';
      if (navigation) {
        url = navigation.extractedUrl.toString();
      }
      return this.canLoadImpl(url);
  }

  canLoadImpl(url: string): Observable<boolean> {
    this.loader$.next(true);
    const resultSubject$ = new Subject<boolean>();
    return this.oidcSecurityService.isAuthenticated$.pipe(
        take(1),
        map(isAuthorized => {
          this.loader$.next(false);
          if (!isAuthorized) {
            this.logger.debug(`write redirect url (${url} in auth.guard`);
              this.localStorageService.write('redirect', url);
              this.router.navigate(['/', AUTH_PATHS.LOGIN]);
          }
          return isAuthorized;
        })
      );
  }
}
