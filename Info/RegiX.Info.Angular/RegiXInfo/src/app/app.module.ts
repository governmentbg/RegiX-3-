import { BrowserModule, HammerModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HttpClientModule, HttpClient } from '@angular/common/http';

import { NgxPermissionsModule } from 'ngx-permissions';
import { MarkdownModule, MarkedOptions, MarkedRenderer } from 'ngx-markdown';
import { LoggerModule, NgxLoggerLevel } from 'ngx-logger';
import { TLAuthModule } from '@tl/tl-common';
import { MainComponent } from './main/main.component';
import { IgxIconModule, IgxButtonModule, IgxLayoutModule, IgxDividerModule } from 'igniteui-angular';
import { RgxModule } from '@tl-rgx/rgx-common';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { AnchorService } from './public/services/anchor.service';

export function markedOptionsFactory(anchorService: AnchorService): MarkedOptions {
  const renderer = new MarkedRenderer();

  // fix `href` for absolute link with fragments so that _copy-paste_ urls are correct
  renderer.link = (href, title, text) => {
    return MarkedRenderer.prototype.link.call(renderer, anchorService.normalizeExternalUrl(href), title, text);
  };

  return { renderer };
}

@NgModule({
  declarations: [AppComponent, MainComponent],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    TLAuthModule,
    BrowserAnimationsModule,
    IgxIconModule,
    IgxButtonModule,
    IgxLayoutModule,
    IgxDividerModule,
    NgxPermissionsModule.forRoot(),
    MarkdownModule.forRoot({
      loader: HttpClient,
      markedOptions: {
        provide: MarkedOptions,
        useFactory: markedOptionsFactory,
        deps: [AnchorService],
      },
    }),
    LoggerModule.forRoot(
      {
        level: NgxLoggerLevel.DEBUG,
      }
    ),
    HammerModule,
    RgxModule,
    ServiceWorkerModule.register(
      'ngsw-worker.js',
      { enabled: environment.production }
    )
  ],
  exports: [BrowserModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor() {
  }
}
