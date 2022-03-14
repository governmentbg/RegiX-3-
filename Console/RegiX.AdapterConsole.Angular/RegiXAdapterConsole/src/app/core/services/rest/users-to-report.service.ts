import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { UserToReportModel } from '../../models/dto/user-to-report.model';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UsersToReportService extends CrudService<
  UserToReportModel,
  number
> {
  constructor(injector: Injector) {
    super(UserToReportModel, injector, 'operations-to-users');
  }
}
