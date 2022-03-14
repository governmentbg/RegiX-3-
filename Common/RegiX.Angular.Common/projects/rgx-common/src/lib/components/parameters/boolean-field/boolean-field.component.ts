import { Component, Injector } from '@angular/core';
import { ParameterComponent } from '../parameter-component';

@Component({
  selector: 'rgx-boolean-field',
  templateUrl: './boolean-field.component.html',
  styleUrls: ['./boolean-field.component.scss']
})
export class BooleanFieldComponent extends ParameterComponent {
  constructor(injector: Injector) {
    super(injector);
  }

  ngOnInitImplementation() {}
}
