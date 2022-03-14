import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { map, filter, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { LoginService } from '../login.service';
import { ReportForUserModel } from '../../models/dto/report-for-user.model';
import { ReportExecutionsModel } from '../../models/dto/report-executions.model';

@Injectable({
  providedIn: 'root'
})
export class ReportExecutionsService extends CrudService<
  ReportExecutionsModel,
  number
> {
  constructor(injector: Injector, private loginService: LoginService) {
    super(ReportExecutionsModel, injector, 'audit-report-executions');
  }

  getReport(asyncId: number): Observable<any> {
    this.isLoading = true;
    return this.http
      .post<any>(this.url + '/readReportExecution/' + asyncId, null)
       .pipe(
        catchError(
          err => {
            this.isLoading = false;
            console.log('error catch');
            throw err;
         }),
         map(
           res => {
             this.isLoading = false;
             return res;
         })
      );
  }
  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      authority: 'authority.displayName',
      report: 'report.displayName',
      user: 'user.displayName'
    };
  }
}
