import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { ConfigurationService } from '@tl/tl-common';
import { AdministrationListModel } from '../../model/administration-list.model';

@Injectable({
  providedIn: 'root',
})
export abstract class RestClientAdministrationsListService {
  private retrieveAllOperations = '/api/administrations/GetNames';

  constructor(
    private http: HttpClient,
    private configurationService: ConfigurationService
  ) {}

  public retrieveAll(sortByCode?: boolean) {
    let httpParams = new HttpParams();
    if (sortByCode) {
      httpParams = httpParams.append('orderByAcronym', sortByCode + '');

    }
    return this.http
      .get(
        this.configurationService.getServiceUrl() + this.retrieveAllOperations,
        {
          params: httpParams
        }
      )
      .pipe(
        map((administrations: AdministrationListModel[]) => {
          return administrations.map((administration) => {
            return new AdministrationListModel(administration);
          });
        })
      );
  }
}
