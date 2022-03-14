import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from '@tl/tl-common';
import { appVersion } from '../app.version';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss'],
})
export class MainComponent implements OnInit {
  public applicationName: string;
  public version = appVersion;

  constructor(configurationService: ConfigurationService) {
    this.applicationName = configurationService.getApplicationName();
  }

  ngOnInit(): void {}
}
