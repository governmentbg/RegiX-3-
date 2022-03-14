import { Component, Injector } from '@angular/core';
import { ValidatorFn, Validators } from '@angular/forms';
import { ParameterComponent } from '../parameter-component';

@Component({
  selector: 'rgx-int-field',
  templateUrl: './int-field.component.html',
  styleUrls: ['./int-field.component.scss']
})
export class IntFieldComponent extends ParameterComponent {
  constructor(injector: Injector) {
    super(injector);
  }

  protected addValidators(validators: ValidatorFn[]) {
    validators.push(
      Validators.pattern(`[0-9]+`)
    );
  }

  ngOnInitImplementation() {}
}
