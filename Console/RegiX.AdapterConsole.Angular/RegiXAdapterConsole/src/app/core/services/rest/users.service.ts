import { CrudService } from '@tl/tl-common';
import { UsersModel } from '../../models/dto/users.model';
import { Injectable, Injector } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService extends CrudService<UsersModel, number> {
  constructor(injector: Injector) {
    super(UsersModel, injector, 'users');
  }

  getUsersByOperation(id: number): Observable<any> {
    return this.http
      .get<any>(this.url + '/getUsersByOperation' + '/' + id);
  }
}
