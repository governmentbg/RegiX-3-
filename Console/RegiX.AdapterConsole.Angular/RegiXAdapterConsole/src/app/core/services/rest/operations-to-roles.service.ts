import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { OperationsToRolesModel } from '../../models/dto/operations-to-roles.model';

@Injectable({
  providedIn: 'root'
})
export class OperationsToRolesService extends CrudService<
  OperationsToRolesModel,
  number
> {
  constructor(injector: Injector) {
    super(OperationsToRolesModel, injector, 'operations-to-roles');
  }
}
