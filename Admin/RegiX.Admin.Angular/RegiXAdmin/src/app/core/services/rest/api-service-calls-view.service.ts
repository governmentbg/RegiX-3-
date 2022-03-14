import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { ApiServiceCallViewModel } from '../../models/dto/api-service-call-view.model';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceCallViewService extends CrudService<
  ApiServiceCallViewModel,
  number
> {
  constructor(injector: Injector) {
    super(ApiServiceCallViewModel, injector, 'api-service-calls-view');
  }

  protected addOrderBy(params?: HttpParams): HttpParams {
    if (!params) {
      params = new HttpParams();
    }  
    return params;
  }
}
