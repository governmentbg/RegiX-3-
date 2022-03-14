import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ConsumerProfileStatusModel } from '../../models/dto/consumer-profile-status.model';

@Injectable({
  providedIn: 'root',
})
export class ConsumerProfileStatusService extends CrudService<
ConsumerProfileStatusModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerProfileStatusModel, injector, 'consumer-profile-status');
  }
}