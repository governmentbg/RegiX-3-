import { HttpClient } from '@angular/common/http';
import { ConfigurationService } from '../configuration.service';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { OperationParameterWithValueModel } from '../../models/operation-values/operation-parameter-with-value.model';

@Injectable({
  providedIn: 'root'
})
export class ReturnedCallMetadataValues {
  baseUrl: string = null;
  protected readonly url;

  constructor(
    private http: HttpClient,
    private configurationService: ConfigurationService
  ) {
    this.baseUrl = this.configurationService.getServiceUrl();
    this.url = this.baseUrl + '/api/returned-calls/withParameters';
  }

  get(ReturnedCallId: number): Observable<OperationParameterWithValueModel[]> {
    return this.http
      .get<any>(this.url + '/' + ReturnedCallId)
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