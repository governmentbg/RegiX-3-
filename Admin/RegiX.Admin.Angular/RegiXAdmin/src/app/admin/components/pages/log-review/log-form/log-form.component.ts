import { Component, OnInit, Injector } from '@angular/core';
import { ApiServiceCallModel } from 'src/app/core/models/dto/api-service-call.model';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Location } from "@angular/common";
import { FormComponent } from '@tl/tl-common';
import { EActions} from '@tl/tl-common';
import { ApiServiceCallService } from 'src/app/core/services/rest/api-service-call.service';

@Component({
  selector: 'app-log-form',
  templateUrl: './log-form.component.html',
  styleUrls: ['./log-form.component.scss']
})
export class LogFormComponent extends FormComponent<
  ApiServiceCallModel,
  ApiServiceCallService
> {
  constructor(
    service: ApiServiceCallService,
    injector: Injector,
    private formBuilder: FormBuilder,
    private location: Location
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      instanceId: [{ value: '', disabled: true }],
      resultReady: [{ value: '', disabled: true }],
      startTime: [{ value: '', disabled: true }],
      endTime: [{ value: '', disabled: true }],
      resultReturned: [{ value: '', disabled: true }],
      callContext: [{ value: '', disabled: true }],
      eidToken: [{ value: '', disabled: true }],
      clientIpAddress: [{ value: '', disabled: true }],
      resultContent: [{ value: '', disabled: true }],
      hasError: [{ value: '', disabled: true }],
      errorContent: [{ value: '', disabled: true }],
      oidToken: [{ value: '', disabled: true }],
      contextSerivceUri: [{ value: '', disabled: true }],
      contextServiceType: [{ value: '', disabled: true }],
      contextEmployeeIdentifier: [{ value: '', disabled: true }],
      contextEmployeeNames: [{ value: '', disabled: true }],
      contextEmployeeAditionalId: [{ value: '', disabled: true }],
      contextEmployeePosition: [{ value: '', disabled: true }],
      contextAdministrationOid: [{ value: '', disabled: true }],
      contextAdministrationName: [{ value: '', disabled: true }],
      contextResponsibleNames: [{ value: '', disabled: true }],
      contextLawReason: [{ value: '', disabled: true }],
      ipAddress: [{ value: '', disabled: true }],
      appName: [{ value: '', disabled: true }],
      apiServiceOperation: [{ value: '', disabled: true }],
      apiServiceOperationName: [{ value: '', disabled: true }],
      consumerCertificate: [{ value: '', disabled: true }],
      consumerCertificateName: [{ value: '', disabled: true }]
    });
  }

  createInputObject(object: ApiServiceCallModel): any {
    return null;
  }

  ngOnInitImplementation() {}

  prepareForm() {
    switch (this.currentAction) {
      case EActions.SHOW: {
        super.prepareForShow(this.formObject);
        break;
      }
    }
  }
}
