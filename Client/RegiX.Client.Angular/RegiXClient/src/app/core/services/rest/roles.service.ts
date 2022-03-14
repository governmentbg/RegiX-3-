import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { RoleModel } from '../../models/dto/role.model';

@Injectable({
  providedIn: 'root'
})
export class RolesService extends CrudService<RoleModel, number> {
  constructor(injector: Injector) {
    super(RoleModel, injector, 'roles');
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      authority: 'authority.displayName',
      adapterOperation: 'adapterOperation.displayName',
    };
  }
}
