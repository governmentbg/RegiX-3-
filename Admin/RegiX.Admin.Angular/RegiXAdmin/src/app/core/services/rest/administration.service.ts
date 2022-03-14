import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { AdministrationModel } from '../../models/dto/administration.model';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, flatMap } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AdministrationsService extends CrudService<
  AdministrationModel,
  number
> {
  constructor(injector: Injector, protected activatedRoute: ActivatedRoute) {
    super(AdministrationModel, injector, 'administrations');

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
