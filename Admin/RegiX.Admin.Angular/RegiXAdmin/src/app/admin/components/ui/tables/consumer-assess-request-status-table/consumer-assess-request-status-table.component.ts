import { Component, Injector, Input } from '@angular/core';
import { RemoteComponentWithForm, GridRemoteFilteringService, EColumnType, TableFilter } from '@tl/tl-common';
import { ConsumerAccessRequstsStatusModel } from 'src/app/core/models/dto/consumer-access-requests-status.model';
import { ConsumerAccessRequstsStatusService } from 'src/app/core/services/rest/consumer-access-requsts-status.service';
import { Params } from '@angular/router';

@Component({
  selector: 'app-consumer-assess-request-status-table',
  templateUrl: './consumer-assess-request-status-table.component.html',
  styleUrls: ['./consumer-assess-request-status-table.component.scss']
})
export class ConsumerAssessRequestStatusTableComponent extends RemoteComponentWithForm<
ConsumerAccessRequstsStatusModel,
ConsumerAccessRequstsStatusService
> {
  isDataLoading = false;
  isDataLoaded = false;
  @Input()
  consumerAccessRequest: number;

  public Status: any = { 0: 'Нов', 1: 'Входиран', 2: 'Отхвърлен', 3: 'Съгласуван', 4: 'Одобрен' }; //TODO: Fix th e index //TODO: Fix the index

  constructor(service: ConsumerAccessRequstsStatusService, injector: Injector) {
    super(service, injector);
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {},
      this.service,
      this.grid,
      this.injector
    );
  }

  protected getIDField(): string {
    return this.consumerAccessRequest.toString();
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }

  //filter by consumerAccessRequestId
  protected initializeFilterWithParams(params: Params){
    const filterField = 'consumerAccessRequestId';
    const idField = this.getIDField();
    this.filter = new TableFilter({
      columnName: filterField,
      columnValue: idField,
      columnType: this.getFilterColumnType()
    });
    this.backService.isBackVisible(true);
  }
}
