import { Component, Injector } from '@angular/core';
import { AdapterOperationModel } from 'src/app/core/models/dto/adapter-operation.model';
import { AdapterOperationsService } from 'src/app/core/services/rest/adapter-operations.service';
import { FormComponent } from '@tl/tl-common';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-adapter-operations-form',
  templateUrl: './adapter-operations-form.component.html',
  styleUrls: ['./adapter-operations-form.component.scss']
})
export class AdapterOperationsFormComponent extends FormComponent<
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
      id: [{ value: '', disabled: true }],
      name: [{ value: '', disabled: true }],
      description: [{ value: '', disabled: true }],
      contract: [{ value: '', disabled: true }],
    });
  }

  createInputObject(object: AdapterOperationModel): any {
    return null;
  }

  ngOnInitImplementation() {}
}

