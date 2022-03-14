import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { UserToRoleModel } from '../../models/dto/user-to-role.model';
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UsersToRoleService extends CrudService<UserToRoleModel, number> {
  constructor(injector: Injector) {
    super(UserToRoleModel, injector, 'users-to-roles');
  }

  // addOrderBy(params?: HttpParams): HttpParams {
  //   if (!params) {
  //     params = new HttpParams();
  //   }
  //   if (!params.has('$orderby')) {
  //     params = params.append('$orderby', 'userId desc');
  //   }

  //   return params;
  // }
}
