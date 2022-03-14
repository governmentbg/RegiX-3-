import { Component, OnInit, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { UsersModel } from 'src/app/core/models/dto/users.model';
import { UserInModel } from 'src/app/core/models/dto/in/user.in.model';

import {
  FormGroup,
  FormBuilder,
  FormControl
} from '@angular/forms';

import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { UserShowModel } from 'src/app/core/models/dto/user-show.model';
import { UserShowService } from 'src/app/core/services/rest/user-show.service';

@Component({
  selector: 'app-user-show-form',
  templateUrl: './user-show-form.component.html',
  styleUrls: ['./user-show-form.component.scss']
})
export class UserShowFormComponent extends FormComponent<UserShowModel, UserShowService> {

  constructor(
    private formBuilder: FormBuilder,
    service: UserShowService,
    private administrationService: AdministrationsService,
    injector: Injector
  ) {
    super(service, injector);
  }
  buildFormImpl(): FormGroup {
    let formBuildObject: any;
    formBuildObject = {
      name: [{ value: '', disabled: this.isShowForm() }],
      userName: [{ value: '', disabled: this.isShowForm() }],
      id: [{ value: '', disabled: true }],
      isLockedOut:[{ value: '', disabled: true }],
      active: new FormControl({ value: '', disabled: this.isShowForm() }),
      email: [{ value: '', disabled: this.isShowForm() }],
      administration: [{ value: '', disabled: this.isShowForm() }],
      administrationName: [{ value: '', disabled: this.isShowForm() }],
      updatedOn: [{ value: '', disabled: true }],
      updatedBy: [{ value: '', disabled: true }],
      createdBy: [{ value: '', disabled: true }]
    };

    return this.formBuilder.group(formBuildObject);
  }

  createInputObject(object: UsersModel): any {
    return new UserInModel(object);
  }

  ngOnInitImplementation() {

  }

  protected onBaseServiceLoaded() {
    // do nothing if in edit or create mode, let the additional operations
    // do their work and set the appropriate flags
    if (this.isShowForm()) {
      super.onBaseServiceLoaded();
    }
  }
}

