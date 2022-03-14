import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ConsumerModel } from '../../models/dto/consumer.model';

@Injectable({
  providedIn: 'root'
})
export class ConsumersService extends CrudService<ConsumerModel, number> {
  constructor(injector: Injector) {
    super(ConsumerModel, injector, 'api-service-consumers');
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      administration: 'administration.displayName'
    };
  }
}
