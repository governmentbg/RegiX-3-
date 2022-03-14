import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ConsumerRequestElementsModel } from '../../models/dto/consumer-request-elements.model';

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
