import { DisplayValueFormatService } from './../../../../../core/services/display-value-format.service';
import { Component, OnInit, Injector } from '@angular/core';
import { AuditExceptionModel } from 'src/app/core/models/dto/audit-exception.model';
import { AuditExceptionsService } from 'src/app/core/services/rest/audit-exceptions.service';
import { RemoteComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DatеFormatService } from 'src/app/core/services/datе-format.service';

@Component({
  selector: 'app-system-errors',
  templateUrl: './system-errors.component.html',
  styleUrls: ['./system-errors.component.scss'],
})
export class SystemErrorsComponent extends RemoteComponentWithForm<
  AuditExceptionModel,
  AuditExceptionsService
> {
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  routes = ROUTES;
  title: string;
  objectName = 'системна грешка';

  constructor(
    service: AuditExceptionsService,
    injector: Injector,
    public dateFormatService: DatеFormatService,
    public displayValueService: DisplayValueFormatService
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

  protected excelExportMapItem(item: AuditExceptionModel) {
    return {
      // Ид: item.id,
      Потребител: item.userName,
      Контролер: item.controller,
      Метод: item.actionMethod,
      Администрация: item.authorityName,
      Дата: this.dateFormatService.formatForExport(item.exceptionTime),
      Грешка: item.exceptionText
    };
  }
}
