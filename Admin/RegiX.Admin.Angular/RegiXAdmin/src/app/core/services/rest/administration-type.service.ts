import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { AdministrationTypeModel } from '../../models/dto/administration-type.model';

@Injectable({
  providedIn: 'root'
})
export class AdministrationTypeService extends CrudService<
  AdministrationTypeModel,
  number
> {
  constructor(injector: Injector) {
    super(AdministrationTypeModel, injector, 'administration-types');
  }
}
