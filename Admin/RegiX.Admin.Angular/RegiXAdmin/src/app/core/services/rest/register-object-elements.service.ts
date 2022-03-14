import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { RegisterObjectElementModel } from '../../models/dto/register-object-element.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterObjectElementsService extends CrudService<
  RegisterObjectElementModel,
  number
> {
  constructor(injector: Injector) {
    super(RegisterObjectElementModel, injector, 'register-object-elements');
  }

  getSelectedElements(request: any): Observable<any> {
    return this.http
      .post<any>(this.url + '/GetSelectedElements', request);
  }

  getSelectedConsumerRoleElements(request: any): Observable<any> {
    return this.http
      .post<any>(this.url + '/GetSelectedConsumerRoleElements', request);
  }
}
