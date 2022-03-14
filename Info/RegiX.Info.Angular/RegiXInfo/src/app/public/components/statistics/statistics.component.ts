import { Records } from './../../models/records.model';
import { ROUTES } from 'src/app/public/routes/static-routes';
import { StatisticsInModel } from './../../models/in/statistics.in.model';
import { StatisticsService } from './../../services/statistics.service';
import { StatisticsModel } from './../../models/statistics.model';
import { Component, Injector } from '@angular/core';
import { ComponentWithForm } from '@tl/tl-common';
import { HttpParams } from '@angular/common/http';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.scss'],
})
export class StatisticsComponent extends ComponentWithForm<
  StatisticsModel,
  StatisticsService
> {
  public refreshedTime: any;
  public routes = ROUTES;
  public subTitle: string;
  statisticsInModel: StatisticsInModel;

  constructor(public datePipe: DatePipe, service: StatisticsService, injector: Injector) {
    super(service, injector);
  }

  ngOnInitImpl() {
    this.subTitle =  this.activatedRoute.snapshot.data['name'];
    this.CreateStatisticsInModel();
  }

  protected readData(params?: HttpParams) {
    this.logger.debug('READ DATA IN BASIC');
    this.service
      .getAllData(this.statisticsInModel, params)
      .subscribe((data: Records) => {
        const obj = Object(data.record);
        this.dataBehavior.next(obj);

        this.refreshedTime = data.refreshedTime;
        this.service.isLoading = false;
      });
  }
  reloadStatistics() {
    this.readData();
  }

  private CreateStatisticsInModel() {
    this.statisticsInModel = new StatisticsInModel();
    let lastElement = this.router.url.toString().split('/').pop();
    if (lastElement === 'error') {
      this.statisticsInModel.showError = true;
      this.statisticsInModel.timeFrame =
        this.activatedRoute.snapshot.url.toString().split('/').pop() +
        lastElement;
    } else {
      this.statisticsInModel.showError = false;
      this.statisticsInModel.timeFrame = lastElement;
    }
  }
}
