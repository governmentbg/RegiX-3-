import { Component, OnInit, Input } from '@angular/core';
import { ParameterComponent } from '../../../base/parameter-component';

@Component({
  selector: 'app-boolean-field',
  templateUrl: './boolean-field.component.html',
  styleUrls: ['./boolean-field.component.scss']
})
export class BooleanFieldComponent extends ParameterComponent {
  constructor() {
    super();
  }

  @Input()
  isDisabled: boolean = false;
  
  ngOnInitImplementation() {}
}
