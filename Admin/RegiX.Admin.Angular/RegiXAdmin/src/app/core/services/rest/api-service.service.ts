import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ApiServiceModel } from '../../models/dto/api-service.model';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService extends CrudService<ApiServiceModel, number> {
  constructor(injector: Injector) {
    super(ApiServiceModel, injector, 'api-services');
  }
}
