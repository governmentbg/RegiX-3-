import { Component, OnInit, Injector } from '@angular/core';
import { RemoteComponentWithForm } from '@tl/tl-common';
import { UsersModel } from 'src/app/core/models/dto/users.model';
import { UsersService } from 'src/app/core/services/rest/users.service';
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
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent extends RemoteComponentWithForm<
  UsersModel,
  UsersService
> {
  public routes = ROUTES;

  constructor(service: UsersService, injector: Injector) {
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
