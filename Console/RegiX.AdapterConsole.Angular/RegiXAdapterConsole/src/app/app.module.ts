import { BrowserModule, HammerModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { TLAuthModule } from '@tl/tl-common';
import { LoggerModule, NgxLoggerLevel } from 'ngx-logger';
import { RgxModule } from '@tl-rgx/rgx-common';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';

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
    HammerModule,
    RgxModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production })
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(
  ) {
  }
}
