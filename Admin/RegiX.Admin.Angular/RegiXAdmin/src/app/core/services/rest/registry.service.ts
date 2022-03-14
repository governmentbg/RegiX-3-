import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { RegistryModel } from '../../models/dto/registy.model';

@Injectable({
  providedIn: 'root'
})
export class RegistryService extends CrudService<RegistryModel, number> {
  constructor(injector: Injector) {
    super(RegistryModel, injector, 'registers');
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      administration: 'administration.displayName'
    };
  }
}
