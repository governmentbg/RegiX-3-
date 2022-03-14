import { UsersToRoleService } from './rest/users-to-role.service';
import { OperationsToRolesModel } from 'src/app/core/models/dto/operations-to-roles.model';
import { ActivatedRoute } from '@angular/router';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { AdapterOperationsService } from './rest/adapter-operations.service';
import {
  IgxGridComponent,
  IgxTreeGridComponent,
} from 'igniteui-angular';
import { HttpParams } from '@angular/common/http';
import { Injector } from '@angular/core';
import { map } from 'rxjs/operators';
import { RoleModel } from '../models/dto/role.model';
import { RolesService } from './rest/roles.service';
import { UserToRoleModel } from '../models/dto/user-to-role.model';

export class UserToRolesGridRemoteFilteringService extends GridRemoteFilteringService<
RoleModel,
RolesService
> {
  constructor(
    sortKeys: any,
    protected service: RolesService,
    protected grid: IgxGridComponent | IgxTreeGridComponent,
    injector: Injector,
    private operationsToRolesService: UsersToRoleService,
    private activatedRoute: ActivatedRoute
  ) {
    super(sortKeys, service, grid, injector);
  }

  //marks the operations that this role has access to 
  protected setSelectedRows() {
    let params = new HttpParams();
    params = params.append(
      '$filter',
      `user.id eq ${this.activatedRoute.snapshot.params['ID']}`
    );
    this.operationsToRolesService
      .getAllNoWrap(params)
      .pipe(
        map((items: UserToRoleModel[]) => {
            return items.map(item => {           
                return item.role.id;
              });
        })
      )
      .subscribe((data) => {
        const selection = data;

        // this._grid.selectRows(this._grid.selectedRows(), true);
        this._grid.deselectAllRows();
        this._grid.selectRows(selection, true);
        this.logger.debug('setSelectedRows', this._grid.selectedRows);
      });
  }
}
