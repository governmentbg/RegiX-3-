import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AgencyModel } from '../../model/regix/agency.model';
import { AgencyInfo } from '../../model/regix/agency-info.model';
import { map } from 'rxjs/operators';
import { ConfigurationService } from '@tl/tl-common';

@Injectable({
  providedIn: 'root'
})
export abstract class RestClientAdministrationsService {
  private retrieveAllInfoAddress = '/api/administrations/GetAll';
  private retrieveAllAddress = '/api/administrations';
  private retrieveByCodeAddress = '/api/administrations/GetByCode';

  constructor(
    private http: HttpClient,
    private configurationService: ConfigurationService
  ) {}

  public retrieveAllInfo() {
    return this.http
      .get(this.configurationService.getServiceUrl() + this.retrieveAllInfoAddress)
      .pipe(
        map((agencies: AgencyInfo[]) => {
          return agencies.map(agency => {
            return new AgencyInfo(agency);
          });
        })
      );
  }

  public retrieveAll() {
    return this.http
      .get(this.configurationService.getServiceUrl() + this.retrieveAllAddress )
      .pipe(
        map((agencies: AgencyModel[]) => {
          return agencies.map(agency => {
            return new AgencyModel(agency);
          });
        })
      );
  }

  public retrieveByCode(code: string) {
    return this.http
      .get(this.configurationService.getServiceUrl() + this.retrieveByCodeAddress + '/' + code )
      .pipe(
        map( (administration: any) => {
          if (administration) {
            const retValue = new AgencyInfo({
              name: administration.name
            });
            return retValue;
          } else {
            return new AgencyInfo({
              name: '-'
            });
          }
        })
      );
  }

  public retrieveOne(id: string) {
    const url =
      this.configurationService.getServiceUrl() +
      this.retrieveAllAddress +
      '/' +
      id;
    return this.http.get(url).pipe(
      map((agency: AgencyModel) => {
        return new AgencyModel(agency);
      })
    );
  }
}
