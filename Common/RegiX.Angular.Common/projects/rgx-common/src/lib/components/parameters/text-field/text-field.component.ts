import { Component, Injector } from '@angular/core';
import { ParameterComponent } from '../parameter-component';

@Component({
  selector: 'rgx-text-field',
  templateUrl: './text-field.component.html',
  styleUrls: ['./text-field.component.scss']
})
export class TextFieldComponent extends ParameterComponent {
  constructor(injector: Injector) {
    super(injector);
  }

  ngOnInitImplementation() {
  }
}
