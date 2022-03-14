import { CrudService } from '@tl/tl-common';
import { ConsumerSystemsModel } from '../models/consumer-systems.model';
import { Injector, Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { CertificateModel } from '../models/certificate.model';

@Injectable({
  providedIn: 'root'
})
export class CertificateService extends CrudService<CertificateModel, number> {
  constructor(injector: Injector) {
    super(CertificateModel, injector, 'consumer-system-certificates');
  }
}
