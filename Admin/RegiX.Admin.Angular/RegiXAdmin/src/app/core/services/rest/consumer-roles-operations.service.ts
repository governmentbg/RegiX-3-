import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ConsumerRoleOperationModel } from '../../models/dto/consumer-role-operation.model';

@Injectable({
  providedIn: 'root'
})
export class ConsumerRolesOperationsService extends CrudService<
ConsumerRoleOperationModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerRoleOperationModel, injector, 'consumer-role-operation-access');
  }
}
