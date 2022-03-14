import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { AdapterModel } from '../../models/dto/adapters.model';

@Injectable({
  providedIn: 'root'
})
export class AdaptersService extends CrudService<AdapterModel, number> {
  constructor(injector: Injector) {
    super(AdapterModel, injector, 'register-adapters');
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      register: 'register.displayName'
    };
  }
}
