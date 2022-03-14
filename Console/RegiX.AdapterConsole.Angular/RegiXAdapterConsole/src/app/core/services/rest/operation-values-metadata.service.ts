import { HttpClient } from '@angular/common/http';
import { ConfigurationService } from '@tl/tl-common';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { OperationParameterWithValueModel } from '../../models/operation-values/operation-parameter-with-value.model';

@Injectable({
  providedIn: 'root'
})
export class OperationValuesMetadataService {
  baseUrl: string = null;
  protected readonly url;

  constructor(
    private http: HttpClient,
    private configurationService: ConfigurationService
  ) {
    this.baseUrl = this.configurationService.getServiceUrl();
    this.url = this.baseUrl + '/api/operation-calls/withParameters';
  }

  get(OperationCallId: number): Observable<OperationParameterWithValueModel[]> {
    return this.http
      .get<any>(this.url + '/' + OperationCallId)
      .pipe(map(data => data.requestParamsValues))
      .pipe(
        map(data => {
          return data.map(item => {
            console.log('item', item);
            const newObj = new OperationParameterWithValueModel(item);
            return newObj;
          });
        })
      );
  }
}
