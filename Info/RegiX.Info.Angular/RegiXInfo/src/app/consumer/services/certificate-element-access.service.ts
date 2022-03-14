import { Injectable, Injector } from '@angular/core';
import { CrudService } from '@tl/tl-common';
import { CertificateElementAccessModel } from '../models/certificate-element-access.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CertificateElementAccessService extends CrudService<
CertificateElementAccessModel,
  number
> {
  constructor(injector: Injector) {
    super(CertificateElementAccessModel, injector, 'certificate-element-access');
  }

  GetCertificateElementAccess(adapterOperationId: number,consumerSystemCertificateId: number): Observable<any> {
    return this.http
      .post<any>(this.url + '/GetCertificateElementAccess'+ '/'+ consumerSystemCertificateId+ '/'+ adapterOperationId, null);
  }
}