import { CertificateConsumerRoleModel } from './../../models/dto/certificate-consumer-role.model';
import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CertificateConsumerRoleService extends CrudService<
CertificateConsumerRoleModel,
  number
> {
  constructor(injector: Injector) {
    super(CertificateConsumerRoleModel, injector, 'certificate-consumer-role');
  }
}
