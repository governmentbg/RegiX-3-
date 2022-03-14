import { OperationsToRolesModel } from 'src/app/core/models/dto/operations-to-roles.model';
import { ActivatedRoute } from '@angular/router';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { AdapterOperationModel } from '../models/dto/adapter-operation.model';
import { AdapterOperationsService } from './rest/adapter-operations.service';
import {
  IgxGridComponent,
  IgxTreeGridComponent,
} from 'igniteui-angular';
import { HttpParams } from '@angular/common/http';
import { Injector } from '@angular/core';
import { OperationsToRolesService } from './rest/operations-to-roles.service';
import { map } from 'rxjs/operators';

export class ReportSelectGridRemoteFilteringService extends GridRemoteFilteringService<
  AdapterOperationModel,
  AdapterOperationsService
> {
  constructor(
    sortKeys: any,
    protected service: AdapterOperationsService,
    protected grid: IgxGridComponent | IgxTreeGridComponent,
    injector: Injector,
    private operationsToRolesService: OperationsToRolesService,
    private activatedRoute: ActivatedRoute
  ) {
    super(sortKeys, service, grid, injector);
  }

  //marks the operations that this role has access to 
  protected setSelectedRows() {
    let params = new HttpParams();
    params = params.append(
      '$filter',
      `role.id eq ${this.activatedRoute.snapshot.params['ID']}`
    );
    this.operationsToRolesService
      .getAllNoWrap(params)
      .pipe(
        map((items: OperationsToRolesModel[]) => {
            return items.map(item => {           
                return item.adapterOperation.id;
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
