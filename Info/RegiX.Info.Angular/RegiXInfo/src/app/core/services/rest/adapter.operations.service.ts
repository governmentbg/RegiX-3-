import { Injectable, Injector } from '@angular/core';
import { CrudService } from '@tl/tl-common';
import { AdapterOperationFilterModel } from '../../model/regix/adapter-operation-filter.model';

@Injectable({
    providedIn: 'root'
  })
export class AdapterOperationsService extends CrudService<
  AdapterOperationFilterModel,
  number
> {
  constructor(injector: Injector) {
    super(AdapterOperationFilterModel, injector, 'adapter-operations');
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      registerAdapter: 'registerAdapter.displayName'
    };
  }
}