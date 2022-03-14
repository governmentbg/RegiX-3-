import { DisplayValueFormatService } from './../../../../../core/services/display-value-format.service';
import { Component, OnInit, Injector } from '@angular/core';
import { RemoteComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { AuditValueModel } from 'src/app/core/models/dto/audit-value.model';
import { AuditValuesService } from 'src/app/core/services/rest/audit-values.service';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { EColumnType } from 'src/app/admin/enums/column.type.enum';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: 'app-audit-history',
  templateUrl: './audit-history.component.html',
  styleUrls: ['./audit-history.component.scss'],
})
export class AuditHistoryComponent extends RemoteComponentWithForm<
  AuditValueModel,
  AuditValuesService
> {
  title: string;
  objectName = 'таблица';
  pageTitle = 'История на промяна на таблици';
  public routes = ROUTES;
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();

  constructor(
    service: AuditValuesService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'id', dir: SortingDirection.Desc }
    // ];
    if (this.filter) {
      if (!this.isIDFilter) {
        this.pageTitle =
          'История на промяна на таблица (' + this.filter.columnValue + ')';
      }
    }
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      { auditTable: 'auditTable.displayName' },
      this.service,
      this.grid,
      this.injector
    );
  }

  protected getFilterColumn(): string {
    return 'audittableid';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }
}
