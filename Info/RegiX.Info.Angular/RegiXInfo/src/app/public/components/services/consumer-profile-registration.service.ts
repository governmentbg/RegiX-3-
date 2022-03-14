import { ConsumerPorofileRegistrationModel } from '../models/consumer-profile-registration.model';
import { Observable } from 'rxjs';
import { Injector, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigurationService } from '@tl/tl-common';

@Injectable({
  providedIn: 'root'
})
export class ConsumerPorofileRegistrationService {
  baseUrl: string = null;
  protected http: HttpClient;
  protected readonly url;
  private configurationService: ConfigurationService;

  constructor(
    injector: Injector,
  ) {
    this.http = injector.get(HttpClient);
    this.configurationService = injector.get(ConfigurationService);

    this.baseUrl = this.configurationService.getStsServiceUrl();
    this.url = `${this.baseUrl}/api/account/${this.configurationService.getClientId()}`;
  }

  save(consumerPorofileRegistrationModel: ConsumerPorofileRegistrationModel): Observable<ConsumerPorofileRegistrationModel> {
    return this.http.post<ConsumerPorofileRegistrationModel>(this.url, consumerPorofileRegistrationModel);
  }
}
