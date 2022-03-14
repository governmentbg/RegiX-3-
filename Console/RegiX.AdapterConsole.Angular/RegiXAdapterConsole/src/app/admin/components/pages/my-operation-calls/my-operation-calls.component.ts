import { Component, OnInit, Injector } from '@angular/core';
import { RemoteComponentWithForm } from '@tl/tl-common';
import { OperationCallModel } from 'src/app/core/models/dto/operation-call.model';
import {
  ConnectedPositioningStrategy,
  HorizontalAlignment,
  VerticalAlignment,
  NoOpScrollStrategy
} from 'igniteui-angular';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { MyOperationCallsService } from 'src/app/core/services/rest/my-operation-calls.service';
import { HttpParams } from '@angular/common/http';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: 'app-my-operation-calls',
  templateUrl: './my-operation-calls.component.html',
  styleUrls: ['./my-operation-calls.component.scss']
})
export class MyOperationCallsComponent extends RemoteComponentWithForm<
  OperationCallModel,
  MyOperationCallsService
> {
  private currentUserId: number = null;
  public routes = ROUTES;

  constructor(
    service: MyOperationCallsService,
    injector: Injector,
    private oidcSecurityService: OidcSecurityService
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'name', dir: SortingDirection.Asc }
    // ];
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {},
      this.service,
      this.grid,
      this.injector
    );
  }
  
  onShowMenuSelected(event) {}
}
