import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { UserFavouriteReportModel } from '../../models/dto/user-favourite-report.model';

@Injectable({
  providedIn: 'root'
})
export class UsersFavouriteReportService extends CrudService<
  UserFavouriteReportModel,
  number
> {
  constructor(injector: Injector) {
    super(UserFavouriteReportModel, injector, 'users-favourite-reports');
  }

  public change(reportId: number, favourite: boolean) {
    return this.http.post(`${this.url}/single/${reportId}`, {value: favourite});
  }
}
