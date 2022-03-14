import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { AccessReportFilterModel } from '../../models/dto/access-report-filter.model';
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AccessReportFilterService extends CrudService<AccessReportFilterModel, number> {
  constructor(injector: Injector) {
    super(AccessReportFilterModel, injector, 'access-report-filter');
  }

  //Removed order by id because the model has no id
  protected addOrderBy(params?: HttpParams): HttpParams {
    if (!params) {
      params = new HttpParams();
    }  
    return params;
  }
}