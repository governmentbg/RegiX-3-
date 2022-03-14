import { IdentifierValidator } from './../../helpers/identifier-validator';
import { Component, OnInit, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConsumerModel } from '../models/consumer.model';
import { ConsumerService } from '../services/consumer.service';
import { ConsumerPorofileRegistrationModel } from '../models/consumer-profile-registration.model';
import { ConsumerPorofileRegistrationService } from '../services/consumer-profile-registration.service';
import { MustMatch } from '../../helpers/must-match-validator';
import { PasswordValidator } from '../../helpers/password-validator';

@Component({
  selector: 'app-consumer-registration',
  templateUrl: './consumer-registration.component.html',
  styleUrls: ['./consumer-registration.component.scss'],
})
export class ConsumerRegistrationComponent extends FormComponent<
  ConsumerModel,
  ConsumerService
> {
  identifierTypes: { value: number; name: string }[] = [];

  consumerUserIdentifierType: { value: number; name: string }[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private consumerPorofileRegistrationService: ConsumerPorofileRegistrationService,
    service: ConsumerService,
    injector: Injector
  ) {
    super(service, injector);
    this.identifierTypes.push(
      { name: 'ЕИК', value: 1 },
      { name: 'ЕГН', value: 2 },
      { name: 'БУЛСТАТ', value: 3 },
      { name: 'ЛНЧ', value: 4 }
    );
    this.consumerUserIdentifierType.push(
      { name: 'ЕГН', value: 1 },
      { name: 'ЛНЧ', value: 2 }
    );
  }

  ngOnInitImplementation() {}

  buildFormImpl(): FormGroup {
    this.isDataLoaded = true;
    this.isDataLoading = false;

    return this.formBuilder.group(
      {
        name: [{ value: '' }, [Validators.required]],
        address: [{ value: '' }, [Validators.required]],
        identifier: [
          { value: '' },
          [Validators.required, IdentifierValidator.validateIdentifier],
        ],
        identifierType: [{ value: '' }, [Validators.required]],
        acceptedEULA: [{ value: '' }, [Validators.required]],
        consumerUserName: [{ value: '' }, [Validators.required]],
        position: [{ value: '' }, [Validators.required]],
        consumerUserIdentifierType: [{ value: '' }, [Validators.required]],
        consumerUserIdentifier: [{ value: '' }, [Validators.required, IdentifierValidator.validateIdentifier ]],
        phoneNumber: [{ value: '' }, [Validators.required]],
        email: [{ value: '' }, [Validators.required, Validators.email]],
        password: [
          { value: '' },
          [
            Validators.required,
            Validators.minLength(6),
            PasswordValidator.strongPass,
          ],
        ],
        passwordConfirm: [
          { value: '' },
          [
            Validators.required,
            Validators.minLength(6),
            PasswordValidator.strongPass,
          ],
        ],
      },
      {
        validator: MustMatch('password', 'passwordConfirm'),
      }
    );
  }

  createInputObject(object: any) {
    return new ConsumerPorofileRegistrationModel({
      name: object.consumerUserName,
      email: object.email,
      password: object.password,
      userName: object.email,
      additionalAttributes: {
        profileName: object.name + '',
        profileAddress: object.address + '',
        profileIdentifier: object.identifier + '',
        profileIdentifierType: object.identifierType + '',
        profileAcceptedEULA: object.acceptedEULA + '',
        userPosition: object.position + '',
        consumerUserIdentifierType: object.consumerUserIdentifierType + '',
        consumerUserIdentifier: object.consumerUserIdentifier + '',
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
