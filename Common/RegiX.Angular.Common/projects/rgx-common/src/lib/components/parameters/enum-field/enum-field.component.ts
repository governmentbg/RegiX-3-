import { Component, Injector } from '@angular/core';
import { ParameterComponent } from '../parameter-component';

@Component({
  selector: 'rgx-enum-field',
  templateUrl: './enum-field.component.html',
  styleUrls: ['./enum-field.component.scss']
})
export class EnumFieldComponent extends ParameterComponent {
  constructor(injector: Injector) {
    super(injector);
  }

  ngOnInitImplementation() {}
}
