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

  getAllForUser(id: number): Observable<any> {
    return this.http
      .get<any>(this.url + '/operationsForUser' + '/' + id);
  }
}
