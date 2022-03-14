import { CrudService } from '@tl/tl-common';
import { ConsumerRequestElementsModel } from '../models/consumer-request-elements.model';
import { Injector, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ConsumerRequestElementsService extends CrudService<
  ConsumerRequestElementsModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerRequestElementsModel, injector, 'consumer-request-elements');
  }
}
