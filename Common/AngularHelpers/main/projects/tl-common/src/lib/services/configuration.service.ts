import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { forkJoin, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {
  private serviceUrl: string;
  private applicationName: string;
  private stsServiceUrl: string;
  private clientId: string;

  constructor(private http: HttpClient) {
  }

  public readConfiguration(): Observable<[any, any]> {
    this.serviceUrl = `${window.location.origin}`;
    const config = this.http.get('assets/config.properties.json').pipe(
      map((c: any) => {
      this.applicationName = c.applicationName;
      return c;
    }));
    const authConfig = this.http.get('assets/auth.clientConfiguration.json').pipe(
      map((c: any) => {
      this.stsServiceUrl = `${window.location.origin}/${c.stsServer}`;
      this.clientId = c.client_id;
      return c;
    }));
    return forkJoin([config, authConfig]);
  }

  public getServiceUrl() {
    return this.serviceUrl;
  }

  public getStsServiceUrl() {
    return this.stsServiceUrl;
  }

  public getClientId() {
    return this.clientId;
  }

  public getApplicationName() {
    return this.applicationName;
  }
}