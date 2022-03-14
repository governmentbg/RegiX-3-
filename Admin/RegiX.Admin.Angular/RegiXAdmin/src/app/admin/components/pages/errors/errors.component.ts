import { Component, OnInit, Injector } from '@angular/core';
import { RemoteComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { OperationErrorLogModel } from 'src/app/core/models/dto/operation-error-log.model';
import { OperationsErrorLogService } from 'src/app/core/services/rest/operations-error-log.service';
import { SortingDirection } from 'igniteui-angular';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DatеFormatService } from 'src/app/core/services/date-format.service';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';

@Component({
  selector: 'app-errors',
  templateUrl: './errors.component.html',
  styleUrls: ['./errors.component.scss'],
})
export class ErrorsComponent extends RemoteComponentWithForm<
  OperationErrorLogModel,
  OperationsErrorLogService
> {
  public routes = ROUTES;
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();

  constructor(
    service: OperationsErrorLogService,
    injector: Injector,
    public dateFormatService: DatеFormatService,
    public displayValueService: DisplayValueFormatService
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'logTime', dir: SortingDirection.Desc }
    // ];
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {
        apiServiceCall: 'apiServiceCall.displayName',
      adapterOperation: 'adapterOperation.displayName',
      consumerCertificate: 'consumerCertificate.displayName',
      apiServiceConsumer: 'apiServiceConsumer.displayName',
      administration: 'administration.displayName',
      },
      this.service,
      this.grid,
      this.injector
    );
  }

  protected excelExportMapItem(item: OperationErrorLogModel){
    return {
      // Ид: item.id,
      'Операция на адаптер': item.adapterOperation,
      'Операция на интерфейс': item.apiServiceCall,
      Консуматор: item.apiServiceConsumer,
      'Сертификат на консуматор': item.consumerCertificate,
      'Администрация на консуматор': item.administration,
      'Време на грешката': this.dateFormatService.formatForExport(item.logTime),
      Грешка: item.errorMessage,
    };
  }
}
