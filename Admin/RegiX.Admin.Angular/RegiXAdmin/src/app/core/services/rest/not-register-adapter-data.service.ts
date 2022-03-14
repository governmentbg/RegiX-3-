import { Injectable, Injector } from '@angular/core';
import { CrudService} from '@tl/tl-common';
import { NotRegisterAdapterDataModel } from '../../models/dto/not-register-adapter-form-models/not-register-adapter-data.model';

@Injectable({
  providedIn: 'root'
})
export class NotRegisterAdapterDataService extends CrudService<NotRegisterAdapterDataModel, string> {
  constructor(injector: Injector) {
    super(NotRegisterAdapterDataModel, injector, 'not-register-adapters');
  }
}
