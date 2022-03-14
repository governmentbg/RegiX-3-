import { Component, OnInit, OnDestroy, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { OperationParameterModel } from 'src/app/core/models/operations/operation-parameter.model';
import { FormGroup, FormBuilder } from '@angular/forms';
import { AdapterOperationsService } from 'src/app/core/services/rest/adapter-operations.service';
import { OperationMetadataService } from 'src/app/core/services/rest/operation-metadata.service';
import { ActivatedRoute } from '@angular/router';
import { HttpParams } from '@angular/common/http';
import { Location } from '@angular/common';
import { Subscription } from 'rxjs';
import { OperationValuesMetadataService } from 'src/app/core/services/rest/operation-values-metadata.service';
import { OperationParameterWithValueModel } from 'src/app/core/models/operation-values/operation-parameter-with-value.model';
import { AdapterOperationModel } from 'src/app/core/models/dto/adapter-operation.model';
import { OperationControlService } from '../../operation-calls/operation-call/operation-control-service.service';
import { ReturnedCallsService } from 'src/app/core/services/rest/returned-calls.service';
import { ReturnedCallModel } from 'src/app/core/models/dto/returned-call.model';

@Component({
  selector: 'app-returned-call',
  templateUrl: './returned-call.component.html',
  styleUrls: ['./returned-call.component.scss'],
  providers: [OperationControlService]
})
export class ReturnedCallComponent  implements OnInit, OnDestroy, AfterViewInit {
  returnedCallId: number = null;
  apiServiceCallId: number = null;

  returnedCall: ReturnedCallModel = null;
  adapterOperation: AdapterOperationModel = null;

  operationSubscription: Subscription;

  isDataLoaded = false;
  isDataLoading = false;
  isShowForm: boolean = null;

  pageTitle = 'Заявка';

  operationParameters: OperationParameterModel[] = null;
  operationParametersResponse: OperationParameterModel[] = null;

  operationParametersValues: OperationParameterWithValueModel[] = [];
  operationParametersValuesResponse: OperationParameterWithValueModel[] = [];

  formGroup: FormGroup = null;
  formGroupResponse: FormGroup = null;

  errorMessage: string = null;
  isRequestLoading = false;

  constructor(
    private activatedRoute: ActivatedRoute,
    private returnedCallsService: ReturnedCallsService,
    private operationService: AdapterOperationsService,
    private operationSubjectService: OperationControlService,
    private locationService: Location,
    private formBuilder: FormBuilder,
    private cdRef: ChangeDetectorRef
  ) {
    // this.returnedCallId = this.activatedRoute.snapshot.params['returnedCall_ID'];
    // this.readreturnedCall();
    this.activatedRoute.params.subscribe(params => {
      this.returnedCallId = params['ID'];
      this.apiServiceCallId = params['API_CALL_ID'];
      this.readreturnedCall();
    });
  }

  ngOnInit() {}

  ngAfterViewInit() {
    this.operationSubscription = this.operationSubjectService.operationSubject.subscribe(
      data => {
        this.setParameterData();
        this.formGroup.markAsPristine();
        this.cdRef.detectChanges();
      }
    );
  }

  ngOnDestroy() {
    if (this.operationSubscription != null) {
      this.operationSubscription.unsubscribe();
    }
  }

  private readreturnedCall() {
    this.isDataLoading = true;
    let httpParameters = new HttpParams();
    if (this.apiServiceCallId) {
      const filteringParams = `apiServiceCallId eq ${this.apiServiceCallId}`;
      httpParameters = httpParameters.append('$filter', filteringParams);
      this.returnedCallsService
      .getAllNoWrap(httpParameters)
      .subscribe(
        (data: ReturnedCallModel[]) => {
          if (data.length === 1){
            this.operationParametersValues = data[0].requestParamsValues;
            this.operationParametersValuesResponse = data[0].responseParamsValues;
            this.readAdapterOperation(data[0]);

          }
        },
        () => {
          this.isDataLoading = false;
          this.isDataLoaded = true;
        }
      );
    } else {
      const filteringParams = `id eq ${this.returnedCallId}`;
      httpParameters = httpParameters.append('$filter', filteringParams);
      this.returnedCallsService
        .find(this.returnedCallId, httpParameters)
        .subscribe(
          (data: ReturnedCallModel) => {
            this.operationParametersValues = data.requestParamsValues;
            this.operationParametersValuesResponse = data.responseParamsValues;
            this.readAdapterOperation(data);
          },
          () => {
            this.isDataLoading = false;
            this.isDataLoaded = true;
          }
        );

    }
  }

  private readAdapterOperation(returnedCall: ReturnedCallModel) {
    this.returnedCall = returnedCall;
    this.operationService.find(returnedCall.adapterOperation.id).subscribe(
      data => {
        this.operationParameters = data.requestMetadata;
        this.operationParametersResponse = data.responseMetadata;
        this.readOperationMetadata(data);
      },
      () => {
        this.isDataLoading = false;
        this.isDataLoaded = true;
      }
    );
  }

  private readOperationMetadata(data) {
    this.adapterOperation = data;
    this.buildOperationsForm();
    this.buildOperationsFormResponse();
  }

  private buildOperationsForm() {
    this.buildForm();

    this.isDataLoading = false;
    this.isDataLoaded = true;
  }

  private buildOperationsFormResponse() {
    this.buildFormResponse();
    this.setSystemData();
  }

  private buildFormResponse() {
    this.formGroupResponse = this.formBuilder.group({
      returnedByName: [{ value: '', disabled: this.isShowForm }],
      startTime: [{ value: '', disabled: true }]
    });
  }

  private buildForm() {
    this.formGroup = this.formBuilder.group({
      // returnedByName: [{ value: "", disabled: false }],
      // startTime: [{ value: "", disabled: false }]
    });
  }

  private setParameterData() {
    if (this.formGroup !== null) {
      this.operationParametersValues.forEach((element) => {
        let fieldValue = element.value;
        let fieldType = this.operationParameters.filter(
          (x) => x.parameterInfo.parameterName === element.name
        )[0].parameterInfo.parameterType.type;

        if (fieldType === 'DateTime' || fieldType === 'Date') {
          fieldValue = new Date(element.value);
        }

        this.formGroup.patchValue({
          [element.name]: fieldValue,
        });
      });
    }
    if (this.formGroupResponse !== null) {
      this.operationParametersValuesResponse.forEach((element) => {
        let fieldValue = element.value;
        let fieldType = this.operationParametersResponse.filter(
          (x) => x.parameterInfo.parameterName === element.name
        )[0].parameterInfo.parameterType.type;

        if (fieldType === 'DateTime' || fieldType === 'Date') {
          fieldValue = new Date(element.value);
        }

        this.formGroupResponse.patchValue({
          [element.name]: fieldValue,
        });
      });
    }

  }

  private setSystemData() {
    this.formGroupResponse.patchValue({
      returnedByName: this.returnedCall.returnedByName,
      startTime: new Date(this.returnedCall.startTime)
    });
  }

  private CheckValueType(value: string): any {
    let date = Date.parse(value);

    if (isNaN(date) === true) {
      return value;
    }
    return new Date(value);
  }

  public onReset() {}

  public onCancel() {
    this.locationService.back();
  }
}

