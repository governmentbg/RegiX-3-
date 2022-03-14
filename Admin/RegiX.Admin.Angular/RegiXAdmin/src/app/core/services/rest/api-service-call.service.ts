import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ApiServiceCallModel } from '../../models/dto/api-service-call.model';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceCallService extends CrudService<
  ApiServiceCallModel,
  number
> {
  constructor(injector: Injector) {
    super(ApiServiceCallModel, injector, 'api-service-calls');
  }
}