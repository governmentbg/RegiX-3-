import { Injectable, Injector } from '@angular/core';
import { Observable } from 'rxjs';
import { CrudService } from '@tl/tl-common';
import { ABaseModel } from '@tl/tl-common';

export abstract class BaseOperationCallsService<T extends ABaseModel> extends CrudService<
  T,
  number
> {
  constructor(injector: Injector,operation:new (any) => T,endpoint: string) {
    super(operation, injector,endpoint);
  }

  executeRequest(request: any): Observable<any> {
    return this.http
      .post<any>(this.url + '/executeRequest', request);
  }

  updateParameters(request: any): Observable<any> {
    return this.http
      .post<any>(this.url + '/updateParameters', request);
  }

  updateAssignedTo(request: any): Observable<any> {
    return this.http
      .post<any>(this.url + '/updateAssignedTo', request);
  }
}
