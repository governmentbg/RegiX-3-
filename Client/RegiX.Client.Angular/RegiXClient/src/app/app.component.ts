import { Component, HostListener, Injector } from '@angular/core';
import { AnchorService, AUTH_PATHS, ConfigurationService, TLAuthAppComponent } from '@tl/tl-common';

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
    configurationService: ConfigurationService,
    private anchorService: AnchorService
  ) {
    super(injector);
    this.applicationTitle = configurationService.getApplicationName();
  }

  protected getTitle(page: string): string {
    return `${this.applicationTitle} - ${page}`;
  }
}
