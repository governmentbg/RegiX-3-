import { Component, OnInit, Input, Injector } from '@angular/core';
import { UserToRoleModel } from 'src/app/core/models/dto/user-to-role.model';
import { UsersToRoleService } from 'src/app/core/services/rest/users-to-role.service';
import { RemoteComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { EActions } from 'src/app/admin/enums/actions.enum';
import { TableFilter } from 'src/app/core/models/filters/table-filter.model';
import { EColumnType } from 'src/app/admin/enums/column.type.enum';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ESourceTable } from 'src/app/admin/enums/source.table.enum';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';

@Component({
  selector: 'app-user-to-roles',
  templateUrl: './user-to-roles.component.html',
  styleUrls: ['./user-to-roles.component.scss'],
})
export class UserToRolesComponent extends RemoteComponentWithForm<
  UserToRoleModel,
  UsersToRoleService
> {
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();

  @Input()
  objectId: number;

  @Input()
  sourceTable: ESourceTable;

  @Input()
  formType: EActions;

  @Input()
  title = 'Роли на потребител';

  objectName = 'достъп до услуги';

  constructor(
    service: UsersToRoleService,
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
