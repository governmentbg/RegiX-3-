import { Injectable, Injector } from '@angular/core';
import { CrudService } from '@tl/tl-common';
import { ConsumerProfileUsersApprovedModel } from '../models/consumer-profile-user-approved.model';

@Injectable({
    providedIn: 'root',
  })
  export class ConsumerProfileUsersApprovedService extends CrudService<
  ConsumerProfileUsersApprovedModel,
    number
  > {
    constructor(injector: Injector) {
      super(ConsumerProfileUsersApprovedModel, injector, 'consumer-profile-users-approved');
    }
  }