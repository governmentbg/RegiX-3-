import { Injectable, Injector } from '@angular/core';
import { CrudService } from '@tl/tl-common';
import { ConsumerSystemCertificatesModel } from '../models/consumer-system-certificates.model';

@Injectable({
  providedIn: 'root',
})
export class ConsumerSystemCertificatesService extends CrudService<
ConsumerSystemCertificatesModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerSystemCertificatesModel, injector, 'consumer-system-certificates');
  }
}