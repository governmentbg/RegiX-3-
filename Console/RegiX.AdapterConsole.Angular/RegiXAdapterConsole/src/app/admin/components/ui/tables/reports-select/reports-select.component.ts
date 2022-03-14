import { Component, Injector, Input } from '@angular/core';
import { RemoteComponentWithForm } from '@tl/tl-common';
import { AdapterOperationModel } from 'src/app/core/models/dto/adapter-operation.model';
import { AdapterOperationsService } from 'src/app/core/services/rest/adapter-operations.service';
import { HttpParams } from '@angular/common/http';
import { ReportSelectGridRemoteFilteringService } from 'src/app/core/services/report-select-grid-remote-filtering.service';
import { OperationsToRolesService } from 'src/app/core/services/rest/operations-to-roles.service';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-reports-select',
  templateUrl: './reports-select.component.html',
  styleUrls: ['./reports-select.component.scss'],
})
export class ReportsSelectComponent extends RemoteComponentWithForm<
  AdapterOperationModel,
  AdapterOperationsService
> {
  @Input()
  formGroup: FormGroup;

  @Input()
  isShowForm: boolean;
  constructor(
    service: AdapterOperationsService,
    injector: Injector,
    private operationsToRolesService: OperationsToRolesService
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {}

  protected createRemoteService() {
    this.remoteService = new ReportSelectGridRemoteFilteringService(
      null,
      this.service,
      this.grid,
      this.injector,
      this.operationsToRolesService,
      this.activatedRoute
    );
  }

  getExtendedParameters(params?: HttpParams) {
    this.logger.debug('READ DATA IN REMOTE');
    const filteringParams = null; //this.getFilterExpression();
    let httpParameters = params;
    if (filteringParams) {
      if (!httpParameters) {
        httpParameters = new HttpParams();
      }
      httpParameters = httpParameters.append('$filter', filteringParams);
    }
    this.logger.debug('httpParameters', httpParameters);
    return httpParameters;
  }

  onRowClickChange(event) {
    if (this.isShowForm) {
      event.newSelection = event.oldSelection;
    } else {
      console.log(event);
      this.formGroup.markAllAsTouched();
      this.formGroup.markAsDirty();
    }
  }
}
