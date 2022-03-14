import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ConsumerRequestStatusModel } from '../../models/dto/consumer-request-status.model';

@Injectable({
  providedIn: 'root',
})
export class ConsumerRequestStatusService extends CrudService<
ConsumerRequestStatusModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerRequestStatusModel, injector, 'consumer-request-status');
  }
}