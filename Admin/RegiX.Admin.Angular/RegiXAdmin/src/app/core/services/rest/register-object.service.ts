import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { RegisterObjectModel } from '../../models/dto/register-object.model';


@Injectable({
  providedIn: 'root'
})
export class RegisterObjectService extends CrudService<
RegisterObjectModel,
  number
> {
  constructor(injector: Injector) {
    super(RegisterObjectModel, injector, 'register-objects');
  }
}
