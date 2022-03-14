import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ApiServiceOperationModel } from '../../models/dto/api-service-operation.model';

@Injectable({
  providedIn: 'root',
})
export class ApiServiceOperationService extends CrudService<
  ApiServiceOperationModel,
  number
> {
  constructor(injector: Injector) {
    super(ApiServiceOperationModel, injector, 'api-service-operations');
  }
}
