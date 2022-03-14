import { CrudService } from '@tl/tl-common';
import { ConsumerSystemsModel } from '../models/consumer-systems.model';
import { Injector, Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ConsumerSystemsService extends CrudService<ConsumerSystemsModel, number> {
  constructor(injector: Injector) {
    super(ConsumerSystemsModel, injector, 'consumer-systems');
  }
}
