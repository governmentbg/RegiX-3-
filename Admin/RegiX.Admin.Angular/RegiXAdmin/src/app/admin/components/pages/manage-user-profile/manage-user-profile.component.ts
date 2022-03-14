import { Component, OnInit, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { UsersModel } from 'src/app/core/models/dto/users.model';
import { UsersService } from 'src/app/core/services/rest/users.service';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-manage-user-profile',
  templateUrl: './manage-user-profile.component.html',
  styleUrls: ['./manage-user-profile.component.scss']
})
export class ManageUserProfileComponent extends FormComponent<
  UsersModel,
  UsersService
> {
  constructor(
    private formBuilder: FormBuilder,
    service: UsersService,
    injector: Injector
  ) {
    super(service, injector);
  }
  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      name: [{ value: '', disabled: true }],
      userName: [{ value: '', disabled: true }],
      id: [{ value: '', disabled: true }],
      active: [{ value: '', disabled: true }],
      email: [{ value: '', disabled: true }],
      isLockedOut: [{ value: '', disabled: true }],
      lastLoginDate: [{ value: '', disabled: true }],
      administration: [{ value: '', disabled: true }],
      administrationName: [{ value: '', disabled: true }],
      updatedOn: [{ value: '', disabled: true }],
      updatedBy: [{ value: '', disabled: true }],
      createdBy: [{ value: '', disabled: true }]
    });
  }
  ngOnInitImplementation() {}
  createInputObject(object: UsersModel): any {
    return null;
  }
}
