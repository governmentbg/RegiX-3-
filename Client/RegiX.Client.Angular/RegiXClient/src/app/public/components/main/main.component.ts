import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfigurationService } from '@tl/tl-common';
import { appVersion } from '../../../app.version';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  registrationHidden = false;
  public applicationName: string;
  public version = appVersion;

  constructor(
    private router: Router,
    private configurationService: ConfigurationService ) { }

  ngOnInit() {
    // Hides registration in production for Public Client application
    this.registrationHidden =
      this.configurationService.getServiceUrl().startsWith('https://clientc-regix.egov.bg')
      || this.configurationService.getServiceUrl().startsWith('https://client-regix.tlogica.com');
    this.applicationName = this.configurationService.getApplicationName();
  }

  onLogin(event) {
    if (! (
      !this.registrationHidden ||
      event.shiftKey ||
      event.altKey)
    ) {
      this.router.navigate(['/eauth']);
    } else {
      this.router.navigate(['/admin']);
    }
  }

  onRegister() {
    this.router.navigate(['/signup']);
  }
}
