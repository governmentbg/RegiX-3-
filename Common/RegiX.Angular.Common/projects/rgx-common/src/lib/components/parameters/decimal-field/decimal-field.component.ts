import { Component, Injector } from '@angular/core';
import { ParameterComponent } from '../parameter-component';
import { ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'rgx-decimal-field',
  templateUrl: './decimal-field.component.html',
  styleUrls: ['./decimal-field.component.scss']
})
export class DecimalFieldComponent extends ParameterComponent {
  constructor(injector: Injector) {
    super(injector);
  }

  protected addValidators(validators: ValidatorFn[]) {
    validators.push(Validators.pattern(`[0-9]+([]*|(.[0-9]+))`));
  }

  ngOnInitImplementation() {}
}
