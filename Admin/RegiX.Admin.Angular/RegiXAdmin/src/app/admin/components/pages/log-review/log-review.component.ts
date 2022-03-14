import { LogReviewFilterModel } from 'src/app/core/models/dto/log-review-filter.model';
import { ApiServiceCallViewModel } from './../../../../core/models/dto/api-service-call-view.model';
import { Component, Injector, ViewChild } from '@angular/core';
import {
  RemoteComponentWithForm,
  GridRemoteFilteringService,
  DisplayValueFilteringOperand,
  IGridPagerOutputParams,
} from '@tl/tl-common';
import {
  IgxCalendarComponent,
  IgxTimePickerComponent,
  IgxDialogComponent,
} from 'igniteui-angular';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DatеFormatService } from 'src/app/core/services/date-format.service';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { HttpParams } from '@angular/common/http';
import { DatePipe } from '@angular/common';
import { ApiServiceCallViewService } from 'src/app/core/services/rest/api-service-calls-view.service';
import { LogReviewPrimaryFilterComponent } from '../filters/log-review-primary-filter/log-review-primary-filter.component';
import { LogReviewPrimaryFilterModel } from 'src/app/core/models/dto/log-review-primary-filter.model';
import { ActivatedRoute, Router, ParamMap, Params } from '@angular/router';
import { SelectedTypesModel } from 'src/app/core/models/selected-types.model';

@Component({
  selector: 'app-log-review',
  templateUrl: './log-review.component.html',
  styleUrls: ['./log-review.component.scss'],
})
export class LogReviewComponent extends RemoteComponentWithForm<
  ApiServiceCallViewModel,
  ApiServiceCallViewService
> {
  @ViewChild('calendar', { static: true })
  public calendar: IgxCalendarComponent;

  @ViewChild('timeFrom', { static: true })
  public timeFrom: IgxTimePickerComponent;

  @ViewChild('timeTo', { static: true })
  public timeTo: IgxTimePickerComponent;

  //PrimaryAdminist
  @ViewChild('primaryAdministrationsFilter', { static: true })
  primaryAdministrationsFilter: IgxDialogComponent;

  @ViewChild('logReviewPrimaryFilter')
  logReviewPrimaryFilter: LogReviewPrimaryFilterComponent;

  formGroupPrimaryAdministrations: FormGroup = null;
  formGroupPrimaryAdministrationsKeys = {
    registerAdministration: {
      title: 'Администрация',
      icon: ROUTES.ADMINISTRATIONS.icon,
    },
    apiService: {
      title: 'Интерфейс',
      icon: ROUTES.INTERFACES.icon,
    },
    apiServiceOperation: {
      title: 'Операция',
      icon: ROUTES.OPERATIONS.icon,
    },
  };
  formGroupPrimaryAdministrationsKeysArray = Object.keys(
    this.formGroupPrimaryAdministrationsKeys
  );

  logReviewPrimaryFilterModel = new LogReviewPrimaryFilterModel();
  //

  //Administrations filter
  @ViewChild('administrationsFilter', { static: true })
  administrationsFilter: IgxDialogComponent;

  @ViewChild('logReviewFilter')
  logReviewFilter: LogReviewPrimaryFilterComponent;

  formGroupAdministrations: FormGroup = null;
  formGroupAdministrationsKeys = {
    administration: {
      title: 'Администрация',
      icon: ROUTES.ADMINISTRATIONS.icon,
    },
    consumers: {
      title: 'Консуматор',
      icon: ROUTES.CONSUMERS.icon,
    },
    certificates: {
      title: 'Сертификат',
      icon: ROUTES.CERTIFICATES.icon,
    },
  };
  formGroupAdministrationsKeysArray = Object.keys(
    this.formGroupAdministrationsKeys
  );

  logReviewFilterModel = new LogReviewFilterModel();
  //

  public routes = ROUTES;
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  httpParameters: HttpParams;
  datesInterval: string;
  startTime: Date;
  endTime: Date;
  params: Params;

  title: string;
  objectName = 'грешка';
  pageTitle = 'Журнал';

  constructor(
    private formBuilder: FormBuilder,
    service: ApiServiceCallViewService,
    injector: Injector,
    public dateFormatService: DatеFormatService,
    public displayValueService: DisplayValueFormatService,
    public datepipe: DatePipe,
    private route: ActivatedRoute
  ) {
    super(service, injector);
    this.formGroupPrimaryAdministrations = this.buildPrimaryAdministrationsForm();
    this.formGroupAdministrations = this.buildAdministrationsForm();

    const defaultFromDate = new Date(Date.now());
    defaultFromDate.setHours(defaultFromDate.getHours() - 1, 0, 0, 0);
    this.startTime = defaultFromDate;

    const defaultToDate = new Date(Date.now());
    defaultToDate.setHours(defaultToDate.getHours(), 0, 0, 0);
    this.endTime = defaultToDate;

    this.SetDateToFilterModel(defaultFromDate, defaultToDate);
    this.verifyRange([defaultFromDate, defaultToDate]);
  }

  ngOnInit() {
    // hides base method implementation (subscription to params and data loading)
    this.createRemoteService();
    this.remoteService._extRemoteData = this.dataBehavior;
    this.remoteService.pagerParams.perPage = this.grid.perPage;
    this.configureExcelExport();
    this.CheckForQueryParams();
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {
        apiServiceOperation: 'apiServiceOperation.displayName',
        consumerCertificate: 'consumerCertificate.displayName',
      },
      this.service,
      this.grid,
      this.injector
    );
  }

  //primary filter
  primaryAdministrationSelected(selectedItems: SelectedTypesModel[]) {
    this.primaryAdministrationsFilter.close();
    this.formGroupPrimaryAdministrationsKeysArray.forEach((k) => {
      this.formGroupPrimaryAdministrations.controls[k].setValue('');
      this.logReviewPrimaryFilterModel[k] = undefined;
    });
    selectedItems.forEach((element) => {
      this.formGroupPrimaryAdministrations.controls[element.key].setValue(
        element.name
      );
      this.logReviewPrimaryFilterModel[element.key] = new DisplayValue({
        id: element.id,
        displayName: element.name,
      });
    });
    this.formGroupPrimaryAdministrations.markAsDirty();
  }

  buildPrimaryAdministrationsForm(): FormGroup {
    const res = {};
    Object.keys(this.formGroupPrimaryAdministrationsKeys).forEach(
      (k) => (res[k] = [{ value: '', disabled: true }])
    );
    return this.formBuilder.group(res);
  }

  openPrimaryAdministrationFilterForm() {
    this.primaryAdministrationsFilter.open();
    this.logReviewPrimaryFilter.loadFirstSection();
  }
  //

  //admin filter
  administrationSelected(
    selectedItems: { id: number; name: string; data: any; key: string }[]
  ) {
    this.administrationsFilter.close();
    this.formGroupAdministrationsKeysArray.forEach((k) => {
      this.formGroupAdministrations.controls[k].setValue('');
      this.logReviewFilterModel[k] = undefined;
    });
    selectedItems.forEach((element) => {
      this.formGroupAdministrations.controls[element.key].setValue(
        element.name
      );
      this.logReviewFilterModel[element.key] = new DisplayValue({
        id: element.id,
        displayName: element.name,
      });
    });
    this.formGroupAdministrations.markAsDirty();
  }

  buildAdministrationsForm(): FormGroup {
    const res = {};
    Object.keys(this.formGroupAdministrationsKeys).forEach(
      (k) => (res[k] = [{ value: '', disabled: true }])
    );
    return this.formBuilder.group(res);
  }

  openAdministrationFilterForm() {
    this.administrationsFilter.open();
    this.logReviewFilter.loadFirstSection();
  }
  //

  clearFilters() {
    this.primaryAdministrationSelected([]);
    this.administrationSelected([]);
    this.formGroupPrimaryAdministrations.markAsPristine();
    this.formGroupAdministrations.markAsPristine();
  }

  onClosing() {}

  verifyRange(dates: Date[]) {
    this.logReviewPrimaryFilterModel.fromDate = dates[0];
    if (this.logReviewPrimaryFilterModel.fromDate !== dates[dates.length - 1]) {
      this.logReviewPrimaryFilterModel.toDate = dates[dates.length - 1];
    }
    this.datesInterval =
      this.datepipe.transform(
        this.logReviewPrimaryFilterModel.fromDate,
        'dd.MM.yyyy'
      ) +
      ' - ' +
      this.datepipe.transform(
        this.logReviewPrimaryFilterModel.toDate,
        'dd.MM.yyyy'
      );

    this.logReviewPrimaryFilterModel.fromDate.setHours(
      this.startTime.getHours(),
      this.startTime.getMinutes(),
      0,
      0
    );
    this.logReviewPrimaryFilterModel.toDate.setHours(
      this.endTime.getHours(),
      this.endTime.getMinutes(),
      0,
      0
    );
  }

  setTimeFrom(timeFrom: IgxTimePickerComponent) {
    this.logReviewPrimaryFilterModel.fromDate.setHours(
      +timeFrom.selectedHour,
      +timeFrom.selectedMinute,
      0,
      0
    );
    this.startTime = this.logReviewPrimaryFilterModel.fromDate;
  }

  setTimeEnd(timeEnd: IgxTimePickerComponent) {
    this.logReviewPrimaryFilterModel.toDate.setHours(
      +timeEnd.selectedHour,
      +timeEnd.selectedMinute,
      0,
      0
    );
    this.endTime = this.logReviewPrimaryFilterModel.toDate;
  }

  runReport() {
    //this.isLoading = true;
    let filter = '';
    filter = this.BuildPrimeAdministrationFilterQuery();
    filter += this.BuildDateQuery(filter);
    filter = this.BuildAdministrationFilterQuery(filter);

    let params = this.BuildParams();

    this.httpParameters = null;
    if (filter) {
      this.httpParameters = new HttpParams();
      this.httpParameters = this.httpParameters.append('$filter', filter);
    }

    this.router.navigate([], { relativeTo: this.route, queryParams: params });
    this.readData(this.httpParameters);
  }

  public onDoneSelected(dropDownCalendar) {
    dropDownCalendar.close();
  }

  public onDoneSelectedTimeFrom(dropDownTimeFrom) {
    dropDownTimeFrom.close();
  }

  public pagerChange(event: IGridPagerOutputParams) {
    this.remoteService.pagerParams.perPage = event.perPage;
    this.remoteService.pagerParams.page = event.page;
    //const httpParameters = this.getExtendedParameters(null);
    this.remoteService.processData(this.httpParameters);
  }

  protected excelExportMapItem(item: ApiServiceCallViewModel){
    return {
      // Ид: item.id,
      Консуматор: item.consumerCertificateName,
      Операция: item.apiServiceOperationName,
      От: this.dateFormatService.formatForExport(item.startTime),
      До: this.dateFormatService.formatForExport(item.endTime),
      Служител: item.contextEmployeeNames,
      'IP Адрес': item.ipAddress,
      Готов: item.resultReady,
      Върнат: item.resultReturned,
      Грешка: item.hasError,
    };
  }

  private BuildPrimeAdministrationFilterQuery(): string {
    const keys = {
      registerAdministration: 'primaryAdministrationId',//администрация
      apiService: 'apiServiceId',//интерфейс
      apiServiceOperation: 'apiServiceOperationId',//операция
    };

    let filter = '';
    filter = Object.keys(keys)
      .filter(
        (key) =>
          this.logReviewPrimaryFilterModel[key] &&
          this.logReviewPrimaryFilterModel[key].id
      )
      .map(
        (key) => `${keys[key]} eq ${this.logReviewPrimaryFilterModel[key].id}`
      )
      .join(' and ');

    return filter;
  }

  private BuildAdministrationFilterQuery(buildFilter: string): string {
    const keys = {
      administration: 'administrationId',//Администрация
      consumers: 'apiServiceConsumerId',//консуматор
      certificates: 'consumerCertificateId',//сертификат
    };
    let filter = buildFilter;

    let query = Object.keys(keys)
      .filter(
        (key) =>
          this.logReviewFilterModel[key] && this.logReviewFilterModel[key].id
      )
      .map((key) => `${keys[key]} eq ${this.logReviewFilterModel[key].id}`)
      .join(' and ');
    if (query.length != 0) {
      filter += ' and ';
    }
    filter += query;
    return filter;
  }

  private BuildDateQuery(filter: string): string {
    let dateFilter = '';

    if (filter.length != 0) {
      dateFilter += ' and ';
    }
    dateFilter += `startTime ge cast(${this.logReviewPrimaryFilterModel.fromDate.toISOString()},Edm.DateTimeOffset) and endTime le cast(${this.logReviewPrimaryFilterModel.toDate.toISOString()},Edm.DateTimeOffset)`;
    return dateFilter;
  }

  private BuildParams(): any {
    let filter = Object.entries(this.logReviewFilterModel);
    let primaryFilter = Object.entries(this.logReviewPrimaryFilterModel);

    filter = [...filter, ...primaryFilter];

    let result = filter
      .filter(([key, value]) => value !== null && value !== undefined)
      .map(([key, value]) => {
        if (key === 'fromDate' || key === 'toDate') {
          return [key, value];
        }
        return [key, value.id + ':' + value.displayName];
      });
    return result;
  }

  private CheckForQueryParams() {
    this.route.queryParams.subscribe((params) => {
      this.params = params;
    });
    if (Object.keys(this.params).length > 1) {
      this.ApplyDateFilters();
      this.ApplyPrimaryAdministrationFilters();
      this.ApplyAdministrationFilters();
      this.runReport();
    }
  }

  private SetDateToFilterModel(defaultFromDate: Date, defaultToDate: Date) {
    this.logReviewPrimaryFilterModel.fromDate = defaultFromDate;
    this.logReviewPrimaryFilterModel.toDate = defaultToDate;
  }

  private ApplyDateFilters() {
    let datesArray = Object.values(this.params)
      .filter(([id, name]) => id === 'fromDate' || id === 'toDate')
      .map(([key, value]) => {
        return [key, new Date(value)];
      });

    let fromDate = datesArray[0][1];
    let toDate = datesArray[1][1];
    this.startTime = fromDate;
    this.endTime = toDate;

    this.SetDateToFilterModel(fromDate, toDate);
    this.verifyRange([fromDate, toDate]);
  }

  private ApplyAdministrationFilters() {
    let selectedTypesAdministration = Object.values(this.params)
      .filter(
        ([id, name]) =>
          id !== 'fromDate' &&
          id !== 'toDate' &&
          id !== 'apiService' &&
          id !== 'apiServiceOperation' &&
          id !== 'registerAdministration'
      )
      .map(([key, value]) => {
        return new SelectedTypesModel({
          id: +value.split(':')[0],
          name: value.split(':')[1],
          data: '',
          key: key,
        });
      });

    this.administrationSelected(selectedTypesAdministration);
  }

  private ApplyPrimaryAdministrationFilters() {
    let selectedTypesPrimeAdministration = Object.values(this.params)
      .filter(
        ([id, name]) =>
          id !== 'fromDate' &&
          id !== 'toDate' &&
          id !== 'administration' &&
          id !== 'consumers' &&
          id !== 'certificates'
      )
      .map(([key, value]) => {
        return new SelectedTypesModel({
          id: +value.split(':')[0],
          name: value.split(':')[1],
          data: '',
          key: key,
        });
      });

    this.primaryAdministrationSelected(selectedTypesPrimeAdministration);
  }
}
