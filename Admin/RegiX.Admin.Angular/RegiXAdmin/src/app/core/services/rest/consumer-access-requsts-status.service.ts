import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ConsumerAccessRequstsStatusModel } from '../../models/dto/consumer-access-requests-status.model';


@Injectable({
  providedIn: 'root'
})
export class ConsumerAccessRequstsStatusService extends CrudService<
ConsumerAccessRequstsStatusModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerAccessRequstsStatusModel, injector, 'consumer-access-requests-status');
  }
}