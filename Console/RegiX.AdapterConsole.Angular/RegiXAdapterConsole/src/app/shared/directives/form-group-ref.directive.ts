import { Directive, Self, Input } from '@angular/core';
import { NgControl } from '@angular/forms';

@Directive({
  selector: '[appFormGroupRef]'
})
export class FormGroupRefDirective {
  // @Input('appFormGroupRef')
  private formControl;

  constructor(aFormControl: NgControl) {
    this.formControl = aFormControl;
  }

  get hasError() {
    return this.formControl.dirty && this.formControl.invalid;
  }

  get errors() {
    if (this.hasError && this.formControl.errors) {
      return this.formControl.errors;
    }
    return '';
  }
}
