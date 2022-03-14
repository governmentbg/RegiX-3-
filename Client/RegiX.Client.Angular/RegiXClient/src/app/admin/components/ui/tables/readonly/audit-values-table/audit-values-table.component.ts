import { Component, OnInit, Input, Injector } from '@angular/core';
import { RemoteComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { AuditValueModel } from 'src/app/core/models/dto/audit-value.model';
import { AuditValuesService } from 'src/app/core/services/rest/audit-values.service';
import { TableFilter } from 'src/app/core/models/filters/table-filter.model';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { EColumnType } from 'src/app/admin/enums/column.type.enum';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';

@Component({
  selector: 'app-audit-values-table',
  templateUrl: './audit-values-table.component.html',
  styleUrls: ['./audit-values-table.component.scss'],
})
export class AuditValuesTableComponent extends RemoteComponentWithForm<
  AuditValueModel,
  AuditValuesService
> {
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  
  @Input()
  auditTableId: number;

  @Input()
  title = 'Промени на таблица';

  objectName = 'промяна на таблица';

  constructor(
    service: AuditValuesService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {}

  protected initializeFilter() {
    this.isIDFilter = false;

    this.filter = new TableFilter({
      columnName: 'auditTable.id',
      columnValue: this.auditTableId,
      columnType: EColumnType.DECIMAL,
    });
    this.afterFilterInitialized();
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

  isShowActions() {
    // return this.formType === EActions.EDIT;
    return false;
  }
}
