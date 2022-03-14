import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AdapterOperationsService } from 'src/app/core/services/rest/adapter-operations.service';
import { AdapterOperationModel } from 'src/app/core/models/dto/adapter-operation.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DatePipe, Location } from '@angular/common';
import { ReportsService } from 'src/app/core/services/rest/reports.service';
import { ReportModel } from 'src/app/core/models/dto/report.model';
import { HttpParams } from '@angular/common/http';
import { OperationMetadataService } from 'src/app/core/services/rest/operation-metadata.service';
import { LoginService } from 'src/app/core/services/login.service';
import { ReportResultModel } from 'src/app/core/models/dto/report-result.model';
import { ClientPermissions } from 'src/app/admin/permissions';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { NgxPermissionsService } from 'ngx-permissions';
import { OperationParameterModel } from '@tl-rgx/rgx-common';
import { ConnectedPositioningStrategy, HorizontalAlignment, NoOpScrollStrategy, VerticalAlignment } from 'igniteui-angular';
import { b64toBlob2 } from 'src/app/admin/utility/b64toBlob2';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.scss']
})
export class ReportComponent implements OnInit {
  operationRoute = ROUTES.OPERATION;
  reportId: number = null;
  authorityId: number = null;
  report: ReportModel = null;
  adapterOperation: AdapterOperationModel = null;
  isDataLoaded = false;
  isDataLoading = false;
  pageTitle = 'Услуга';
  executionDate: Date;
  operationParameters: OperationParameterModel[] = null;
  formGroup: FormGroup = null;
  errorMessage: string = null;
  isRequestLoading = false;
  reportResult: ReportResultModel = null;
  asyncReportExecutionID: any = null;
  basicPermissions = ClientPermissions.BASIC;
  allPermissions = ClientPermissions.ALL;

  public menuOverlaySettings = {
    positionStrategy: new ConnectedPositioningStrategy({
      horizontalDirection: HorizontalAlignment.Left,
      horizontalStartPoint: HorizontalAlignment.Right,
      verticalStartPoint: VerticalAlignment.Top,
      verticalDirection: VerticalAlignment.Top
    }),
    scrollStrategy: new NoOpScrollStrategy()
  };

  constructor(
    private activatedRoute: ActivatedRoute,
    private reportsService: ReportsService,
    private operationService: AdapterOperationsService,
    private operationMetadataService: OperationMetadataService,
    private formBuilder: FormBuilder,
    private locationService: Location,
    private loginService: LoginService,
    private ngxPermissions: NgxPermissionsService,
    private datePipe: DatePipe
  ) {
    // this.reportId = this.activatedRoute.snapshot.params['REPORT_ID'];
    // this.readReport();
    this.activatedRoute.params.subscribe(params => {
      this.authorityId = params['AUTHORITY_ID'];
      this.reportId = params['REPORT_ID'];
      this.readReport();
    });
  }

  ngOnInit() {}

  private readReport() {
    console.log('read report');
    this.isDataLoading = true;

    let httpParameters = new HttpParams();
    const filteringParams =
      'id eq ' +
      this.reportId;
      // ' and registerAuthority.id eq ' +
      // this.authorityId
    httpParameters = httpParameters.append('$filter', filteringParams);

    this.reportsService.find(this.reportId, httpParameters).subscribe(
      (data: ReportModel) => {
          this.pageTitle = data.name;
          this.readAdapterOperation(data);
      },
      error => {
        this.isDataLoading = false;
        this.isDataLoaded = true;
      }
    );
  }

  private readAdapterOperation(report: ReportModel) {
    this.report = report;
    this.operationService.find(report.adapterOperation.id).subscribe(
      data => {
        this.readOperationMetadata(data);
      },
      error => {
        this.isDataLoading = false;
        this.isDataLoaded = true;
      }
    );
  }

  private readOperationMetadata(data) {
    this.adapterOperation = data;
    this.buildOperationsForm();
  }

  markFormAsUntouched() {
    this.formGroup.markAsPristine();
    this.formGroup.markAsUntouched();
  }

  private buildOperationsForm() {
    this.operationMetadataService.get(this.adapterOperation.id).subscribe(
      data => {
        const parameters = data;
        this.buildForm(parameters);
      },
      error => {
        this.isDataLoading = false;
        this.isDataLoaded = true;
      }
    );
  }

  private buildForm(parameters: OperationParameterModel[]) {
    this.ngxPermissions.hasPermission('PUBLIC').then(
      isPublic => {
        this.formGroup = this.formBuilder.group({
          regiXClient_employeeName: [{ value: '', disabled: true }],
          regiXClient_employeeId: [{ value: '', disabled: true }],
          regiXClient_administrationName: [{ value: '', disabled: true }],
          regiXClient_employeePosition: [{ value: '', disabled: true }],
          regiXClient_additionalEmployeeId: [{ value: '', disabled: false }],
          regiXClient_serviceURI: [{ value: '', disabled: false }, isPublic ? [] : [Validators.required]],
          regiXClient_serviceType: [{ value: '', disabled: false } ],
          regiXClient_lawReason: [{ value: '', disabled: false}, isPublic ? [] : [Validators.required]],
          regiXClient_remarks: [{ value: '', disabled: false }],
          regiXClient_resultAsPDF: [{ value: false, disabled: false }],
          regiXClient_returnAccessMatrix: [{ value: true, disabled: false }],
          regiXClient_signResult: [{ value: true, disabled: false }]
        });
        this.setSystemData();

        this.operationParameters = parameters;
        console.log('operationParameters', this.operationParameters);

        this.isDataLoading = false;
        this.isDataLoaded = true;
        this.markFormAsUntouched();
      }
    );
  }

  private setSystemData() {
    this.formGroup.patchValue({
      regiXClient_lawReason: this.report.lawReason,
      // employeeId: user.id,
      // employeeName: user.name,
      regiXClient_administrationName: this.report.authorityName,
      regiXClient_resultAsPDF: false,
      regiXClient_returnAccessMatrix: true,
      regiXClient_signResult: true
    });
  }

  onSubmit(event: any) {
    let request: any = null;
    request = {
          operationId: this.report.adapterOperation.id,
          reportId: this.report.id,
          requestData: this.formGroup.getRawValue()
      };
    this.isRequestLoading = true;
    this.operationService
        .executeRequest(
          request
        )
        .subscribe(r => {
          this.isRequestLoading = false;
          if (r.asyncReportExecutionId) {
            this.asyncReportExecutionID = r.asyncReportExecutionId;
          } else {
            this.executionDate = new Date();
            this.reportResult = new ReportResultModel(r);
          }
        }, e => {
          console.log(e);
          this.reportResult = new ReportResultModel({ hasError: true, isReady: true, error: e.message});
          this.isRequestLoading = false;
        });
  }

  public onCancelRequest() {
    this.reportResult = null;
    this.isRequestLoading = false;
    this.asyncReportExecutionID = null;
  }

  public onReset() {
    this.isDataLoading = true;
    this.isDataLoaded = false;
    this.executionDate = null;
    this.reportResult = null;
    this.asyncReportExecutionID = null;
    this.formGroup = null;
    this.buildOperationsForm();
  }


  public onCancel() {
    this.locationService.back();
  }

  public isFormValid() {
    return this.formGroup.dirty && this.formGroup.valid;
  }

  public isFormDirty() {
    return this.formGroup.dirty;
  }

  public onClear() {
    this.formGroup.markAsPristine();
    this.formGroup.markAsUntouched();
    this.errorMessage = null;
    let hasDisabledFields = false;
    const keys = Object.keys(this.formGroup.controls);
    // TODO: Check if deeper level resets are needed
    keys.forEach( k => {
      if (!this.formGroup.controls[k].disabled) {
        this.formGroup.controls[k].reset();
      } else {
        hasDisabledFields = true;
      }
    });
    if (hasDisabledFields) {
      this.formGroup.markAsDirty();
    }
    this.setSystemData();
  }

  onPrint() {
    const printContents = document.getElementById('report-result').innerHTML;
    const popupWin = window.open('', '_blank');
    const executionDateFormatted = this.datePipe.transform(this.executionDate, 'dd.MM.yyyy HH:mm:ss');
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <title></title>
          <style>
          </style>
        </head>
        <body onload="window.print();window.close()">
            <div>${printContents}</div>
            <h4>Дата на изпълнение: ${executionDateFormatted}</h4>
        </body>
      </html>`
    );
    popupWin.document.close();
  }

  onResponseSaveXML(event: any) {
    const blob = new Blob([this.reportResult.responseXml], { type: 'text/xml' });
    const url = window.URL.createObjectURL(blob);
    if (event.newSelection.value === 'Open') {
      window.open(url);
    } else {
      const a = document.createElement('a');
      document.body.appendChild(a);
      a.setAttribute('style', 'display: none');
      a.href = url;
      a.download = 'Response.xml';
      a.click();
      window.URL.revokeObjectURL(url);
      a.remove();
    }
  }

  onRequestSaveXML(event: any) {
    const blob = new Blob([this.reportResult.requestXml], { type: 'text/xml' });
    const url = window.URL.createObjectURL(blob);
    if (event.newSelection.value === 'Open') {
      window.open(url);
    } else {
      const a = document.createElement('a');
      document.body.appendChild(a);
      a.setAttribute('style', 'display: none');
      a.href = url;
      a.download = 'Request.xml';
      a.click();
      window.URL.revokeObjectURL(url);
      a.remove();
    }
  }

  onCertSave(event: any) {
    if (event.newSelection.value === 'Certificate') {
      const blob = new Blob([this.reportResult.signatureCertirifcate], { type: 'application/pkix-cert' });
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      document.body.appendChild(a);
      a.setAttribute('style', 'display: none');
      a.href = url;
      a.download = 'Certificate.crt';
      a.click();
      window.URL.revokeObjectURL(url);
      a.remove();
    } else {
      const blob = new Blob([this.reportResult.rawResponseXml], { type: 'text/xml' });
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      document.body.appendChild(a);
      a.setAttribute('style', 'display: none');
      a.href = url;
      a.download = 'RawResponse.xml';
      a.click();
      window.URL.revokeObjectURL(url);
      a.remove();
    }
  }

  onPDFSave(event: any) {
    b64toBlob2(this.reportResult.responsePdf, 'application/pdf').then( b => {
      const url = window.URL.createObjectURL(b);
      if (event.newSelection.value === 'Open') {
        window.open(url);
      } else {
        const a = document.createElement('a');
        document.body.appendChild(a);
        a.setAttribute('style', 'display: none');
        a.href = url;
        a.download = 'Response.pdf';
        a.click();
        window.URL.revokeObjectURL(url);
        a.remove();
      }
    });
  }
}
