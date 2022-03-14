import { CrudService } from '@tl/tl-common';
import { ConsumerModel } from '../models/consumer.model';
import { Injector, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConsumerService extends CrudService<
ConsumerModel,
number
> {
  constructor(injector: Injector) {
    super(ConsumerModel, injector, 'ConsumerProfile');
  }
}
