import { OperationParameterModel } from 'src/app/core/models/operations/operation-parameter.model';
import { Input, OnInit, Directive } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  ValidatorFn
} from '@angular/forms';

@Directive()
export abstract class ParameterComponent implements OnInit {
  public isControlReady = false;

  @Input()
  parameter: OperationParameterModel;

  @Input()
  formGroup: FormGroup;

  parameterName: string = null;
  parameterLabel: string = null;

  constructor() {}

  ngOnInit() {
    this.buildControl();
    this.ngOnInitImplementation();
  }

  private buildControl() {
    this.parameterName = this.parameter.parameterInfo.parameterName;
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
