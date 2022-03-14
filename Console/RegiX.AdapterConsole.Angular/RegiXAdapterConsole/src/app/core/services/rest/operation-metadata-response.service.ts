import { HttpClient } from '@angular/common/http';
import { ConfigurationService } from '../configuration.service';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { ParameterInfoModel } from '../../models/operations/parameter-info.model';
import { OperationParameterModel } from '../../models/operations/operation-parameter.model';

@Injectable({
  providedIn: 'root'
})
export class OperationMetadataResponseService {
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
      .pipe(map(data => data.responseMetadata.parameters))
      .pipe(
        map(data => {
          return data.map(item => {
            const newObj = new OperationParameterModel(item);
            return newObj;
          });
        })
      );
  }
}

