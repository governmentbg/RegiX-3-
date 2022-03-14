import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ConsumerAccessRequestsModel } from '../../models/dto/consumer-access-requests.model';

@Injectable({
  providedIn: 'root',
})
export class ConsumerAccessRequestsService extends CrudService<
  ConsumerAccessRequestsModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerAccessRequestsModel, injector, 'consumer-access-requests');
  }
}
