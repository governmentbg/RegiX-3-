import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ConsumerCertificateModel } from '../../models/dto/consumer-certificate.model';
import { HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConsumerCertificatesService extends CrudService<
  ConsumerCertificateModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerCertificateModel, injector, 'consumer-certificates');
  }

  protected addOrderBy(params?: HttpParams): HttpParams {
    if (!params) {
      params = new HttpParams();
    }
    return params;
  }

  swapCertificates(sourceId: number, destionationId: number): Observable<ConsumerCertificateModel> {
    return this.http
      .get<ConsumerCertificateModel>(this.url + '/' + 'SwapCertificates' + '/' + sourceId + '/' + destionationId)
      .pipe(map(item => new this.createT(item)));
  }
}
