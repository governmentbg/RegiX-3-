import { HttpClient } from '@angular/common/http';
import { OnDestroy, ViewEncapsulation } from '@angular/core';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { forkJoin, Subscription } from 'rxjs';
import { ConfigurationService } from '../../services/configuration.service';

@Component({
  selector: 'tl-marked',
  templateUrl: './marked.component.html',
  styleUrls: ['./marked.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class TLMarkedComponent implements OnInit, OnDestroy {
  @Input()
  public title: string;
  @Input()
  public icon: string;
  @Input()
  public permissions: string[];
  @Input()
  public subtitle: string;
  source: string;
  public serviceURL: string;
  @Input()
  public helpContents: string = ''
  @Input()
  public contentsRoute: string[];
  private activatedRouteSubscription: Subscription;
  loaded = false;

  constructor(
    private activatedRoute: ActivatedRoute,
    private httpClient: HttpClient,
    configuraionService: ConfigurationService) {
    this.serviceURL = configuraionService.getServiceUrl();
    this.helpContents = `${this.serviceURL}/api/marked/Contents.md`;
  }
  ngOnDestroy(): void {
    if (this.activatedRouteSubscription){
      this.activatedRouteSubscription.unsubscribe();
      this.activatedRouteSubscription = undefined;
    }
  }

  ngOnInit(): void {
    this.activatedRouteSubscription = 
      this.activatedRoute.params.subscribe( params => {
        this.loaded = false;
        this.source = `${this.serviceURL}/api/marked/${params.MARKED}`;
        this.httpClient.get(`${this.serviceURL}/api/marked/md-description.md`)
          .subscribe( description => {
            this.subtitle = description[params.MARKED];
            this.loaded = true;
          });
      });
  }
}
