import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { AdapterOperationModel } from '../../models/dto/adapter-operation.model';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdapterOperationsService extends CrudService<
  AdapterOperationModel,
  number
> {
  constructor(injector: Injector) {
    super(AdapterOperationModel, injector, 'adapter-operations');
  }

  executeRequest(request: any): Observable<any> {
    return this.http
      .post<any>(this.url + '/executeRequest', request);
  }
}
