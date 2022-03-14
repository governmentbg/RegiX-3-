import { Component, OnInit } from '@angular/core';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { TLRouteReference } from '@tl/tl-common';
import { ConsumerProfilesService } from 'src/app/core/services/rest/consumer-profiles.service';
import { HttpParams } from '@angular/common/http';
import { ConsumerRequestsService } from 'src/app/core/services/rest/consumer-requests.service';

function helper(
  ref: TLRouteReference,
  argms?: any,
  aBadge?: any
): {
  reference: TLRouteReference;
  args: any;
  badge: any
} {
  if (!argms) {
    argms = {};
  }
  return {
    reference: ref,
    args: argms,
    badge: aBadge
  };
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  routes = ROUTES;

  primaryAdministrations = [
    helper(ROUTES.ADMINISTRATIONS, { ':ADM_TYPE': 'primary' }),
    helper(ROUTES.REGISTRIES, { ':ADM_TYPE': 'primary' }),
    helper(ROUTES.ADAPTERS, { ':ADM_TYPE': 'primary' }),
    helper(ROUTES.OPERATIONS, { ':ADM_TYPE': 'primary' }),
    // helper(ROUTES.INTERFACES),
  ];

  consumers = [
    helper(ROUTES.ADMINISTRATIONS),
    helper(ROUTES.CONSUMERS),
    helper(ROUTES.CONSUMER_ROLES),
    helper(ROUTES.CERTIFICATES),
    helper(ROUTES.ACCESS_REPORT),
    helper(ROUTES.STATISTICS),
    helper(ROUTES.LOGS),
    helper(ROUTES.ERRORS),
  ];

  consumersProfiles = [
    helper(ROUTES.CONSUMER_PROFILES),
    helper(ROUTES.CONSUMER_SYSTEMS),
    helper(ROUTES.CONSUMER_PROFILES_APPROVAL),
    helper(ROUTES.CONSUMER_REQUEST_APPROVAL),
  ];

  settings = [
    helper(ROUTES.USERS, { ':ADM_TYPE': 'primary' }),
    helper(ROUTES.ADMINISTRATIONS_TYPES),
    helper(ROUTES.AUDIT),
    // helper(ROUTES.USER_ACTIONS),
  ];


  constructor(
    private consumerProfileService: ConsumerProfilesService,
    private consumerRequestsService: ConsumerRequestsService) {}

  ngOnInit() {
    let params = new HttpParams();
    params = params.append('$skip', '0');
    params = params.append('$top', '1');
    params = params.append('$count', 'false');
    params = params.append(
      '$filter',
      'status eq 0'
    );
    this.consumerProfileService.getAll(params).subscribe( res => {
      if ((res as any).data.length > 0) {
        const badge = {
          icon: 'new_releases',
          type: 'error'
        };
        this.consumersProfiles[2].badge = badge;
      }
    });

    let paramsRequests = new HttpParams();
    paramsRequests = paramsRequests.append('$skip', '0');
    paramsRequests = paramsRequests.append('$top', '1');
    paramsRequests = paramsRequests.append('$count', 'false');
    paramsRequests = paramsRequests.append(
      '$filter',
      'status eq 1'
    );
    this.consumerRequestsService.getAll(paramsRequests).subscribe(res => {
      if ((res as any).data.length > 0) {
        const badge = {
          icon: 'new_releases',
          type: 'error'
        };
        this.consumersProfiles[3].badge = badge;
      }
    });
  }
}
