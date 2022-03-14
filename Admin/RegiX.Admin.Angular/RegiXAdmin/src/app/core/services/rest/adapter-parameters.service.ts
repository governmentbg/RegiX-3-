import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { AdapterModel } from '../../models/dto/adapters.model';
import { AdapterParametersModel } from '../../models/dto/adapter-parameters.model';
import { HttpClient } from '@angular/common/http';
import { ConfigurationService } from '@tl/tl-common';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdapterParametersService {
  protected http: HttpClient;
  private configurationService: ConfigurationService;
  baseUrl: string = null;
  protected readonly url;

  constructor(injector: Injector) {
    this.http = injector.get(HttpClient);
    this.configurationService = injector.get(ConfigurationService);

    this.baseUrl = this.configurationService.getServiceUrl();
    this.url = this.baseUrl + '/api/parameters';
  }

  public get(adapterId: number): Observable<AdapterParametersModel[]> {
    return this.http
      .get<AdapterParametersModel[]>(this.url + '/' + adapterId);
  }
  public post(adapterId: number, parameters: AdapterParametersModel[]): Observable<any> {
    return this.http
      .post(this.url + '/' + adapterId, parameters);
  }
}
