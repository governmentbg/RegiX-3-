import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { RoleToReportModel } from '../../models/dto/role-to-report.model';

@Injectable({
  providedIn: 'root'
})
export class RolesToReportService extends CrudService<
  RoleToReportModel,
  number
> {
  constructor(injector: Injector) {
    super(RoleToReportModel, injector, 'roles-to-reports');
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      role: 'role.displayName',
      report: 'report.displayName'
    };
  }
}
