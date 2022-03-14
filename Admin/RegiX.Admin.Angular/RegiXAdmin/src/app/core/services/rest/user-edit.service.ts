import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { UserEditModel } from '../../models/dto/user-edit.model';

@Injectable({
  providedIn: 'root'
})
export class UserEditService extends CrudService<UserEditModel, number> {
  constructor(injector: Injector) {
    super(UserEditModel, injector, 'users');
  }
}
