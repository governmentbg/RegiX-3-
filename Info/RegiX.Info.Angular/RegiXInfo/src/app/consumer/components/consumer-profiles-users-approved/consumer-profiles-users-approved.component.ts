import { ConsumerProfileUsersModel } from './../../models/consumer-profile-user.model';
import { Component, Injector } from '@angular/core';
import {
  RemoteComponentWithForm,
  DisplayValueFilteringOperand,
} from '@tl/tl-common';
import { CONSUMER_ROUTES } from '../../routes/consumer-static-routes';
import { ConsumerProfileUsersService } from '../../services/consumer-profile-users.service';
import { DisplayValueFormatService } from '../../services/display-value-format.service';
import { ConsumerProfileUsersApprovedModel } from '../../models/consumer-profile-user-approved.model';
import { ConsumerProfileUsersApprovedService } from '../../services/consumer-profile-users-approved.service';

@Component({
  selector: 'app-consumer-profiles-users-approved',
  templateUrl: './consumer-profiles-users-approved.component.html',
  styleUrls: ['./consumer-profiles-users-approved.component.scss'],
})
export class ConsumerProfilesUsersApprovedComponent extends RemoteComponentWithForm<
ConsumerProfileUsersApprovedModel,
ConsumerProfileUsersApprovedService
> {
  public routes = CONSUMER_ROUTES;

  constructor(
    service: ConsumerProfileUsersApprovedService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService
  ) {
    super(service, injector);
  }
}
