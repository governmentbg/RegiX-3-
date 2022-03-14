import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AuthModule, ConfigResult, OidcConfigService, OidcSecurityService, OpenIdConfiguration } from 'angular-auth-oidc-client';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthInterceptor } from './AuthInterceptor';

const oidcConfiguration = 'assets/auth.clientConfiguration.json';

export function loadConfig(oidcConfigService: OidcConfigService) {
  return () => oidcConfigService.load(oidcConfiguration);
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
        { path: '', component: AppComponent },
        { path: 'home', component: AppComponent },
        { path: 'forbidden', component: AppComponent },
        { path: 'unauthorized', component: AppComponent },
    ]),
    AuthModule.forRoot(),
  ],
  providers: [
      OidcConfigService,
      {
          provide: APP_INITIALIZER,
          useFactory: loadConfig,
          deps: [OidcConfigService],
          multi: true,
      },
      {
        provide: HTTP_INTERCEPTORS,
        useClass: AuthInterceptor,
        multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(private oidcSecurityService: OidcSecurityService, private oidcConfigService: OidcConfigService) {
    this.oidcConfigService.onConfigurationLoaded.subscribe((configResult: ConfigResult) => {

        // Use the configResult to set the configurations
        const config: OpenIdConfiguration = {
            stsServer: configResult.customConfig.stsServer,
            redirect_url: configResult.customConfig.redirect_url,
            client_id: configResult.customConfig.client_id,
            scope: configResult.customConfig.scope,
            response_type: configResult.customConfig.response_type,
            silent_renew: configResult.customConfig.silent_renew,
            silent_renew_url: configResult.customConfig.silent_renew_url,
            log_console_debug_active: configResult.customConfig.log_console_debug_active,
            post_logout_redirect_uri: configResult.customConfig.post_logout_redirect_uri
        };

        this.oidcSecurityService.setupModule(config, configResult.authWellknownEndpoints);
    });
  }
}
