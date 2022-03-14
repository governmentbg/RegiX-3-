import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { AdministrationModel } from '../../models/dto/administration.model';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AdministrationsService extends CrudService<
  AdministrationModel,
  number
> {
  constructor(injector: Injector) {
    super(AdministrationModel, injector, 'authorities');
  }

  getAllProvidersNoWrap(
    aParams?: HttpParams
  ): Observable<AdministrationModel[]> {
    return this.http
      .get<AdministrationModel[]>(this.url + '/getAllProviders', {
        params: aParams
      })
      .pipe(
        map((items: AdministrationModel[]) => {
          return items.map(item => {
            const newObj = new this.createT(item);
            return newObj;
          });
        })
      );
  }

  createRolesAndReports(
    aId: number
  ): Observable<number> {
    return this.http.get<number>(`${this.url}/GenerateReportsAndRoleForAuth/${aId}`);
  }
}
