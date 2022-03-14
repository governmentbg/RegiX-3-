
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { ConfigurationService } from '@tl/tl-common';
import { OperationListModel } from '../../model/operation-list.model';
import { OperationDetailsModel } from '../../model/operation-details.model';

@Injectable({
  providedIn: 'root',
})
export abstract class RestClientOperationsListService {
  private serviceAddress = '/api/operations';
  private GetByAdapter = 'GetByAdapter';
  private GetByOperationName = 'GetByOperationName';

  constructor(
    private http: HttpClient,
    private configurationService: ConfigurationService
  ) {}

  public retrieveAll() {
    return this.http
      .get(this.configurationService.getServiceUrl() + this.serviceAddress)
      .pipe(
        map((operaitons: OperationListModel[]) => {
          return operaitons.map((operation) => {
            return new OperationListModel(operation);
          });
        })
      );
  }

  public retrieveAllByAdapter(id: any) {
    const url =
      this.configurationService.getServiceUrl() +
      this.serviceAddress +
      '/' +
      this.GetByAdapter;
    return this.http.post(url, id).pipe(
      map((operations: OperationListModel[]) => {
        return operations.map((operation) => {
          return new OperationListModel(operation);
        });
      })
    );
  }

  public retrieveByName(id: any) {
    const url =
      this.configurationService.getServiceUrl() +
      this.serviceAddress +
      '/' +
      this.GetByOperationName +
      '/' +
      id;
    return this.http
    .get(url)
    .pipe(
      map((operation: OperationDetailsModel) => {
        return new OperationDetailsModel(operation);
      })
    );
  }
}
