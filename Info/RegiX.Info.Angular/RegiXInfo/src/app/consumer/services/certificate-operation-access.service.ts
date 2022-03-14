import { Injectable, Injector } from '@angular/core';
import { CrudService } from '@tl/tl-common';
import { CertificateOperationAccessModel } from '../models/certificate-operation-access.model';
import { map } from 'rxjs/operators';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CertificateOperationAccessService extends CrudService<
  CertificateOperationAccessModel,
  number
> {
  constructor(injector: Injector) {
    super(
      CertificateOperationAccessModel,
      injector,
      'certificate-operation-access'
    );
  }

  getAllByCertificate(certificateId: number,params?: HttpParams): Observable<CertificateOperationAccessModel[]> {
    const _params = this.addOrderBy(params);

    this.isLoading = true;
    return this.http.post<CertificateOperationAccessModel[]>(this.url + '/GetAllByCertificate'+ '/' + certificateId, { params: _params })
    .pipe(
      map((items: CertificateOperationAccessModel[]) => {
        const newItems = items['data'].map(item => {
          const newObj = new this.createT(item);
          return newObj;
        });
        items['data'] = newItems;
        this.isLoading = false;
        return items;
      })
    );
  }


}
