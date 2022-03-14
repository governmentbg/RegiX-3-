import { Component, OnInit } from '@angular/core';
import { CONSUMER_ROUTES } from '../../routes/consumer-static-routes';
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
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  routes = CONSUMER_ROUTES;

  menu = [
    helper(CONSUMER_ROUTES.SYSTEMS),
    helper(CONSUMER_ROUTES.CERTIFICATES),
    helper(CONSUMER_ROUTES.REQUESTS),
    helper(CONSUMER_ROUTES.CONSUMER_PROFILE_USERS_APPROVED)
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
