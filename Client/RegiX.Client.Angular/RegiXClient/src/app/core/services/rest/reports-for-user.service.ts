import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { map, filter } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { LoginService } from '../login.service';
import { ReportForUserModel } from '../../models/dto/report-for-user.model';

@Injectable({
  providedIn: 'root'
})
export class ReportsForUserService extends CrudService<
  ReportForUserModel,
  number
> {
  constructor(injector: Injector, private loginService: LoginService) {
    super(ReportForUserModel, injector, 'reports-for-users');
  }

  getAllNoWrap(parameters?: HttpParams): Observable<ReportForUserModel[]> {
    if (!parameters) {
      parameters = new HttpParams();
    }
    // const userId = this.loginService.user.id;
    // const userField = 'userId eq ' + userId;

    // let filterParam = parameters.get('$filter');
    // if (filterParam) {
    //   filterParam = '(' + filterParam + ') and ' + userField;
    // } else {
    //   filterParam = userField;
    // }
    // parameters = parameters.delete('$filter');
    // parameters = parameters.append('$filter', filterParam);
    return super.getAllNoWrap(parameters);
  }

  getAll(parameters?: HttpParams): Observable<ReportForUserModel[]> {
    if (!parameters) {
      parameters = new HttpParams();
    }
    // const userId = this.loginService.user.id;
    // const userField = 'userId eq ' + userId;

    // let filterParam = parameters.get('$filter');
    // if (filterParam) {
    //   filterParam = '(' + filterParam + ') and ' + userField;
    // } else {
    //   filterParam = userField;
    // }
    // parameters = parameters.delete('$filter');
    // parameters = parameters.append('$filter', filterParam);
    return super.getAll(parameters);
  }

  getAllForUser(parameters?: HttpParams): Observable<ReportForUserModel[]> {
    if (!parameters) {
      parameters = new HttpParams();
    }
    // const userId = this.loginService.user.id;
    // const userField = 'userId eq ' + userId;

    // let filterParam = parameters.get('$filter');
    // if (filterParam) {
    //   filterParam = '(' + filterParam + ') and ' + userField;
    // } else {
    //   filterParam = userField;
    // }
    // parameters = parameters.delete('$filter');
    // parameters = parameters.append('$filter', filterParam);

    return this.http
      .get<ReportForUserModel[]>(this.url + '/getAll', {
        params: parameters
      })
      .pipe(
        map((items: ReportForUserModel[]) => {
          return items.map(item => {
            const newObj = new this.createT(item);
            return newObj;
          });
        })
      );
  }
}
