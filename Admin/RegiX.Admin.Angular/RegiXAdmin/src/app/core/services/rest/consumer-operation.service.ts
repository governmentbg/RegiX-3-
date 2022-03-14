import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { RegisterObjectModel } from '../../models/dto/register-object.model';
import { ConsumerOperationModel } from '../../models/dto/consumer-operation.model';


@Injectable({
  providedIn: 'root'
})
export class ConsumerOperationService extends CrudService<
ConsumerOperationModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerOperationModel, injector, 'consumer-role-operation-access');
  }
}
