import { Component, OnInit, Injector } from '@angular/core';
import {
  RemoteComponentWithForm,
  GridRemoteFilteringService,
} from '@tl/tl-common';
import { ConsumerProfileStatusModel } from 'src/app/core/models/dto/consumer-profile-status.model';
import { ConsumerProfileStatusService } from 'src/app/core/services/rest/consumer-profile-status.service';

@Component({
  selector: 'app-consumer-profile-status-table',
  templateUrl: './consumer-profile-status-table.component.html',
  styleUrls: ['./consumer-profile-status-table.component.scss'],
})
export class ConsumerProfileStatusTableComponent extends RemoteComponentWithForm<
  ConsumerProfileStatusModel,
  ConsumerProfileStatusService
> {
  isDataLoading = false;
  isDataLoaded = false;

  public Status: any = { 0: 'Нов', 1: 'Отхвърлен', 2: 'Одобрен' }; //TODO: Fix the index

  constructor(service: ConsumerProfileStatusService, injector: Injector) {
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

  protected getIdColumn(): string {
    return 'consumerProfile.id';
  }
}
