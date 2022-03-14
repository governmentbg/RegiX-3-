import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { CertificateElementAccessModel } from '../../models/dto/certificate-element-access.model';

@Injectable({
  providedIn: 'root'
})
export class CertificateElementAccessService extends CrudService<
  CertificateElementAccessModel,
  number
> {
  constructor(injector: Injector) {
    super(
      CertificateElementAccessModel,
      injector,
      'certificate-element-access'
    );
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      consumerCertificate: 'consumerCertificate.displayName',
      registerObjectElement: 'registerObjectElement.displayName',
    };
  }
}
