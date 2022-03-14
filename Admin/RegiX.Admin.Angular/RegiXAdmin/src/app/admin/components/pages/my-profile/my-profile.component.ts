import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EActions, FormComponent } from '@tl/tl-common';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { IgxSelectComponent } from 'igniteui-angular';
import { MyProfileModel } from 'src/app/core/models/dto/in/my-profile.model';
import { UsersEauthModel } from 'src/app/core/models/dto/in/users-eauth.model';
import { IdentificatorType } from 'src/app/core/models/identitfiactor-type.model';
import { MyProfileService } from 'src/app/core/services/rest/my-profile.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.scss']
})
export class MyProfileComponent extends FormComponent<
MyProfileModel,
MyProfileService
> implements OnInit {
public identifierTypeEnum: IdentificatorType[] = [
  { name: 'PNOBG', displayName: 'ЕГН' },
  { name: 'PI:BG', displayName: 'ЛНЧ' },
];

constructor(
  private formBuilder: FormBuilder,
  service: MyProfileService,
  injector: Injector,
  private oidcSecurityService: OidcSecurityService
) {
  super(service, injector);
}

buildFormImpl(): FormGroup {
  return this.formBuilder.group({
    name: [
      { value: '', disabled: this.isShowForm() },
      [Validators.required, Validators.minLength(5)],
    ],
    id: [{ value: '', disabled: true }],
    userName: [{ value: '', disabled: true }, [Validators.required]],
    email: [{ value: '', disabled: this.isShowForm() }],
    updatedOn: [{ value: '', disabled: true }],
    updatedBy: [{ value: '', disabled: true }],
    createdBy: [{ value: '', disabled: true }],
    usersEauth: this.formBuilder.group({
      identifierType: [{ value: '', disabled: this.isShowForm() }],
      identifier: [
        { value: '', disabled: this.isShowForm() },
        [Validators.minLength(5)],
      ],
      id: [{ value: '', disabled: this.isShowForm() }],
    }),
  });
}

createInputObject(object: MyProfileModel) {
  return object;
}

protected buildForm() {
  this.formGroup = this.buildFormImpl();
  if (this.formObject.usersEauth === undefined) {
    this.formObject.usersEauth = new UsersEauthModel();
    this.formObject.usersEauth.identifier = '';
    this.formObject.usersEauth.identifierType = '';
  }
}

ngOnInit() {
  this.objectName = 'Моят профил';
  this.name = 'Моят профил';
  this.icon = 'person';

  this.oidcSecurityService.userData$.subscribe((userData) => {
    this.objectId = userData.sub;
    this.currentAction = EActions.EDIT;
    this.readObjectDetails();
  });

  this.ngOnInitImplementation();
}

public setToNull(igxSelect: IgxSelectComponent, formControlName: string) {
  this.formGroup.get('usersEauth').get('identifierType').markAsDirty();
  this.formObject.usersEauth.identifierType = null;
  super.setToNull(igxSelect, formControlName);
}

ngOnInitImplementation() {}

protected updateObject() {
  if (this.validateForm()) {
    if (this.formGroup.valid && this.formGroup.dirty) {
      this.isPending = true;
      const formData = this.formGroup.getRawValue();
      this.logger.debug('formData', formData, this.formGroup.value);
      const inputObject = this.createInputObject(formData);
      this.logger.debug('inputObject', inputObject);

      this.service.update(formData.id, inputObject).subscribe(
        (data) => {
          // this.updateRowInUI(data);
          this.logger.debug('object updated, refresh form or redirect', data);
          this.formGroup.markAsPristine();
          this.formGroup.markAsUntouched();
          this.errorMessage = null;
          this.toastService.showMessage('Обектът е обновен успешно!');
          this.locationService.back();
          this.isPending = false;
        },
        (error) => {
          this.logger.error(error);
          this.isPending = false;
          this.errorMessage =
            'Грешка при обновяване на обект: ' + error.error;
        }
      );
    }
  }
}

public validateForm(): boolean {
  if (
    this.formGroup.get('usersEauth').get('identifier').dirty ||
    this.formGroup.get('usersEauth').get('identifierType').dirty
  ) {
    if (
      (this.formGroup.get('usersEauth').get('identifier').value !== '' &&
        (this.formGroup.get('usersEauth').get('identifierType').value ===
          null ||
          this.formGroup.get('usersEauth').get('identifierType').value ===
            '')) ||
      (this.formGroup.get('usersEauth').get('identifier').value === '' &&
        this.formGroup.get('usersEauth').get('identifierType').value !==
          null &&
        this.formGroup.get('usersEauth').get('identifierType').value !== '')
    ) {
      this.toastService.showMessage(
        'Идентификатор и тип идентификатор трябва да са попълнени!'
      );
      return false;
    }
  }
  return true;
}
}
