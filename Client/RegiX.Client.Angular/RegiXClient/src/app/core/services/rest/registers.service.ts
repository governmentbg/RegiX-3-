import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { RegistryModel } from '../../models/dto/registry.model';

@Injectable({
  providedIn: 'root'
})
export class RegistersService extends CrudService<RegistryModel, number> {
  constructor(injector: Injector) {
    super(RegistryModel, injector, 'registers');
  }
}
