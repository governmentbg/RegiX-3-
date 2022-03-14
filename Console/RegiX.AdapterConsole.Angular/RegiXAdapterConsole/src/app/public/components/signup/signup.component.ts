import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { MustMatch } from "../../helpers/must-match.validator";
import { Location } from "@angular/common";
import { SignupService } from "../../services/signup.service";
import { ConfigurationService, ToastService } from '@tl/tl-common'
import { Router } from '@angular/router';

@Component({
  selector: "app-signup",
  templateUrl: "./signup.component.html",
  styleUrls: ["./signup.component.scss"]
})
export class SignupComponent implements OnInit {
  public applicationName: string;

  signupForm: FormGroup;

  errorMessage: string = null;
  isDataLoading = false;

  constructor(
    private formBuilder: FormBuilder,
    private locationService: Location,
    private toastService: ToastService,
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
          "",
          [
            Validators.required,
            Validators.minLength(2),
            Validators.maxLength(50)
          ]
        ],
        userName: [
          "",
          [
            Validators.required,
            Validators.minLength(2),
            Validators.maxLength(50)
          ]
        ],
        email: ["", [Validators.required, Validators.email]],
        confirmPassword: ["", Validators.required],
        password: [
          "",
          [
            Validators.required,
            Validators.minLength(6),
            Validators.maxLength(25),
            Validators.pattern(
              "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@!#$%^&+=]).*$"
            )
          ]
        ]
      },
      {
        validator: MustMatch("password", "confirmPassword")
      }
    );
  }

  onSubmit(event: any) {
    this.isDataLoading = true;
    this.signupService.register(this.signupForm.getRawValue()).subscribe(
      data => {
        this.signupForm.markAsPristine();
        this.signupForm.markAsUntouched();
        this.toastService.showMessage("Обектът е създаден успешно!");
        this.isDataLoading = false;
        this.router.navigate(["/loggedout"]);
      },
      error => {
        this.isDataLoading = false;
        this.errorMessage = "Грешка при създаване на обект: " + error.error[0].description;//Takes error description
      }
    );
  }

  public onCancel() {
    this.locationService.back();
  }

  public isFormValid() {
    return this.signupForm.touched && this.signupForm.valid;
  }
}
