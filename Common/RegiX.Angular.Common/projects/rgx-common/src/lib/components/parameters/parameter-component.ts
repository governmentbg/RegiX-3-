import { Input, OnInit, Injector, OnDestroy } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  ValidatorFn
} from '@angular/forms';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Subscription } from 'rxjs';
import { OperationParameterModel } from '../../models/parameters/operation-parameter.model';
import { IdentifierTypeEnum } from '../../models/parameters/parameter-info.model';

export abstract class ParameterComponent implements OnInit, OnDestroy {
  public isControlReady = false;

  @Input()
  parameter: OperationParameterModel;

  @Input()
  formGroup: FormGroup;

  @Input()
  arrayIndex: number = null;
  
  @Input()
  isDisabled = false;

  parameterName: string = null;
  parameterLabel: string = null;

  protected oidcSecurityService: OidcSecurityService;
  private userDataSubscription: Subscription;

  constructor(protected injector: Injector) {
    this.oidcSecurityService = this.injector.get<OidcSecurityService>(OidcSecurityService);
  }

  ngOnInit() {
    this.buildControl();
    this.fillPublicControl();
    this.ngOnInitImplementation();
  }

  ngOnDestroy() {
    if (this.userDataSubscription) {
      this.userDataSubscription.unsubscribe();
    }
  }

  protected fillPublicControl() {
    // Check http://tfstl:8080/tfs/DefaultCollection/eGov/_versionControl?path=%24%2FeGov%2FRegiX%2FRegiX.Services.Web%2FRegiX.Services.Web%2FControllers%2FBaseAPISController.cs
    // for proper implementation
    if (this.parameter.parameterInfo.identifierType) {
      this.userDataSubscription = this.oidcSecurityService.userData$.subscribe( ud => {
        if (ud.role === 'PUBLIC') {
          const identifier = ud.Identifier;
          const identifierType = ud.IdentifierType;
          this.formGroup.controls[this.parameterName].disable();
          switch (this.parameter.parameterInfo.identifierType) {
            case IdentifierTypeEnum.EGN: {
              if (identifierType === 'EGN') {
                const patchValue = {};
                patchValue[this.parameterName] = identifier;
                this.formGroup.patchValue(patchValue);
                this.formGroup.markAsDirty();
              }
              break;
            }
            case IdentifierTypeEnum.LNCH: {
              if (identifierType === 'LNCH') {
                const patchValue = {};
                patchValue[this.parameterName] = identifier;
                this.formGroup.patchValue(patchValue);
                this.formGroup.markAsDirty();
              }
              break;
            }
            case IdentifierTypeEnum.EGN_LNCH: {
              const patchValue = {};
              patchValue[this.parameterName] = identifier;
              this.formGroup.patchValue(patchValue);
              this.formGroup.markAsDirty();
              break;
            }
            case IdentifierTypeEnum.EGN_EIK: {
              if (identifierType === 'EGN') {
                const patchValue = {};
                patchValue[this.parameterName] = identifier;
                this.formGroup.patchValue(patchValue);
                this.formGroup.markAsDirty();
              }
              break;
            }
            case IdentifierTypeEnum.ALL: {
              const idType =
                identifierType === 'EGN' ? IdentifierTypeEnum.EGN : identifierType === 'LNCH' ? IdentifierTypeEnum.LNCH : undefined;
              const enumValues =
                this.parameter.parameterInfo.parameterType.enumValues
                .filter( ev => +ev.identifierType === idType );
              if (enumValues.length === 1) {
                // Parameter is identifier type
                const patchValue = {};
                patchValue[this.parameterName] = enumValues[0].value;
                this.formGroup.patchValue(patchValue);
                this.formGroup.markAsDirty();
              }
              if (this.parameter.parameterInfo.parameterType.type === 'string') {
                // Parameter is identifier
                const patchValue = {};
                patchValue[this.parameterName] = identifier;
                this.formGroup.patchValue(patchValue);
                this.formGroup.markAsDirty();
              }
              break;
            }
          }
        }
      });
    }
  }

  protected buildControl() {
    const parameterNameSuffix = (this.arrayIndex != null) ? '_' + this.arrayIndex : '';
    this.parameterName = this.parameter.parameterInfo.parameterName + parameterNameSuffix;
    this.parameterLabel = this.parameter.parameterInfo.parameterLabel;
    if (!this.parameterLabel) {
      this.parameterLabel = this.parameterName;
    }

    const formControl = new FormControl();
    const validators: ValidatorFn[] = [];
    if (this.parameter.parameterInfo.isRequired === true) {
      validators.push(Validators.required);
    }
    if (this.parameter.parameterInfo.regexExpression) {
      validators.push(
        Validators.pattern(this.parameter.parameterInfo.regexExpression)
      );
    }
    this.addValidators(validators);
    formControl.setValidators(validators);

    this.formGroup.setControl(this.parameterName, formControl);
    this.isControlReady = true;
  }

  protected addValidators(validators: ValidatorFn[]) {}

  protected abstract ngOnInitImplementation();
}
