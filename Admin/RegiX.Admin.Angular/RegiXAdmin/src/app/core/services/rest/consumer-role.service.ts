import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ConsumerRoleModel } from '../../models/dto/consumer-role.model';


@Injectable({
  providedIn: 'root'
})
export class ConsumerRoleService extends CrudService<
ConsumerRoleModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerRoleModel, injector, 'consumer-roles');
  }
}
