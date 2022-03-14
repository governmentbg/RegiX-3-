import { Injectable, Injector } from '@angular/core';
import { CrudService } from '@tl/tl-common';
import { ConsumerRequestsModel } from '../models/consumer-requests.model';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ConsumerRequestsInModel } from '../models/in/consumer-request.in.model';

@Injectable({
  providedIn: 'root',
})
export class ConsumerRequestsService extends CrudService<
  ConsumerRequestsModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerRequestsModel, injector, 'consumer-requests');
  }

  updateStatus(id: number, t: ConsumerRequestsInModel): Observable<ConsumerRequestsInModel> {
    return this.http.put<ConsumerRequestsInModel>(this.url + '/' + id, t, {});
  }

  generateReport(requestId: number): Observable<string> {
    let a = this.url;
    return this.http.post<string>(this.url + '/GetReport/' + requestId, null).pipe(map((item) => item));
  }
}
