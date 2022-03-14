import { Component, Injector } from '@angular/core';
import {
  RemoteComponentWithForm,
  GridRemoteFilteringService,
} from '@tl/tl-common';
import { CONSUMER_ROUTES } from '../../routes/consumer-static-routes';
import { ConsumerSystemsModel } from '../../models/consumer-systems.model';
import { ConsumerSystemsService } from '../../services/consumer-systems.service';

@Component({
  selector: 'app-systems',
  templateUrl: './systems.component.html',
  styleUrls: ['./systems.component.scss'],
})
export class SystemsComponent extends RemoteComponentWithForm<
  ConsumerSystemsModel,
  ConsumerSystemsService
> {
  public routes = CONSUMER_ROUTES;

  constructor(service: ConsumerSystemsService, injector: Injector) {
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
}
