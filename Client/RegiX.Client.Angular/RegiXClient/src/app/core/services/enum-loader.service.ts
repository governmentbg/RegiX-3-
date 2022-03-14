import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ConfigurationService } from '@tl/tl-common';
import { EnumValueModel } from '../models/operations/enum-value.model';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class EnumLoaderService {
  baseUrl: string = null;
  protected readonly url;
  protected http: HttpClient;
  private configurationService: ConfigurationService;
  constructor(
    injector: Injector
    ) {
      this.http = injector.get(HttpClient);
      this.configurationService = injector.get(ConfigurationService);
      this.baseUrl = this.configurationService.getServiceUrl();
      this.url = this.baseUrl + '/api/enum-from-operation/';
    }

    getEnumValues(operation: string, hasEmptyValue: boolean): Observable<EnumValueModel[]> {
      let httpParams = new HttpParams();
      httpParams = httpParams.append('hasEmptyValue', hasEmptyValue + '');
      return this.http.get<EnumValueModel[]>(this.url + operation, { params: httpParams }).pipe(
        map((items: EnumValueModel[]) => {
          return items.map(item => {
            const newObj = new EnumValueModel(item);
            return newObj;
          });
        })
      );
    }
}
