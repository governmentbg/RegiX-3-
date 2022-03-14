import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ConsumerRequestOperationsModel } from '../../models/dto/consumer-request-operations.model';


@Injectable({
  providedIn: 'root'
})
export class ConsumerRequestOperationsService extends CrudService<
ConsumerRequestOperationsModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerRequestOperationsModel, injector, 'consumer-request-operations');
  }
}