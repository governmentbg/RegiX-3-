import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { AccessReportFilterConsumerModel } from '../../models/dto/access-report-filter-consumer.model';

@Injectable({
  providedIn: 'root'
})
export class AccessReportFilterConsumerService extends CrudService<AccessReportFilterConsumerModel, number> {
  constructor(injector: Injector) {
    super(AccessReportFilterConsumerModel, injector, 'access-report-filter-consumer');
  }

  //Removed order by id because the model has no id
  protected addOrderBy(params?: HttpParams): HttpParams {
    if (!params) {
      params = new HttpParams();
    }  
    return params;
  }
}