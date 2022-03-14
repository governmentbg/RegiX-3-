import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { CertificateOperationModel } from '../../models/dto/certificate-operation.model';

@Injectable({
  providedIn: 'root'
})
export class CertificateOperationsService extends CrudService<
  CertificateOperationModel,
  number
> {
  constructor(injector: Injector) {
    super(CertificateOperationModel, injector, 'certificate-operation-access');
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      adapterOperation: 'adapterOperation.displayName',
      adapterOperationDescription: 'adapterOperation.description'
    };
  }
}
