import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ConsumerProfilesModel } from '../../models/dto/consumer-profiles.model';
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ConsumerProfilesService extends CrudService<
  ConsumerProfilesModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerProfilesModel, injector, 'consumer-profiles');
  }

  // protected addOrderBy(params?: HttpParams): HttpParams {
  //   if (!params) {
  //     params = new HttpParams();
  //   }  
  //   if (!params.has('$orderby')) {
  //     params = params.append('$orderby', 'status asc');
  //   }
  //   return params;
  // }
}
