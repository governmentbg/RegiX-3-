import { AdapterOpetationsToRoleModel } from '../../models/dto/adapter-opetations-to-role.model';
import { Injector, Injectable } from '@angular/core';
import { CrudService } from '@tl/tl-common';

@Injectable({
    providedIn: 'root'
  })
  export class AdapterOpetationsToRoleService extends CrudService<
    AdapterOpetationsToRoleModel,
    number
  > {
    constructor(injector: Injector) {
      super( AdapterOpetationsToRoleModel, injector, 'operations-to-roles');
    }
  }
