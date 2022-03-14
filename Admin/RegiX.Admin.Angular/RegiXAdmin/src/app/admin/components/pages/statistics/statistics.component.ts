import { Component, Injector, OnDestroy, ViewChild } from '@angular/core';
import { StatisticsModel } from 'src/app/core/models/dto/statistics.model';
import { StatisticsService } from 'src/app/core/services/rest/statistics.service';
import {
  IgxCalendarComponent,
  IgxDialogComponent,
} from 'igniteui-angular';
import { ComponentWithForm } from '@tl/tl-common';
import { FormGroup, FormBuilder } from '@angular/forms';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { StatisticParameters } from 'src/app/core/models/dto/statistics-params.model';
import { StatisticInParameters } from 'src/app/core/models/dto/in/statistics-params.in.model';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DatePipe } from '@angular/common';
import { OperationFilterComponent } from '../filters/operation-filter/operation-filter.component';
import { ConsumerFilterComponent } from '../filters/consumer-filter/consumer-filter.component';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.scss'],
})
export class StatisticsComponent
  extends ComponentWithForm<StatisticsModel, StatisticsService>
  implements OnDestroy {
  routes = ROUTES;
  title: string;
  objectName = 'статистика';
  pageTitle = 'Статистика за брой заявки на всеки консуматор';

  @ViewChild('calendar', { static: true })
  public calendar: IgxCalendarComponent;

  @ViewChild('primaryAdministrationsFilter', { static: true })
  primaryAdministrationsFilter: IgxDialogComponent;

  @ViewChild('consumersFilter', { static: true })
  consumersFilter: IgxDialogComponent;

  @ViewChild('operationFilter')
  operationFilter: OperationFilterComponent;

  @ViewChild('consumerFilterComponent')
  consumerFilterComponent: ConsumerFilterComponent;

  formGroupAdministrations: FormGroup = null;
  formGroupAdministrationsKeys = {
    registerAdministration: {
      title: 'Администрация',
      icon: ROUTES.ADMINISTRATIONS.icon,
    },
    register: {
      title: 'Регистър',
      icon: ROUTES.REGISTRIES.icon,
    },
    adapter: {
      title: 'Адаптер',
      icon: ROUTES.ADAPTERS.icon,
    },
    adapterOperation: {
      title: 'Операция',
      icon: ROUTES.OPERATIONS.icon,
    },
  };
  formGroupAdministrationsKeysArray = Object.keys(
    this.formGroupAdministrationsKeys
  );
  formGroupConsumers: FormGroup = null;
  formGroupConsumersKeys = {
    consumerAdministration: {
      title: 'Администрация',
      icon: ROUTES.ADMINISTRATIONS.icon,
    },
    consumer: {
      title: 'Консуматор',
      icon: ROUTES.CONSUMERS.icon,
    },
    certificate: {
      title: 'Сертификат',
      icon: ROUTES.CERTIFICATES.icon,
    }
  };
  formGroupConsumersKeysArray = Object.keys(this.formGroupConsumersKeys);
  statisticsParams: StatisticParameters = null;

  staisticsRoute = ROUTES.STATISTICS;

  datesInterval: string;
  isLoading = false;

  constructor(
    private formBuilder: FormBuilder,
    service: StatisticsService,
    public datepipe: DatePipe,

    injector: Injector
  ) {
    super(service, injector);

    this.formGroupAdministrations = this.buildAdministrationsForm();
    this.formGroupConsumers = this.buildConsumersForm();

    const defaultFromDate = new Date(Date.now() - 2 * 1000 * 60 * 60 * 24);
    defaultFromDate.setHours(0, 0, 0, 0);
    const defaultToDate = new Date(Date.now());
    defaultToDate.setHours(0, 0, 0, 0);

    this.statisticsParams = new StatisticParameters({
      fromDate: defaultFromDate,
      toDate: defaultToDate,
    });
    this.verifyRange([defaultFromDate, defaultToDate]);
  }

  public readData() {}

  buildAdministrationsForm(): FormGroup {
    const res = {};
    Object.keys(this.formGroupAdministrationsKeys).forEach(
      (k) => (res[k] = [{ value: '', disabled: true }])
    );
    return this.formBuilder.group(res);
  }

  buildConsumersForm(): FormGroup {
    const res = {};
    Object.keys(this.formGroupConsumersKeys).forEach(
      (k) => (res[k] = [{ value: '', disabled: true }])
    );
    res['consumerDescription'] = [{ value: '', disabled: false }]
    return this.formBuilder.group(res);
  }

  openPrimaryAdministraionsForm() {
    this.primaryAdministrationsFilter.open();
    this.operationFilter.loadFirstSection();
  }

  openConsumersFilterForm() {
    this.consumersFilter.open();
    this.consumerFilterComponent.loadFirstSection();
  }

  ngOnInitImpl() {}

  ngOnDestroy() {}

  onShowMenuSelected() {}

  clearFilters() {
    this.operationSelected([]);
    this.consumerSelected([]);
    this.formGroupConsumers.controls['consumerDescription'].setValue('');
    this.formGroupAdministrations.markAsPristine();
    this.formGroupConsumers.markAsPristine();
  }

  operationSelected(
    selectedItems: { id: number; name: string; data: any; key: string }[]
  ) {
    this.primaryAdministrationsFilter.close();
    this.formGroupAdministrationsKeysArray.forEach((k) => {
      this.formGroupAdministrations.controls[k].setValue('');
      this.statisticsParams[k] = undefined;
    });
    selectedItems.forEach((element) => {
      this.formGroupAdministrations.controls[element.key].setValue(
        element.name
      );
      this.statisticsParams[element.key] = new DisplayValue({
        id: element.id,
        displayName: element.name,
      });
    });
    this.formGroupAdministrations.markAsDirty();
  }

  consumerSelected(
    selectedItems: { id: number; name: string; data: any; key: string }[]
  ) {
    this.consumersFilter.close();
    this.formGroupConsumersKeysArray.forEach((k) => {
      this.formGroupConsumers.controls[k].setValue('');
      this.statisticsParams[k] = undefined;
    });
    selectedItems.forEach((element) => {
      this.formGroupConsumers.controls[element.key].setValue(element.name);
      this.statisticsParams[element.key] = new DisplayValue({
        id: element.id,
        displayName: element.name,
      });
    });
    this.formGroupConsumers.markAsDirty();
  }

  runStatistics() {
    this.isLoading = true;
    this.statisticsParams['consumerDescription'] = this.formGroupConsumers.controls['consumerDescription'].value;
    const parameters = new StatisticInParameters(this.statisticsParams);
    this.service
      .getStatistics(parameters)
      .subscribe((data: StatisticsModel[]) => {
        const obj = Object(data);
        this.isLoading = false;
        this.dataBehavior.next(obj);
      });
  }

  onClosing() {}
  verifyRange(dates: Date[]) {
    this.statisticsParams.fromDate = dates[0];
    if (this.statisticsParams.fromDate !== dates[dates.length - 1]) {
      this.statisticsParams.toDate = dates[dates.length - 1];
    }
    this.datesInterval =
      this.datepipe.transform(this.statisticsParams.fromDate, 'dd.MM.yyyy') +
      ' - ' +
      this.datepipe.transform(this.statisticsParams.toDate, 'dd.MM.yyyy');
  }

  public onDoneSelected(dropDownCalendar) {
    dropDownCalendar.close();
  }
}
