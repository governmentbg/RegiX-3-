import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ConsumerSystemsModel } from '../../models/dto/consumer-systems.model';

@Injectable({
  providedIn: 'root'
})
export class ConsumerSystemsService extends CrudService<ConsumerSystemsModel, number> {
  constructor(injector: Injector) {
    super(ConsumerSystemsModel, injector, 'consumer-systems');
  }
}