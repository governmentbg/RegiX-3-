import { Component, OnInit, Injector, Input } from '@angular/core';
import { RemoteComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { RoleToReportModel } from 'src/app/core/models/dto/role-to-report.model';
import { RolesToReportService } from 'src/app/core/services/rest/ropes-to-report.service';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { TableFilter } from 'src/app/core/models/filters/table-filter.model';
import { EColumnType } from 'src/app/admin/enums/column.type.enum';
import { EActions } from 'src/app/admin/enums/actions.enum';
import { ESourceTable } from 'src/app/admin/enums/source.table.enum';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';

@Component({
  selector: 'app-roles-to-report',
  templateUrl: './roles-to-report.component.html',
  styleUrls: ['./roles-to-report.component.scss'],
})
export class RolesToReportComponent extends RemoteComponentWithForm<
  RoleToReportModel,
  RolesToReportService
> {
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  @Input()
  objectId: number;

  @Input()
  sourceTable: ESourceTable;

  @Input()
  formType: EActions;

  @Input()
  title = 'Достъп до услуги';

  objectName = 'достъп до услуги';

  constructor(
    service: RolesToReportService,
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

  initializeFilter() {
    this.isIDFilter = false;
    if (this.sourceTable === ESourceTable.USERS) {
      this.filter = new TableFilter({
        columnName: 'user.id',
        columnValue: this.objectId,
        columnType: EColumnType.DECIMAL,
      });
    } else if (this.sourceTable === ESourceTable.REPORTS) {
      this.filter = new TableFilter({
        columnName: 'report.id',
        columnValue: this.objectId,
        columnType: EColumnType.DECIMAL,
      });
    } else if (this.sourceTable === ESourceTable.ROLES) {
      this.filter = new TableFilter({
        columnName: 'role.id',
        columnValue: this.objectId,
        columnType: EColumnType.DECIMAL,
      });
    }
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
