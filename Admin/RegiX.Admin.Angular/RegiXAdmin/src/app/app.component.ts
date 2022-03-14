import { Component, HostListener, Injector } from '@angular/core';
import { AnchorService, ConfigurationService, TLAuthAppComponent} from '@tl/tl-common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent extends TLAuthAppComponent {

  public applicationName: string;

  @HostListener('document:click', ['$event'])
  onDocumentClick(event: Event) {
    this.anchorService.interceptClick(event);
  }

  constructor(
    injector: Injector,
    configurationService: ConfigurationService,
    private anchorService: AnchorService,
  ) {
    super(injector);
    this.applicationName = configurationService.getApplicationName();
  }

  protected getTitle(page: string): string {
    return `${this.applicationName} - ${page}`;
  }
}
