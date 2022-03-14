import {
  Component,
  OnInit,
  OnDestroy,
  ViewChild,
  Injector,
} from '@angular/core';
import {
  ComponentWithForm,
  RemoteComponentWithForm,
  IGridPagerOutputParams,
} from '@tl/tl-common';
import { ConsumerUsageModel } from 'src/app/core/models/dto/consumer-usage.model';
import { ConsumerUsageService } from 'src/app/core/services/rest/consumer-usage.service';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { IChangeCheckboxEventArgs, IgxCalendarComponent, IgxDialogComponent } from 'igniteui-angular';
import { FormGroup, FormBuilder } from '@angular/forms';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { AccessReportFilterNewModel } from 'src/app/core/models/dto/access-report-filter-new.model';
import { HttpParams } from '@angular/common/http';
import { DatеFormatService } from 'src/app/core/services/date-format.service';
import { OperationFilterComponent } from '../filters/operation-filter/operation-filter.component';
import { ConsumerFilterComponent } from '../filters/consumer-filter/consumer-filter.component';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-access-report-new',
  templateUrl: './access-report-new.component.html',
  styleUrls: ['./access-report-new.component.scss'],
})
export class AccessReportNewComponent
  extends RemoteComponentWithForm<ConsumerUsageModel, ConsumerUsageService>
  implements OnDestroy {
  routes = ROUTES;
  title: string;
  objectName = 'статистика';
  pageTitle = ROUTES.ACCESS_REPORT.title;
  public includeElements = false;

  @ViewChild('calendar', { static: true })
  public calendar: IgxCalendarComponent;

  @ViewChild('primaryAdministrationsFilter', { static: true })
  primaryAdministrationsFilter: IgxDialogComponent;
  @ViewChild('consumersFilter', { static: true })
  consumersFilter: IgxDialogComponent;

  @ViewChild('operationFilter')
  operationFilter: OperationFilterComponent;
  @ViewChild('operationFilterWithElements')
  operationFilterWithElements: OperationFilterComponent;

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
    operationElement: {
      title: 'Елементи',
      icon: ROUTES.CERTIFICATE_OPERATION_ELEMENTS_ACCESS_FILTER.icon,
    }
  };
  formGroupAdministrationsKeysArray = Object.keys(
    this.formGroupAdministrationsKeys
  ).filter( k => k !== 'operationElement' || this.includeElements);
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
  accessReportFilter = new AccessReportFilterNewModel();
  httpParameters: HttpParams;

  accessReportRoute = ROUTES.ACCESS_REPORT;

  datesInterval: string;
  isLoading = false;

  constructor(
    private formBuilder: FormBuilder,
    service: ConsumerUsageService,
    injector: Injector,
    public dateFormatService: DatеFormatService
  ) {
    super(service, injector);

    this.formGroupAdministrations = this.buildAdministrationsForm();
    this.formGroupConsumers = this.buildConsumersForm();
  }

  // public readData() {}

  buildAdministrationsForm(): FormGroup {
    const res = {};
    this.formGroupAdministrationsKeysArray.forEach(
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
    if (this.operationFilterWithElements) {
      this.operationFilterWithElements.loadFirstSection();
    }
    if (this.operationFilter) {
      this.operationFilter.loadFirstSection();
    }
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
      this.accessReportFilter[k] = undefined;
    });
    selectedItems.forEach((element) => {
      this.formGroupAdministrations.controls[element.key].setValue(
        element.name
      );
      this.accessReportFilter[element.key] = new DisplayValue({
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
      this.accessReportFilter[k] = undefined;
    });
    selectedItems.forEach((element) => {
      this.formGroupConsumers.controls[element.key].setValue(element.name);
      this.accessReportFilter[element.key] = new DisplayValue({
        id: element.id,
        displayName: element.name,
      });
    });
    this.formGroupConsumers.markAsDirty();
  }

  ngOnInit() {
    // hides base method implementation (subscription to params and data loading)
    this.createRemoteService();
    this.remoteService._extRemoteData = this.dataBehavior;
    this.remoteService.pagerParams.perPage = this.grid.perPage;
    this.configureExcelExport();
  }

  runReport() {
    this.isLoading = true;
    const keys = {
      consumerAdministration: 'consumerAdministrationId',
      consumer: 'consumerId',
      registerAdministration: 'administrationId',
      register: 'registerId',
      adapter: 'adapterId',
      certificate: 'certificateId',
      adapterOperation: 'operationId',
      operationElement: 'elementId'
    };
    let filter = Object.keys(keys)
      .filter(
        (key) => (key !== 'operationElement' || this.includeElements) && this.accessReportFilter[key] && this.accessReportFilter[key].id
      )
      .map((key) => `${keys[key]} eq ${this.accessReportFilter[key].id}`)
      .join(' and ');
    const consumerFilter = this.formGroupConsumers.controls['consumerDescription'].value;
    if (consumerFilter !== undefined && consumerFilter !== '') {
      if (filter !== undefined && filter !== '') {
        filter = `${filter} and contains(consumerDescription, '${consumerFilter}')`;
      } else {
        filter = `contains(consumerDescription, '${consumerFilter}')`;
      }
    }
    this.httpParameters = new HttpParams();
    if (filter) {
      this.httpParameters = this.httpParameters.append('$filter', filter);
    }
    if (this.includeElements) {
      this.httpParameters = this.httpParameters.append('$includeElements', 'true');
    }
    this.readData(this.httpParameters);
  }

  onClosing() {}

  public onDoneSelected(dropDownCalendar) {
    dropDownCalendar.close();
  }

  public pagerChange(event: IGridPagerOutputParams) {
    this.remoteService.pagerParams.perPage = event.perPage;
    this.remoteService.pagerParams.page = event.page;
    //const httpParameters = this.getExtendedParameters(null);
    this.remoteService.processData(this.httpParameters);
  }

  protected excelExportMapItem(item: ConsumerUsageModel){
    const result =  {
      // Ид: item.id,
      Консуматор: item.consumerName,
      Сертификат: item.consumerCertificate,
      Thumbprint: item.certificateThumbprint,
      'Активен сертификат': item.certificateIsActive,
      Регистър: item.registerName,
      Адаптер: item.adapterName,
      Операция: item.operationNameEn,
      Описание: item.operationName,
      Потребител: item.updatedBy,
      Елемент: item.elementName,
      'Променено на': this.dateFormatService.formatForExport(item.updatedOn)
    };
    if (!this.includeElements){
      delete result.Елемент;
    }
    return result;
  }
  includeElementsChanged(event: IChangeCheckboxEventArgs) {
    this.clearFilters();
    this.includeElements = event.checked;
    this.formGroupAdministrationsKeysArray = Object.keys(
      this.formGroupAdministrationsKeys
    ).filter( k => k !== 'operationElement' || this.includeElements);
    this.formGroupAdministrations = this.buildAdministrationsForm();
  }
}
