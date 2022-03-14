import { Component, OnInit, Injector } from '@angular/core';
import { AdaptersService } from 'src/app/core/services/rest/adapters.service';
import { RemoteComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import {
  SortingDirection,
  ConnectedPositioningStrategy,
  HorizontalAlignment,
  VerticalAlignment,
  NoOpScrollStrategy
} from 'igniteui-angular';
import { AdapterOperationModel } from 'src/app/core/models/dto/adapter-operation.model';
import { AdapterOperationsService } from 'src/app/core/services/rest/adapter-operations.service';
import { ETables } from 'src/app/admin/enums/tables.enum';
import { EColumnType } from '@tl/tl-common';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';

@Component({
  selector: 'app-operations',
  templateUrl: './operations.component.html',
  styleUrls: ['./operations.component.scss']
})
export class OperationsComponent extends RemoteComponentWithForm<
  AdapterOperationModel,
  AdapterOperationsService
> {
  public routes = ROUTES;
  public ADAPTER_OPERATIONS = ETables.ADAPTER_OPERATIONS.toLowerCase();
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  title: string;
  subtitle: string;
  objectName = 'операция';
  pageTitle = 'Операции';

  constructor(
    service: AdapterOperationsService,
    private adapterService: AdaptersService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService
  ) {
    super(service, injector);
  }

  protected getFilterField(): string{
    return 'ADA_ID';
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'name', dir: SortingDirection.Asc }
    // ];
    if (this.filter) {
      if (!this.isIDFilter) {
        this.adapterService.find(this.filter.columnValue).subscribe(data => {
          if (data) {
            this.pageTitle = 'Операции на "' + data.name + '"';
            this.subtitle = this.pageTitle;
          }
        });
      } else {
        this.pageTitle = 'Операция с ID: ' + this.filter.columnValue;
        this.subtitle = this.pageTitle;
      }
    } else {
      this.pageTitle = 'Операции';
      this.subtitle = null;
    }
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {
        registerAdapter: 'registerAdapter.displayName',
        registerObject: 'registerObject.displayName'
      },
      this.service,
      this.grid,
      this.injector
    );
  }

  protected getFilterColumn(): string {
    return 'registerAdapter.id';
  }

  protected getIdColumn(): string {
    return 'Id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }

  protected excelExportMapItem(item: AdapterOperationModel){
    return {
      // Ид: item.id,
      Име: item.name,
      Адаптер: item.registerAdapter?.displayName,
      registerObject: item.registerObject?.displayName,
      Описание: item.description,
    };
  }
}
