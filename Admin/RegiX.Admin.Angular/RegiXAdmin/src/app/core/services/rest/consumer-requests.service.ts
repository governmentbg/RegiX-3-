import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ConsumerRequestsModel } from '../../models/dto/consumer-requests.model';

@Injectable({
  providedIn: 'root',
})
export class ConsumerRequestsService extends CrudService<
  ConsumerRequestsModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerRequestsModel, injector, 'consumer-requests');
  }
}
