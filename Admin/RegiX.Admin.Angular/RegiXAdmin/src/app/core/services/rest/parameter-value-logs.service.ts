import { Injectable, Injector } from '@angular/core';
import { CrudService} from '@tl/tl-common';
import { ParameterValueLogModel } from '../../models/dto/parameter-value-log.model';

@Injectable({
  providedIn: 'root'
})
export class ParameterValueLogsService extends CrudService<
  ParameterValueLogModel,
  number
> {
  constructor(injector: Injector) {
    super(ParameterValueLogModel, injector, 'parameters-values-log');
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      registerAdapter: 'registerAdapter.displayName'
    };
  }
}
