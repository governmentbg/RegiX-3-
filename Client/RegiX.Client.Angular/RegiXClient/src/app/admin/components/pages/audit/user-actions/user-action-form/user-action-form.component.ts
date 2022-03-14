import { Component, OnInit, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { UserActionModel } from 'src/app/core/models/dto/user-action.model';
import { UserActionsService } from 'src/app/core/services/rest/user-actions.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EActions } from 'src/app/admin/enums/actions.enum';

@Component({
  selector: 'app-user-action-form',
  templateUrl: './user-action-form.component.html',
  styleUrls: ['./user-action-form.component.scss']
})
export class UserActionFormComponent extends FormComponent<
  UserActionModel,
  UserActionsService
> {
  constructor(
    service: UserActionsService,
    injector: Injector,
    private formBuilder: FormBuilder
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      userActionTime: [{ value: '', disabled: true }],
      userActionText: [{ value: '', disabled: true }],
      userActionType: [{ value: '', disabled: true }],
      userName: [{ value: '', disabled: true }],
      controller: [{ value: '', disabled: true }],
      actionMethod: [{ value: '', disabled: true }],
      executeStatus: [{ value: '', disabled: true }],
      params: [{ value: '', disabled: true }],
      url: [{ value: '', disabled: true }],
      changedTables: [{ value: '', disabled: true }],
    });
  }

  createInputObject(object: UserActionModel): any {
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
