import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { AdapterOperationModel } from '../../models/dto/adapter-operation.model';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

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

  public getAllForAdapter(
    adapterId: number
  ): Observable<AdapterOperationModel[]> {
    return this.http
      .get<AdapterOperationModel[]>(
        this.url + '/getAll' + '?$filter=RegisterAdapterId eq ' + adapterId
      )
      .pipe(
        map((items: AdapterOperationModel[]) => {
          return items.map(item => {
            const newObj = new this.createT(item);
            return newObj;
          });
        })
      );
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      registerAdapter: 'registerAdapter.displayName'
    };
  }
}
