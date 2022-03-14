import { Component, OnInit, Injector } from '@angular/core';
import { RoleModel } from 'src/app/core/models/dto/role.model';
import { RolesService } from 'src/app/core/services/rest/roles.service';
import { RemoteComponentWithForm } from '@tl/tl-common';
import {
  ConnectedPositioningStrategy,
  HorizontalAlignment,
  VerticalAlignment,
  NoOpScrollStrategy
} from 'igniteui-angular';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ERoleTypes } from 'src/app/admin/enums/role-type.enum';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.scss']
})
export class RolesComponent extends RemoteComponentWithForm<
  RoleModel,
  RolesService
> {
  public routes = ROUTES;
  
  constructor(service: RolesService, injector: Injector) {
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

  getRoleType(type: number) {
    switch (type) {
      case ERoleTypes.BASIC:
        return 'Нормална';
      case ERoleTypes.ADMIN:
        return 'Администратор';
    }
  }
}
