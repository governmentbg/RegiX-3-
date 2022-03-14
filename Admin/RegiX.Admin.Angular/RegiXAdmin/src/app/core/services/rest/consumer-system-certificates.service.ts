import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ConsumerSystemCertificatesModel } from '../../models/dto/consumer-system-certificates.model';

@Injectable({
  providedIn: 'root'
})
export class ConsumerSystemCertificatesService extends CrudService<
ConsumerSystemCertificatesModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerSystemCertificatesModel, injector, 'consumer-system-certificates');
  }
}