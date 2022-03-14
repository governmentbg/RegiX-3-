import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ReturnedCallModel } from '../../models/dto/returned-call.model';

@Injectable({
  providedIn: 'root'
})
export class ReturnedCallsService extends CrudService<
  ReturnedCallModel,
  number
> {
  constructor(injector: Injector) {
    super(ReturnedCallModel, injector, 'returned-calls');
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      adapterOperation: 'adapterOperation.displayName',
      returnedBy: 'returnedBy.displayName',
    };
  }
}
