import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { ConsumerProfileUsersModel } from '../../models/dto/consumer-profile-users.model';

@Injectable({
  providedIn: 'root',
})
export class ConsumerProfileUsersService extends CrudService<
ConsumerProfileUsersModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerProfileUsersModel, injector, 'consumer-profile-users');
  }

  //Removed order by id because the model has no id
  protected addOrderBy(params?: HttpParams): HttpParams {
    if (!params) {
      params = new HttpParams();
    }  
    return params;
  }
}