import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { MustMatch } from '../../helpers/must-match.validator';
import { SignupService } from '../../services/sign-up.service';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { IgxDialogComponent } from 'igniteui-angular';
import { ConsumerProfileRegistrationModel } from '../../models/consumer-profile-registration.model';
import { AdministrationsFilterComponent } from 'src/app/shared/components/administrations-filter/administrations-filter.component';
import { PasswordValidator } from '../../helpers/password-validator';
import { ConfigurationService } from '@tl/tl-common';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  signupForm: FormGroup;

  @ViewChild('administraionsFilterDialog')
  administraionsFilterDialog: IgxDialogComponent;
  @ViewChild('administrationsFilter')
  administrationsFilter: AdministrationsFilterComponent;

  @ViewChild('dialog', { read: IgxDialogComponent, static: true })
  public dialog: IgxDialogComponent;

  errorMessage: string = null;
  isDataLoading = false;
  isDataLoaded = false;
  administrationId: number;

  applicationName: string;


  constructor(
    private formBuilder: FormBuilder,
    private locationService: Location,
    private signupService: SignupService,
    private router: Router,
    configurationService: ConfigurationService
  ) {
    this.applicationName = configurationService.getApplicationName();

  }

  ngOnInit() {
    this.signupForm = this.formBuilder.group(
      {
        name: [
          '',
          [
            Validators.required,
            Validators.minLength(2),
            Validators.maxLength(50)
          ]
        ],
        email: ['', [Validators.required, Validators.email]],
        confirmPassword: ['', Validators.required, PasswordValidator.strongPass],
        password: [
          '',
          [
            Validators.required,
            Validators.minLength(6),
            Validators.maxLength(25),
            PasswordValidator.strongPass,
            // ,Validators.pattern(
            //   '^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@!#$%^&+=]).*$'
            // )
          ]
        ],
        identifierType: [''],
        identifier: [''],
        administration: this.formBuilder.group({
          displayName: [{ value: '', disabled: true}, Validators.required],
          id: [{ value: '', disabled: true }],
        })
      },
      {
        validator: MustMatch('password', 'confirmPassword')
      }
    );
  }

  onSubmit() {
    this.isDataLoading = true;
    const rawValue = this.signupForm.getRawValue();
    rawValue.administrationId = rawValue.administration.id;
    let profile = new ConsumerProfileRegistrationModel({
      name: rawValue.name,
      userName: rawValue.email,//We dont need it, but the interface in the API requires it as param
      email: rawValue.email,
      password: rawValue.password,
      additionalAttributes: {
        'administrationID': rawValue.administrationId + '',
        'administrationName': rawValue.administration.displayName + '',
        'identifierType': rawValue.identifierType,
        'identifier': rawValue.identifier
      }
    });
    delete rawValue.administration;
    this.signupService.register(profile).subscribe(
      () => {
        this.signupForm.markAsPristine();
        this.signupForm.markAsUntouched();
        this.isDataLoading = false;
        this.dialog.open();
      },
      error => {
        this.isDataLoading = false;
        this.errorMessage = 'Грешка при създаване на обект: ' + error.error[0].description; // Takes error description
      }
    );
  }

  public onCancel() {
    this.locationService.back();
  }

  public isFormValid() {
    return this.signupForm.touched && this.signupForm.valid;
  }

  public onSuccessConfirm() {
    this.router.navigate(['/main']);
  }

  showAdministraions() {
    this.administraionsFilterDialog.open();
    this.administrationsFilter.loadFirstSection();
  }

  administraionSelected(
    selectedItems: { id: number; name: string; data: any; key: string }[]
  ) {
    this.administrationId = selectedItems[0].id;

    this.administraionsFilterDialog.close();
    const admDisplayValue = new DisplayValue({
      id: selectedItems[0].id,
      displayName: selectedItems[0].name,
    });
    this.signupForm.patchValue({
      administration: admDisplayValue,
    });
    this.signupForm.markAsDirty();
  }
}
