import { Injectable, Injector } from '@angular/core';
import { NotRegisterAdapterModel } from '../../models/dto/not-register-adapter.model';
import { CrudService} from '@tl/tl-common';

@Injectable({
  providedIn: 'root'
})
export class NotRegisterAdaptersService extends CrudService<NotRegisterAdapterModel, string> {
  constructor(injector: Injector) {
    super(NotRegisterAdapterModel, injector, 'not-register-adapters');
  }
}
