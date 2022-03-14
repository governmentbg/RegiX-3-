import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { UserActionModel } from '../../models/dto/user-action.model';

@Injectable({
  providedIn: 'root'
})
export class UserActionsService extends CrudService<UserActionModel, number> {
  constructor(injector: Injector) {
    super(UserActionModel, injector, 'audit-user-actions');
  }
}
