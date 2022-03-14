import { Injectable, Injector } from '@angular/core';
import { CrudService } from '@tl/tl-common';
import { ConsumerProfileUsersModel } from '../models/consumer-profile-user.model';

@Injectable({
    providedIn: 'root',
  })
  export class ConsumerProfileUsersService extends CrudService<
  ConsumerProfileUsersModel,
    number
  > {
    constructor(injector: Injector) {
      super(ConsumerProfileUsersModel, injector, 'consumer-profile-users');
    }
  }