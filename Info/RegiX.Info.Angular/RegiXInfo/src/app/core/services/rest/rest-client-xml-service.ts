import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EXmlFileType } from '../../enums/xml-file-type.enum';
import { ConfigurationService } from '@tl/tl-common';

@Injectable({
  providedIn: 'root'
})
export abstract class RestClientXmlService {
  private serviceAddress = '/api';

  constructor(
    private http: HttpClient,
    private configurationService: ConfigurationService
  ) {}

  public retrieveOne(id: string, type: EXmlFileType) {
    const url =
      this.configurationService.getServiceUrl() +
      this.serviceAddress +
      '/' +
      type +
      '/' +
      id;
    return this.http.get(url);
  }
}
