import { Component, OnInit, Injector } from '@angular/core';
import {
  DisplayValueFilteringOperand,
  RemoteComponentWithForm,
} from '@tl/tl-common';
import { UsersModel } from 'src/app/core/models/dto/users.model';
import { UsersService } from 'src/app/core/services/rest/users.service';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss'],
})
export class UsersComponent extends RemoteComponentWithForm<
  UsersModel,
  UsersService
> {
  title: string;
  objectName = 'потребители';
  public routes = ROUTES;
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();

  constructor(
    service: UsersService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService
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

  formatRoles(value) {
    return value.join(', ');
  }

  onShowMenuSelected(event) {}

  protected excelExportMapItem(item: UsersModel) {
    return {
      // Ид: item.id,
      Администрация: item.authority?.displayName,
      'Потребителско име': item.userName,
      Име: item.name,
      Email: item.email,
      Позиция: item.position,
      Роли: item.userRoles,
      Активен: item.isActive
    };
  }
}
