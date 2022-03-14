import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, flatMap } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';
import { AdministrationModel } from '../../model/regix/administration.model';
import { SearchResult } from '../../model/search-result.model';

@Injectable({
  providedIn: 'root'
})
export class AdministrationsService extends CrudService<
  AdministrationModel,
  number
> {
  constructor(injector: Injector, protected activatedRoute: ActivatedRoute) {
    super(AdministrationModel, injector, 'administrations-filter');

  }

  search(term: string): Observable<SearchResult[]> {
    return this.http.post<SearchResult[]>(this.url + '/search/' + encodeURIComponent(term), undefined).pipe(
      map( (items: SearchResult[]) => {
          const newItems = items.map(item => {
            const newObj = new SearchResult(item);
            return newObj;
            });
          return newItems;
        }
    ));
  }

  getAll(params?: HttpParams): Observable<AdministrationModel[]> {
    return this.activatedRoute.params.pipe(
      map( prms => {
        if (prms['ADM_TYPE'] === 'primary') {
          return this.GetAllPrimariesWithPagination(params);
        } else {
          return super.getAll(params);
        }
      }),
      flatMap( obs => obs)
    );
  }

  GetAllPrimariesWithPagination(params?: HttpParams): Observable<AdministrationModel[]> {
    const prms = this.addOrderBy(params);

    this.isLoading = true;
    return this.http.get<AdministrationModel[]>(this.url + '/GetAllPrimariesWithPagination', { params: prms }).pipe(
      map((items: AdministrationModel[]) => {
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

  GetAllPrimaries(aParams?: HttpParams): Observable<AdministrationModel[]> {
    this.isLoading = true;
    return this.http.get<AdministrationModel[]>(this.url + '/GetAllPrimaries', { params: aParams }).pipe(
      map((items: AdministrationModel[]) => {
        this.isLoading = false;
        return items.map(item => {
          const newObj = new this.createT(item);
          return newObj;
        });
      })
    );
  }

  GetAllPrimariesAnonymous(aParams?: HttpParams): Observable<AdministrationModel[]> {
    this.isLoading = true;
    return this.http.get<AdministrationModel[]>(this.url + '/GetAllPrimariesAnonymous', { params: aParams }).pipe(
      map((items: AdministrationModel[]) => {
        this.isLoading = false;
        return items.map(item => {
          const newObj = new this.createT(item);
          return newObj;
        });
      })
    );
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      administrationType: 'administrationType.displayName'
    };
  }
}
