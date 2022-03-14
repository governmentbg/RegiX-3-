import { HttpInterceptor, HttpRequest, HttpEvent, HttpHandler, HttpErrorResponse } from '@angular/common/http';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Injectable, Injector } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NGXLogger } from 'ngx-logger';
import { Router } from '@angular/router';
import { LocalStorageService } from '../services/local-storage.service';

@Injectable()
export class TLAuthInterceptor implements HttpInterceptor {
    private oidcSecurityService: OidcSecurityService;
    private router: Router;
    private logger: NGXLogger;
    private localStorageService: LocalStorageService;

    constructor(private injector: Injector) {
      this.logger = this.injector.get<NGXLogger>(NGXLogger);
      this.router = this.injector.get<Router>(Router);
      this.localStorageService = this.injector.get<LocalStorageService>(LocalStorageService);
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let requestToForward = req;

        if (this.oidcSecurityService === undefined) {
            this.oidcSecurityService = this.injector.get(OidcSecurityService);
        }
        if (this.oidcSecurityService !== undefined) {
            const token = this.oidcSecurityService.getToken();
            if (token !== '') {
                const tokenValue = 'Bearer ' + token;
                requestToForward = req.clone({ setHeaders: { Authorization: tokenValue } });
            }
        }
        return next.handle(requestToForward).pipe(
          catchError( (err) => {
            if (err instanceof HttpErrorResponse && err.status === 401) {
              if (this.oidcSecurityService) {
                const navigation = this.router.url;
                let url = '/';
                this.logger.debug(`navigation: ${navigation}`)
                if (navigation) {
                  url = navigation;
                }
                this.localStorageService.write('redirect', url);
                this.logger.debug('authorize called');
                this.oidcSecurityService.authorize();
                return;
              }
            }
            return throwError(err);
          })
        );
    }
}
