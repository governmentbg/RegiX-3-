import { Component, OnInit, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { AuditExceptionModel } from 'src/app/core/models/dto/audit-exception.model';
import { AuditExceptionsService } from 'src/app/core/services/rest/audit-exceptions.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EActions } from 'src/app/admin/enums/actions.enum';

@Component({
  selector: 'app-system-error-form',
  templateUrl: './system-error-form.component.html',
  styleUrls: ['./system-error-form.component.scss']
})
export class SystemErrorFormComponent extends FormComponent<
  AuditExceptionModel,
  AuditExceptionsService
> {
  constructor(
    service: AuditExceptionsService,
    injector: Injector,
    private formBuilder: FormBuilder
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      exceptionTime: [{ value: '', disabled: true }],
      exceptionText: [{ value: '', disabled: true }],
      userName: [{ value: '', disabled: true }],
      controller: [{ value: '', disabled: true }],
      actionMethod: [{ value: '', disabled: true }],
      authority: [{ value: '', disabled: true }],
      authorityName: [{ value: '', disabled: true }]
    });
  }

  createInputObject(object: AuditExceptionModel): any {
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
