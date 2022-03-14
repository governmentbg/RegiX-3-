import { Component, OnInit, Input, Injector } from '@angular/core';
import { EActions } from 'src/app/admin/enums/actions.enum';
import { UserToReportModel } from 'src/app/core/models/dto/user-to-report.model';
import { UsersToReportService } from 'src/app/core/services/rest/users-to-report.service';
import { RemoteComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { TableFilter } from 'src/app/core/models/filters/table-filter.model';
import { EColumnType } from 'src/app/admin/enums/column.type.enum';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ESourceTable } from 'src/app/admin/enums/source.table.enum';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';

@Component({
  selector: 'app-user-to-reports',
  templateUrl: './user-to-reports.component.html',
  styleUrls: ['./user-to-reports.component.scss'],
})
export class UserToReportsComponent extends RemoteComponentWithForm<
  UserToReportModel,
  UsersToReportService
> {
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();

  @Input()
  objectId: number;

  @Input()
  sourceTable: ESourceTable;

  @Input()
  title = 'Услуги на потребител';

  @Input()
  formType: EActions;

  objectName = 'услуга на потребител';

  constructor(
    service: UsersToReportService,
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
