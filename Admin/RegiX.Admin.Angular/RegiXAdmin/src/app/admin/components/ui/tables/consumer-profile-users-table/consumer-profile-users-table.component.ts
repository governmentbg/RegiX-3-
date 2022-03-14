import { Component, Injector } from '@angular/core';
import { RemoteComponentWithForm, GridRemoteFilteringService } from '@tl/tl-common';
import { ConsumerProfileUsersModel } from 'src/app/core/models/dto/consumer-profile-users.model';
import { ConsumerProfileUsersService } from 'src/app/core/services/rest/consumer-profile-users.service';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
  selector: 'app-consumer-profile-users-table',
  templateUrl: './consumer-profile-users-table.component.html',
  styleUrls: ['./consumer-profile-users-table.component.scss'],
})
export class ConsumerProfileUsersTableComponent extends RemoteComponentWithForm<
  ConsumerProfileUsersModel,
  ConsumerProfileUsersService
> {

  isDataLoading = false;
  isDataLoaded = false;
  public routes = ROUTES;
  public identifierType: any = { 0: 'ЕГН', 1: 'ЕИК' }; //TODO: Fix the index

  constructor(service: ConsumerProfileUsersService,
     injector: Injector) {
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

  protected getIdColumn(): string {
    return 'consumerProfile.id';
  }
}
