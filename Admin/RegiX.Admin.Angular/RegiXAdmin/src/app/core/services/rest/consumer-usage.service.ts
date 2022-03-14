import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ConsumerUsageModel } from '../../models/dto/consumer-usage.model';
import { Observable } from 'rxjs';
import { HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ConsumerUsageService extends CrudService<
  ConsumerUsageModel,
  number
> {
  constructor(injector: Injector) {
    super(ConsumerUsageModel, injector, 'consumer-usage');
  }

  getAllNoWrap(aParams?: HttpParams): Observable<ConsumerUsageModel[]> {
    let _params = this.addOrderBy(aParams);
    this.isLoading = true;
    let includeElements = false;
    if (_params.has('$includeElements')) {
      includeElements = true;
      _params = _params.delete('$includeElements')
    }
    _params = _params.delete('$top');
    return this.http.get<ConsumerUsageModel[]>(
      (includeElements ? `${this.url}-elements` : this.url) + '/getAll', { params: _params }).pipe(
      map((items: ConsumerUsageModel[]) => {
        this.isLoading = false;
        return items.map(item => {
          const newObj = new this.createT(item);
          return newObj;
        });
      })
    );
  }

  getAll(params?: HttpParams): Observable<ConsumerUsageModel[]> {
    let _params = this.addOrderBy(params);
    let includeElements = false;
    if (_params.has('$includeElements')) {
      includeElements = true;
      _params = _params.delete('$includeElements')
    }
    this.isLoading = true;
    return this.http
      .get<ConsumerUsageModel[]>(
        includeElements ? `${this.url}-elements` : this.url,
        { params: _params })
      .pipe(
        map((items: ConsumerUsageModel[]) => {
          const newItems = items['data'].map((item) => {
            const newObj = new this.createT(item);
            return newObj;
          });
          items['data'] = newItems;
          this.isLoading = false;
          return items;
        })
      );
  }

  protected addOrderBy(params?: HttpParams): HttpParams {
    if (!params) {
      params = new HttpParams();
    }

    return params;
  }
}
