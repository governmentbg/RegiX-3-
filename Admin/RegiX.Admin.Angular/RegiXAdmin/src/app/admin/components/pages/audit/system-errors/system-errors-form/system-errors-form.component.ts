import { Component, OnInit, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { ExceptionModel } from 'src/app/core/models/dto/exception.model';
import { ExceptionsService } from 'src/app/core/services/rest/exceptions.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EActions} from '@tl/tl-common';

@Component({
  selector: 'app-system-errors-form',
  templateUrl: './system-errors-form.component.html',
  styleUrls: ['./system-errors-form.component.scss']
})
export class SystemErrorsFormComponent extends FormComponent<
  ExceptionModel,
  ExceptionsService
> {
  constructor(
    service: ExceptionsService,
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
      userId: [{ value: '', disabled: true }],
      userName: [{ value: '', disabled: true }],
      controller: [{ value: '', disabled: true }],
      actionMethod: [{ value: '', disabled: true }],
      ipAddress: [{ value: '', disabled: true }]
    });
  }

  createInputObject(object: ExceptionModel): any {
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
