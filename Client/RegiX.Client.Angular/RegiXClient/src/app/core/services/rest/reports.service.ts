import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ReportModel } from '../../models/dto/report.model';

@Injectable({
  providedIn: 'root'
})
export class ReportsService extends CrudService<ReportModel, number> {
  constructor(injector: Injector) {
    super(ReportModel, injector, 'reports');
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      authority: 'authority.displayName',
      adapterOperation: 'adapterOperation.displayName',
    };
  }
}
