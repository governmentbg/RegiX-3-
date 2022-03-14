import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { StatisticsModel } from '../../models/dto/statistics.model';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { StatisticInParameters } from '../../models/dto/in/statistics-params.in.model';

@Injectable({
  providedIn: 'root'
})
export class StatisticsService extends CrudService<StatisticsModel, number> {
  constructor(injector: Injector) {
    super(StatisticsModel, injector, 'statistics');
  }

  getStatistics(
    statisticsParams: StatisticInParameters
  ): Observable<StatisticsModel[]> {
    return this.http.post<StatisticsModel[]>(this.url, statisticsParams).pipe(
      map((items: StatisticsModel[]) => {
        const newItems = items.map(item => {
          const newObj = new this.createT(item);
          return newObj;
        });
        items = newItems;
        return items;
      })
    );
  }
}
