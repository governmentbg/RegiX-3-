import { IdentifierValidator } from './../../helpers/identifier-validator';
import { Component, OnInit, Injector } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConsumerUserService } from '../services/consumer-user.service';
import { ConsumerUserModel } from '../models/consumer-user.model';
import { FormComponent, MustMatch } from '@tl/tl-common';
import { ConsumerPorofileRegistrationModel } from '../models/consumer-profile-registration.model';
import { ConsumerPorofileRegistrationService } from '../services/consumer-profile-registration.service';
import { PasswordValidator } from '../../helpers/password-validator';

@Component({
  selector: 'app-consumer-user-registration',
  templateUrl: './consumer-user-registration.component.html',
  styleUrls: ['./consumer-user-registration.component.scss'],
})
export class ConsumerUserRegistrationComponent extends FormComponent<
  ConsumerUserModel,
  ConsumerUserService
> {
  identifierTypes: { value: number; name: string }[] = [];
  identifierTypesConsumer: { value: number; name: string }[] = [];

  constructor(
    private formBuilder: FormBuilder,
    service: ConsumerUserService,
    injector: Injector,
    private consumerPorofileRegistrationService: ConsumerPorofileRegistrationService
  ) {
    super(service, injector);
    this.identifierTypes.push(
      { name: 'ЕГН', value: 1 },
      { name: 'ЛНЧ', value: 2 }
    );
    this.identifierTypesConsumer.push(
      {name: 'ЕИК', value: 1},
      {name: 'ЕГН', value: 2},
      {name: 'БУЛСТАТ', value: 3},
      {name: 'ЛНЧ', value: 4}
    );
  }

  ngOnInitImplementation() {}

  buildFormImpl(): FormGroup {
    this.isDataLoaded = true;
    this.isDataLoading = false;

    return this.formBuilder.group(
      {
        name: [{ value: '' }, [Validators.required]],
        position: [{ value: '' }, [Validators.required]],
        identifierType: [{ value: '' }, [Validators.required]],
        identifier: [{ value: '' }, [Validators.required,IdentifierValidator.validateIdentifier]],
        identifierTypesConsumer: [{ value: '' }, [Validators.required]],
        identifierConsumer: [{ value: '' }, [Validators.required,,IdentifierValidator.validateIdentifier]],
        phoneNumber: [{ value: '' }, [Validators.required]],
        email: [{ value: '' }, [Validators.required,Validators.email]],
        password: [{ value: '' }, [Validators.required,Validators.minLength(6), PasswordValidator.strongPass]],
        passwordConfirm: [{ value: '' }, [Validators.required, Validators.minLength(6), PasswordValidator.strongPass]],
      },
      {
        validator: MustMatch('password', 'passwordConfirm')
      });
  }

  createInputObject(object: any) {
    return new ConsumerPorofileRegistrationModel({
      name: object.name,
      email: object.email,
      password: object.password,
      userName: object.email,
      additionalAttributes: {
        profileIdentifier: object.identifierConsumer + '',
        profileIdentifierType: object.identifierTypesConsumer + '',
        userPosition: object.position + '',
        consumerUserIdentifierType: object.identifierType + '',
        consumerUserIdentifier: object.identifier + '',
        consumerUserPhoneNumber: object.phoneNumber + '',
      },
      // additionalAttributes: [
      //   {key: 'profileName', value: object.name},
      //   {key: 'profileAddress', value: object.address},
      //   {key: 'profileIdentifier', value: object.identifier},
      //   {key: 'profileIdentifierType', value: object.identifierType},
      //   {key: 'profileAcceptedEULA', value: object.acceptedEULA},
      //   {key: 'userPosition', value: object.position},
      //   {key: 'consumerUserIdentifierType', value: object.consumerUserIdentifierType},
      //   {key: 'consumerUserIdentifier', value: object.consumerUserIdentifier},
      //   {key: 'consumerUserPhoneNumber', value: object.phoneNumber}
      // ]
    });
  }

  createObject() {
    this.validateForm();
    if (this.formGroup.valid && this.formGroup.dirty) {
      this.isPending = true;
      const formData = this.formGroup.getRawValue();
      const inputObject = this.createInputObject(formData);
      this.consumerPorofileRegistrationService.save(inputObject).subscribe(
        (data) => {
          // this.createRowInUI(data);
          this.logger.debug('object inserted, refresh form or redirect', data);
          this.formGroup.markAsPristine();
          this.formGroup.markAsUntouched();
          this.errorMessage = null;
          this.toastService.showMessage('Обектът е създаден успешно!');
          this.locationService.back();
          this.isPending = false;
        },
        (error) => {
          this.errorMessage = 'Грешка при създаване на обект: ' + error.error;
          this.isPending = false;
        }
      );
    }
  }
}
