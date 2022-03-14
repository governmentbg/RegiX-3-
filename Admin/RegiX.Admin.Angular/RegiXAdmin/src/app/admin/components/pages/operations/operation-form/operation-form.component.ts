import { Component, OnInit, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { AdapterOperationModel } from 'src/app/core/models/dto/adapter-operation.model';
import { AdapterOperationsService } from 'src/app/core/services/rest/adapter-operations.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EActions} from '@tl/tl-common';

@Component({
  selector: 'app-operation-form',
  templateUrl: './operation-form.component.html',
  styleUrls: ['./operation-form.component.scss']
})
export class OperationFormComponent extends FormComponent<
  AdapterOperationModel,
  AdapterOperationsService
> {
  constructor(
    service: AdapterOperationsService,
    injector: Injector,
    private formBuilder: FormBuilder
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      name: [{ value: '', disabled: true }],
      id: [{ value: '', disabled: true }],
      description: [{ value: '', disabled: true }],
      updatedOn: [{ value: '', disabled: true }],
      updatedBy: [{ value: '', disabled: true }],
      createdBy: [{ value: '', disabled: true }],
      registerAdapterName: [{ value: '', disabled: true }],
      registerAdapter: [{ value: '', disabled: true }],
      registerObjectName: [{ value: '', disabled: true }],
      registerObject: [{ value: '', disabled: true }]
    });
  }

  createInputObject(object: AdapterOperationModel): any {
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
