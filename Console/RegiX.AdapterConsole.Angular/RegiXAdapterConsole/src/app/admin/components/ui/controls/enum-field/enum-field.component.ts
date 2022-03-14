import { Component, OnInit, Input } from '@angular/core';
import { ParameterComponent } from '../../../base/parameter-component';

@Component({
  selector: 'app-enum-field',
  templateUrl: './enum-field.component.html',
  styleUrls: ['./enum-field.component.scss']
})
export class EnumFieldComponent extends ParameterComponent {
  constructor() {
    super();
  }

  @Input()
  isDisabled: boolean;
  
  ngOnInitImplementation() {}
}
