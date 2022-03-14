import { Component, Injector } from '@angular/core';
import { RemoteComponentWithForm } from '@tl/tl-common';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { AuditTableWithDataModel } from 'src/app/core/models/dto/audit-table-with-data.model';
import { AuditTablesWithDataService } from 'src/app/core/services/rest/audit-tables-with-data.service';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DatеFormatService } from 'src/app/core/services/date-format.service';

@Component({
  selector: 'app-audit',
  templateUrl: './audit.component.html',
  styleUrls: ['./audit.component.scss'],
})
export class AuditComponent extends RemoteComponentWithForm<
  AuditTableWithDataModel,
  AuditTablesWithDataService
> {
  public routes = ROUTES;
  pageTitle = ROUTES.AUDIT.title;
  subtitle: string;

  constructor(
    service: AuditTablesWithDataService,
    injector: Injector,
    public dateFormatService: DatеFormatService
  ) {
    super(service, injector);
  }

  protected getFilterField(): string {
    return 'TABLE_NAME';
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'id', dir: SortingDirection.Desc }
    // ];
    this.subtitle = null;
    if (this.filter) {
      if (!this.isIDFilter) {
        const tableName = '' + this.filter.columnValue;
        // tableName = ('"' + this.filter.columnValue + '"').toUpperCase();
        //  this.pageTitle = 'Одит на таблица ' + tableName;
        this.subtitle = `Таблица ${tableName.toUpperCase()}`;
      }
    }
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {},
      this.service,
      this.grid,
      this.injector
    );
  }

  onShowMenuSelected() {}

  protected getFilterColumn(): string {
    return 'tableName';
  }

  protected excelExportMapItem(item: AuditTableWithDataModel){
    return {
      // Ид: item.id,
      'Ид на потребител': item.userId,
      Потребител: item.userName,
      Дата: this.dateFormatService.formatForExport(item.auditDate),
      Действие: item.action,
      'Ид на таблица': item.tableId,
      Таблица: item.tableName,
      Приложение: item.ipAddress,
      Описание: item.description,
    };
  }
}
