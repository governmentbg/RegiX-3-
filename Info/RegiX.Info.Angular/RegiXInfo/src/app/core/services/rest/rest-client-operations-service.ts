import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { AdapterModel } from '../../model/regix/adapter.model';
import { ConfigurationService } from '@tl/tl-common';
import { OperationModel } from '../../model/regix/operation.model';

@Injectable({
  providedIn: 'root'
})
export abstract class RestClientOperationsService {
  private serviceAddress = '/api/XSLT';

  constructor(
    private http: HttpClient,
    private configurationService: ConfigurationService
  ) {}

  public allOperations() {
    const url =
      this.configurationService.getServiceUrl() +
      this.serviceAddress +
      '/operations';
    return this.http.get(url).pipe(
      map((adapter: OperationModel[]) => {
        const res = [];
        adapter.forEach( a => res.push(new OperationModel(a)));
        console.log(res);
        return res;
      })
    );
  }
}
