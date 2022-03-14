import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormComponent } from '@tl/tl-common';
import { ConsumerProfileUsersApprovedModel } from 'src/app/consumer/models/consumer-profile-user-approved.model';
import { ConsumerProfileUsersApprovedInModel } from 'src/app/consumer/models/in/consumer-profile-users-approved.in.model';
import { ConsumerProfileUsersApprovedService } from 'src/app/consumer/services/consumer-profile-users-approved.service';

@Component({
  selector: 'app-consumer-profiles-users-approved-form',
  templateUrl: './consumer-profiles-users-approved-form.component.html',
  styleUrls: ['./consumer-profiles-users-approved-form.component.scss'],
})
export class ConsumerProfilesUsersApprovedFormComponent extends FormComponent<
  ConsumerProfileUsersApprovedModel,
  ConsumerProfileUsersApprovedService
> {

  constructor(
    private formBuilder: FormBuilder,
    service: ConsumerProfileUsersApprovedService,
    injector: Injector
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      name: [ { value: '', disabled: true }],
      email: [{ value: '', disabled: true }],
      position: [{ value: '', disabled: true }],
      phoneNumber: [{ value: '', disabled: true }],
      isActive: [{ value: '', disabled: this.isShowForm()}],
    });
  }

  createInputObject(object: ConsumerProfileUsersApprovedModel): any {
     return new ConsumerProfileUsersApprovedInModel(object); 
  }

  ngOnInitImplementation() {}
}
