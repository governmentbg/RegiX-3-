import { AdapterListModel } from './../../model/adapter-list.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { AdapterModel } from '../../model/regix/adapter.model';
import { ConfigurationService } from '@tl/tl-common';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export abstract class RestClientAdapterService {
  private serviceAddress = '/api/Adapter';
  private adapterBasicInfoAddress = '/api/Adapter/adapterBasicInfo';
  private getByRegister = 'GetByRegister';

  constructor(
    private http: HttpClient,
    private configurationService: ConfigurationService
  ) {}

  public retrieveAll() {
    return this.http
      .get(this.configurationService.getServiceUrl() + this.serviceAddress)
      .pipe(
        map((adapters: AdapterListModel[]) => {
          return adapters.map((adapter) => {
            return new AdapterListModel(adapter);
          });
        })
      );
  }
  public retrieveOne(id: string) {
    const url =
      this.configurationService.getServiceUrl() +
      this.serviceAddress +
      '/' +
      id;
    return this.http.get(url).pipe(
      map((adapter: AdapterModel) => {
        return new AdapterModel(adapter);
      })
    );
  }

  public retrieveAllByRegister(id: any) {
    const url =
      this.configurationService.getServiceUrl() +
      this.serviceAddress +
      '/' + this.getByRegister;
    return this.http
    .post(url,id)
    .pipe(
      map((adapters: AdapterListModel[]) => {
        return adapters.map((adapter) => {
          return new AdapterListModel(adapter);
        });
      })
    );
  }

  public retrieveBasicInfoForAdapter(id: string) {
    const url =
      this.configurationService.getServiceUrl() +
      this.adapterBasicInfoAddress +
      '/' +
      id;
    return this.http.get(url).pipe(
      map((adapter: AdapterModel) => {
        return new AdapterModel(adapter);
      })
    );
  }
}
