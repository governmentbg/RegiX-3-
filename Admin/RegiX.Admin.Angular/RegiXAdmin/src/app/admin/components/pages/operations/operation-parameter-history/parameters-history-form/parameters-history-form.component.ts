import { Component, OnInit, Injector } from '@angular/core';
import { ParameterValueLogModel } from 'src/app/core/models/dto/parameter-value-log.model';
import { ParameterValueLogsService } from 'src/app/core/services/rest/parameter-value-logs.service';
import { FormComponent } from '@tl/tl-common';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EActions} from '@tl/tl-common';

@Component({
  selector: 'app-parameters-history-form',
  templateUrl: './parameters-history-form.component.html',
  styleUrls: ['./parameters-history-form.component.scss']
})
export class ParametersHistoryFormComponent extends FormComponent<
  ParameterValueLogModel,
  ParameterValueLogsService
> {
  constructor(
    service: ParameterValueLogsService,
    injector: Injector,
    private formBuilder: FormBuilder
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      key: [{ value: '', disabled: true }],
      id: [{ value: '', disabled: true }],
      oldValue: [{ value: '', disabled: true }],
      newValue: [{ value: '', disabled: true }],
      editedTime: [{ value: '', disabled: true }],
      registerAdapter: [{ value: '', disabled: true }],
      registerAdapterName: [{ value: '', disabled: true }],
      user: [{ value: '', disabled: true }],
      userName: [{ value: '', disabled: true }]
    });
  }

  createInputObject(object: ParameterValueLogModel): any {
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
