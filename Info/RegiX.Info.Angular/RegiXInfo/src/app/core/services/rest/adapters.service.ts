import { CrudService } from '@tl/tl-common';
import { Injector, Injectable } from '@angular/core';
import { AdapterFilterModel } from '../../model/regix/adapter-filter.model';

@Injectable({
    providedIn: 'root'
  })
export class AdaptersService extends CrudService<AdapterFilterModel, number> {
    constructor(injector: Injector) {
      super(AdapterFilterModel, injector, 'register-adapters');
    }
  
    gridFilteringFields(): {
      [name: string]: string;
    } {
      return {
        register: 'register.displayName'
      };
    }
  }
  