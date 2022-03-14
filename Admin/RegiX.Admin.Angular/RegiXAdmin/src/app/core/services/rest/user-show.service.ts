import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { UserShowModel } from '../../models/dto/user-show.model';

@Injectable({
  providedIn: 'root'
})
export class UserShowService extends CrudService<UserShowModel, number> {
  constructor(injector: Injector) {
    super(UserShowModel, injector, 'users');
  }
}
