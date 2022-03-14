import { Component, Injector } from "@angular/core";
import { ConfigurationService, TLAuthAppComponent } from '@tl/tl-common';

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"]
})
export class AppComponent extends TLAuthAppComponent {
  public applicationName: string;

  constructor(
    injector: Injector,
    configurationService: ConfigurationService
  ) {
    super(injector);
    this.applicationName = configurationService.getApplicationName();
  }

  protected getTitle(page: string): string {
    return `${this.applicationName} - ${page}`;
  }
}
