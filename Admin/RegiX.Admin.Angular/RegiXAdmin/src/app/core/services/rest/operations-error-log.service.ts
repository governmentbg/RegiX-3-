import { Injectable, Injector } from '@angular/core';
import { OperationErrorLogModel } from '../../models/dto/operation-error-log.model';
import { CrudService} from '@tl/tl-common';

@Injectable({
  providedIn: 'root'
})
export class OperationsErrorLogService extends CrudService<
  OperationErrorLogModel,
  number
> {
  constructor(injector: Injector) {
    super(OperationErrorLogModel, injector, 'operations-error-log');
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      apiServiceCall: 'apiServiceCall.displayName',
      adapterOperation: 'adapterOperation.displayName',
      consumerCertificate: 'consumerCertificate.displayName',
     apiServiceConsumer: 'apiServiceConsumer.displayName',
      administration: 'administration.displayName',
    };
  }
}
