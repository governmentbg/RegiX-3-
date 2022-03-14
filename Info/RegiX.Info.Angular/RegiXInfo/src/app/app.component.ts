import { Component, HostListener, Injector } from '@angular/core';
import { TLAuthAppComponent, AUTH_PATHS, ConfigurationService } from '@tl/tl-common';
import { AnchorService } from './public/services/anchor.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent extends TLAuthAppComponent {
  public applicationTitle: string;

  @HostListener('document:click', ['$event'])
  onDocumentClick(event: Event) {
    this.anchorService.interceptClick(event);
  }

  constructor(
    injector: Injector,
    private anchorService: AnchorService,
    configurationService: ConfigurationService
  ) {
    super(injector);
    this.applicationTitle = configurationService.getApplicationName();
    AUTH_PATHS.AUTHENTICATED = 'consumer';
  }

  protected getTitle(page: string): string {
    return `${this.applicationTitle} - ${page}`;
  }
}
