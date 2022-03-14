import { CrudService } from '@tl/tl-common';
import { Injector, Injectable } from '@angular/core';
import { ConsumerUserModel } from '../models/consumer-user.model';

@Injectable({
  providedIn: 'root'
})
export class ConsumerUserService extends CrudService<
ConsumerUserModel,
number
> {
  constructor(injector: Injector) {
    super(ConsumerUserModel, injector, 'consumer-users');
  }
}
