import { Component, OnInit } from '@angular/core';
import { ROUTES } from '../../routes/static-routes';
import { AdministrationListModel } from 'src/app/core/model/administration-list.model';
import { RestClientAdministrationsListService } from 'src/app/core/services/rest/rest-client-adminstrations-list-service';
import { Router, ActivatedRoute } from '@angular/router';
import { TLRouteReference } from '@tl/tl-common';
function helper(
  refrnc: TLRouteReference,
  argmnts?: any
): {
  reference: TLRouteReference;
  args: any;
} {
  if (!argmnts) {
    argmnts = {};
  }
  return {
    reference: refrnc,
    args: argmnts,
  };
}
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  routes = ROUTES;

  developers = [
    helper(ROUTES.REGIX_ENVIRONMENTS),
    helper(ROUTES.CERTIFICATE_PROVISION),
    helper(ROUTES.ADAPTER_DEVELOPMENT),
  ];

  statistics = [
    helper(ROUTES.STATISTICS_HOUR),
    helper(ROUTES.STATISTICS_DAY),
    helper(ROUTES.STATISTICS_WEEK),
    helper(ROUTES.STATISTICS_MONTH),
  ];

  consumers = [
    helper(ROUTES.CONSUMER_REGISTRATION),
    helper(ROUTES.CONSUMER_USER_REGISTRATION)
  ];

  administrations: AdministrationListModel[] = [];
  isAdministrationsLoading = false;

  constructor(
    private administrationService: RestClientAdministrationsListService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {
      const login = new TLRouteReference();
      login.icon = 'input';
      login.route = ['/', 'consumer'];
      // login.route = ['/', 'public', 'administrations'];
      login.title = 'Вход';
      this.consumers.push(helper(login));
    }


  ngOnInit() {
    this.isAdministrationsLoading = true;
    this.administrationService.retrieveAll(true).subscribe(
      res => {
        this.administrations.push(...res);
        this.isAdministrationsLoading = false;
      },
      err => {
        this.isAdministrationsLoading = false;
      }
    );
  }

  filterAdministrations(admCode: string) {
    this.routes.REGISTRIES.navigate(this.router, { ':ADM_CODE': admCode }, this.activatedRoute);
  }

  onRegiXService() {
    window.open('https://regix-service.egov.bg/', '_blank');
  }
  onRegiXServiceTest() {
    window.open('https://regix-service-test.egov.bg/', '_blank');
  }

  public searchWithClear(input: any) {
    if (input && input.value !== '') {
      this.routes.SEARCH_RESULTS.navigate(
        this.router,
        { ':TERM': input.value },
        this.activatedRoute
      );
      input.value = '';
    }
  }
  public openHref(url: string){
    window.open(url, '_blank');
  }
}
