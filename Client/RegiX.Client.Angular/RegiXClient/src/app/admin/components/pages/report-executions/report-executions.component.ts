import { Component, OnInit, Injector } from '@angular/core';
import { RemoteComponentWithForm } from '@tl/tl-common';
import { ReportExecutionsService } from 'src/app/core/services/rest/report-executions.service';
import { GridRemoteFilteringService, DisplayValueFilteringOperand } from '@tl/tl-common';
import { ReportExecutionsModel } from 'src/app/core/models/dto/report-executions.model';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { ClientPermissions } from 'src/app/admin/permissions';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';
import { DatеFormatService } from 'src/app/core/services/datе-format.service';

@Component({
  selector: 'app-report-executions',
  templateUrl: './report-executions.component.html',
  styleUrls: ['./report-executions.component.scss'],
})
export class ReportExecutionsComponent extends RemoteComponentWithForm<
  ReportExecutionsModel,
  ReportExecutionsService
> {
  title: string;
  objectName = 'потребителско действие';
  public routes = ROUTES;
  public adminRoles = ClientPermissions.ADMIN;
  public globalAdmin = ClientPermissions.GLOBAL_ADMIN;
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();

  constructor(
    public dateFormatService: DatеFormatService,
    public displayValueService: DisplayValueFormatService,
    service: ReportExecutionsService,
    injector: Injector) {
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

  protected excelExportMapItem(item: ReportExecutionsModel) {
    return {
      // Ид: item.id,
      Администрация: item.authority?.displayName,
      Потребител: item.user?.displayName,
      Услуга: item.report?.displayName,
      'Номер на извикване': item.apiServiceCallId,
      'Допълнителен идентификатор на служител': item.contextEmployeeAdditionalId,
      'Вид на услугата': item.contextServiceType,
      'Номер на преписка': item.contextServiceURI,
      'Правно основание': item.contextLawReason,
      Грешка: item.hasError,
      'Дата на изпълнение': this.dateFormatService.formatForExport(item.reportExecutionTime)
    };
  }
}
