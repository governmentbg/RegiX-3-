import { Component, OnInit, Input } from '@angular/core';
import { ParameterComponent } from '../../../base/parameter-component';
import { ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'app-decimal-field',
  templateUrl: './decimal-field.component.html',
  styleUrls: ['./decimal-field.component.scss']
})
export class DecimalFieldComponent extends ParameterComponent {
  constructor() {
    super();
  }

  @Input()
  isDisabled: boolean = false;

  protected addValidators(validators: ValidatorFn[]) {
    validators.push(Validators.pattern(`[0-9]+([]*|(.[0-9]+))`));
  }

  ngOnInitImplementation() {}
}
