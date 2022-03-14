import { Component, Injector } from '@angular/core';
import { FormControl, ValidatorFn, Validators } from '@angular/forms';
import { ParameterComponent } from '../parameter-component';

function _arrayBufferToBase64( buffer ) {
  var binary = '';
  var bytes = new Uint8Array( buffer );
  var len = bytes.byteLength;
  for (var i = 0; i < len; i++) {
      binary += String.fromCharCode( bytes[ i ] );
  }
  return window.btoa( binary );
}
@Component({
  selector: 'rgx-file',
  templateUrl: './file.component.html',
  styleUrls: ['./file.component.scss']
})
export class FileComponent extends ParameterComponent {
  constructor(injector: Injector) {
    super(injector);
  }

  ngOnInitImplementation() {
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


    const formControlDismiss = new FormControl();
    const validatorsDismiss: ValidatorFn[] = [];
    if (this.parameter.parameterInfo.isRequired === true) {
      validatorsDismiss.push(Validators.required);
    }
    if (this.parameter.parameterInfo.regexExpression) {
      validatorsDismiss.push(
        Validators.pattern(this.parameter.parameterInfo.regexExpression)
      );
    }
    this.addValidators(validatorsDismiss);
    formControlDismiss.setValidators(validators);

    this.formGroup.setControl(this.parameterName + '_dismiss', formControlDismiss);


    this.isControlReady = true;
  }

  openFile(event) {
    const input = event.target;
    for (var index = 0; index < input.files.length; index++) {
        const reader = new FileReader();
        const fileName = input.files[index].name;
        reader.onload = () => {
            var base64 = reader.result.toString().split("base64,")[1];
            const patchValue = {};
            patchValue[this.parameterName] = base64;
            patchValue[this.parameterName + '_dismiss'] = fileName;
            this.formGroup.patchValue(patchValue);
        };
        reader.readAsDataURL(input.files[index]);
    }
    this.formGroup.markAsTouched();
    this.formGroup.markAsDirty();
}

}
