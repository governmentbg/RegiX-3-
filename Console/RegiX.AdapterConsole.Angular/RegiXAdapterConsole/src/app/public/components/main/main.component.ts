import 'hammerjs';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfigurationService } from '@tl/tl-common';
import { appVersion } from '../../../app.version';

@Component({
  selector: 'app-loggedout',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  public applicationName: string;
  public version = appVersion;

  constructor(
    private router: Router,
    configurationService: ConfigurationService) {
    this.applicationName = configurationService.getApplicationName();
  }

  ngOnInit() {
  }

  onLogin() {
    this.router.navigate(['/admin']);
  }

  onRegister(){
    this.router.navigate(['/signup']);
  }
}
