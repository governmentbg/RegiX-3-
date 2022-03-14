import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { AsyncReportModel } from '../../models/dto/async-report.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AsyncReportsService extends CrudService<AsyncReportModel, number> {
  constructor(injector: Injector) {
    super(AsyncReportModel, injector, 'async-report-execution');
  }

  getReport(asyncId: number): Observable<any> {
    return this.http
      .post<any>(this.url + '/readReportExecution/' + asyncId, null);
  }

  poll(asyncId: number): Observable<any> {
    return this.http
      .post<any>(this.url + '/poll/' + asyncId, null);
  }
}
