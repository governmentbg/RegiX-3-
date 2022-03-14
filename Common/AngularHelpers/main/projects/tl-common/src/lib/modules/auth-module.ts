import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';
import { AuthModule, OidcConfigService } from 'angular-auth-oidc-client';
import { NgxPermissionsModule } from 'ngx-permissions';
import { NgModule, APP_INITIALIZER, Injector } from '@angular/core';
import { APP_BASE_HREF, PlatformLocation } from '@angular/common';
import { TLAuthInterceptor } from '../interceptors/auth-interceptor';
import { TLPostLoginComponent } from '../components/post-login/post-login.component';
import { TLLoginComponent } from '../components/login/login.component';
import { switchMap, map } from 'rxjs/operators';
import { TLLoginErrorComponent } from '../components/login-error/login-error.component';
import { ConfigurationService } from '../services/configuration.service';
import { forkJoin } from 'rxjs';

const oidcConfiguration = 'assets/auth.clientConfiguration.json';

export function configureAuth(oidcConfigService: OidcConfigService, configurationService: ConfigurationService, httpClient: HttpClient, injector: Injector) {
  let baseHref = injector.get<string>(APP_BASE_HREF);
  const setupAction$ = httpClient.get<any>(`${window.location.origin}${baseHref}${oidcConfiguration}`).pipe(
      map((customConfig) => {
          const res = {
              stsServer: `${window.location.origin}/${customConfig.stsServer}`,
              redirectUrl:  `${window.location.origin}${baseHref}${customConfig.redirect_url}`,
              clientId: customConfig.client_id,
              responseType: customConfig.response_type,
              scope: customConfig.scope,
              postLogoutRedirectUri: `${window.location.origin}${baseHref}${customConfig.post_logout_redirect_uri}`,
              startCheckSession: customConfig.start_checksession,
              silentRenew: customConfig.silent_renew,
              silentRenewUrl: `${window.location.origin}${baseHref}${customConfig.silent_renew_url}`,
              postLoginRoute: customConfig.post_login_route,
              forbiddenRoute: customConfig.forbidden_route,
              unauthorizedRoute: customConfig.unauthorized_route,
              logLevel: customConfig.logLevel,
              maxIdTokenIatOffsetAllowedInSeconds: customConfig.max_id_token_iat_offset_allowed_in_seconds,
              historyCleanupOff: true,
              triggerAuthorizationResultEvent: true
              // autoUserinfo: false,
          };
          console.log('authConfig', res);
          return res;
      }),
      switchMap((config) => oidcConfigService.withConfig(config))
  );

  const setupConfiguration$ = configurationService.readConfiguration()

  return () => forkJoin([setupAction$, setupConfiguration$]).toPromise();
}


export function baseHrefFactory(s: PlatformLocation): string {
  return s.getBaseHrefFromDOM();
}

@NgModule({
  declarations: [
    TLPostLoginComponent,
    TLLoginErrorComponent,
    TLLoginComponent
  ],
  exports: [
    HttpClientModule,
    AuthModule,
    NgxPermissionsModule,
    TLPostLoginComponent,
    TLLoginErrorComponent,
    TLLoginComponent
  ],
  imports: [
    HttpClientModule,
    AuthModule.forRoot(),
    NgxPermissionsModule.forRoot()
  ],
  providers: [
    OidcConfigService,
    {
      provide: APP_INITIALIZER,
      useFactory: configureAuth,
      deps: [OidcConfigService, ConfigurationService, HttpClient, Injector],
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TLAuthInterceptor,
      multi: true
    },
    {
      provide: APP_BASE_HREF,
      useFactory: baseHrefFactory,
      deps: [PlatformLocation]
    }
  ]
})
export class TLAuthModule {
  constructor(
  ) {
  }
}
