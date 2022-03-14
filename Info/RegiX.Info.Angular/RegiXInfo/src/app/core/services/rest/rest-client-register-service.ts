import { RegisterListModel } from './../../model/register-list.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { ConfigurationService } from '@tl/tl-common';
import { Observable } from 'rxjs';
import { RegisterModel } from '../../model/regix/register.model';

@Injectable({
  providedIn: 'root'
})
export abstract class RestClientRegistersService {

  private baseUrl = '/api/registers';
  private retrieveAllByAdministration = '/GetByAdministration';
  private retrieveAllByAdministrationCode = '/GetByAdministrationCode';

  constructor(
    private http: HttpClient,
    private configurationService: ConfigurationService
  ) {}

  public retrieveAll() {
    return this.http
      .get(this.configurationService.getServiceUrl() + this.baseUrl)
      .pipe(
        map((registers: RegisterListModel[]) => {
          return registers.map(register => {
            return new RegisterListModel(register);
          });
        })
      );
  }

  public retrieveByAdministration(acronym: any): Observable<any> {
    return this.http
      .post(this.configurationService.getServiceUrl() + this.baseUrl + this.retrieveAllByAdministration,acronym);
  }

  public retrieveByAdministrationCode(code: string): Observable<RegisterModel[]> {
    return this.http
      .get<RegisterModel[]>(
        this.configurationService.getServiceUrl() +
      this.baseUrl + this.retrieveAllByAdministrationCode + '/' + code);

  }
}
