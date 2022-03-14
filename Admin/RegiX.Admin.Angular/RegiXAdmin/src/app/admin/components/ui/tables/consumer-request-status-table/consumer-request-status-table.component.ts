import { Component, OnInit, Input, Injector } from '@angular/core';
import { RemoteComponentWithForm, GridRemoteFilteringService, EColumnType, TableFilter } from '@tl/tl-common';
import { ConsumerRequestStatusModel } from 'src/app/core/models/dto/consumer-request-status.model';
import { ConsumerRequestStatusService } from 'src/app/core/services/rest/consumer-request-status.service';
import { Params } from '@angular/router';
import { ConsumerProfilesStatus } from 'src/app/admin/enums/consumer-profiles-status.enum';
import { ConsumerRequestsStatus } from 'src/app/admin/enums/consumer-requests-status.enum';

@Component({
  selector: 'app-consumer-request-status-table',
  templateUrl: './consumer-request-status-table.component.html',
  styleUrls: ['./consumer-request-status-table.component.scss']
})
export class ConsumerRequestStatusTableComponent extends RemoteComponentWithForm<
ConsumerRequestStatusModel,
ConsumerRequestStatusService
> {
  isDataLoading = false;
  isDataLoaded = false;
  @Input()
  consumerRequest: number;

  public Status: any = {
    0: ConsumerRequestsStatus.DRAFT,//DRAFT shouldnt be shown
    1: ConsumerRequestsStatus.NEW,
    2: ConsumerRequestsStatus.DECLINED,
    3: ConsumerRequestsStatus.ACCEPTED,
  };

  constructor(service: ConsumerRequestStatusService, injector: Injector) {
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
  
  protected getFilterField(): string {
    return 'ID';
  }

  protected getFilterColumn(): string {
    return 'consumerRequestId';
  }

  protected getIdColumn(): string {
    return 'id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }
}
