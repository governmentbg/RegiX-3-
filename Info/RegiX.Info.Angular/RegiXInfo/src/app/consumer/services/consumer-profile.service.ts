import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ConsumerProfileModel } from '../models/consumer-profile.model';

@Injectable({
  providedIn: 'root',
})
export class ConsumerProfileService extends CrudService<
ConsumerProfileModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerProfileModel, injector, 'consumer-profile');
  }
}