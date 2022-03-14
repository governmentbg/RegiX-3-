import { BaseOperationCallsService } from './../../../core/services/rest/base/base-operation-calls.service';
import {
  Component,
  OnInit,
  OnDestroy,
  AfterViewInit,
  NgZone, Directive
} from '@angular/core';
import { OperationCallModel } from 'src/app/core/models/dto/operation-call.model';
import { OperationParameterModel } from 'src/app/core/models/operations/operation-parameter.model';
import { FormGroup, FormBuilder } from '@angular/forms';
import { AdapterOperationsService } from 'src/app/core/services/rest/adapter-operations.service';
import { ActivatedRoute } from '@angular/router';
import { HttpParams } from '@angular/common/http';
import { Location } from '@angular/common';
import { Subscription } from 'rxjs';
import { OperationParameterWithValueModel } from 'src/app/core/models/operation-values/operation-parameter-with-value.model';
import { AdapterOperationModel } from 'src/app/core/models/dto/adapter-operation.model';
import { ToastService } from '@tl/tl-common';
import { UsersService } from 'src/app/core/services/rest/users.service';
import { UsersModel } from 'src/app/core/models/dto/users.model';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { map } from 'rxjs/operators';
import { IgxSelectComponent } from 'igniteui-angular';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { OperationControlService } from '../pages/operation-calls/operation-call/operation-control-service.service';

@Directive()
export abstract class BaseOperationCallComponent<
  T extends OperationCallModel,
  CS extends BaseOperationCallsService<T>
> implements OnInit, OnDestroy, AfterViewInit {
  adapterOperationId: number = null;
  operationCallId: number = null;
  isShowForm: boolean = null;
  isAdmin: boolean = null;

  operationCall: T = null;
  adapterOperation: AdapterOperationModel = null;

  operationSubscriptionRequest: Subscription;

  isDataLoaded = false;
  isDataLoading = false;

  pageTitle = 'Заявка';
  pageTitleResponse = 'Отговор на заявката';

  assignedTo = new DisplayValue();
  users: DisplayValue[] = [];

  // Request parametes and values for them
  operationParameters: OperationParameterModel[] = null;
  operationParametersValues: OperationParameterWithValueModel[] = [];

  // Response parameters(With them we build the form)
  operationParametersResponse: OperationParameterModel[] = null;
  operationParametersValuesResponse: OperationParameterWithValueModel[] = [];

  formGroup: FormGroup = null;
  formGroupResponse: FormGroup = null;

  errorMessage: string = null;
  isRequestLoading = false;

  constructor(
    private activatedRoute: ActivatedRoute,
    protected operationCallsService: CS,
    private adapterOperationService: AdapterOperationsService,
    private operationSubjectService: OperationControlService,
    private userService: UsersService,
    protected locationService: Location,
    private formBuilder: FormBuilder,
    private toastService: ToastService,
    private ngZone: NgZone,
    protected oidcSecurityService: OidcSecurityService
  ) {
    this.isShowForm =
      this.activatedRoute.snapshot.url.pop().toString() === 'edit'
        ? false
        : true;

    this.activatedRoute.params.subscribe((params) => {
      this.operationCallId = params.ID;
      this.readOperationCall();
    });
  }

  ngOnInit() {
    this.SetCurrentUserData();
  }

  ngAfterViewInit() {
    this.operationSubscriptionRequest = this.operationSubjectService.operationSubject.subscribe(
      (data) => {
        this.ngZone.run(() => {
          console.log(this.formGroup === data);
          console.log('initialized => AfterViewInit', data);

          if (this.formGroup === data) {
            this.setParameterDataRequest();
            this.formGroup.markAsPristine();
          } else if (this.formGroupResponse === data) {
            this.setParameterDataResponse();
            this.formGroupResponse.markAsPristine();
            this.formGroupResponse.markAsUntouched();
          } else {
            throw new Error('not implemented');
          }
        });
      }
    );
  }

  ngOnDestroy() {
    if (this.operationSubscriptionRequest != null) {
      this.operationSubscriptionRequest.unsubscribe();
    }
  }

  private readOperationCall() {
    console.log('read operationCall');
    this.isDataLoading = true;

    let httpParameters = new HttpParams();

    this.operationCallsService
      .find(this.operationCallId, httpParameters)
      .subscribe(
        (data: T) => {
          this.operationParametersValues = data.requestParamsValues;
          this.operationParametersValuesResponse = data.responseParamsValues;
          this.adapterOperationId = data.adapterOperation.id;
          this.readAdapterOperation(data);
        },
        () => {
          this.isDataLoading = false;
          this.isDataLoaded = true;
        }
      );
  }

  private readAdapterOperation(operationCall: T) {
    this.operationCall = operationCall;
    this.adapterOperationService
      .find(operationCall.adapterOperation.id)
      .subscribe(
        (data) => {
          this.operationParameters = data.requestMetadata;
          this.operationParametersResponse = data.responseMetadata;
          this.adapterOperationId = data.id;
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
    this.buildOperationsFormRequest();
    this.buildOperationsFormResponse();
    this.isDataLoading = false;
    this.isDataLoaded = true;
  }

  private buildOperationsFormRequest() {
    this.buildForm();
  }

  private buildOperationsFormResponse() {
    this.buildFormResponse();
    this.setSystemData();
  }

  private buildForm() {
    this.formGroup = this.formBuilder.group({});
  }

  private buildFormResponse() {
    this.formGroupResponse = this.formBuilder.group({
      assignedToName: [{ value: '', disabled: this.isShowForm }],
      startTime: [{ value: '', disabled: true }],
    });
  }

  protected abstract setSystemData();

  private setParameterDataRequest() {
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
  }

  private setParameterDataResponse() {
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

  onSubmit($event) {
    if (this.formGroupResponse.valid && this.formGroupResponse.touched) {
      const formData = this.formGroupResponse.getRawValue();
      this.operationCallsService
        .executeRequest({
          operationId: this.operationCall.id,
          operationCallName: this.operationCall.adapterOperationName,
          requestData: formData,
        })
        .subscribe(
          () => {
            this.errorMessage = null;
            // this.isPending = false;
            this.toastService.showMessage('Обектът е обновен успешно!');
            this.locationService.back();
          },
          (error) => {
            console.log('error', error);
            this.errorMessage =
              'Грешка при обновяване на обект: ' + error.message;
          }
        );
    }
  }

  onSave(event: any) {
    this.updateObject();
  }

  public onReset() {}

  public onCancel() {
    if (!this.isAdmin) {
      this.onClear(); // clear filled fields
      if (!this.formGroupResponse.valid && !this.formGroupResponse.touched) {
        this.operationCallsService
          .updateAssignedTo({
            operationId: this.operationCall.id,
            operationCallName: this.operationCall.adapterOperationName,
            assignedToId: null,
          })
          .subscribe(
            () => {
              this.errorMessage = null;
            },
            (error) => {
              console.log('error', error);
              this.errorMessage =
                'Грешка при обновяване на обект: ' + error.message;
            }
          );
      }
    }
    this.locationService.back();
  }

  public isFormValid() {
    // TODO: Add another validation for "Изпрати"
    return (
      this.formGroupResponse.touched &&
      (this.isAdmin ? true : this.formGroupResponse.valid)
    );
  }

  public isFormTouched() {
    return this.formGroupResponse.touched;
  }

  public onClear() {
    this.errorMessage = null;
    this.formGroupResponse.reset();
    this.formGroupResponse.markAsPristine();
    this.formGroupResponse.markAsUntouched();
  }

  public setToNull(igxSelect: IgxSelectComponent, formControlName: string) {
    this.formGroupResponse.markAsTouched();
    console.log('setToNull', igxSelect, formControlName);
    igxSelect.value = null;
    this.formGroupResponse.controls[formControlName].setValue(null);
  }

  private updateObject() {
    // If you are Admin you can update the form without it being valid
    if (
      (this.isAdmin ? true : this.formGroupResponse.valid) &&
      this.formGroupResponse.touched
    ) {
      const formData = this.formGroupResponse.getRawValue();
      this.operationCallsService
        .updateParameters({
          operationId: this.operationCall.id,
          operationCallName: this.operationCall.adapterOperationName,
          requestData: formData,
        })
        .subscribe(
          () => {
            this.errorMessage = null;
            // this.isPending = false;
            this.toastService.showMessage('Обектът е обновен успешно!');
            this.locationService.back();
          },
          (error) => {
            console.log('error', error);
            this.errorMessage =
              'Грешка при обновяване на обект: ' + error.message;
          }
        );
    }
  }

  protected readUsers() {
    console.log('READING USERS...');
    // Users types
    this.userService
      .getUsersByOperation(this.adapterOperation.id)
      .pipe(
        map((items: UsersModel[]) => {
          return items.map((item) => {
            return new DisplayValue({ id: item.id, displayName: item.name });
          });
        })
      )
      .subscribe(
        (data) => {
          this.users = data;
          this.isDataLoaded = true;
          this.isDataLoading = false;
        },
        () => {
          this.isDataLoaded = false;
          this.isDataLoading = false;
          this.errorMessage =
            'Грешка при извличане на данни за типове администрации.';
        }
      );
  }

  protected abstract SetCurrentUserData();
}
