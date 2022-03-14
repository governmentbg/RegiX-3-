import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ConsumerRoleElementAccessModel } from '../../models/dto/consumer-role-element-access.model';

@Injectable({
  providedIn: 'root'
})
export class ConsumerRoleElementAccessService extends CrudService<
ConsumerRoleElementAccessModel,
  number
> {
  constructor(injector: Injector) {
    super(
    ConsumerRoleElementAccessModel,
      injector,
      'consumer-role-element-access'
    );
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      registerObjectElement: 'registerObjectElement.displayName'
    };
  }
}
