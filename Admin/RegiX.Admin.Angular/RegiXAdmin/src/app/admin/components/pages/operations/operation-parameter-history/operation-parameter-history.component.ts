import { Component, OnInit, Injector } from '@angular/core';
import { RemoteComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { SortingDirection } from 'igniteui-angular';
import { ParameterValueLogModel } from 'src/app/core/models/dto/parameter-value-log.model';
import { ParameterValueLogsService } from 'src/app/core/services/rest/parameter-value-logs.service';
import { EColumnType } from '@tl/tl-common';
import { AdapterOperationsService } from 'src/app/core/services/rest/adapter-operations.service';
import { AdaptersService } from 'src/app/core/services/rest/adapters.service';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';

@Component({
  selector: 'app-operation-parameter-history',
  templateUrl: './operation-parameter-history.component.html',
  styleUrls: ['./operation-parameter-history.component.scss']
})
export class OperationParameterHistoryComponent extends RemoteComponentWithForm<
  ParameterValueLogModel,
  ParameterValueLogsService
> {
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  routes = ROUTES;
  title: string;
  objectName = 'история на параметър';

  pageTitle = 'История на параметри';

  constructor(
    service: ParameterValueLogsService,
    private adapterService: AdaptersService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'editedTime', dir: SortingDirection.Desc }
    // ];
    if (this.filter) {
      if (!this.isIDFilter) {
        this.adapterService.find(this.filter.columnValue).subscribe(data => {
          if (data) {
            this.pageTitle = 'История на параметри за "' + data.name + '"';
          }
        });
      } else {
        this.pageTitle =
          'История на апраметър с ID: ' + this.filter.columnValue;
      }
    }
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      { registerAdapter: 'registerAdapter.displayName' },
      this.service,
      this.grid,
      this.injector
    );
  }

  protected getFilterColumn(): string {
    return 'registerAdapter.id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }
}
