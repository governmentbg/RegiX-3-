import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { UserToReportModel } from '../../models/dto/user-to-report.model';

@Injectable({
  providedIn: 'root'
})
export class UsersToReportService extends CrudService<
  UserToReportModel,
  number
> {
  constructor(injector: Injector) {
    super(UserToReportModel, injector, 'users-to-reports');
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      report: 'report.displayName',
      user: 'user.displayName'
    };
  }
}
