import { HttpClient } from '@angular/common/http';
import { ConfigurationService } from '@tl/tl-common';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { ParameterInfoModel } from '../../models/operations/parameter-info.model';
import { OperationParameterModel } from '../../models/operations/operation-parameter.model';

@Injectable({
  providedIn: 'root'
})
export class OperationMetadataService {
  baseUrl: string = null;
  protected readonly url;

  constructor(
    private http: HttpClient,
    private configurationService: ConfigurationService
  ) {
    this.baseUrl = this.configurationService.getServiceUrl();
    this.url = this.baseUrl + '/api/adapter-operations/withParameters';
  }

  get(adapterOperationId: number): Observable<OperationParameterModel[]> {
    return this.http
      .get<any>(this.url + '/' + adapterOperationId)
      .pipe(map(data => data.requestMetadata.parameters))
      .pipe(
        map(data => {
          return data.map(item => {
            console.log('item', item);
            const newObj = new OperationParameterModel(item);
            return newObj;
          });
        })
      );
  }
}
