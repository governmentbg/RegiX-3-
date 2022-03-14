import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import { FormComponent, EActions } from '@tl/tl-common';
import { ConsumerProfileUsersModel } from 'src/app/core/models/dto/consumer-profile-users.model';
import { ConsumerProfileUsersService } from 'src/app/core/services/rest/consumer-profile-users.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DisplayValue } from 'src/app/core/models/display-value.model';

@Component({
  selector: 'app-consumer-profile-users-form',
  templateUrl: './consumer-profile-users-form.component.html',
  styleUrls: ['./consumer-profile-users-form.component.scss'],
})
export class ConsumerProfileUsersFormComponent extends FormComponent<
  ConsumerProfileUsersModel,
  ConsumerProfileUsersService
> {

  public identifierTypeEnum: DisplayValue[]  = [ {id: 1, displayName: 'ЕГН'}, {id: 2, displayName: 'ЛНЧ'} ];
  public currentIdentifierType: number;

  constructor(
    service: ConsumerProfileUsersService,
    injector: Injector,
    private formBuilder: FormBuilder
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      name: [{ value: '', disabled: true }],
      position: [{ value: '', disabled: true }],
      email: [{ value: '', disabled: true }],
      isActive: [{ value: '', disabled: this.isShowForm() }],
      identifier: [{ value: '', disabled: true }],
      identifierType: [{ value: '', disabled: true }],
      lockoutEnabled: [{ value: '', disabled: true }],
      accessFailedCount: [{ value: '', disabled: true }],
      emailConfirmed: [{ value: '', disabled: true }],
      phoneNumber: [{ value: '', disabled: this.isShowForm() }],
      phoneNumberConfirmed: [{ value: '', disabled: true }],
      twoFactorEnabled: [{ value: '', disabled: true }],
      consumerProfile: this.formBuilder.group({
        displayName: [{ value: '', disabled: true }],
        id: [{ value: '', disabled: true }],
      }),
    });
  }

  protected buildForm() {
    this.formGroup = this.buildFormImpl();
    this.currentIdentifierType = this.formObject.identifierType;
  }

  createInputObject(object: ConsumerProfileUsersModel): any {
    return object;
  }

  ngOnInitImplementation() {}
}
