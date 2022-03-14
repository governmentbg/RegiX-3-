import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { TLAuthModule } from '@tl/tl-common';
import { LoggerModule, NgxLoggerLevel } from 'ngx-logger';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
// import { MatomoModule } from 'ngx-matomo';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    TLAuthModule,
    LoggerModule.forRoot(
      {
        level: NgxLoggerLevel.DEBUG,
      }
    ),
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production }),
    // MatomoModule.forRoot({
    //   // Should include ${baseHref}
    //   scriptUrl: `${window.location.origin}/matomo/matomo.js`,
    //   trackers: [
    //     {
    //       // Should include ${baseHref}
    //       trackerUrl: `${window.location.origin}/matomo/matomo.php`,
    //       siteId: 1
    //     }
    //   ],
    //   routeTracking: {
    //     enable: true
    //   }
    // }),
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(
  ) {
  }
}
