import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConfigurationService, ToastService } from '@tl/tl-common';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { MustMatch } from '../../helpers/must-match.validator';
import { SignupService } from '../../services/sign-up.service';
import { AdministrationModel } from 'src/app/core/models/dto/administration.model';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { map } from 'rxjs/operators';
import { RegisterObjectModel } from 'src/app/core/models/dto/not-register-adapter-form-models/register-object.model';
import { IgxDialogComponent } from 'igniteui-angular';
import { ConsumerProfileRegistrationModel } from '../../models/consumer-profile-registration.model';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  public applicationName: string;

  @ViewChild('dialog', { read: IgxDialogComponent, static: true })
  public dialog: IgxDialogComponent;

  signupForm: FormGroup;

  errorMessage: string = null;
  isDataLoading = false;
  isDataLoaded = false;
  administrations: DisplayValue[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private locationService: Location,
    private toastService: ToastService,
    private signupService: SignupService,
    private administrationService: AdministrationsService,
    private router: Router,
    configurationService: ConfigurationService
  ) {
    this.applicationName = configurationService.getApplicationName();}

  ngOnInit() {
    this.readAdministrations();
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
        userName: [
          '',
          [
            Validators.required,
            Validators.minLength(2),
            Validators.maxLength(50)
          ]
        ],
        email: ['', [Validators.required, Validators.email]],
        confirmPassword: ['', Validators.required],
        password: [
          '',
          [
            Validators.required,
            Validators.minLength(6),
            Validators.maxLength(25)
            // ,Validators.pattern(
            //   '^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@!#$%^&+=]).*$'
            // )
          ]
        ],
        identifierType: [''],
        identifier: [''],
        administration: ['', [Validators.required]]
      },
      {
        validator: MustMatch('password', 'confirmPassword')
      }
    );
  }

  private readAdministrations() {
    this.isDataLoaded = false;
    this.isDataLoading = true;
    this.administrationService
      .GetAllPrimariesAnonymous()
      .pipe(
        map((items: AdministrationModel[]) => {
          return items.map(item => {
            return new DisplayValue({ id: item.id, displayName: item.name });
          });
        })
      )
      .subscribe(
        data => {
          this.administrations = data;
          this.isDataLoaded = true;
          this.isDataLoading = false;
        },
        error => {
          this.isDataLoaded = true;
          this.isDataLoading = false;
          this.errorMessage = 'Грешка при извличане на данни за администрации.';
        }
      );
  }

  onSubmit(event: any) {
    this.isDataLoading = true;
    const rawValue = this.signupForm.getRawValue();
    rawValue.administrationId = rawValue.administration.id;
    const profile = new ConsumerProfileRegistrationModel({
      name: rawValue.name,
      email: rawValue.email,
      password: rawValue.password,
      userName: rawValue.userName,
      additionalAttributes: {
        administrationID: rawValue.administrationId + '',
        administrationName: rawValue.administration.displayName + '',
        identifierType: rawValue.identifierType,
        identifier: rawValue.identifier
      }
    });
    delete rawValue.administration;
    this.signupService.register(profile).subscribe(
      data => {
        this.signupForm.markAsPristine();
        this.signupForm.markAsUntouched();
        this.toastService.showMessage('Обектът е създаден успешно!');
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
    this.router.navigate(['/loggedout']);
  }

}
