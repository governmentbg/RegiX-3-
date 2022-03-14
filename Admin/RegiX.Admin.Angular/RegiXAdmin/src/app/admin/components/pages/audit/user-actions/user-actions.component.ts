import { Component, Injector } from '@angular/core';
import { UserActionModel } from 'src/app/core/models/dto/user-action.model';
import { UserActionsService } from 'src/app/core/services/rest/user-actions.service';
import { RemoteComponentWithForm } from '@tl/tl-common';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DatеFormatService } from 'src/app/core/services/date-format.service';

@Component({
  selector: 'app-user-actions',
  templateUrl: './user-actions.component.html',
  styleUrls: ['./user-actions.component.scss'],
})
export class UserActionsComponent extends RemoteComponentWithForm<
  UserActionModel,
  UserActionsService
> {
  public routes = ROUTES;

  constructor(
    service: UserActionsService,
    injector: Injector,
    public dateFormatService: DatеFormatService
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {}

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {},
      this.service,
      this.grid,
      this.injector
    );
  }
  protected excelExportMapItem(item: UserActionModel){
    return {
      Потребител: item.userName,
      Тип: item.userActionType,
      Действие: item.userActionText,
      'Дата на действие': this.dateFormatService.formatForExport(item.userActionTime),
      Статус: item.executeStatus,
      Контролер: item.controller,
      Метод: item.actionMethod,
      URL: item.url
    };
  }
}
