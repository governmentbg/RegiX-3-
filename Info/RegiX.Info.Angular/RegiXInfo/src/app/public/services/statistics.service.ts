import { Records } from './../models/records.model';
import { StatisticsInModel } from './../models/in/statistics.in.model';
import { Injectable, Injector } from '@angular/core';
import { CrudService } from '@tl/tl-common';
import { StatisticsModel } from '../models/statistics.model';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
  })
  export class StatisticsService extends CrudService<StatisticsModel, number> {
    constructor(injector: Injector) {
      super(StatisticsModel, injector, 'statistics');
    }

    getAllData(statisticsInModel: StatisticsInModel,params?: HttpParams): Observable<Records> {
        const _params = this.addOrderBy(params);
        this.isLoading = true;
        return this.http.post<Records>(this.url,statisticsInModel).pipe(
          map((item: Records) => { 
            return item;
          })
        );
      }
  }