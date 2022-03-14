import { Component, OnInit, Input } from '@angular/core';
import { ParameterComponent } from '../../../base/parameter-component';
import { ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'app-int-field',
  templateUrl: './int-field.component.html',
  styleUrls: ['./int-field.component.scss']
})
export class IntFieldComponent extends ParameterComponent {
  constructor() {
    super();
  }

  protected addValidators(validators: ValidatorFn[]) {
    validators.push(
      Validators.pattern(`[0-9]+`)
    );
  }

  @Input()
  isDisabled: boolean = false;

  ngOnInitImplementation() {}
}
