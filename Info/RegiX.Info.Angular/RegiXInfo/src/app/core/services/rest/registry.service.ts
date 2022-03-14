import { RegistryModel } from '../../model/regix/registry.model';
import { CrudService } from '@tl/tl-common';
import { Injector, Injectable } from '@angular/core';


@Injectable({
    providedIn: 'root'
  })
export class RegistryService extends CrudService<RegistryModel, number> {
    constructor(injector: Injector) {
      super(RegistryModel, injector, 'registers-filter');
    }
  
    gridFilteringFields(): {
      [name: string]: string;
    } {
      return {
        administration: 'administration.displayName'
      };
    }
  }