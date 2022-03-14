import { Injector } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
// import { environment } from 'src/environments/environment';
import { CrudOperations } from './crud-operation';
import { ConfigurationService } from './configuration.service';

export abstract class CrudService<T, ID> implements CrudOperations<T, ID> {
  baseUrl: string = null;
  protected http: HttpClient;
  protected readonly url;
  private configurationService: ConfigurationService;
  public isLoading = false;

  constructor(
    public createT: new (any) => T,
    injector: Injector,
    protected endpoint: string
  ) {
    this.http = injector.get(HttpClient);
    this.configurationService = injector.get(ConfigurationService);

    this.baseUrl = this.configurationService.getServiceUrl();
    this.url = this.baseUrl + '/api/' + this.endpoint;
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {};
  }

  save(t: T): Observable<T> {
    return this.http.post<T>(this.url, t);
  }
  update(id: ID, t: T): Observable<T> {
    return this.http.put<T>(this.url + '/' + id, t, {});
  }
  find(id: ID, params?: HttpParams): Observable<T> {
    const _params = this.addOrderBy(params);
    return this.http
      .get<T>(this.url + '/' + id, { params: _params })
      .pipe(map(item => new this.createT(item)));
  }
  getAllNoWrap(aParams?: HttpParams): Observable<T[]> {
    this.isLoading = true;
    return this.http.get<T[]>(this.url + '/getAll', { params: aParams }).pipe(
      map((items: T[]) => {
        this.isLoading = false;
        return items.map(item => {
          const newObj = new this.createT(item);
          return newObj;
        });
      })
    );
  }
  getAll(params?: HttpParams): Observable<T[]> {
    const _params = this.addOrderBy(params);

    this.isLoading = true;
    return this.http.get<T[]>(this.url, { params: _params }).pipe(
      map((items: T[]) => {
        const newItems = items['data'].map(item => {
          const newObj = new this.createT(item);
          return newObj;
        });
        items['data'] = newItems;
        this.isLoading = false;
        return items;
      })
    );
  }

  // getAllById(id: ID): Observable<T[]> {
  //   const _params = this.addOrderBy();
  //   return this.http.get<T[]>(this.url + '/' + id, { params: _params });
  // }
  delete(id: ID): Observable<any> {
    return this.http.delete<T>(this.url + '/' + id);
  }

  protected addOrderBy(params?: HttpParams): HttpParams {
    if (!params) {
      params = new HttpParams();
    }

    if (!params.has('$orderby')) {
      params = params.append('$orderby', 'id desc');
    }

    return params;
  }

  public getPagingParams(index, perPage) {
    let res = new HttpParams();
    if (perPage) {
      res = res.append('$skip', index);
      res = res.append('$top', perPage);
      res = res.append('$count', 'true');
    }
    return res;
  }
}
