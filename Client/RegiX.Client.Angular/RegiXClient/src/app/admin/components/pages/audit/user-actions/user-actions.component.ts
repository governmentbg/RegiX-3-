import { Component, OnInit, Injector } from '@angular/core';
import { UserActionModel } from 'src/app/core/models/dto/user-action.model';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { RemoteComponentWithForm } from '@tl/tl-common';
import { UserActionsService } from 'src/app/core/services/rest/user-actions.service';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DatеFormatService } from 'src/app/core/services/datе-format.service';

@Component({
  selector: 'app-user-actions',
  templateUrl: './user-actions.component.html',
  styleUrls: ['./user-actions.component.scss'],
})
export class UserActionsComponent extends RemoteComponentWithForm<
  UserActionModel,
  UserActionsService
> {
  title: string;
  objectName = 'потребителско действие';
  public routes = ROUTES;

  constructor(
    service: UserActionsService,
    injector: Injector,
    public dateFormatService: DatеFormatService
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'id', dir: SortingDirection.Desc }
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

  protected excelExportMapItem(item: UserActionModel) {
    return {
      // Ид: item.id,
      Потребител: item.userName,
      Тип: item.userActionType,
      Действие: item.userActionText,
      Статус: item.executeStatus,
      Контролер: item.controller,
      Метод: item.actionMethod,
      URL: item.url
    };
  }
}
