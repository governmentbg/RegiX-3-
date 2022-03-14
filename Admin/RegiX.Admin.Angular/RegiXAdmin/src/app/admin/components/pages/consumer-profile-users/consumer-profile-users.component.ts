import { Component, Injector } from '@angular/core';
import { RemoteComponentWithForm, GridRemoteFilteringService } from '@tl/tl-common';
import { ConsumerProfileUsersModel } from 'src/app/core/models/dto/consumer-profile-users.model';
import { ConsumerProfileUsersService } from 'src/app/core/services/rest/consumer-profile-users.service';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
  selector: 'app-consumer-profile-users',
  templateUrl: './consumer-profile-users.component.html',
  styleUrls: ['./consumer-profile-users.component.scss'],
})
export class ConsumerProfileUsersComponent extends RemoteComponentWithForm<
  ConsumerProfileUsersModel,
  ConsumerProfileUsersService
> {

  isDataLoading = false;
  isDataLoaded = false;

  public identifierType: any = { 0: 'ЕГН', 1: 'ЕИК' };

  constructor(service: ConsumerProfileUsersService, injector: Injector) {
    super(service, injector);
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {  },
      this.service,
      this.grid,
      this.injector
    );
  }
}
