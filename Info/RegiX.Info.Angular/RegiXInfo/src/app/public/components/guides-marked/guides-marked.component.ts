import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConfigurationService } from '@tl/tl-common';
import { ROUTES } from '../../routes/static-routes';

@Component({
  selector: 'app-guides-marked',
  templateUrl: './guides-marked.component.html',
  styleUrls: ['./guides-marked.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class GuidesMarkedComponent implements OnInit {

  source: string;
  routes = ROUTES;
  public serviceURL: string;
  public guidesSource: string;
  constructor(
    private activatedRoute: ActivatedRoute,
    private configuraionService: ConfigurationService) {
      this.serviceURL = configuraionService.getServiceUrl();
      this.guidesSource = `${this.serviceURL}/api/marked/Guides.md`;
      this.activatedRoute.params.subscribe((params) => {
        this.source = `${this.serviceURL}/api/marked/${params['MARKED']}`;
     });
    }

  ngOnInit(): void {
  }

}
