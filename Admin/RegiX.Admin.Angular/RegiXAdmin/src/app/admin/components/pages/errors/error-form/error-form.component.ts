import { Component, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { OperationErrorLogModel } from 'src/app/core/models/dto/operation-error-log.model';
import { OperationsErrorLogService } from 'src/app/core/services/rest/operations-error-log.service';
import { FormGroup, FormBuilder } from '@angular/forms';import { EActions} from '@tl/tl-common';
@Component({
  selector: 'app-error-form',
  templateUrl: './error-form.component.html',
  styleUrls: ['./error-form.component.scss']
})
export class ErrorFormComponent extends FormComponent<
  OperationErrorLogModel,
  OperationsErrorLogService
> {
  constructor(
    service: OperationsErrorLogService,
    injector: Injector,
    private formBuilder: FormBuilder
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      errorMessage: [{ value: '', disabled: true }],
      logTime: [{ value: '', disabled: true }],
      createdOn: [{ value: '', disabled: true }],
      errorContent: [{ value: '', disabled: true }],
      adapterOperation: [{ value: '', disabled: true }],
      adapterOperationName: [{ value: '', disabled: true }],
      apiServiceCall: [{ value: '', disabled: true }],
      apiServiceCallName: [{ value: '', disabled: true }],
      apiServiceOperations: [{ value: '', disabled: true }],
      apiServiceOperationsName: [{ value: '', disabled: true }],
      apiServiceConsumer: this.formBuilder.group({
        displayName: [{ value: '', disabled: true }],
        id: [{ value: '', disabled: true }],
      }),
      consumerCertificate: this.formBuilder.group({
        displayName: [{ value: '', disabled: true }],
        id: [{ value: '', disabled: true }],
      }),
      administration: this.formBuilder.group({
        displayName: [{ value: '', disabled: true }],
        id: [{ value: '', disabled: true }],
      }),
    });
  }

  createInputObject(object: OperationErrorLogModel): any {
    return null;
  }

  ngOnInitImplementation() {}

 
}
