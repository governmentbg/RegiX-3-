import { Component, OnInit, Injector } from '@angular/core';
import { AuditValueModel } from 'src/app/core/models/dto/audit-value.model';
import { AuditValuesService } from 'src/app/core/services/rest/audit-values.service';
import { RemoteComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { SortingDirection } from 'igniteui-angular';
import { EColumnType } from '@tl/tl-common';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';

@Component({
  selector: 'app-audit-history',
  templateUrl: './audit-history.component.html',
  styleUrls: ['./audit-history.component.scss'],
})
export class AuditHistoryComponent extends RemoteComponentWithForm<
  AuditValueModel,
  AuditValuesService
> {
  public routes = ROUTES;
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  pageTitle = 'История на промяна на таблици';

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
    return 'auditTable.id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }
}
