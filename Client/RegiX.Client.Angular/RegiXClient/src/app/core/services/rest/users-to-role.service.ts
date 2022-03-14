import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { UserToRoleModel } from '../../models/dto/user-to-role.model';

@Injectable({
  providedIn: 'root'
})
export class UsersToRoleService extends CrudService<UserToRoleModel, number> {
  constructor(injector: Injector) {
    super(UserToRoleModel, injector, 'users-to-roles');
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      user: 'user.displayName',
      role: 'role.displayName'
    };
  }
}
